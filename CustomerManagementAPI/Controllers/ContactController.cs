using AutoMapper;
using CustomerManagementAPI.Data;
using CustomerManagementAPI.Dto_s;
using CustomerManagementAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContactController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllContacts()
        {
            var contacts = await _context.Contacts
                .Include(c => c.Account)
                .ToListAsync();

            var contactsDto = _mapper.Map<List<ContactDTO>>(contacts);
            return Ok(contactsDto);
        }

        [HttpGet("{email}")]
        public async Task<IActionResult> GetContact(string email)
        {
            var contact = await _context.Contacts
                .Include(c => c.Account)
                .FirstOrDefaultAsync(c => c.Email == email);

            if (contact == null)
            {
                return NotFound("Contact not found.");
            }

            var contactDto = _mapper.Map<ContactDTO>(contact);
            return Ok(contactDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateContact(ContactDTO request)
        {
            var existingContact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.Email == request.Email);

            if (existingContact != null)
            {
                return Conflict("A contact with this email already exists.");
            }

            var newContact = new Contact
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            _context.Contacts.Add(newContact);
            await _context.SaveChangesAsync();

            var createdContactDto = _mapper.Map<ContactDTO>(newContact);
            return CreatedAtAction(nameof(GetContact), new { email = newContact.Email }, createdContactDto);
        }

        [HttpDelete("{email}")]
        public async Task<IActionResult> DeleteContact(string email)
        {
            var contact = await _context.Contacts
                .Include(c => c.Account)
                .FirstOrDefaultAsync(c => c.Email == email);

            if (contact == null)
            {
                return NotFound("Contact not found.");
            }

            var accountId = contact.AccountId;
            var accountName = contact.Account?.Name;

            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();

            var hasContacts = await _context.Contacts.AnyAsync(c => c.AccountId == accountId);

            if (!hasContacts && accountName != null)
            {
                return RedirectToAction(
                    actionName: "DeleteAccount",    
                    controllerName: "Account",      
                    routeValues: new { name = accountName } 
                );
            }

            return NoContent();
        }
    }
}

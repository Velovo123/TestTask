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
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public AccountController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _context.Accounts
                .Include(a => a.Contacts)
                .Include(a => a.Incident)
                .ToListAsync();

            var accountsDto = _mapper.Map<List<AccountDTO>>(accounts);

            return Ok(accountsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAccount(string id)
        {
            var account = await _context.Accounts
                .Include(a => a.Contacts)
                .Include(a => a.Incident)
                .FirstOrDefaultAsync(a => a.Name == id);

            if (account == null)
            {
                return NotFound("Account not found.");
            }

            var accountDto = _mapper.Map<AccountDTO>(account);
            return Ok(accountDto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public async Task<IActionResult> CreateAccount(AccountDTO request)
        {
            if (request.Contacts == null || !request.Contacts.Any())
            {
                return BadRequest("Account must have at least one contact.");
            }

            var existingAccount = await _context.Accounts
                    .FirstOrDefaultAsync(a => a.Name == request.Name);

            if (existingAccount != null)
            {
                return Conflict($"An account with the name '{request.Name}' already exists.");
            }


            var account = new Account { Name = request.Name };
            _context.Accounts.Add(account);

            foreach (var contactDto in request.Contacts)
            {
                var existingContact = await _context.Contacts
                    .FirstOrDefaultAsync(c => c.Email == contactDto.Email);

                if (existingContact != null)
                {
                    var isContactLinked = await _context.Accounts
                        .AnyAsync(a => a.Contacts.Any(c => c.Email == contactDto.Email));

                    if (isContactLinked)
                    {
                        return Conflict($"The contact with email {contactDto.Email} is already linked to another account.");
                    }

                    if (existingContact.FirstName != contactDto.FirstName || existingContact.LastName != contactDto.LastName)
                    {
                        existingContact.FirstName = contactDto.FirstName;
                        existingContact.LastName = contactDto.LastName;
                    }

                    existingContact.Account = account; 
                }
                else
                {
                    var newContact = new Contact
                    {
                        FirstName = contactDto.FirstName,
                        LastName = contactDto.LastName,
                        Email = contactDto.Email,
                        Account = account 
                    };
                    _context.Contacts.Add(newContact);
                }
            }

            await _context.SaveChangesAsync();

            var createdAccountDto = _mapper.Map<AccountDTO>(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, createdAccountDto);
        }


        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{name}")]
        public async Task<IActionResult> DeleteAccount(string name)
        {
            var account = await _context.Accounts
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(a => a.Name == name);

            if (account == null)
            {
                return NotFound("Account not found.");
            }

            var incidentName = account.IncidentName;

            
            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            var remainingAccountsCount = await _context.Accounts
                .CountAsync(a => a.IncidentName == incidentName);

            if (remainingAccountsCount == 0 && incidentName != null)
            {
                return RedirectToAction(
                    actionName: "DeleteIncident",    
                    controllerName: "Incident",      
                    routeValues: new { id = incidentName } 
                );
            }

            return NoContent();
        }


    }
}

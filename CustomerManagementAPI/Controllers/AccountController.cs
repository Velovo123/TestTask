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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> CreateAccount(AccountDTO request)
        {
            if (request.Contacts == null || !request.Contacts.Any())
            {
                return BadRequest("Account must have at least one contact.");
            }

            var account = new Account { Name = request.Name };

            foreach (var contactDto in request.Contacts)
            {
                var existingContact = await _context.Contacts
                    .FirstOrDefaultAsync(c => c.Email == contactDto.Email);

                if (existingContact != null)
                {
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

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            var createdAccountDto = _mapper.Map<AccountDTO>(account);
            return CreatedAtAction(nameof(GetAccount), new { id = account.Id }, createdAccountDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(string id)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Name == id);

            if (account == null)
            {
                return NotFound("Account not found.");
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

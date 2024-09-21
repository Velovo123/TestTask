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
    public class IncidentController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public IncidentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PostIncident(IncidentCreateDTO request)
        {
            // Check if request is valid
            if (string.IsNullOrWhiteSpace(request.IncidentDescription))
            {
                return BadRequest("Incident description is required.");
            }

            var account = await _context.Accounts
                .Include(a => a.Contacts)
                .FirstOrDefaultAsync(a => a.Name == request.AccountName);

            if (account == null)
            {
                return NotFound("Account not found.");
            }

            var contact = await _context.Contacts
                .FirstOrDefaultAsync(c => c.Email == request.ContactEmail);

            if (contact != null)
            {
                contact.FirstName = request.ContactFirstName;
                contact.LastName = request.ContactLastName;

                if (!account.Contacts.Any(c => c.Email == request.ContactEmail))
                {
                    account.Contacts.Add(contact);
                }
            }
            else
            {
                contact = new Contact
                {
                    FirstName = request.ContactFirstName,
                    LastName = request.ContactLastName,
                    Email = request.ContactEmail,
                    Account = account
                };
                _context.Contacts.Add(contact);
            }

            var incident = new Incident
            {
                IncidentName = GenerateIncidentName(),
                Description = request.IncidentDescription,
                Accounts = new List<Account> { account }
            };

            _context.Incidents.Add(incident);

            await _context.SaveChangesAsync();

            var incidentDto = _mapper.Map<IncidentDTO>(incident);
            return CreatedAtAction("GetIncident", new { id = incident.IncidentName }, incidentDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllIncidents()
        {
            var incidents = await _context.Incidents
                .Include(i => i.Accounts)
                    .ThenInclude(a => a.Contacts)
                .ToListAsync();

            var incidentsDto = _mapper.Map<List<IncidentDTO>>(incidents);
            return Ok(incidentsDto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<IncidentDTO>> GetIncident(string id)
        {
            var incident = await _context.Incidents
                .Include(i => i.Accounts)
                    .ThenInclude(a => a.Contacts)
                .FirstOrDefaultAsync(i => i.IncidentName == id);

            if (incident == null)
            {
                return NotFound();
            }

            var incidentDto = _mapper.Map<IncidentDTO>(incident);
            return Ok(incidentDto);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteIncident(string id)
        {
            var incident = await _context.Incidents
                .FirstOrDefaultAsync(i => i.IncidentName == id);

            if (incident == null)
            {
                return NotFound("Incident not found.");
            }

            if (incident.Accounts != null)
            {
                foreach (var account in incident.Accounts)
                {
                    account.IncidentName = null;
                }
            }

            _context.Incidents.Remove(incident);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateIncident(string id, UpdateIncidentDTO request)
        {
            if (string.IsNullOrWhiteSpace(request.Description))
            {
                return BadRequest("Description cannot be empty.");
            }

            var incident = await _context.Incidents
                .FirstOrDefaultAsync(i => i.IncidentName == id);

            if (incident == null)
            {
                return NotFound("Incident not found.");
            }

            incident.Description = request.Description;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private string GenerateIncidentName()
        {
            return $"INC-{DateTime.UtcNow:MM/dd/yyyyHH:mm:ss}";
        }
    }
}

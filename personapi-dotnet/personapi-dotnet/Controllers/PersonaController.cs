using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase

    {
        private IPersonaRepository _personaRepository;

        public PersonaController(IPersonaRepository personaRepository)
        {
            _personaRepository = personaRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetPersonasAsync))]
        public IEnumerable<Persona> GetPersonasAsync()
        {
            return _personaRepository.GetPersonas();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetPersonaById))]
        public ActionResult<Persona> GetPersonaById(int id)
        {
            var PersonaByID = _personaRepository.GetPersonaById(id);
            if (PersonaByID == null)
            {
                return NotFound();
            }
            return PersonaByID;
        }

        [HttpPost]
        [ActionName(nameof(CreatePersonaAsync))]
        public async Task<ActionResult<Persona>> CreatePersonaAsync(Persona Persona)
        {
            await _personaRepository.CreatePersonaAsync(Persona);
            return CreatedAtAction(nameof(GetPersonaById), new { id = Persona.Cc }, Persona);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdatePersona))]
        public async Task<ActionResult> UpdatePersona(int id, Persona Persona)
        {
            if (id != Persona.Cc)
            {
                return BadRequest();
            }

            await _personaRepository.UpdatePersonaAsync(Persona);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeletePersona))]
        public async Task<IActionResult> DeletePersona(int id)
        {
            var Persona = _personaRepository.GetPersonaById(id);
            if (Persona == null)
            {
                return NotFound();
            }

            await _personaRepository.DeletePersonaAsync(Persona);

            return NoContent();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using Profesionpi_dotnet.Models.Repository;

namespace Profesionpi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfesionController : ControllerBase
    {
        private IProfesionRepository _profesionRepository;

        public ProfesionController(IProfesionRepository profesionRepository)
        {
            _profesionRepository = profesionRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetProfesionsAsync))]
        public IEnumerable<Profesion> GetProfesionsAsync()
        {
            return _profesionRepository.GetProfesions();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetProfesionById))]
        public ActionResult<Profesion> GetProfesionById(int id)
        {
            var profesionByID = _profesionRepository.GetProfesionById(id);
            if (profesionByID == null)
            {
                return NotFound();
            }
            return profesionByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateProfesionAsync))]
        public async Task<ActionResult<Profesion>> CreateProfesionAsync(Profesion profesion)
        {
            await _profesionRepository.CreateProfesionAsync(profesion);
            return CreatedAtAction(nameof(GetProfesionById), new { id = profesion.Id }, profesion);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateProfesion))]
        public async Task<ActionResult> UpdateProfesion(int id, Profesion profesion)
        {
            if (id != profesion.Id)
            {
                return BadRequest();
            }

            await _profesionRepository.UpdateProfesionAsync(profesion);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteProfesion))]
        public async Task<IActionResult> DeleteProfesion(int id)
        {
            var profesion = _profesionRepository.GetProfesionById(id);
            if (profesion == null)
            {
                return NotFound();
            }

            await _profesionRepository.DeleteProfesionAsync(profesion);

            return NoContent();
        }

    }
}

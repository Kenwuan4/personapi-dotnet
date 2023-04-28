using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using Estudiopi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private EstudioRepository _EstudioRepository;

        public EstudioController(IEstudioRepository EstudioRepository)
        {
            _EstudioRepository = EstudioRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEstudiosAsync))]
        public IEnumerable<Estudio> GetEstudiosAsync()
        {
            return _EstudioRepository.GetEstudios();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetEstudioByNum))]
        public ActionResult<Estudio> GetEstudioByProfIdAndCc(int idProf, int cc)
        {
            var EstudioByID = _EstudioRepository.GetEstudioByProfIdAndCc(idProf, cc);

            if (EstudioByID == null)
            {
                return NotFound();
            }

            return EstudioByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateEstudioAsync))]
        public async Task<ActionResult<Estudio>> CreateEstudioAsync(Estudio Estudio)
        {
            await _EstudioRepository.CreateEstudioAsync(Estudio);
            return CreatedAtAction(nameof(GetEstudioByNum), new { id = Estudio.IdProf }, Estudio);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateEstudio))]
        public async Task<ActionResult> UpdateEstudio(int idProf, int cc, Estudio estudio)
        {
            if (idProf != estudio.IdProf && cc != estudio.CcPer)
            {
                return BadRequest();
            }

            await _EstudioRepository.UpdateEstudioAsync(Estudio);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteEstudio))]
        public async Task<IActionResult> DeleteEstudio(int idProf, int cc)
        {
            var Estudio = _EstudioRepository.GetEstudioByProfIdAndCc(idProf, cc);
            if (Estudio == null)
            {
                return NotFound();
            }

            await _EstudioRepository.DeleteEstudioAsync(Estudio);
            return NoContent();
        }
    }
}

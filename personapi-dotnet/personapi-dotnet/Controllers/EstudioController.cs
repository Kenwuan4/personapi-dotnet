using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using Estudiopi_dotnet.Models.Repository;
using personapi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository;

        public EstudioController(IEstudioRepository estudioRepository)
        {
            _estudioRepository = estudioRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetEstudiosAsync))]
        public IEnumerable<Estudio> GetEstudiosAsync()
        {
            return _estudioRepository.GetEstudios();
        }

        [HttpGet("{idprof},{cc}")]
        [ActionName(nameof(GetEstudioByProfIdAndCc))]
        public ActionResult<Estudio> GetEstudioByProfIdAndCc(int idProf, int cc)
        {
            var EstudioByID = _estudioRepository.GetEstudioByProfIdAndCc(idProf, cc);

            if (EstudioByID == null)
            {
                return NotFound();
            }

            return EstudioByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateEstudioAsync))]
        public async Task<ActionResult<Estudio>> CreateEstudioAsync(Estudio estudio)
        {
            await _estudioRepository.CreateEstudioAsync(estudio);
            return CreatedAtAction(nameof(GetEstudioByProfIdAndCc), new { id = estudio.IdProf }, estudio);
        }

        [HttpPut("{idprof},{cc}")]
        [ActionName(nameof(UpdateEstudio))]
        public async Task<ActionResult> UpdateEstudio(int idProf, int cc, Estudio estudio)
        {
            if (idProf != estudio.IdProf && cc != estudio.CcPer)
            {
                return BadRequest();
            }

            await _estudioRepository.UpdateEstudioAsync(estudio);

            return NoContent();
        }

        [HttpDelete("{idprof},{cc}")]
        [ActionName(nameof(DeleteEstudio))]
        public async Task<IActionResult> DeleteEstudio(int idProf, int cc)
        {
            var estudio = _estudioRepository.GetEstudioByProfIdAndCc(idProf, cc);
            if (estudio == null)
            {
                return NotFound();
            }

            await _estudioRepository.DeleteEstudioAsync(estudio);
            return NoContent();
        }
    }
}

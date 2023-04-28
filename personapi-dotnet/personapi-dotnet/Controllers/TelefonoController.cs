using Microsoft.AspNetCore.Mvc;
using personapi_dotnet.Models.Entities;
using Telefonopi_dotnet.Models.Repository;

namespace personapi_dotnet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelefonoController : ControllerBase
    {
        private ITelefonoRepository _telefonoRepository;

        public TelefonoController(ITelefonoRepository telefonoRepository)
        {
            _telefonoRepository = telefonoRepository;
        }

        [HttpGet]
        [ActionName(nameof(GetTelefonosAsync))]
        public IEnumerable<Telefono> GetTelefonosAsync()
        {
            return _telefonoRepository.GetTelefonos();
        }

        [HttpGet("{id}")]
        [ActionName(nameof(GetTelefonoByNum))]
        public ActionResult<Telefono> GetTelefonoByNum(string num)
        {
            var TelefonoByID = _telefonoRepository.GetTelefonoByNum(num);
            if (TelefonoByID == null)
            {
                return NotFound();
            }
            return TelefonoByID;
        }

        [HttpPost]
        [ActionName(nameof(CreateTelefonoAsync))]
        public async Task<ActionResult<Telefono>> CreateTelefonoAsync(Telefono telefono)
        {
            await _telefonoRepository.CreateTelefonoAsync(telefono);
            return CreatedAtAction(nameof(GetTelefonoByNum), new { id = telefono.Num }, telefono);
        }

        [HttpPut("{id}")]
        [ActionName(nameof(UpdateTelefono))]
        public async Task<ActionResult> UpdateTelefono(string num, Telefono telefono)
        {
            if (num != telefono.Num)
            {
                return BadRequest();
            }

            await _telefonoRepository.UpdateTelefonoAsync(telefono);

            return NoContent();

        }

        [HttpDelete("{id}")]
        [ActionName(nameof(DeleteTelefono))]
        public async Task<IActionResult> DeleteTelefono(string num)
        {
            var telefono = _telefonoRepository.GetTelefonoByNum(num);
            if (telefono == null)
            {
                return NotFound();
            }

            await _telefonoRepository.DeleteTelefonoAsync(telefono);
            return NoContent();
        }
    }
}

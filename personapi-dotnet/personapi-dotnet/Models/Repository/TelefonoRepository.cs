using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace Telefonopi_dotnet.Models.Repository
{
    public class TelefonoRepository: ITelefonoRepository
    {
        protected readonly PersonaDbContext _context;
        public TelefonoRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Telefono> GetTelefonos()
        {

            return _context.Telefonos.ToList();
        }

        public Telefono GetTelefonoByNum(string num)
        {
            return _context.Telefonos.Find(num);
        }

        public async Task<Telefono> CreateTelefonoAsync(Telefono Telefono)
        {
            await _context.Set<Telefono>().AddAsync(Telefono);
            await _context.SaveChangesAsync();
            return Telefono;
        }

        public async Task<bool> UpdateTelefonoAsync(Telefono Telefono)
        {
            _context.Entry(Telefono).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteTelefonoAsync(Telefono Telefono)
        {
            if (Telefono is null)
            {
                return false;
            }
            _context.Set<Telefono>().Remove(Telefono);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}

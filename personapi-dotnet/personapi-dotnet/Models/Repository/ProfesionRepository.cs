using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;
using Profesionpi_dotnet.Models.Repository;

namespace Profesionpi_dotnet.Models.Repository
{
    public class ProfesionRepository:IProfesionRepository
    {
        protected readonly PersonaDbContext _context;
        public ProfesionRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Profesion> GetProfesions()
        {

            return _context.Profesions.ToList();
        }

        public Profesion GetProfesionById(int id)
        {
            return _context.Profesions.Find(id);
        }

        public async Task<Profesion> CreateProfesionAsync(Profesion profesion)
        {
            await _context.Set<Profesion>().AddAsync(profesion);
            await _context.SaveChangesAsync();
            return profesion;
        }

        public async Task<bool> UpdateProfesionAsync(Profesion profesion)
        {
            _context.Entry(profesion).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProfesionAsync(Profesion profesion)
        {
            if (profesion is null)
            {
                return false;
            }
            _context.Set<Profesion>().Remove(profesion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

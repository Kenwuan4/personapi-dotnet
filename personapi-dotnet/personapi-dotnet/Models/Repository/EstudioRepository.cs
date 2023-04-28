using Estudiopi_dotnet.Models.Repository;
using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class EstudioRepository: IEstudioRepository
    {
        protected readonly PersonaDbContext _context;
        public EstudioRepository(PersonaDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Estudio> GetEstudios()
        {
            return _context.Estudios.ToList();
        }

        public Estudio GetEstudioByProfIdAndCc(int id, int cc)
        {
            return _context.Estudios.Find(id,cc);
        }

        public async Task<Estudio> CreateEstudioAsync(Estudio estudio)
        {
            await _context.Set<Estudio>().AddAsync(estudio);
            await _context.SaveChangesAsync();
            return estudio;
        }

        public async Task<bool> UpdateEstudioAsync(Estudio estudio)
        {
            _context.Entry(estudio).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteEstudioAsync(Estudio estudio)
        {
            if (estudio is null)
            {
                return false;
            }
            _context.Set<Estudio>().Remove(estudio);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class PersonaRepository: IPersonaRepository
    {
        protected readonly PersonaDbContext _context;
        public PersonaRepository(PersonaDbContext context) { 
            _context = context; 
        }

        public IEnumerable<Persona> GetPersonas() { 
       
            return _context.Personas.ToList();   
        }

        public Persona GetPersonaById(int id)
        {
            return _context.Personas.Find(id);
        }

        public async Task<Persona> CreatePersonaAsync( Persona persona)
        {
            await _context.Set<Persona>().AddAsync(persona);
            await _context.SaveChangesAsync();
            return persona;
        }

        public async Task<bool> UpdatePersonaAsync(Persona persona)
        {
            _context.Entry(persona).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeletePersonaAsync(Persona persona)
        {
            if (persona is null)
            {
                return false;
            }
            _context.Set<Persona>().Remove(persona);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

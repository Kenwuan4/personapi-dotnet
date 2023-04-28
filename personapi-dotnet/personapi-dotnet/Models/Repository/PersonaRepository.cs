using personapi_dotnet.Models.Entities;

namespace personapi_dotnet.Models.Repository
{
    public class PersonaRepository: IPersonaRepository
    {
        protected readonly PersonaDbContext _context;
        public PersonaRepository(PersonaDbContext context) { _context = context; }
    }
}

using personapi_dotnet.Models.Entities;

namespace Profesionpi_dotnet.Models.Repository
{
    public interface IProfesionRepository
    {
        Task<Profesion> CreateProfesionAsync(Profesion profesion);
        Task<bool> DeleteProfesionAsync(Profesion profesion);
        Profesion GetProfesionById(int id);
        IEnumerable<Profesion> GetProfesions();
        Task<bool> UpdateProfesionAsync(Profesion profesion);
    }
}

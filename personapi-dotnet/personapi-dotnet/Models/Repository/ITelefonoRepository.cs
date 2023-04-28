using personapi_dotnet.Models.Entities;

namespace Telefonopi_dotnet.Models.Repository
{
    public interface ITelefonoRepository
    {
        Task<Telefono> CreateTelefonoAsync(Telefono telefono);
        Task<bool> DeleteTelefonoAsync(Telefono telefono);
        Telefono GetTelefonoByNum(string num);
        IEnumerable<Telefono> GetTelefonos();
        Task<bool> UpdateTelefonoAsync(Telefono telefono);
    }
}

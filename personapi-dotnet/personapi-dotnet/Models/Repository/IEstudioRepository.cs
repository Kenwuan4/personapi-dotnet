using personapi_dotnet.Models.Entities;

namespace Estudiopi_dotnet.Models.Repository
{
    public interface IEstudioRepository
    {
        Task<Estudio> CreateEstudioAsync(Estudio Estudio);
        Task<bool> DeleteEstudioAsync(Estudio Estudio);
        Estudio GetEstudioByProfIdAndCc(int id, int cc);
        IEnumerable<Estudio> GetEstudios();
        Task<bool> UpdateEstudioAsync(Estudio Estudio);

    }
}

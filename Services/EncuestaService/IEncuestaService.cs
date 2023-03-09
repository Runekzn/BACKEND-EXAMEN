using EXAMEN.Models;

namespace EXAMEN.Services.EncuestaService
{
    public interface IEncuestaService
    {
        Task<List<Encuesta>> GetAllEncuesta();
        Task<Encuesta?> GetSingleEncuesta(int id);
        Task<List<Encuesta>> AddEncuesta(Encuesta encuesta);
        Task<List<Encuesta>?> UpdateEncuesta(int id, Encuesta request);
        Task<List<Encuesta>?> DeleteEncuesta(int id);
    }
}

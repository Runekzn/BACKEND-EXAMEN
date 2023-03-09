using EXAMEN.Models;

namespace EXAMEN.Services.EncuestadoService
{
    public interface IEncuestadoService
    {
        Task<List<Encuestado2>> GetAllEncuestados();
        Task<Encuestado2?> GetSingleEncuestados(int id);
        Task<List<Encuestado2>> AddEncuestado(Encuestado2 encuestado);
        Task<List<Encuestado2>?> UpdateEncuestado(int id, Encuestado2 request);
        Task<List<Encuestado2>?> DeleteEncuestado(int id);

    }
}

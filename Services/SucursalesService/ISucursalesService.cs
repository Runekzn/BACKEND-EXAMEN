using EXAMEN.Models;

namespace EXAMEN.Services.SucursalesService
{
    public interface ISucursalesService
    {
        Task<List<Sucursal>> GetAllSucursales();
        Task<Sucursal?> GetSingleSucurales(int id);
        Task<List<Sucursal>> AddSucursales(Sucursal sucursales);
        Task<List<Sucursal>?> UpdateSucursales(int id, Sucursal request);
        Task<List<Sucursal>?> DeleteSucursales(int id);
    }
}

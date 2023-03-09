using EXAMEN.Data;
using EXAMEN.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN.Services.SucursalesService
{
    public class SucursalesService : ISucursalesService
    {
        private readonly DataContext _context;

        public SucursalesService(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<List<Sucursal>> AddSucursales(Sucursal sucursales)
        {
            _context.Sucursal.Add(sucursales);
            await _context.SaveChangesAsync();
            return await _context.Sucursal.ToListAsync();
        }

        public async Task<List<Sucursal>?> DeleteSucursales(int id)
        {
            var sucursal = await _context.Sucursal.FindAsync(id);
            if (sucursal == null) { return null; }
            _context.Sucursal.Remove(sucursal);
            await _context.SaveChangesAsync();
            return await _context.Sucursal.ToListAsync();
        }

        public async Task<List<Sucursal>> GetAllSucursales()
        {
            var sucursal = await _context.Sucursal.ToListAsync();
            return sucursal;
        }

        public async Task<Sucursal?> GetSingleSucurales(int id)
        {
            var sucursal = await _context.Sucursal.FindAsync(id);
            if (sucursal is null) 
                return null;
            return sucursal;
        }

        public async Task<List<Sucursal>?> UpdateSucursales(int id, Sucursal request)
        {
            var sucural = await _context.Sucursal.FindAsync(id);
            if (sucural is null)
                return null;
            sucural.NOMBRE = request.NOMBRE;
            sucural.CIUDAD = request.CIUDAD;
            sucural.PROVINCIA = request.PROVINCIA; 
            
            await _context.SaveChangesAsync();
            return await _context.Sucursal.ToListAsync();
        }
    }
}

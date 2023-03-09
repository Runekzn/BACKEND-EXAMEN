using EXAMEN.Data;
using EXAMEN.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN.Services.EncuestadoService
{
    public class EncuestadoService:IEncuestadoService
    {
        private readonly DataContext _context;

        public EncuestadoService(DataContext dataContext)
        {
            _context = dataContext;
        }
    

        public async Task<List<Encuestado2>> AddEncuestado(Encuestado2 encuestado)
        {
            _context.Encuestado2.Add(encuestado);
            await _context.SaveChangesAsync();
            return await _context.Encuestado2.ToListAsync();
        }


        public async Task<List<Encuestado2>?> DeleteEncuestado(int id)
        {
           var encuestado = await _context.Encuestado2.FindAsync(id);
            if(encuestado == null) { return null; }
            _context.Encuestado2.Remove(encuestado);
            await _context.SaveChangesAsync();
            return await _context.Encuestado2.ToListAsync();   
        }

        public async Task<List<Encuestado2>> GetAllEncuestados()
        {
            var encuestado = await _context.Encuestado2.ToListAsync();
            return encuestado;
        }
      
        public async Task<Encuestado2?> GetSingleEncuestados(int id)
        {
            var encuestado = await _context.Encuestado2.FindAsync(id);
            if(encuestado is null)
                return null;
            return encuestado;
        }

        public async Task<List<Encuestado2>?> UpdateEncuestado(int id, Encuestado2 request)
        {
            var encuestado = await _context.Encuestado2.FindAsync(id);
            if (encuestado is null)
                return null;
            encuestado.CI= request.CI;
            encuestado.NOMBRE = request.NOMBRE;
            encuestado.SEXO = request.SEXO;
            encuestado.EDAD = request.EDAD;

            await _context.SaveChangesAsync();
            return await _context.Encuestado2.ToListAsync();
        }
    }
}

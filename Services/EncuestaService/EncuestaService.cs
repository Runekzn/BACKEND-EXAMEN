using EXAMEN.Data;
using EXAMEN.Models;
using Microsoft.EntityFrameworkCore;

namespace EXAMEN.Services.EncuestaService
{
    public class EncuestaService : IEncuestaService
    {
        private readonly DataContext _context;

        public EncuestaService(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<List<Encuesta>> AddEncuesta(Encuesta encuesta)
        {
            _context.Encuesta.Add(encuesta);
            await _context.SaveChangesAsync();
            return await _context.Encuesta.ToListAsync();
        }

        public async Task<List<Encuesta>?> DeleteEncuesta(int id)
        {
           var encuesta = await _context.Encuesta.FindAsync(id);
            if (encuesta == null) { return null; }
            _context.Encuesta.Remove(encuesta);
            await _context.SaveChangesAsync();
            return await _context.Encuesta.ToListAsync();
        }

        public async Task<List<Encuesta>> GetAllEncuesta()
        {
            var encuesta = await _context.Encuesta.ToListAsync(); 
            return encuesta;
        }

        public async Task<Encuesta?> GetSingleEncuesta(int id)
        {
            var encuesta = await _context.Encuesta.FindAsync(id);
            if(encuesta is null) 
                { return null; }
            return encuesta;
        }

        public async Task<List<Encuesta>?> UpdateEncuesta(int id, Encuesta request)
        {
            var encuesta = await _context.Encuesta.FindAsync(id);
            if(encuesta is null) 
                { return null; }
            encuesta.PREGUNTA1 = request.PREGUNTA1;
            encuesta.PREGUNTA2  = request.PREGUNTA2;
            encuesta.PREGUNTA3 = request.PREGUNTA3; 
            encuesta.PREGUNTA4 = request.PREGUNTA4;
            encuesta.PREGUNTA5 = request.PREGUNTA5; 
            encuesta.OBSERVACIONES = request.OBSERVACIONES;
            encuesta.ID_ENCUESTADO = request.ID_ENCUESTADO;
            encuesta.ID_SUCURSAL = request.ID_SUCURSAL; 
           
            await _context.SaveChangesAsync();
            return await _context.Encuesta.ToListAsync();
        }
    }
}

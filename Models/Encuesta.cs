using System.ComponentModel.DataAnnotations;

namespace EXAMEN.Models
{
    public class Encuesta
    {
        [Key]
        public int ENCUESTA_ID { get; set; }
        public string PREGUNTA1 { get; set; } = string.Empty;
        public string PREGUNTA2 { get; set; } = string.Empty;
        public int PREGUNTA3 { get; set; }
        public int PREGUNTA4 { get; set; }
        public int PREGUNTA5 { get; set; }
        public string OBSERVACIONES { get; set; } = string.Empty;
        public int ID_ENCUESTADO { get; set; }   
        public int ID_SUCURSAL { get; set; }    
    }
}

using System.ComponentModel.DataAnnotations;

namespace EXAMEN.Models
{
    public class Encuestado2
    {
        [Key]
        public int ID_ENCUESTADO { get; set; }
        public string CI { get; set; } = string.Empty;
        public string NOMBRE { get; set; } = string.Empty;
        public string SEXO { get; set; } = string.Empty;
        public int EDAD { get; set; }
    }
}

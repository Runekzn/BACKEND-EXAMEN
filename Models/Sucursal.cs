using System.ComponentModel.DataAnnotations;

namespace EXAMEN.Models
{
    public class Sucursal
    {
        [Key]
        public int SUCURSAL_ID { get; set; }
        public string NOMBRE { get; set; } = string.Empty;
        public string CIUDAD { get; set; } = string.Empty;
        public string PROVINCIA { get; set; } = string.Empty;
    }
}

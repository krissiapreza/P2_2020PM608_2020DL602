using System.ComponentModel.DataAnnotations;

namespace P2_2020PM608_2020DL602.Models
{
    public class Departamentos
    {
        [Key]
        public int departamentoID { get; set; }
        public string? departamento { get; set; }
    }
}

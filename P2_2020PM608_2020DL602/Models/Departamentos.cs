using System.ComponentModel.DataAnnotations;

namespace P2_2020RC6005_2020UL601.Models
{
    public class Departamentos
    {
        [Key]
        public int departamentoID { get; set; }
        public string? departamento { get; set; }
    }
}

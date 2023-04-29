using System.ComponentModel.DataAnnotations;

namespace P2_2020RC6005_2020UL601.Models
{
    public class Generos
    {
        [Key]
        public int generoID { get; set; }
        public string? genero { get; set; }
    }
}

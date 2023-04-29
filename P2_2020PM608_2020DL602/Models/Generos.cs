using System.ComponentModel.DataAnnotations;

namespace P2_2020PM608_2020DL602.Models
{
    public class Generos
    {
        [Key]
        public int generoID { get; set; }
        
        public string? genero { get; set; }
    }
}

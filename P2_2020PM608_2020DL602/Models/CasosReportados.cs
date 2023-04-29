using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace P2_2020RC6005_2020UL601.Models
{
    public class CasosReportados
    {
        [Key]
        public int casosID { get; set; }
        public int departamentoID { get; set; }
        [NotMapped]
        public string? departamento { get; set; }
        public int generoID { get; set; }
        [NotMapped]
        public string? genero { get; set; }
        public int confirmados { get; set; }
        public int recuperados { get; set; }
        public int fallecidos { get; set; }
    }
}

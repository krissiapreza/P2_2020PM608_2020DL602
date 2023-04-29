using Microsoft.EntityFrameworkCore;
using P2_2020PM608_2020DL602.Models;

namespace P2_2020PM608_2020DL602.Models {
    public class parcialDbContext: DbContext {
        public parcialDbContext(DbContextOptions options) : base(options) {


        }

        public DbSet<Generos> generos { get; set; }
        public DbSet<Departamentos> departamentos { get; set; }
        public DbSet<CasosReportados> casosReportados { get; set; }

    }
}

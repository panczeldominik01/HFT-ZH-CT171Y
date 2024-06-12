using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CT171Y_ZH
{
    public class TopCelebrity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Nationality { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }
        public string BirthPlace { get; set; }
        public int Age { get; set; }
        public int NumOfFilms {  get; set; }
        public int OscarNominations { get; set; }
        public int OscarAwards {  get; set; }
        public string Degree { get; set; }
        public bool IsProducer {  get; set; }
    }
    public class CelebrityDbContext : DbContext
    {
        public DbSet<TopCelebrity> TopCelebrities { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = celebrities.db");
        }
    }
}

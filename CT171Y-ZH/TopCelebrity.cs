using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Net.Http.Headers;

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
    [AttributeUsage(AttributeTargets.Property)]
    public class DataDescription : Attribute {
        public string Description { get; }
        public DataDescription(string desc) 
        {
            Description = desc;
        }
    }
    public static class AttributeHelper
    {
        public static string GetPropertyDescription<T>(string propertyName)
        {
            PropertyInfo propInfo = typeof(T).GetProperty(propertyName);
            if (propInfo == null)
            {
                throw new ArgumentException($"Propety '{propertyName}' does not exist on type '{typeof(T).Name}'");
            }
            DataDescription attribute = propInfo.GetCustomAttribute<DataDescription>();
            return attribute?.Description ?? $"No description found on property '{propertyName}'.";
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace CT171Y_ZH
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////a
            var celebrities = new List<Celebrity>();
            int threeTimesNominated = celebrities.Count(c => c.OscarNominations >= 3);
            ////////b
            var mostFilms = celebrities.OrderByDescending(c => c.NumOfFilms).First();
            string mostFilmsName= mostFilms.Name;
            int mostFilmCount = mostFilms.NumOfFilms;
            ///////d
            var OscarWinningProducers = celebrities.Where(c => c.OscarAwards > 0 && c.IsProducer).ToList();
            /////e
            var nominationsByNationality = celebrities.GroupBy(c => c.Nationality).Select(group => new {Nationality = group.Key, Nominations = group.Sum(c => c.OscarNominations) }).ToList();
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(nominationsByNationality, Formatting.Indented);
            File.WriteAllText("nominationsByNationality.json", json);
            //////////f
            var qualifiedCelebrities = celebrities
                .Where(c => c.OscarNominations >= 2 && c.NumOfFilms >= 15)
                .Select(c => new TopCelebrity
                {
                    Name = c.Name,
                    OscarNominations = c.OscarNominations,
                    NumOfFilms = c.NumOfFilms
                }).ToList();
            using (var context = new CelebrityDbContext())
            {
                context.TopCelebrities.RemoveRange(context.TopCelebrities);
                context.TopCelebrities.AddRange(qualifiedCelebrities);
                context.SaveChanges();
            }
        }
    }
}

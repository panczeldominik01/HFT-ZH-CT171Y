using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CT171Y_ZH
{
    public class Celebrity
    {
        [DataDescription("Full name")]
        public string Name { get; set; }
        [DataDescription("Nationality")]
        public string Nationality { get; set; }
        [DataDescription("Date of birth")]
        public string BirthDate { get; set; }
        [DataDescription("Place of birth")]
        public string BirthPlace { get; set; }       
        public int Age { get; set; }
        public int NumOfFilms { get; set; }
        public int OscarNominations { get; set; }
        public int OscarAwards { get; set; }
        public string Degree { get; set; }
        public bool IsProducer { get; set; }
    }
    public static class CelebrityImporter
    {
        public static List<Celebrity> Import()
        { 
            XmlSerializer serializer = new XmlSerializer(typeof(List<Celebrity>));
            using (FileStream fs = new FileStream("celebrities.xml", FileMode.Open))
            {
                return (List<Celebrity>)serializer.Deserialize(fs);
            }
        } 
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Windows.Data.Json;

namespace Aya.Models
{
    public class Phrase
    {
        public string Original { get; set; }
        public string Translated { get; set; }
        public string Description { get; set; }
        public string SAMPA { get; set; }
        public int Importance { get; set; }

        public static Phrase FromJsonObject(JsonObject jObject)
        {
            return new Phrase()
            {
                Original = jObject["original"].GetString(),
                Translated = jObject["translated"].GetString(),
                Description = jObject["description"].GetString(),
                SAMPA = jObject["sampa"].GetString(),
                Importance = (int)jObject["importance"].GetNumber()
            };
        }
    }
}

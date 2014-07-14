using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;
using Windows.Data.Json;

namespace Aya.Models
{
    public class Alphabet
    {
        public Alphabet(string title, string subtitle, string description)
        {
            this.Title = title;
            this.Subtitle = subtitle;
            this.Description = description;
            this.Symbols = new ObservableCollection<Symbol>();
            this.Numbers = new ObservableCollection<Number>();
            this.NumbersDisplay = new ObservableCollection<Number>();
            this.PhraseGroups = new ObservableCollection<PhraseGroup>();
        }

        public void AddPhraseGroup(PhraseGroup p)
        {
            this.PhraseGroups.Add(p);
        }

        public void AddSymbol(Symbol s)
        {
            this.Symbols.Add(s);
        }

        public void AddNumber(Number n, bool addToDisplay = false)
        {
            this.Numbers.Add(n);
            if (addToDisplay)
            {
                this.NumbersDisplay.Add(n);
            }
        }

        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public ObservableCollection<Symbol> Symbols { get; private set; }
        public ObservableCollection<Number> Numbers { get; private set; }
        public ObservableCollection<Number> NumbersDisplay { get; private set; }
        public ObservableCollection<PhraseGroup> PhraseGroups { get; private set; }

        public static Alphabet FromJsonObject(JsonObject jObject)
        {
            Alphabet _alfabeto = new Alphabet(jObject["title"].GetString()
                , jObject["subtitle"].GetString()
                , jObject["description"].GetString());

            JsonArray simbolos = jObject["symbols"].GetArray();
            foreach (JsonValue simbolo in simbolos)
            {
                JsonObject simb = simbolo.GetObject();
                _alfabeto.AddSymbol(new Symbol()
                {
                    Lowercase = simb["lowercase"].GetString(),
                    Uppercase = simb["uppercase"].GetString(),
                    Origin = simb["origin"].GetString(),
                    SAMPA = simb["sampa"].GetString(),
                    Description = simb["description"].GetString()
                });
            }

            JsonArray numeros = jObject["numbers"].GetArray();
            int i = 10;
            foreach (JsonValue numero in numeros)
            {
                JsonObject nmb = numero.GetObject();
                _alfabeto.AddNumber(new Number()
                {
                    NumberInteger = Int32.Parse(nmb["number"].GetString()),
                    NumberString = nmb["number"].GetString(),
                    Name = nmb["name"].GetString(),
                    SAMPA = nmb["sampa"].GetString()
                }, --i > 0);
            }

            JsonArray phraseGroups = jObject["commonPhrasesGroup"].GetArray();
            JsonObject commonPhrasesGroup = jObject["commonPhrases"].GetObject();
            foreach (JsonValue pg in phraseGroups)
            {
                JsonObject pgo = pg.GetObject();
                string key = pgo["key"].GetString();
                string name = pgo["name"].GetString();
                PhraseGroup phraseGroup = new PhraseGroup(name);
                JsonArray phrasesArray = commonPhrasesGroup[key].GetArray();
                var arrau = from x in phrasesArray
                            orderby x.GetObject()["importance"].GetNumber()
                            select Phrase.FromJsonObject(x.GetObject());
                phraseGroup.FullPhrases = new ObservableCollection<Phrase>(arrau);
                phraseGroup.DisplayPhrases = new ObservableCollection<Phrase>(phraseGroup.FullPhrases.Take(5));
                _alfabeto.AddPhraseGroup(phraseGroup);
            }
            return _alfabeto;

        }

        public static Alphabet FromString(string jsonText)
        {
            JsonObject jObject = JsonObject.Parse(jsonText);
            return FromJsonObject(jObject["alphabet"].GetObject());
        }
    }
}

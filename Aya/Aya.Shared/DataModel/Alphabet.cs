﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Windows.Data.Json;

namespace Aya.DataModel
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

        public static Alphabet FromString(string jsonText)
        {
            JsonObject jsonObjectA = JsonObject.Parse(jsonText);
            Alphabet _alfabeto = new Alphabet(jsonObjectA["title"].GetString()
                , jsonObjectA["subtitle"].GetString()
                , jsonObjectA["description"].GetString());

            JsonArray simbolos = jsonObjectA["symbols"].GetArray();
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

            JsonArray numeros = jsonObjectA["numbers"].GetArray();
            int i = 8;
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
            return _alfabeto;
        }
    }
}
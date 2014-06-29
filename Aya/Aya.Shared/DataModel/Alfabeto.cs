using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

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
        }

        public void AddSymbol(Symbol s){
            this.Symbols.Add(s);
        }
        public string Title { get; private set; }
        public string Subtitle { get; private set; }
        public string Description { get; private set; }
        public ObservableCollection<Symbol> Symbols { get; private set; }
    }
}

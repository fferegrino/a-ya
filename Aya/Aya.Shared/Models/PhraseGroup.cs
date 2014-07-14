using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aya.Models
{
    public class PhraseGroup
    {
        public string Name { get; set; }

        public PhraseGroup( string name)
        {
            Name = name;
            FullPhrases = new ObservableCollection<Phrase>();
            DisplayPhrases = new ObservableCollection<Phrase>();
        }
        public ObservableCollection<Phrase> FullPhrases { get; set; }
        public ObservableCollection<Phrase> DisplayPhrases { get; set; }
    }
}

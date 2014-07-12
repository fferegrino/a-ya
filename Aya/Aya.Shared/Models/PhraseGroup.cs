using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Aya.Models
{
    public class PhraseGroup
    {
        public string Name { get; set; }
        public ObservableCollection<Phrase> Phrases { get; set; }
        public ObservableCollection<Phrase> DisplayPhrases { get; set; }
    }
}

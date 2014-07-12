using System;
using System.Collections.Generic;
using System.Text;

namespace Aya.DataModel
{
    public class Phrase
    {
        public string Original { get; set; }
        public string Translated { get; set; }
        public string SAMPA { get; set; }
        public int Importance { get; set; }

    }
}

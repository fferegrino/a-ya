using System;
using System.Collections.Generic;
using System.Text;

namespace Aya.DataModel
{
    public class Symbol
    {
        public string UniqueID { get; set; }
        public string Uppercase { get; set; }
        public string Lowercase { get; set; }
        public string Origin { get; set; }
		public string Description { get; set; }
        public string SAMPA { get; set; }

    }
}

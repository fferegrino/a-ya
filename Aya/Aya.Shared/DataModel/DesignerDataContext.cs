using System;
using System.Collections.Generic;
using System.Text;

namespace Aya.DataModel
{
    public class DesignerDataContext
    {
        private Alphabet aph;

        public Alphabet Alfabeto
        {
            get
            {
                if (aph == null)
                {
                    aph = new Alphabet("My alphabet", "Subtle", "LOrem");
                    for (int i = 0; i < 10; i++)
                    {
                        aph.AddSymbol(new Symbol()
                        {
                            Lowercase = ('a' + i).ToString(),
                            Uppercase = ('A' + i).ToString()
                        });
                    }
                } return aph;
            }
        }

    }
}

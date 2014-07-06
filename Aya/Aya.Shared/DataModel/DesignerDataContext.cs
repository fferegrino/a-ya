using System;
using System.Collections.Generic;
using System.Text;

namespace Aya.DataModel
{
    public class DesignerDataContext
    {
        private Alphabet aph;
        private List<Resource> res;

        public List<Resource> Recursos
        {
            get
            {
                if (res == null)
                {
                    res = new List<Resource>();
                    for (int i = 0; i < 20; i++)
                    {
                        res.Add(new Resource()
                        {
                            Url = "http://google.com",
                            Name = "Recurso " + i
                        });
                    }
                }
                return res;
            }
        }

        public Alphabet Alfabeto
        {
            get
            {
                if (aph == null)
                {
                    aph = new Alphabet("Alfabeto crílico", "Se usa el alfabeto crílico", "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum ante vel suscipit elementum. Donec lobortis felis ut erat rhoncus euismod. Curabitur commodo diam quis massa rutrum rhoncus. Nullam elementum.");
                    for (int i = 0; i < 20; i++)
                    {
                        aph.AddSymbol(new Symbol()
                        {
                            Uppercase = "A",
                            Lowercase = "a",
                            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum ante vel suscipit elementum.",
                            Origin = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed condimentum ante vel suscipit elementum.",
                            SAMPA = "/íj/"
                        });
                        aph.AddNumber(new Number()
                        {
                            Name = "uno",
                            SAMPA = "/íjaasf/",
                            NumberString = "10",
                            NumberInteger = 10
                        }, i < 10);
                    }
                } return aph;
            }
        }

    }
}

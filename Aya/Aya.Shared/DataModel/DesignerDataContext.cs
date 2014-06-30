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
                            Uppercase = ('A' + i).ToString(),
							Origin = "La letra Б es derivada de la letra beta del alfabeto griego, aunque en el alfabeto cursivo ruso es más parecida a una delta, δ. El nombre antiguo de esta letra era buki. No tenía ningún valor numérico.",
                            Description ="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nam consequat iaculis urna, ultrices congue elit tristique nec. Mauris sit amet egestas nunc, aliquam congue ante. Maecenas lectus turpis, lacinia at vulputate id, egestas id magna. Pellentesque vehicula vehicula neque, vel porttitor nibh. Quisque cursus porta magna id pretium. Sed nec.",
                            IPA = "/çʝ/"
                        });
                    }
                } return aph;
            }
        }

    }
}

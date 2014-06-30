using System;
using System.Collections.Generic;
using System.Text;

namespace Aya.DataModel
{
    public class DesignerDataContext
    {
        private Alphabet aph;

        public const string designerText = "{\"title\":\"El alfabeto crílico\",\"subtitle\":\"El alfabeto que se usa es el crílico\",\"description\":\"Es una variante del alfabeto cirílico. Desde el año 1918 (oficialmente desde 1942) consta de 33 letras.\nFue desarrollado en Bulgaria. Desde allí fue introducido en la Rus de Kiev, estado medieval de los eslavos del este. Esta introducción fue simultánea a su conversión al cristianismo en 988 d. C. o, si ciertos restos arqueológicos están correctamente datados, en una fecha ligeramente anterior.\",\"symbols\":[{\"uppercase\":\"A\",\"lowercase\":\"a\",\"sampa\":\"/a/\",\"origin\":\"Proviene directamente de la letra alfa del alfabeto griego. En el alfabeto cirílico antiguo su nombre era azǔ y representaba al número uno.\",\"description\":\"En el ruso la B se pronuncia como te enseñaron la V tus profesores (poniendo tus dientes superiores sobre tu labio inferior).\"},{\"uppercase\":\"Б\",\"lowercase\":\"б\",\"sampa\":\"/b/ o /bʲ/\",\"origin\":\"La letra Б es derivada de la letra beta del alfabeto griego, aunque en el alfabeto cursivo ruso es más parecida a una delta, δ. El nombre antiguo de esta letra era buki. No tenía ningún valor numérico.\",\"description\":\"б se pronuncia como \"bomba\" en acento yucateco.\"},{\"uppercase\":\"В\",\"lowercase\":\"в\",\"sampa\":\"/v/ o /vʲ/\",\"origin\":\"Junto con la Б del alfabeto cirílico, esta letra es derivada de la letra beta del alfabeto griego.\",\"description\":\"En el ruso la B se pronuncia como te enseñaron la V tus profesores (poniendo tus dientes superiores sobre tu labio inferior).\"},{\"uppercase\":\"Г\",\"lowercase\":\"г\",\"sampa\":\"/g/\",\"origin\":\"Proviene de la letra gamma del alfabeto griego. Ambas letras son iguales en las versiones estándar de ambos alfabetos.\",\"description\":\"El sonido siempre es g sin importar la vocal siguiente. Га, гэ, ги, го, гу equivale a ga, gue, gui, go, gu; nunca como en ge, gi. Entre las letras \"e\" y \"o\" se pronuncia como /v/, ej. \"его\" se pronuncia /yevó/. Este fenómeno aplica sólo al final de palabra y cuando se trata de una terminación de caso (genitivo y acusativo).\"},{\"uppercase\":\"Д\",\"lowercase\":\"д\",\"sampa\":\"/d/ o /dʲ/\",\"origin\":\"Proviene de la letra del alfabeto griego delta (Δ). La mayor diferencia gráfica con su equivalente griego se encuentra en las dos patas por debajo de las dos esquinas inferiores.\",\"description\":\"Se pronuncia como la d en español. Para recordar cómo se pronuncia la д, piensa en la D mayúscula con patitas.\"},{\"uppercase\":\"Е\",\"lowercase\":\"е\",\"origin\":\"Es exactamente como la letra latina E. Deriva de la épsilon (Ε, ε) griega.\",\"sampa\":\"/jɛ/ o / ʲɛ/\",\"description\":\"En el ruso la B se pronuncia como te enseñaron la V tus profesores (poniendo tus dientes superiores sobre tu labio inferior).\"}],\"numbers\":[{\"number\":\"1\",\"name\":\"оди́н\",\"sampa\":\"[adín]\"},{\"number\":\"2\",\"name\":\"два\",\"sampa\":\"[dva]\"},{\"number\":\"3\",\"name\":\"три\",\"sampa\":\"[trí]\"},{\"number\":\"4\",\"name\":\"четы́ре\",\"sampa\":\"[chitúir'e]\"},{\"number\":\"5\",\"name\":\"пять\",\"sampa\":\"[p'at']\"},{\"number\":\"6\",\"name\":\"шесть\",\"sampa\":\"[shest']\"},{\"number\":\"7\",\"name\":\"семь\",\"sampa\":\"[sem']\"},{\"number\":\"8\",\"name\":\"во́семь\",\"sampa\":\"[vósim']\"},{\"number\":\"9\",\"name\":\"де́вять\",\"sampa\":\"[d'évit']\"},{\"number\":\"10\",\"name\":\"де́сять\",\"sampa\":\"[d'ésit']\"}]}";

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
                    //aph = Alphabet.FromString(designerText);
                } return aph;
            }
        }

    }
}

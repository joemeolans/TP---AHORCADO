using System;

namespace Diveria.Ahorcado
{
    class Palabra
    {
        List<string> palabras = new List<string> {"AHORCADO", "NUMERO", "CLASE", "MURCIELAGO", "MAYORMENTE", "OLA", "EL", "A", "CHAU"};
        public string GetPalabraRandom(){
            Random rnd = new Random();
            int randIndex = rnd.Next(palabras.Count);
            string random = palabras[randIndex];
            return random;
        }
    }
}
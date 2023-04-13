using System;

namespace Diveria.Ahorcado
{
    class Tablero
    {
        internal bool ChequearWin()
        {
            return false;
        }
        internal bool HorcaIsFull()
        {
            return false;
        }
        public string CrearPalabraOculta(string palabraRandom){
            string palabra_oculta = palabraRandom.Replace(palabraRandom, new string('_', palabraRandom.Length));
            return palabra_oculta;
        }
        public bool ChequearChar(char charIngresado, string palabraRandom)
        {
            foreach (char letra in palabraRandom)
            {
                if (char.ToUpper(charIngresado) == char.ToUpper(letra))
                {
                    return true;
                }
            }
            return false;

        }

        public void DibujarPalabraResultante(){

        }
    }
}
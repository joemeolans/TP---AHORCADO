using System;

namespace Diveria.Ahorcado
{
    class Tablero
    {
        internal bool ChequearWin(string palabraOculta)
        {
            foreach (char s in palabraOculta)
            {
                if (s == '_')
                {
                    return false;
                }
            }
            return true;
        }
        internal bool SinVidas(int vidas)
        {
            if (vidas == 0)
            {
                return true;
            }
            return false;
        }
        public string CrearPalabraOculta(string palabraRandom)
        {
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

        public void DibujarPalabraResultante()
        {

        }
    }
}
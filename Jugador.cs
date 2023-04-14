using System;

namespace Diveria.Ahorcado
{
    class Jugador
    {
        public char IntroducirChar()
        {
            Console.WriteLine("");
            Console.Write("Pulse una letra o número: ");
            char letra;
            do
            {
                letra = Console.ReadKey().KeyChar;
            } while (!(char.IsLetter(letra)));
            return char.ToUpper(letra);
        }
    }
}
using System;

namespace Diveria.Ahorcado
{
    class Player
    {
        Word _word;
        Board _board;
        public Player(){
            this._word = new Word();
        }
        public char GetIntoChar()
        {
            Console.WriteLine("");
            Console.Write("Pulse una letra o número: ");
            char letter;
            do
            {
                letter = Console.ReadKey().KeyChar;
            } while (!(char.IsLetter(letter)));
            return char.ToUpper(letter);
        }
        
    }
}
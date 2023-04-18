using System;

namespace Diveria.Ahorcado
{
    class Board
    {
        Word _word;
        Player _player;
        int lifes;
        public List<char> wrongLetters;
        public Board()
        {
            this._word = new Word();
            this._player = new Player();
            lifes = 5;
            this.wrongLetters = new List<char>();
        }
        internal bool NoLives()
        {
            if (lifes == 0)
            {
                return true;
            }
            return false;
        }
        public void ShowWrongLetters()
        {
            Console.WriteLine("");
            if (wrongLetters.Count > 0)
            {
                Console.WriteLine("Las siguientes son las letras que ya fueron pulsadas y son incorrectas:");
                foreach (char letter in wrongLetters)
                {
                    Console.Write(" " + letter + " ");
                }
            }
            else
            {
                Console.WriteLine("Aun no ha seleccionado ninguna letra que sea incorrecta");
            }
            Console.WriteLine(" ");
            Console.WriteLine("Le quedan: " + lifes + " vidas");
        }
        public void RecreaseLife()
        {
            lifes--;
        }
        public bool CheckPulse(char letterEntered)
        {
            foreach (char letter in wrongLetters)
            {
                if (letter == letterEntered)
                {
                    return true;
                }
            }
            return false;
        }
        /*dsd*/
        public void ReadLetter()
        {
            char letterEntered;
            letterEntered = this._player.GetIntoChar();
            bool charExist;
            charExist = this._word.CheckChar(letterEntered);
            if(charExist)
            {
                Console.Clear();
                this._word.UpdateResultingWord(letterEntered);
            }
            else
            {
                bool pulsado = this.CheckPulse(letterEntered);
                if (!pulsado)
                {
                    this.wrongLetters.Add(letterEntered);
                    this.RecreaseLife();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Esa letra ya fue pulsada anteriormente");
                    Thread.Sleep(3000);
                }
            }
        }
    }
}
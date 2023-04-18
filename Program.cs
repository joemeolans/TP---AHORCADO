using System;

namespace Diveria.Ahorcado
{
    class Ahorcado
    {
        Player _player;
        Board _board;
        Word _word;
        //int lifes;
        //List<char> wrongLetters;
        public Ahorcado()
        {
            this._player = new Player();
            this._board = new Board();
            this._word = new Word();
            //this.lifes = 5;
            //this.wrongLetters = new List<char>();
        }
        static void Main(string[] args)
        {
            new Ahorcado().Play();
        }
        private void Play()
        {
            this.DisplayInicial();
            this.DisplayIntermediate();
            this.DisplayFinal();
        }
        private void DisplayInicial()
        {
            ConsoleKeyInfo key;
            do
            {
                Console.WriteLine("Bienvenidos al juego! Presiona enter para continuar:");
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);
        }
        private void DisplayIntermediate()
        {
            this._word.GenerateWordRandom();
            bool charExist;
            do
            {
                this.DisplayGame();
                this._board.ReadLetter();
                /*
                char letterEntered;
                letterEntered = _player.GetIntoChar();
                charExist = this._word.CheckChar(letterEntered);
                if (charExist)
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
                        this._board.RecreaseLife();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Esa letra ya fue pulsada anteriormente");
                        Thread.Sleep(3000);
                    }
                }
                */
            } while (!(this._word.CheckWin()) && !(this._board.NoLives()));
        }
        private void DisplayFinal()
        {
            if (this._word.CheckWin())
            {
                this.DisplayWin();
            }

            if (this._board.NoLives())
            {
                this.DisplayLose();
            }
        }
        private void DisplayGame()
        {
            this._word.DrawResultingWord();
            this._board.ShowWrongLetters();
        }
        private void DisplayWin()
        {
            Console.Clear();
            Console.WriteLine("Adivinaste la palabra, felicidades!");
            Console.WriteLine("Presiona ENTER para cerrar el juego");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);
        }
        private void DisplayLose()
        {
            Console.Clear();
            Console.WriteLine("Has perdido!");
            Console.WriteLine("Presiona ENTER para cerrar el juego");
            ConsoleKeyInfo key;
            do
            {
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Enter);
        }
        /*
        private bool CheckPulse(char letterEntered)
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
        */
    }
}
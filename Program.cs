using System;

namespace Diveria.Ahorcado
{
    class Ahorcado
    {

        Jugador _jugador;
        Tablero _tablero;
        Palabra _palabra;
        string palabraOculta;
        int vidas;
        List<char> letrasIncorrectas;
        public Ahorcado()
        {
            this._jugador = new Jugador();
            this._tablero = new Tablero();
            this._palabra = new Palabra();
            this.palabraOculta = "null";
            this.vidas = 5;
            this.letrasIncorrectas = new List<char>();
        }
        static void Main(string[] args)
        {
            new Ahorcado().Jugar();
        }


        private void Jugar()
        {
            string palabraRandom;
            palabraRandom = this._palabra.GetPalabraRandom();
            ConsoleKeyInfo tecla;
            do
            {
                this.DisplayInterfazBienvenida();
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Enter);
            bool ExisteElChar;
            palabraOculta = this._tablero.CrearPalabraOculta(palabraRandom);
            do
            {
                Console.Clear();
                Console.WriteLine(vidas);
                this.DibujarPalabraResultante(palabraOculta);
                this.MostrarLetrasIncorrectasUsadas(letrasIncorrectas);
                Console.WriteLine(" ");
                Console.WriteLine("Le quedan: "+ vidas + " vidas");
                char charIngresado;
                charIngresado = _jugador.IntroducirChar();
                ExisteElChar = this._tablero.ChequearChar(charIngresado, palabraRandom);
                if (ExisteElChar)
                {
                    Console.Clear();
                    this.ActualizarPalabraResultante(charIngresado, palabraRandom);
                }
                else
                {
                    bool pulsado = this.ChequearSiFuePulsado(charIngresado);
                    if (!pulsado)
                    {
                        this.letrasIncorrectas.Add(charIngresado);
                        vidas--;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Esa letra ya fue pulsada anteriormente");
                        Thread.Sleep(3000);
                    }
                }

            } while (!(this._tablero.ChequearWin(palabraOculta)) && !(this._tablero.SinVidas(vidas)));

            if (this._tablero.ChequearWin(palabraOculta))
            {
                this.DisplayWin();
            }

            if (this._tablero.SinVidas(vidas))
            {
                this.DisplayLose();
            }
        }

        private void DisplayInterfazBienvenida()
        {
            Console.WriteLine("Bienvenidos al juego! Presiona enter para continuar:");
        }

        private void DisplayWin()
        {
            Console.Clear();
            Console.WriteLine("Adivinaste la palabra, felicidades!");
            Console.WriteLine("Presiona ENTER para cerrar el juego");
            ConsoleKeyInfo tecla;
            do
            {
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Enter);
        }

        private void DisplayLose()
        {
            Console.Clear();
            Console.WriteLine("Has perdido!");
            Console.WriteLine("Presiona ENTER para cerrar el juego");
            ConsoleKeyInfo tecla;
            do
            {
                tecla = Console.ReadKey();
            } while (tecla.Key != ConsoleKey.Enter);
        }

        private void ActualizarPalabraResultante(char charIngresado, string palabraRandom)
        {
            int idx = 0;
            foreach (char letra in palabraRandom)
            {
                if (letra == charIngresado)
                {
                    palabraOculta = palabraOculta.Substring(0, idx) + charIngresado + palabraOculta.Substring(idx + 1);
                }
                idx++;
            }
        }

        private void DibujarPalabraResultante(string palabraOculta)
        {
            Console.Clear();
            Console.WriteLine("La siguiente es la palabra oculta a adivinar:");
            foreach (char s in palabraOculta)
            {
                Console.Write(" " + s + " ");
            }
            Console.WriteLine("");
        }

        private void MostrarLetrasIncorrectasUsadas(List<char> letrasIncorrectas)
        {
            Console.WriteLine("");
            if (letrasIncorrectas.Count > 0)
            {
                Console.WriteLine("Las siguientes son las letras que ya fueron pulsadas y son incorrectas:");
                foreach (char s in letrasIncorrectas)
                {
                    Console.Write(" " + s + " ");
                }
            }
            else
            {
                Console.WriteLine("Aun no ha seleccionado ninguna letra que sea incorrecta");
            }
        }

        private bool ChequearSiFuePulsado(char charIngresado)
        {
            foreach (char s in letrasIncorrectas)
            {
                if (s == charIngresado)
                {
                    return true;
                }
            }
            return false;
        }

    }
}
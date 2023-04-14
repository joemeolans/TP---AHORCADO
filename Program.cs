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
        public Ahorcado()
        {
            this._jugador = new Jugador();
            this._tablero = new Tablero();
            this._palabra = new Palabra();
            this.palabraOculta = "null";
            this.vidas = 5;
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
            do{
                this.DisplayInterfazBienvenida();
                tecla = Console.ReadKey();
            }while(tecla.Key != ConsoleKey.Enter);
            bool ExisteElChar;
            this.InterfazInicialDelJuego(palabraRandom);
            palabraOculta = this._tablero.CrearPalabraOculta(palabraRandom);
            do
            {
                char charIngresado;
                charIngresado = _jugador.IntroducirChar();
                ExisteElChar = this._tablero.ChequearChar(charIngresado, palabraRandom);
                if(ExisteElChar){
                    this.ActualizarPalabraResultante(charIngresado, palabraRandom);
                    this.DibujarPalabraResultante(palabraOculta);
                }
                else{
                    this.RestarVidas(vidas);
                }

            } while (!(this._tablero.ChequearWin(palabraOculta)) || !(this._tablero.SinVidas(vidas)));

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

        public void InterfazInicialDelJuego(string palabraRandom){
            Console.Clear();
            Console.WriteLine("La siguiente es la palabra oculta a adivinar:");
            foreach(char character in palabraRandom){
                    Console.Write(" _ "); 
            }
        }

        private void DisplayWin()
        {
            Console.Clear();
            Console.WriteLine("Adivinaste la palabra, felicidades!");
            Console.WriteLine("Presiona ENTER para cerrar el juego");
            ConsoleKeyInfo tecla;
            do{
                tecla = Console.ReadKey();
            }while(tecla.Key != ConsoleKey.Enter);
        }

        private void DisplayLose()
        {
            Console.Clear();
            Console.WriteLine("Has perdido!");
            Console.WriteLine("Presiona ENTER para cerrar el juego");
            ConsoleKeyInfo tecla;
            do{
                tecla = Console.ReadKey();
            }while(tecla.Key != ConsoleKey.Enter);
        }

        private void ActualizarPalabraResultante(char charIngresado, string palabraRandom){
            int idx = 0;
            foreach(char letra in palabraRandom){
                if(letra == charIngresado){
                    palabraOculta = palabraOculta.Substring(0, idx) + charIngresado + palabraOculta.Substring(idx + 1);
                }
                idx++;
            }
        }

        private void DibujarPalabraResultante(string palabraOculta){
            Console.Clear();
            Console.WriteLine("La siguiente es la palabra oculta a adivinar:");
            foreach(char s in palabraOculta){
                Console.Write(" "+s+" ");
            }
            Console.WriteLine("");
        }

        private void RestarVidas(int vidas){
            vidas--;
        }

    }
}
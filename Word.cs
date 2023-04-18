using System;

namespace Diveria.Ahorcado
{
    class Word
    {
        List<string> words = new List<string> { "AHORCADO", "NUMERO", "CLASE", "MURCIELAGO", "MAYORMENTE", "OLA", "EL", "A", "CHAU" };
        string randomWord;
        string hideWord;
        public Word(){
            this.randomWord = this.GetWordRandom();
            this.hideWord = this.CreateHideWord();
        }
        public void GenerateWordRandom(){
            randomWord = this.GetWordRandom();
            hideWord = this.CreateHideWord();
        }
        public string GetWordRandom()
        {
            Random rnd = new Random();
            int randIndex = rnd.Next(words.Count);
            string random = words[randIndex];
            return random;
        }
        internal bool CheckWin()
        {
            foreach (char letter in hideWord)
            {
                if (letter == '_')
                {
                    return false;
                }
            }
            return true;
        }
        public string CreateHideWord()
        {
            string hideWord = randomWord.Replace(randomWord, new string('_', randomWord.Length));
            return hideWord;
        }
        public bool CheckChar(char letterEntered)
        {
            foreach (char letter in randomWord)
            {
                if (char.ToUpper(letterEntered) == char.ToUpper(letter))
                {
                    return true;
                }
            }
            return false;
        }
        public void UpdateResultingWord(char letterEntered)
        {
            int idx = 0;
            foreach (char letter in randomWord)
            {
                if (letter == letterEntered)
                {
                    hideWord = hideWord.Substring(0, idx) + letterEntered + hideWord.Substring(idx + 1);
                }
                idx++;
            }
        }
        public void DrawResultingWord()
        {
            Console.Clear();
            Console.WriteLine("La siguiente es la palabra oculta a adivinar:");
            foreach (char letter in hideWord)
            {
                Console.Write(" " + letter + " ");
            }
            Console.WriteLine("");
        }
    }
}
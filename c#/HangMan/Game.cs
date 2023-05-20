using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HangMan
{
    public class Game
    {
        private readonly string word;
        public string Word { get { return word; } }
        private string guess;
        public string Guess { get { return guess; } }
        private readonly List<char> availableLetters = new ();
        public List<char> AvailableLetters { get { return availableLetters; } }
        private int lives;
        public int Lives
        {
            get { return lives; }
        }

        public Game()
        {
            this.lives = 6;
            for (int i = 65; i <= 80; i++)
                availableLetters.Add((char)i);
            this.word = "hangman";
            for(int i = 0; i < this.word.Length; i++)
                this.guess += "_";
        }
        public Game(string word)
        {
            this.lives = 6;
            for (int i = 65; i <= 90; i++)
                this.availableLetters.Add((char)i);
            this.word = word;
            for (int i = 0; i < this.word.Length; i++)
                this.guess += "_";
        }

        public void Draw()
        {
            //Write guessed letters
            Console.Write("\n\nHasło:\n");
            foreach (char c in this.guess)
                Console.Write($"{c} ");

            //Write available letters
            Console.Write("\n\nDostępne znaki:\n");
            foreach (char c in this.availableLetters)
                Console.Write($"{c} ");
        }
        public bool CheckLetter(char letter)
        {
            if (this.word is null)
            {
                throw new ArgumentNullException(null, nameof(word));
            }
            return this.word.Contains(Char.ToLower(letter));
        }
        public bool CheckCanBeUsed(char letter)
        {
            if (!this.availableLetters.Contains(Char.ToUpper(letter)))
            {
                Console.Write("\n\nError2001: Znak nie rozpoznany");
                Thread.Sleep(2000);
                return false;
            }
            return true;
        }
        public void ShowGuessed(char letter)
        {
            if(this.word.Contains(Char.ToLower(letter)))
                for (int i = 0; i < this.word.Length; i++)
                    if (this.word[i] == Char.ToLower(letter))
                    {
                        this.guess = this.guess.Remove(i, 1);
                        this.guess = this.guess.Insert(i, Char.ToUpper(letter).ToString());
                    }
        }
        public void RemoveLetter(char letter)
        {
            if(this.availableLetters.Contains(Char.ToUpper(letter)))
                this.availableLetters.Remove(Char.ToUpper(letter));
        }
        public void RemoveLife()
        {
            this.lives--;
        }
        public bool CheckIfWin()
        {
            return !this.guess.Contains("_");
        }
    }
}

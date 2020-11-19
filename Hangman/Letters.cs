using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Letters
    {
        public List<char> letters = new List<char>();
        public List<char> not_in_word = new List<char>();
        public List<char> in_word = new List<char>();
        private char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper().ToCharArray();

        public Letters()
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                letters.Add(alphabet[i]);

            }
        }
        public void removeLetter(char letter)
        {

            letters.Remove(letter);
                     

        }
        public void printLetters()
        {

            letters.ForEach(Console.Write);
        }

        public void printNiw()
        {
            not_in_word.ForEach(Console.Write);
        }
    }
}

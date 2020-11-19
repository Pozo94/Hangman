using System;
using System.Collections.Generic;
using System.Text;

namespace Hangman
{
    class Word
    {
        private char[] capital;
        private char[] country;
        private char[] ans;

        public char[] Ans { get => ans; set => ans = value; }
        public char[] Country { get => country; set => country = value; }
        public char[] Capital { get => capital; set => capital = value; }

        public Word(char[] country, char[] capital)
        {
            this.Capital = capital;
           
            this.Country = country;
            Ans = new char[this.Capital.Length];
            for (int i = 0; i < this.Capital.Length; i++)
            {
                

               if (Capital[i].Equals(' ')) { Ans[i] = ' ';}
               else { Ans[i] = '_'; }

            }
        }
        public bool checkWord(String ans)
        {


            if (correctAnswer(ans.ToCharArray(),Capital))
            {
                Ans = Capital;
                return true;


            }

            return false;
        }
        public bool checkLetter(char x)
        {
            bool contain = false;



            for (int i = 0; i < Capital.Length; i++)
            {
                if (x == Capital[i])
                {
                    Ans[i] = Capital[i];
                    contain = true;

                }

            }
            return contain;

        }
        public bool correctAnswer(char[] ans,char[] capital)
        {
            for(int i = 0; i < capital.Length; i++)
            {
                if (!(ans[i] == capital[i]))
                {
                    return false;
                }
                
            }
            return true;
        }

    }
}

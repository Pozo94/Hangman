using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Hangman
{
    class IOHandler
    {
        private List<String> scores = new List<String>();
        private List<String> capitals = new List<String>();
        private String country;
        private String capital;

        public string Country { get => country; set => country = value; }
        public string Capital { get => capital; set => capital = value; }

        public void Load()
        {
            using (StreamReader sr = File.OpenText(@"C:\Users\Jacek\C# Projects\repos\Hangman\Hangman\countries_and_capitals.txt"))
        {
            string s;
            while ((s = sr.ReadLine()) != null)
            {
                    capitals.Add(s);
            }
        }

        }
        public async void Save(String name, int count, String time)

        {
            
            String result = name + " | " + getCurrentTime() + " | " + time + " | " + count + " | " + capital;
            scores.Add(result);
            SortByScore();
            if (scores.Capacity <= 10)
            {

                if (!File.Exists(@"C:\Users\Jacek\C# Projects\repos\Hangman\Hangman\Scores.txt"))
                {
                   
                    // Create a file to write to.
                    using (StreamWriter sw = new StreamWriter(@"C:\Users\Jacek\C# Projects\repos\Hangman\Hangman\Scores.txt"))
                    {
                         sw.WriteLine(result);
                    }

                }
                else
                {
                    using (StreamWriter sw = File.AppendText(@"C:\Users\Jacek\C# Projects\repos\Hangman\Hangman\Scores.txt"))
                    {
                       sw.WriteLine(result);
                    }
                }
            }
            else
            {
                
                SortByScore();
                using (StreamWriter sw = new StreamWriter(@"C:\Users\Jacek\C# Projects\repos\Hangman\Hangman\Scores.txt"))
                {
                    for(int i=0;i<10;i++)
                    {
                        sw.WriteLine(scores[i]);
                    }
                }

            }
            
        }

        public void drawCountry()
        {

            Random rnd = new Random();
            int i=rnd.Next(183);

            String[] words = capitals[i].Split(" | ");
           
            Country = words[0].ToUpper().Trim();
            Capital = words[1].ToUpper().Trim();

        }
        public String getCurrentTime()
        {
            DateTime date = DateTime.Now;


            return date.ToString();
        }
        private void SortByScore()
        {
            scores.Sort(delegate (String s1, String s2) {
                String score1 = s1.Split(" | ")[2];
                String score2 = s2.Split(" | ")[2];
                if (score1.CompareTo(score2) > 0)
                    return 1;
                if (score2.CompareTo(score1) > 0)
                    return -1;
                return 0;
            });
        }
        public void PrintScores()   
        {
            Console.WriteLine(scores.Count);
            if (scores.Count < 10)
            {
            for (int i = 0; i < scores.Count; i++)
                        {
                            
                            Console.WriteLine((i + 1) + ". " + scores[i]);
                        }
            }else
            {
                for (int i = 0; i < 10; i++)
                {
                    
                    Console.WriteLine((i + 1) + ". " + scores[i]);
                }

            }
            
        }
        public void LoadScores()
        {
            
            using (StreamReader sr = File.OpenText(@"C:\Users\Jacek\C# Projects\repos\Hangman\Hangman\Scores.txt"))
            {
                string s;
                
                while ((s = sr.ReadLine()) != null)
                {
                    
                    scores.Add(s);
                    
                }

            }
            
  
        }
    }

}



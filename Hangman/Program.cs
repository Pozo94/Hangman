using System;
using System.Diagnostics;

namespace Hangman
{
    class Program
    {
        public static Stopwatch stopWatch;
        public static int LIFES;
        public static Letters letters;
        public static IOHandler io;
        public static char[] country;
        public static char[] capital;
        public static Word word;
        public static bool loop = true;
        public static int counter;
       
        public static long stop;
        static void Main(string[] args)
        {
            
               String x;
                newGame();
                while (loop)
                {
                    displayGame();
                    Console.WriteLine("Choose type of answer:");
                    Console.WriteLine("1.Letter");
                    Console.WriteLine("2.Word");

                    x = Console.ReadLine();
                    Console.WriteLine(x);
                
                    switch (x)
                    {
                        case "1":
                            Console.WriteLine("Type letter:");
                            String letter = Console.ReadLine();
                            guesLetter(letter);
                            displayGame();


                            break;
                        case "2":
                            Console.WriteLine("Type capital:");
                            String capital = Console.ReadLine();
                            guesWord(capital);

                            break;
                        default:
                         Console.WriteLine("nedziaa");
                            break;


                    }
                    wonOrLose();

                }



            }
            public static void newGame()  {
                LIFES = 5;
                counter = 0;
                io= new IOHandler();
                stopWatch = new Stopwatch();
                stopWatch.Start();
                io.Load();
                io.LoadScores();    
                io.drawCountry();
                letters = new Letters();
                capital = io.Capital.ToCharArray();
                country = io.Country.ToCharArray();
                word = new Word(country, capital);
                
                

            }
     

            public static void guesLetter(String letter)
            {
                char[] w = letter.ToUpper().ToCharArray();
                if (word.checkLetter(w[0]))
                {
                    letters.in_word.Add(w[0]);
                    letters.removeLetter(w[0]);
                    counter++;
                }
                else
                {
                    letters.not_in_word.Add(w[0]);
                    letters.removeLetter(w[0]);
                    LIFES--;
                    counter++;
                }

            }
            public static void guesWord(String ans)
            {
                if (word.checkWord(ans.ToUpper()))
                {

                }
                else
                {
                    LIFES = LIFES - 2;
                }
            }

            public static void wonOrLose()  {
                if (LIFES <= 0)
                {
                     Console.WriteLine("You Lost!");


                }

                else if (word.correctAnswer(word.Ans,word.Capital))
                {
                    
                    Console.WriteLine("You Won!");
                    
                    stopWatch.Stop();
                    String cTime = stopWatch.Elapsed.ToString();
                    Console.WriteLine("You guessed the capital after " + counter + " letters. It took you " + cTime +
                            " seconds");

                    Console.WriteLine("Enter your nickname: ");

                    String name = Console.ReadLine();
                    io.Save(name, counter, cTime);
                    
                    io.PrintScores();
                    

                }
                 
                if (LIFES == 0 || word.correctAnswer(word.Ans,word.Capital))
                {
                
                Console.WriteLine("Play again?(y/n)");
                
                
                String x = Console.ReadLine();
                    if (x.Equals("y"))
                    {
                        newGame();

                    }
                    else if (x.Equals("n"))
                    {
                        loop = false;

                    }
                }
            }
             


             public static void displayGame() {

                Console.Clear();
            
            if (LIFES == 0)
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("**************            *************************");
                    Console.WriteLine("************** ********** *************************");
                    Console.WriteLine("************** *********   ************************");
                    Console.WriteLine("************** ********* * ************************");
                    Console.WriteLine("************** ******** * * ***********************");
                    Console.WriteLine("************** ******* ** ** **********************");
                    Console.WriteLine("************** ****** *** *** *********************");
                    Console.WriteLine("************** ********* * ************************");
                    Console.WriteLine("************** ******** *** ***********************");
                    Console.WriteLine("************** ******** *** ***********************");
                    Console.WriteLine("************* * ******* *** ***********************");
                    Console.WriteLine("************ *** **********************************");
                    Console.WriteLine("*********** ***** *********************************");
                    Console.WriteLine("***************************************************");
                }
                else if (LIFES == 1)
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("**************            *************************");
                    Console.WriteLine("************** ********** *************************");
                    Console.WriteLine("************** *********   ************************");
                    Console.WriteLine("************** ********* * ************************");
                    Console.WriteLine("************** ******** * * ***********************");
                    Console.WriteLine("************** ******* ** ** **********************");
                    Console.WriteLine("************** ****** *** *** *********************");
                    Console.WriteLine("************** ********* **************************");
                    Console.WriteLine("************** ******** ***************************");
                    Console.WriteLine("************** ******** ***************************");
                    Console.WriteLine("************* * ******* ***************************");
                    Console.WriteLine("************ *** **********************************");
                    Console.WriteLine("*********** ***** *********************************");
                    Console.WriteLine("***************************************************");
                }
                else if (LIFES == 2)
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("**************            *************************");
                    Console.WriteLine("************** ********** *************************");
                    Console.WriteLine("************** *********   ************************");
                    Console.WriteLine("************** ********* * ************************");
                    Console.WriteLine("************** ******** * * ***********************");
                    Console.WriteLine("************** ******* ** ** **********************");
                    Console.WriteLine("************** ****** *** *** *********************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************* * ***********************************");
                    Console.WriteLine("************ *** **********************************");
                    Console.WriteLine("*********** ***** *********************************");
                    Console.WriteLine("***************************************************");
                }
                else if (LIFES == 3)
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("**************            *************************");
                    Console.WriteLine("************** ********** *************************");
                    Console.WriteLine("************** *********   ************************");
                    Console.WriteLine("************** ********* * ************************");
                    Console.WriteLine("************** ******** *** ***********************");
                    Console.WriteLine("************** ******* ***** **********************");
                    Console.WriteLine("************** ****** ******* *********************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************* * ***********************************");
                    Console.WriteLine("************ *** **********************************");
                    Console.WriteLine("*********** ***** *********************************");
                    Console.WriteLine("***************************************************");
                }
                else if (LIFES == 4)
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("**************            *************************");
                    Console.WriteLine("************** ********** *************************");
                    Console.WriteLine("************** *********   ************************");
                    Console.WriteLine("************** ********* * ************************");
                    Console.WriteLine("************** ************ ***********************");
                    Console.WriteLine("************** ************* **********************");
                    Console.WriteLine("************** ************** *********************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************* * ***********************************");
                    Console.WriteLine("************ *** **********************************");
                    Console.WriteLine("*********** ***** *********************************");
                    Console.WriteLine("***************************************************");
                }
                else if (LIFES == 5)
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("**************            *************************");
                    Console.WriteLine("************** ********** *************************");
                    Console.WriteLine("************** *********   ************************");
                    Console.WriteLine("************** *********   ************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************* * ***********************************");
                    Console.WriteLine("************ *** **********************************");
                    Console.WriteLine("*********** ***** *********************************");
                    Console.WriteLine("***************************************************");
                }
                else if (LIFES == 6)
                {
                    Console.WriteLine("***************************************************");
                    Console.WriteLine("**************            *************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************** ************************************");
                    Console.WriteLine("************* * ***********************************");
                    Console.WriteLine("************ *** **********************************");
                    Console.WriteLine("*********** ***** *********************************");
                    Console.WriteLine("***************************************************");
                }
                Console.WriteLine("Lifes left: " + LIFES);
                Console.WriteLine(word.Ans);
            if (LIFES <= 2)
            {
                Console.Write("The capital of ");
                Console.WriteLine(word.Country);
            }
                Console.WriteLine("");
                Console.WriteLine("Available letters:");
                letters.printLetters();
                Console.WriteLine();
                Console.WriteLine("Not in word:");
                letters.printNiw();
                Console.WriteLine();



            }
        }
    }




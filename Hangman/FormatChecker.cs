//using System;
//using System.Collections.Generic;
//using System.Text;

//namespace Hangman
//{
//    public class FormatChecker
//    {
//        public string strInput = string.Empty;
//        int intInput = 0;
//        public bool correctFormat;

//        public FormatChecker()
//        {

//        }

//        public int StringToInt()
//        {
//            correctFormat = false;
//            this.intInput = 0;
//            do
//            {
//                try
//                {
//                    intInput = int.Parse(Console.ReadLine());
//                    correctFormat = true;
//                }
//                catch (FormatException)
//                {
//                    Console.Write("Wrong format. Please try again: ");
//                }
//                catch (OverflowException)
//                {
//                    Console.Write("Too big number. Try again: ");
//                }
//            } while (!correctFormat);

//            return intInput;
//        }

        
//        public int StringToInt(int start, int end)
//        {
//            correctFormat = false;
//            this.intInput = 0;
//            do
//            {
//                try
//                {
//                    intInput = int.Parse(Console.ReadLine());
//                    correctFormat = true;
//                }
//                catch (FormatException)
//                {
//                    Console.Write("Wrong format. Please try again: ");
//                }
//                catch (OverflowException)
//                {
//                    Console.Write("Too big number. Try again: ");
//                }
//                if(intInput < start || intInput > end)
//                {
//                    Console.Write("The option is not available. Try again: ");
//                }


//            } while (correctFormat == false || intInput < start || intInput > end);

//            return intInput;
//        }

//        public string CheckString()
//        {

//            correctFormat = false;
//            strInput = string.Empty;

//            do
//            {
//                try
//                {
//                    strInput = Console.ReadLine();
//                    correctFormat = true;
//                }
//                catch (FormatException)
//                {
//                    Console.Write("Invalid format. Try again: ");
//                }
//                catch (OverflowException)
//                {
//                    Console.Write("Input too big. Try again: ");
//                }
//                catch (ArgumentNullException) {

//                    Console.Write("No input. Try again: ");
//                }

//            } while (!correctFormat);

//            return strInput;
//        }

//    }
//}

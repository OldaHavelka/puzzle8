using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace puzzle8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Welcome to puzzle8 solver.\nPlease input 9 numbers from left to right, from top to bottom.\nInstead of blank, please use number 0.\nNumbers: ");


            string startingNumber = GetStartingNumberFromUser();
            if (!IsSolvable(startingNumber)){
                Console.WriteLine("Your input is unsolvable.");
            }
            else
            {
                Console.WriteLine("Your input is solvable but the person who wrote this code is too lazy to implement a solution to your problem.");
            }




            Console.WriteLine("To end this program, please press Enter.");
            Console.ReadLine(); //Since this program runs in a console I want users to be able to end their program after they've done their things.
        }

        private static string GetStartingNumberFromUser() { //This method gets the starting position of puzzle8. Output is guaranteed to be correct but not solvable.
            do  //Repeatedly asks the user for input until user inputs a correct input.
            {
                string uncheckedStartingNumber = Console.ReadLine();
                if (uncheckedStartingNumber.Length == 9) {
                    bool missingNumberDetected = false;
                    for (int i = 0; i < 9; i++) {  //Checking if the user input contains every number from the range of 0 to 8.
                        if (!uncheckedStartingNumber.Contains(i.ToString())) {
                            missingNumberDetected = true;
                            break;
                        }
                    }
                    if (!missingNumberDetected) {
                        return uncheckedStartingNumber;  //String contains every number needed and is proper length. It is a correct input!
                    }
                    else
                    {
                        Console.WriteLine("Your input contains a duplicate number or a non-number.");
                    }
                }
                else
                {
                    Console.WriteLine("Your input has incorrect length.");
                }
                Console.Write("Your input has to contain exactly 9 unique numbers ranging from 0 to 8.\nPlease input your numbers again: ");  //If we get here, the user has not inputed a correct input. Therefore we'll kindly ask the user to input another number.
            } while (true);
        }

        private static bool IsSolvable(string startingNumber){  //This method takes a starting number and checks if it's solvable.
            int numberReversals = 0;
            startingNumber=startingNumber.Replace("0", ""); //In order to make the process easier, we'll just remove the blank space. Now it won't have to calculate with blank space's position.
            for (int i = 0; i < 6; i++) {  //We will check only the first 7 numbers since it's pointless to compare the last number with itself.
                char toCompare = startingNumber[i];
                for (int ii = i; ii < 7; ii++) { //Here we choose what number to use to compare.
                    if (toCompare > startingNumber[ii]) {
                        numberReversals++;
                    }
                }
            }
            return numberReversals % 2 == 0 ? true : false;
        }
    }
}

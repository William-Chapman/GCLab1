using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1App
{
    class Program
    {
        static void Main()
        {
            //Create variables for this function
            int first = 0;
            int second = 0;
            bool win = false;
            bool attempt = false;
            string repeat = "";
            //Ask user to input numbers with the same amount of digits
            Console.WriteLine("Please enter the first number.");
            attempt = Int32.TryParse(Console.ReadLine(), out first);
            if (attempt == false)
            {
                //If the user entered anything but a number let them know and restart
                Console.WriteLine("What you entered was not a number. Please try again.");
                Main();
            }
            Console.WriteLine("Please enter the second number. Be sure it has the same number of digits as the first.");
            attempt = Int32.TryParse(Console.ReadLine(), out second);
            if (attempt == false)
            {
                //If the user entered anything but a number let them know and restart
                Console.WriteLine("What you entered was not a number. Please try again.");
                Main();
            }
            //Check if the numbers the user entered have the same amount of digits
            if (Math.Floor(Math.Log10(first) + 1) == Math.Floor(Math.Log10(second) + 1))
            {
                //Take the two numbers from the user and run the split function
                win = SpComp(first, second);
            }
            else
            {
                //If the amount of digits did not match, tell the user and restart
                Console.WriteLine("The amount of digits in the numbers did not match. Please try again.");
                Main();
            }
            //Take value returned from compare and print it within a fluff message
            Console.WriteLine("The result of this test has been found to be " + win);
            //Ask the user if they would like to run the program again
            Console.WriteLine("Would you like to try different numbers? (Yes/No)");
            repeat = Console.ReadLine();
            if (repeat == "Yes")
            {
                //If they reply yes
                Main();
            }
            else if (repeat == "No")
            {
                //If they reply no
                Console.WriteLine("Thank you for using this program.");
                System.Environment.Exit(1);
            }
            else
            {
                //If they reply something the program can't understand
                Console.WriteLine("I could not understand that response. Thank you for using this program.");
                System.Environment.Exit(1);
            }
        }

        //Split and compare function (return type bool)
        static bool SpComp(int first, int second)
        {
            //Create variables for function
            int workingVar1 = 0;
            int workingVar2 = 0;
            int compSum = 0;

            while (first > 0)
            {
                //Take the last digit off of the first number
                workingVar1 = first % 10;
                first = first / 10;
                if (second > 0)
                {
                    //Take the last digit off of the second number
                    workingVar2 = second % 10;
                    second = second / 10;
                }
                if (compSum == 0) //If the Compare Sum does not have a value yet
                //This if statement will only run on the first set of digits so there is no need to compare them to the compSum
                {
                    //Make it equal to the digit taken from the first number plus the digit taken from the second
                    compSum = workingVar1 + workingVar2;
                    //Console.WriteLine(workingVar1 + "+" + workingVar2 + "=" + (workingVar1 + workingVar2));
                }
                else
                {
                    //Console.WriteLine(workingVar1 + "+" + workingVar2 + "=" + (workingVar1 + workingVar2));
                    if (compSum != workingVar1 + workingVar2)
                    {
                        //Compare the sum of digits to the compSum we got from the first set of digits
                        //If they are not equal the function will return false
                        //If they are equal it will repeat the function until we have no more numbers left to compare
                        return false;
                    }
                }
            }
            //If after the function has gone through all of the digits and not found a set that is false, the function will return true
            return true;
        }

    }
}

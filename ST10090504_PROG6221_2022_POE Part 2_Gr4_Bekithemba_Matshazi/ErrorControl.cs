using System;

namespace Assignment
{
    class ErrorControl
    {            
        //method to control blank user input as well ass reject string input
        public double Control(string input)
        {
            double value;

            if(string.IsNullOrEmpty(input)  || Double.TryParse(input, out double num)== false)
            {
                value = 0;
            }
            else
            {
                value = Convert.ToDouble(input);
            }
            return value;
        }

        //method to prompt user for in homeloan information and not allow the to leave a question blank
        public double ControlPrompt(string input)
        {
            while(string.IsNullOrEmpty(input)  || Double.TryParse(input, out double num)== false)
            {
                Console.Write("***Value can not be blank  or a letter***");
                Console.Write("  Please enter a interger value: ");
                input = Console.ReadLine();
            }
            return Convert.ToDouble(input);
        }

        //method to ensure a correct input is given to the chaice between home buy and home rent
        public double ControlChoice(string input)
        {

            while(string.IsNullOrEmpty(input)  || Double.TryParse(input, out double num)== false)
            {
                Console.Write("***Value can not be blank  or a letter***");
                Console.Write("  Please enter a interger value: ");
                input = Console.ReadLine();
            }
            
            double choice = Convert.ToDouble(input); 

            while(!(choice == 1 || choice == 2))
            {
                Console.Write("Please choose ***between*** the following: (1)-Renting a house or (2)-Buy a house:  ");
                choice = Convert.ToDouble(Console.ReadLine());
            }
            return choice;
        }

        public double SingleControlChoice(string input)
        {

            while(string.IsNullOrEmpty(input)  || Double.TryParse(input, out double num)== false)
            {
                Console.Write("***Value can not be blank  or a letter***");
                Console.Write("  Please enter  (1)-yes or any other key for no");
                input = Console.ReadLine();
            }
            
            double choice = Convert.ToDouble(input); 

            return choice;
        }
    }
}
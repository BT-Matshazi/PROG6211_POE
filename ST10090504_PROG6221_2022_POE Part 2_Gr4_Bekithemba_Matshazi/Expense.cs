using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public delegate void Del(string message);

namespace Assignment
{
    class Expense : HomeLoan
    {
        // Create a dictionary with string key and Int16 value pair  
        public static Dictionary<string, double> ExpenseList = new Dictionary<string, double>(); 

        ErrorControl c = new ErrorControl();


        //Array to store expenses
        static double[] expenseArray = new double[6];
        static double housingCost;

        //method to prompt user for expenses and store in array
        public void Expeses()
        {
            Console.WriteLine("\n*********************************");
            Console.WriteLine("Please enter your expenses");
            Console.WriteLine("**********************************");
            Console.Write("Please enter your groceries: R");
            ExpenseList.Add("Groceries", c.Control(Console.ReadLine()));

            Console.Write("Please enter your water bill: R");
            ExpenseList.Add("Water Bill", c.Control(Console.ReadLine()));

            Console.Write("Please enter your electric bill: R");
            ExpenseList.Add("Electric Bill", c.Control(Console.ReadLine()));

            Console.Write("Please enter your travel cost (including fuel costs): R");
            ExpenseList.Add("Travel Cost", c.Control(Console.ReadLine()));

            Console.Write("Please enter your cellphone bill: R");
            ExpenseList.Add("Cellphone Bill", c.Control(Console.ReadLine()));

            Console.Write("If there are any other costs please enter the total: R");
            ExpenseList.Add("Other Costs", c.Control(Console.ReadLine()));
            Console.WriteLine("**********************************\n");
        }

        //method to prompt user for housing situation (rent/buy)
        public override void Home(double income)
        {
            Console.Write("\nPlease choose between the following: (1)-Renting a house or (2)-Buy a house:  ");
            double choice = c.ControlChoice(Console.ReadLine());
            Console.WriteLine("****************************************************");
            //rent path
            if (choice == 1)
            {
                Console.Write("Please enter the monthly rental cost: R");
                double houseRent = Convert.ToDouble(Console.ReadLine());
                housingCost = houseRent;
                ExpenseList.Add("Rent", housingCost);
                Console.Write("****************************************************\n\n");
            }

            //homeloan path
            if (choice == 2)
            {
                Console.Write("Please enter the full house cost: R");
                double housePrice = c.ControlPrompt(Console.ReadLine());
                Console.Write("Please enter the house deposit: R");
                double houseDeposit = c.ControlPrompt(Console.ReadLine());
                Console.Write("Please enter the intrest rate (Please do NOT add the '%' symbol): ");
                double intrestRate = c.ControlPrompt(Console.ReadLine()) / 100;
                Console.Write("Please enter the number of months for repayment between 240 and 360: ");
                double repaymentPeriod = c.ControlPrompt(Console.ReadLine());

                while(repaymentPeriod < 240 || repaymentPeriod > 360 )
                {
                    Console.Write("Please enter the number of months for repayment ***between*** 240 and 360: ");
                    repaymentPeriod = c.ControlPrompt(Console.ReadLine());
                }
                Console.Write("****************************************************");

                //Home loan calculation
                double P = housePrice - houseDeposit;
                double i = intrestRate;
                double n = repaymentPeriod / 12;

                double A = P * (1 + (i * n));
                double loanRepayment = A / repaymentPeriod;
                housingCost = loanRepayment;
                ExpenseList.Add("Home Loan Repayment", Math.Round(housingCost, 2));

                //Loan likely hood calculation
                if (loanRepayment > ((income) / 3))
                {
                    Console.WriteLine("\nYour likely would of getting approved is LOW.");
                }
                else
                {
                    Console.WriteLine("\nYour likely would of getting approved is HIGH.");
                }
            }
        }

        //method to calculate user income after all deductions
        public void netIncome(double income, double tax)
        {
            double sum = 0;

            //loop to sum up the expenses array
            foreach (var x in ExpenseList)
            {
                sum += x.Value;
            }

            double netIncome = (income - (tax + housingCost + sum));

            Console.WriteLine("\n****************************************************");
            Console.WriteLine("REPORT");
            Console.WriteLine("****************************************************");
            Console.WriteLine("Your income is R{0}", Math.Round(income, 2));
            Console.WriteLine("Your tax deductions is R{0}", Math.Round(tax, 2));
            Console.WriteLine("Your home cost is R{0} per month", Math.Round(housingCost, 2));
            Console.WriteLine("Your total expenses are R{0}", Math.Round(sum, 2));
            Console.WriteLine("Your income after deductions is R{0}", Math.Round(netIncome, 2));
            Console.WriteLine("****************************************************");
        }

        public void SortDictionary()  
        {    
            // Sorted by Value  
            Console.WriteLine("\nExpenses Sorted By Value \n ===============================");  

            foreach (KeyValuePair<string, double> expense in ExpenseList.OrderByDescending(key => key.Value))  
            {  
                Console.WriteLine("Expense: {0} --- Cost: R{1}", expense.Key, expense.Value);  
            }  
            Console.WriteLine("=================================================\n"); 
        } 
        public void ExpenseSum(double income)  
        {       
            // Instantiate the delegate.
            Del handler = DelegateMethod;
            double sum = 0;
             //add the values
            foreach (var x in ExpenseList)
            {
                sum += x.Value;
            }
            if(sum  > income )
            {
                handler("\nbYour Expenses have exceeded 75% of your income");
            }
        }

        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }
    }
}

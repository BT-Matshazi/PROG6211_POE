using System;

namespace Assignment
{
    
    class Expense : HomeLoan
    {
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
            expenseArray[0] = c.Control(Console.ReadLine());

            Console.Write("Please enter your water bill: R");
            expenseArray[1] = c.Control(Console.ReadLine());

            Console.Write("Please enter your electric bill: R");
            expenseArray[2] = c.Control(Console.ReadLine());

            Console.Write("Please enter your travel cost (including fuel costs): R");
            expenseArray[3] = c.Control(Console.ReadLine());

            Console.Write("Please enter your cellphone bill: R");
            expenseArray[4] = c.Control(Console.ReadLine());

            Console.Write("If there are any other costs please enter the total: R");
            expenseArray[5] = c.Control(Console.ReadLine());
            Console.WriteLine("**********************************\n");

        }

        //method to prompt user for housing situation (rent/buy)
        public override void Home(double income)
        {
            
            Console.Write("Please choose between the following: (1)-Renting a house or (2)-Buy a house:  ");
            double choice = c.ControlChoice(Console.ReadLine());

            //rent path
            if (choice == 1)
            {
                Console.Write("Please enter the monthly rental cost: R");
                double houseRent = Convert.ToDouble(Console.ReadLine());
                housingCost = houseRent;
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

                //Home loan calculation
                double P = housePrice - houseDeposit;
                double i = intrestRate;
                double n = repaymentPeriod / 12;

                double A = P * (1 + (i * n));
                double loanRepayment = A / repaymentPeriod;
                housingCost = loanRepayment;

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
            for (int i = 0; i < expenseArray.Length; i++)
            {
                sum += expenseArray[i];
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
    }
}

using System;

namespace Assignment
{
    class Income
    {
        ErrorControl c = new ErrorControl();

        //private varable deductions
        private double grossIncome;
        private double tax;

        //method to prompt user for income information
        public void UserIncome()
        {
            Console.Write("Please enter your gross income before deductions: R");
            this.grossIncome = c.Control(Console.ReadLine());

            Console.Write("Please enter your tax deductions: R");
            this.tax = c.Control(Console.ReadLine());
        }   

        //returning statements to be accessible in other classes
        public double getTax()
        {
            return tax;
        } 
        public double getGrossIncome()
        {
            return grossIncome;
        }
    }
}

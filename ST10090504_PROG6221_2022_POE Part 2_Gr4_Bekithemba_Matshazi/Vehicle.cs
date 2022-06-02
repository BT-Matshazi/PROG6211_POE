using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace Assignment
{
    class Vehicle : Expense
    {
        public void VehiclePurchase()
        {
            ErrorControl c = new ErrorControl();
            Console.Write("\nWill you be buying a vehicle (1)-yes or any other key for no:  ");
            double choice = Int32.Parse(Console.ReadLine());

            //rent path
            if(choice == 1)
            {
                Console.WriteLine("Please enter the vehicle information");
                Console.WriteLine("*********************************************");

                Console.Write("Please enter the Model and make: ");
                string vehicletModelandMake = Console.ReadLine();

                Console.Write("Please enter the full Purchase price: R");
                double vehiclePurchasePrice = c.ControlPrompt(Console.ReadLine());

                Console.Write("Please enter the vehicle deposit: R");
                double vehicleDeposit = c.ControlPrompt(Console.ReadLine());

                Console.Write("Please enter the interest rate (Please do NOT add the '%' symbol): ");
                double vehicleIntrestRate = c.ControlPrompt(Console.ReadLine()) / 100;
            
                Console.Write("Please enter the vehicle estimated insurance premium: R");
                double vehicleInsurancePremium = c.ControlPrompt(Console.ReadLine());
                Console.Write("*********************************************\n");

                double carpayment = Math.Round(vehicleInsurancePremium  + (vehiclePurchasePrice - vehicleDeposit) * ((vehicleIntrestRate/12) * Math.Pow((1 + (vehicleIntrestRate/12)), 60))/(Math.Pow((1 + (vehicleIntrestRate/12)), 60) - 1), 2);
                ExpenseList.Add("Vehicle Monthly Payments", carpayment);
            }
        }
    }
}
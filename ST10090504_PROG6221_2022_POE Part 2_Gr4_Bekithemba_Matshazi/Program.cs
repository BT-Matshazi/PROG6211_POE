using System;

namespace Assignment
{
    class Program
    {            
        static void Main(string[] args)
        {            
            //income class access modifier 
            Income a = new Income();

            //calling method in Income class
            a.UserIncome();
            
            //Expense class access modifier
            Expense b = new Expense();

            //calling methods in Expense class
            b.Expeses();
            b.Home(a.getGrossIncome());

            //Vehicle class access modifier
            Vehicle c = new Vehicle();

            //Vehicle methods in Expense class
            c.VehiclePurchase();

            //calling methods in Expense class
            b.SortDictionary();
            b.ExpenseSum(a.getGrossIncome());
            b.netIncome(a.getGrossIncome(), a.getTax());
        }
    }
}

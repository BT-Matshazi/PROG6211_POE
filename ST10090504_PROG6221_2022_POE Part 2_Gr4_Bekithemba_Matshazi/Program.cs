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
            b.netIncome(a.getGrossIncome(), a.getTax());


            Vehicle c = new Vehicle();

            c.VehiclePurchase();

            
            b.SortDictionary();
            b.ExpenseSum(a.getGrossIncome());
        }
    }
}

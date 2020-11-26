using System;
using System.Collections.Generic;

namespace Assignment_1
{
    class Program
    {
        private static void Main(string[] args)
        {
            const decimal rate = 0.0625m;
            const decimal vat = 0.075m;
            const decimal cot = 0.02m;
            var accountTypes = new List<string>() { "savings", "current", "dom", "student", "child", "dollar" };

            Console.WriteLine("...Welcome to Amy's Bank...");
            Console.WriteLine("Please enter the account type");
            var accountFor = Console.ReadLine().ToLower();
            while (string.IsNullOrEmpty(accountFor) || !accountTypes.Contains(accountFor))
            {
                Console.WriteLine("These are our valid account types");
                foreach (var accounts in accountTypes)
                {
                    //Console.Write($"{accounts.ToUpper()}, ");
                    Console.WriteLine(accounts.ToUpper());
                }

                Console.WriteLine("Please choose an account type from the list");
                accountFor = Console.ReadLine().ToLower();
            }

            Console.WriteLine("Please enter the principal amount you are investing");
            decimal principal = decimal.Parse(Console.ReadLine());

            //Compound interest
            Console.WriteLine("Please enter the duration of time the principal should be compounded in 12 months");
            int duration = int.Parse(Console.ReadLine()) ;
            Console.WriteLine("Please enter the time in years");
            int time = int.Parse(Console.ReadLine());

            decimal interest;
            switch (accountFor)
            {
                case "savings":
                    interest = principal * (decimal)Math.Pow((double)(1 + (rate / duration)), time * duration);
                    decimal afterVAT = interest * vat;
                    decimal finalAmount = interest - afterVAT;
                    Console.WriteLine($"The total interest accruing to you after {time} years if you run a savings account will be {finalAmount:C}");
                    //Console.WriteLine($"Amount after vat {finalAmount:C}");
                    break;

                case "student":
                    interest = principal * (decimal)Math.Pow((double)(1 + (rate / duration)), time * duration);
                    decimal afterVAC = interest * vat * cot;
                    finalAmount = interest - afterVAC;
                    Console.WriteLine($"The total interest accruing to you after {time} years if you run a student account will be {finalAmount:C}");
                    // Console.WriteLine($"The total interest accruing to you if you run a student account will be {interest:C}");
                    break;

                case "dom":
                    interest = principal * (decimal)Math.Pow((double)(1 + (rate / duration)), time * duration) * cot;
                    decimal afterCOT = interest * cot;
                    finalAmount = interest - afterCOT;
                    //Console.WriteLine($"The total interest accruing to you if you run a dom account will be {finalAmount:C}");
                    Console.WriteLine($"The total interest you will get after {time} years if you run a dom account will be {finalAmount:C}");
                    break;

                case "current":
                    interest = principal * (decimal)Math.Pow((double)(1 + (rate / duration)), time * duration) * cot;
                    afterCOT = interest * cot;
                    finalAmount = interest - afterCOT;
                    //Console.WriteLine($"The total interest accruing to you if you run a savings account will be {finalAmount:C}");
                    Console.WriteLine($"The total interest you will get after {time} years if you run a current account will be {finalAmount:C}");
                    break;

                case "child":
                    interest = principal * (decimal)Math.Pow((double)(1 + (rate / duration)), time * duration);
                    Console.WriteLine($"The total interest your child will get after {time} years if you are running a children savings account will be {interest:C}");
                    break;

                case "dollar":
                    Console.WriteLine("Please enter the  multiplier");
                    var multiplier = decimal.Parse(Console.ReadLine());
                    interest = principal * (decimal)Math.Pow((double)(1 + (rate / duration)), time * duration) * multiplier;
                    Console.WriteLine(interest);
                    break;

                default:
                    Console.WriteLine("Please input a valid account type");
                    break;
            }

            //Just Compound Interest in 1 year or 12 months
            //compound interest is calculated thus: A = P(1 + rate/n)^time the principal amount is compounded in a year * duration in years 
            //var interest = (decimal)(principal * (decimal) Math.Pow((double)(1 + (rate / duration)), (double)(duration * time / 12)));
            // Console.WriteLine($"The final sum you will get at the end of the duration is " + interest);

            //Console.WriteLine($"The final sum you will get at the end of {duration} years is {interest:C}.");
            Console.WriteLine("Thank you for banking with us :)");
            Console.ReadLine();
        }       
    }
}
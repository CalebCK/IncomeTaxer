using System;

namespace IncomeTaxCalculator
{
    class Program
    {
        private static bool isMonthly;
        private static decimal basicSalary;
        private static decimal totalTaxableAllowances;
        
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Welcome to the GRA Income Tax Calculator based on the Income Tax(Amendment) Act, 2019 (ACT 1007).");
                Console.WriteLine($"©{DateTime.Now.Year} Caleb's.\n");

                StartApp();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}. Contact Author: Caleb");
            }
        }

        public static void StartApp()
        {
            ReadMonthlyResponse();
            ReadBasicSalary();
            ReadTaxableAllowances();

            Taxer.CalculateNetIncome(basicSalary + totalTaxableAllowances, isMonthly);

            bool retry = Retry();

            if (retry)
                StartApp();
        }

        public static void ReadMonthlyResponse()
        {
            Console.WriteLine("Enter (M) to calculate your monthly income tax or (A) to calculate your annual income tax (M/A):");
            var input = Console.ReadLine().Trim();

            if(string.IsNullOrEmpty(input) || (!input.ToLower().Equals("m") && !input.ToLower().Equals("a")))
            {
                Console.WriteLine("Invalid input! 'M' or 'A' is required.\n");
                ReadMonthlyResponse();
            }
            else
            {
                isMonthly = input.ToLower().Equals("m");
            }
        }

        public static void ReadBasicSalary()
        {
            Console.WriteLine("\nEnter your basic salary:");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || !decimal.TryParse(input, out basicSalary))
            {
                Console.WriteLine("Invalid input!.\n");
                ReadBasicSalary();
            }
        }

        private static void ReadTaxableAllowances()
        {
            Console.WriteLine("\nEnter total taxable allowances:");
            var input = Console.ReadLine();

            if (string.IsNullOrEmpty(input) || !decimal.TryParse(input, out totalTaxableAllowances))
            {
                Console.WriteLine("Invalid input!.\n");
                ReadTaxableAllowances();
            }
        }

        public static bool Retry()
        {
            Console.WriteLine("\nEnter (Y) to retry or (N) to terminate this console (Y/N):");
            var input = Console.ReadLine().Trim();

            if (string.IsNullOrEmpty(input) || (!input.ToLower().Equals("y") && !input.ToLower().Equals("n")))
            {
                Console.WriteLine("Invalid input! 'Y' or 'N' is required.\n");
                ReadMonthlyResponse();
            }

            if (input.ToLower().Equals("y"))
                Console.Clear();


            Console.WriteLine("Welcome to the GRA Income Tax Calculator based on the Income Tax(Amendment) Act, 2019 (ACT 1007).");
            Console.WriteLine($"©{DateTime.Now.Year} Caleb's.\n");
            return input.ToLower().Equals("y");
        }
    }
}

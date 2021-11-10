using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IncomeTaxCalculator
{
    public static class Taxer
    {
        /// <summary>
        /// Calculate net income based on taxable gross salary
        /// </summary>
        /// <param name="taxableGross"></param>
        /// <returns></returns>
        public static void CalculateNetIncome(decimal taxableGross, bool isMonth)
        {
            Console.WriteLine($"\nGROSS INCOME: {taxableGross}");
            var totalIncomeTax = GetTax(taxableGross, isMonth);
            Console.WriteLine($"INCOME TAX: {totalIncomeTax}");
            Console.WriteLine($"NET INCOME: {taxableGross - totalIncomeTax}");
        }

        private static decimal GetTax(decimal gross, bool isMonthly)
        {
            decimal tax = 0;
            decimal grossRemainder = gross;

            TaxModel taxModel = new TaxModel();
            var modelBuild = isMonthly ? taxModel.BuildMonthTaxModel(gross) : taxModel.BuildAnnualTaxModel(gross);

            if(modelBuild.Count == 1)
                return Math.Round((((decimal)modelBuild.Single().TaxRate / 100) * grossRemainder), 2);

            Extension.PrintLine();
            Extension.PrintRow("DESCRIPTION", "AMOUNT", "PERCENTAGE", "TAX");
            Extension.PrintLine();
            foreach (var m in modelBuild)
            {
                decimal currentTax = 0;

                if (grossRemainder <= m.NextAmount)
                {
                    tax += currentTax = Math.Round((((decimal)m.TaxRate / 100) * grossRemainder), 2);

                    Extension.PrintRow($"Remainder", $"{grossRemainder}", $"{m.TaxRate}", $"{currentTax}");
                    break;
                }
                tax += currentTax = Math.Round((((decimal)m.TaxRate / 100) * m.NextAmount), 2);
                grossRemainder -= m.NextAmount;

                string description = modelBuild.First() == m ? "First" : "Next";
                Extension.PrintRow($"{description}", $"{m.NextAmount}", $"{m.TaxRate}", $"{currentTax}");
            }
            Extension.PrintLine();

            return tax;
        }
    }
}

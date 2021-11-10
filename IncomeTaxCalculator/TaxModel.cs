using System;
using System.Collections.Generic;
using System.Text;

namespace IncomeTaxCalculator
{
    class TaxModel
    {
        public decimal NextAmount { get; set; }
        public double TaxRate { get; set; }

        public List<TaxModel> BuildMonthTaxModel(decimal grossFigure)
        {
            List<TaxModel> taxModelList = new List<TaxModel>();

            decimal[] nextAmounts = { 319.00m, 100.00m, 120.00m, 3000.00m, 16461.00m };
            double[] nextAmountRates = { 0, 5, 10, 17.5, 25 };

            if (grossFigure >= 20000)
            {
                nextAmounts = new decimal[1] { 20000.00m };
                nextAmountRates = new double[1] { 30 };
            }

            for (int i = 0; i < nextAmounts.Length; i++)
            {
                TaxModel taxModel = new TaxModel
                {
                    NextAmount = nextAmounts[i],
                    TaxRate = nextAmountRates[i]
                };

                taxModelList.Add(taxModel);
            }

            return taxModelList;
        }

        public List<TaxModel> BuildAnnualTaxModel(decimal grossFigure)
        {
            List<TaxModel> taxModelList = new List<TaxModel>();
            decimal[] nextAmounts = { 3828.00m, 1200.00m, 1440.00m, 36000.00m, 197532.00m };
            double[] nextAmountRates = { 0, 5, 10, 17.5, 25 };

            if (grossFigure >= 240000)
            {
                nextAmounts = new decimal[1] { 240000.00m };
                nextAmountRates = new double[1] { 30 };
            }

            for (int i = 0; i < nextAmounts.Length; i++)
            {
                TaxModel taxModel = new TaxModel
                {
                    NextAmount = nextAmounts[i],
                    TaxRate = nextAmountRates[i]
                };

                taxModelList.Add(taxModel);
            }

            return taxModelList;
        }
    }
}

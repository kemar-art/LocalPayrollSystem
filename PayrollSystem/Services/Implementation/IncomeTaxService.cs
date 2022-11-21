using Microsoft.Build.Framework;
using PayrollSystem.Services.Contracts;
using static System.Net.Mime.MediaTypeNames;

namespace PayrollSystem.Services.Implementation
{
    public class IncomeTaxService : IIncomTaxService
    {
        private readonly INationalInsuranceSchemeTaxService _nisTaxService;
        private decimal itax;
        private decimal periodThreshold;
        private decimal sixMilPAYERate;
        private decimal itax2;
        private decimal itaxTotal;
        private decimal itaxTotal2;
        private decimal itaxSum;
        private decimal itaxSum2;
        private decimal nisTax;
        private decimal itaxRate;

        private decimal test; 
        private decimal test2;
        private decimal test3;


        public IncomeTaxService(INationalInsuranceSchemeTaxService nisTaxService)
        {
            _nisTaxService = nisTaxService;
        }

        public decimal IncomeTaxContibution(decimal totalAmount)
        {
            nisTax = _nisTaxService.NISTaxContibution(totalAmount) * 12;
            periodThreshold = 1500096.00m;
            itaxRate = 0.25m;
            if ((totalAmount * 12) > 6000000.00m)
            {
                //Basic tax rate
                periodThreshold = 1500096.00m;
                sixMilPAYERate = 0.3m;
                //Income tax ( Taxable emoluments up to JMD 6 million per annum less the annual tax-free threshold at 30%)
                itax = ((((totalAmount * 12 / 12 * 9) + (totalAmount * 12 / 12 * 3)) - 12000000.00m - periodThreshold) * itaxRate +
                       (((totalAmount * 12 / 12 * 9) + (totalAmount * 12 / 12 * 3)) - 6000000.00m - nisTax) * sixMilPAYERate) / 12;
            }
            else if ((totalAmount * 12) <= 1500096.00m)
            {
                //Tax free rate
                itaxRate = .0m;
                //Calculation for income tax when your annual salary is equal or less than the threshold
                itax = ((totalAmount * 12 / 12 * 9) + (totalAmount * 12 / 12 * 3)) * itaxRate;
            }
            else if ((totalAmount * 12) > 1500096.00m && (totalAmount * 12) <= 6000000)
            {
                //Basic tax rate
                itaxRate = 0.25m;
                //Income tax ( Taxable emoluments up to JMD 6 million per annum less the annual tax-free threshold at 25%)
                itax = ((totalAmount * 12 / 12 * 9) + (totalAmount * 12 / 12 * 3) - nisTax - periodThreshold) * itaxRate / 12;
            }

            return itax;
        }
    }
}


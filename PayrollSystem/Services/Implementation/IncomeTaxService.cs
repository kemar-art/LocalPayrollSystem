using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class IncomeTaxService : IIncomTaxService
    {
        private readonly INationalInsuranceSchemeTaxService _nisTaxService;
        private decimal itax;
        private decimal itax2;
        private decimal itax3;
        private decimal itax4;
        private decimal itax5;
        private decimal itax6;
        private decimal itaxTotal;
        private decimal itaxTotal2;
        private decimal itaxSum;
        private decimal nisTax;
        private decimal itaxSum2;
        private decimal itaxSum3;
        private decimal itaxRate;
        private decimal itaxRate2;

        public IncomeTaxService(INationalInsuranceSchemeTaxService nisTaxService)
        {
            _nisTaxService = nisTaxService;
        }

        public decimal IncomeTaxContibution(decimal totalAmount)
        {
            if (totalAmount <= 125008)
            {
                //Tax free rate
                itaxRate = .0m;
                itax = totalAmount * itaxRate;
            }
            else if (totalAmount > 125008 && totalAmount <= 500000)
            {
                //Basic tax rate
                itaxRate = 0.25m;
                //Income tax ( Taxable emoluments up to JMD 6 million per annum less the annual tax-free threshold at 25%)
                //itax = ((totalAmount - 1500096) * itaxRate)
                nisTax = _nisTaxService.NISTaxContibution(totalAmount) * 12;
                itaxSum = ((totalAmount * 12) - nisTax);
                itaxSum2 = 125008 * 12;
                itaxTotal = itaxSum - itaxSum2;
                itax2 = itaxTotal * itaxRate;
                itax = itax2 / 12;
            }
            else if (totalAmount > 500000)
            {
                //Higher tax rate
                /*itaxRate = 0.30m;
                itaxRate2 = 0.25m;
                //Income tax ( Taxable emoluments in excess of JMD 6 million per annum 30% )
                nisTax = _nisTaxService.NISTaxContibution(totalAmount);
                itaxSum = totalAmount * 3;
               // itaxSum3 = 
                itaxSum2 = totalAmount * 9;
                itaxTotal = itaxSum - itaxSum2;
                itax2 = itaxTotal * itaxRate;
                itax = itax2 / 12;*/
            }

            return itax;
        }
    }
}


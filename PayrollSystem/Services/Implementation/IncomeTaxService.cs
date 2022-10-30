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
        private decimal itaxTotal;
        private decimal itaxTotal2;
        private decimal itaxSum;
        private decimal itaxSum2;
        private decimal itaxSum3;
        private decimal nisTax;
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
                itaxSum = (totalAmount * 12) - nisTax;
                itaxSum2 = 125008 * 12;
                itaxTotal = itaxSum - itaxSum2;
                itax2 = itaxTotal * itaxRate;
                itax = itax2 / 12;
            }
            else if (totalAmount > 500000)
            {
                itaxRate = 0.25m;
                itaxRate2 = 0.3m;
                nisTax = _nisTaxService.NISTaxContibution(totalAmount) * 12;
                itaxSum = (totalAmount * 12) - nisTax;
                itaxSum2 = 125008 * 12;
                itaxTotal = itaxSum - itaxSum2;
                itax2 = itaxTotal * itaxRate;
                itax3 = itax2 / 12;

                itaxSum3 = (itaxSum + itaxSum2) - 6000000;
                itaxTotal2 = itaxSum3 * itaxRate2;
                itax4 = itaxTotal2 / 12;
                itax = itax3 + itax4;
            }

            return itax;
        }
    }
}


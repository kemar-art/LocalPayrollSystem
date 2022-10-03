using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class IncomeTaxService : IIncomTaxService
    {
        private decimal tax;
        private decimal taxRate;

        public decimal IncomeTaxContibution(decimal totalAmount)
        {
            if (totalAmount <= 1042)
            {
                //Tax Free Rate
                taxRate = .0m;
                tax = totalAmount * taxRate;
            }
            else if (totalAmount > 1042 && totalAmount <= 3125)
            {
                //Basic tax rate
                taxRate = .20m;
                //Income tax
                tax = (1042 * .0m) + ((totalAmount - 1042) * taxRate);
            }
            else if (totalAmount > 3125 && totalAmount <= 12500)
            {
                //Higher tax rate
                taxRate = .40m;
                //Income tax
                tax = (1042 * .0m) + ((3125 - 1042) * .20m) + ((totalAmount - 3125) * taxRate);
            }
            else if (totalAmount > 12500)
            {
                //Additional tax Rate
                taxRate = .45m;
                //Income tax
                tax = (1042 * .0m) + ((3125 - 1042) * .20m) +
                    ((12500 - 3125) * .40m) + ((totalAmount - 12500) * taxRate);
            }
            return tax;

            /*if (totalAmount <= 1500096)
            {
                //Tax free rate
                itaxRate = .0m;
                itax = totalAmount * itaxRate;
            }
            else if (totalAmount > 1500096 && totalAmount <= 6000000)
            {
                //Basic tax rate
                itaxRate = 0.25m;
                //Income tax ( Taxable emoluments up to JMD 6 million per annum less the annual tax-free threshold at 25%)
                //itax = ((totalAmount - 1500096) * itaxRate);
                itax = (1500096 * .0m) + ((totalAmount - 1500096) * itaxRate);
            }
            else if (totalAmount > 6000000)
            {
                //Higher tax rate
                itaxRate = 0.30m;
                //Income tax ( Taxable emoluments in excess of JMD 6 million per annum 30% )
                itax = (1500096 * .0m) + ((1500096 - 1042) * .25m) + ((totalAmount - 1500096) * itaxRate);
            }

            return itax;*/
        }
    }
}

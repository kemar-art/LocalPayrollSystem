using MessagePack;
using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class NationalInsuranceSchemeService : INationalInsuranceSchemeTaxService
    {
        private decimal nisRate;
        private decimal nis;
        private decimal nisSum;
        private decimal nisSum2;
        private decimal nisSubTotal;
        private decimal nisSubTotal2;
        public decimal NISTaxContibution(decimal totalAmount)
        {
            nisRate = 3m;
            nis = (nisRate / 100) * totalAmount;
            return nis;
        }
    }
}

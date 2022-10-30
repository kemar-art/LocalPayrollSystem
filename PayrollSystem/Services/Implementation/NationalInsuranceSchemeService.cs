using MessagePack;
using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class NationalInsuranceSchemeService : INationalInsuranceSchemeTaxService
    {
        private decimal nisRate;
        private decimal nis;
        public decimal NISTaxContibution(decimal totalAmount)
        {
            nisRate = 3m;
            nis = (nisRate / 100) * totalAmount;
            return nis;
        }
    }
}

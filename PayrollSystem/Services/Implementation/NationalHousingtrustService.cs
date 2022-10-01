using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class NationalHousingtrustService : INationalHousingtrustTaxService
    {
        private decimal nhtRate;
        private decimal nht;
        public decimal NHTTaxContribution(decimal totalAmount)
        {
            nhtRate = 0.02m;
            nht = totalAmount * nhtRate;
            return nht;
        }
    }
}

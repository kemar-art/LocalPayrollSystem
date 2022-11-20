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
            if ((totalAmount * 12) > 6000000)
            {
                            //Salary for January to March                   April to December 
                nht = ((totalAmount * 3 * nhtRate) + (totalAmount * 9 * nhtRate)) / 12;
            }
            else if ((totalAmount * 12) <= 1500096.00m)
            {
                nht = totalAmount * nhtRate;
            }
            else if ((totalAmount * 12) > 1500096.00m && (totalAmount * 12) <= 6000000)
            {
                nht = totalAmount * nhtRate;
            }
            
            return nht;
        }
    }
}

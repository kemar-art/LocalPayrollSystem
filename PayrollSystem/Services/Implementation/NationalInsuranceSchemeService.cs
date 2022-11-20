using MessagePack;
using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class NationalInsuranceSchemeService : INationalInsuranceSchemeTaxService
    {
        private decimal nisRate;
        private decimal nis;
        private decimal januaryToMarch;
        private decimal aprilToDecember;

        public decimal AprilToDecember()
        {
            aprilToDecember = 2250000 * nisRate; ;
            return aprilToDecember;
        }

        public decimal JanuaryToMarch()
        {
            januaryToMarch = 750000 * nisRate;
            return januaryToMarch;
        }

        public decimal NISTaxContibution(decimal totalAmount)
        {
            nisRate = 0.03m;
            if ((totalAmount * 12) > 6000000)
            {
                //Salary for January to March
                januaryToMarch = 750000 * nisRate;
                //April to December 
                aprilToDecember = 2250000 * nisRate;

                nis = (januaryToMarch + aprilToDecember) / 12;
            }
            else if ((totalAmount * 12) <= 1500096.00m)
            {
                nis = nis = nisRate * totalAmount;
            }
            else if ((totalAmount * 12) > 1500096.00m && (totalAmount * 12) <= 6000000)
            {
                nis = nis = nisRate * totalAmount;
            }
            
            return nis;
        }
    }
}

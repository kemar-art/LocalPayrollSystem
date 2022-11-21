using PayrollSystem.Services.Contracts;
using PayrollSystem.Services.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayrollSystem.Services
{
    internal class EducationTaxService : IEducationTaxService
    {
        //private decimal nis;
        private decimal eduRate;
        private decimal edu;
        private readonly INationalInsuranceSchemeTaxService _nisTaxService;

        public EducationTaxService(INationalInsuranceSchemeTaxService nisTaxService)
        {
            _nisTaxService = nisTaxService;
        }

        public decimal EDUTaxContibution(decimal totalAmount)
        {
            eduRate = 0.0225m;
            if ((totalAmount * 12) > 6000000)
            {
                                 //Salary for January to March                    
                edu = (((totalAmount * 3) - _nisTaxService.JanuaryToMarch()) * eduRate +
                             //April to December
                      ((totalAmount * 9) - _nisTaxService.AprilToDecember()) * eduRate) /12;
            }
            else if ((totalAmount * 12) <= 1500096.00m)
            {
                edu = (totalAmount - _nisTaxService.NISTaxContibution(totalAmount)) * eduRate;
            }
            else if ((totalAmount * 12) > 1500096.00m && (totalAmount * 12) <= 6000000)
            {
                edu = (totalAmount - _nisTaxService.NISTaxContibution(totalAmount)) * eduRate;
            }
            
            return edu;
        }
    }
}

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
            edu = ((totalAmount - _nisTaxService.NISTaxContibution(totalAmount)) * eduRate);
            return edu;
        }
    }
}

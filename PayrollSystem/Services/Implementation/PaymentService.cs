using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollSystem.Data;
using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class PaymentService : IPaymentService
    {
        private readonly ApplicationDbContext _context;
        private decimal cantractualEarnings;
        private decimal overtimeHours;

        public PaymentService(ApplicationDbContext context)
        {
            _context = context;
        }
        public decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate)
        {
            if (hoursWorked < contractualHours)
            {
                cantractualEarnings = hoursWorked * hourlyRate;
            }
            else
            {
                cantractualEarnings = contractualHours * hourlyRate;
            }

            return cantractualEarnings;
        }

        public async Task CreateAsync(PaymentRecord paymentRecord)
        {
           await _context.PaymentRecords.AddAsync(paymentRecord);
           await _context.SaveChangesAsync();
        }

        public IEnumerable<PaymentRecord> GetAll()
        {
            return _context.PaymentRecords.OrderBy(p => p.EmployeeId);
        }

        public IEnumerable<SelectListItem> GetAllTaxYear()
        {
            var allTaxYear = _context.TaxYears.Select(taxYears => new SelectListItem
            {
                Text = taxYears.YearOfTax,
                Value = taxYears.Id.ToString()
            });

            return allTaxYear;
        }

        public PaymentRecord GetById(int id)
        {
            return _context.PaymentRecords.Where(pay => pay.Id == id).FirstOrDefault();
        }

        public TaxYear GetTaxYearById(int id)
        {
            return _context.TaxYears.Where(year => year.Id == id).FirstOrDefault();
        }

        public decimal NetPay(decimal totalEarnings, decimal totalDeuction)
        {
            return totalEarnings - totalDeuction;
        }

        public decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours)
        {
            return overtimeRate * overtimeHours;
        }

        public decimal OvertimeHours(decimal hoursWorked, decimal contractualHours)
        {
            if (hoursWorked <= contractualHours)
            {
                overtimeHours = 0.00m;
            }
            else if (hoursWorked > contractualHours)
            {
                overtimeHours = hoursWorked - contractualHours;
            }

            return overtimeHours;
        }

        public decimal OvertimeRate(decimal hourlyRate)
        {
            return hourlyRate * 1.5m;
        }

        public decimal TotalDeduction(decimal nisTax, decimal nhtTax, decimal eduTax, decimal incomTax /*decimal loan*/)
        {
            return nisTax + nhtTax + eduTax + incomTax /*+ loan*/;
        }

        public decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings)
        {
            return overtimeEarnings + contractualEarnings;
        }
    }
}

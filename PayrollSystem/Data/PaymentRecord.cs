using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Data
{
    public class PaymentRecord
    {
        public int Id { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }

        public string? FullName { get; set; }
        public string? PayMonth { get; set; }
        public DateTime PayDate { get; set; }

        [ForeignKey("TaxYearId")]
        public TaxYear? TaxYear { get; set; }
        public int TaxYearId { get; set; }

        public string? TaxCode { get; set; }
        public decimal HourlyRate { get; set; }
        public decimal HoursWorked { get; set; }
        public decimal ContractualHours { get; set; }
        public decimal OvertimeHours { get; set; }
        public decimal HolidayHours { get; set; }
        public decimal ContractualEarnings { get; set; }
        public decimal HolidayEarning { get; set; }
        public decimal OvertimeEarnings { get; set; }
        // National Insurance Scheme 
        public decimal NISTax { get; set; }
        public decimal NHTTax { get; set; }
        public decimal EDUTax { get; set; }
        public decimal IncomTax { get; set; }
        public decimal? Loan { get; set; }
        public decimal TotalEarnings { get; set; }
        public decimal TotalDeduction { get; set; }
        public decimal NetSalary { get; set; }
        public decimal AnnualGrossSalary { get; set; }
        public decimal AnnualIncomTax { get; set; }
        public decimal AnnualNISTax { get; set; }
        public decimal AnnualEDUTax { get; set; }
        public decimal AnnualNHTTas { get; set; }
        public decimal AnnualNetSalary { get; set; }
    }
}

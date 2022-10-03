using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PayrollSystem.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Data
{
    public class PaymentRecord
    {
        public int Id { get; set; }

        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
        

        [MaxLength(100)]
        public string? FullName { get; set; }

        public string? PayMonth { get; set; }

        public string? NISNum { get; set; }

        public string? TRNNum { get; set; }

        //[Display(Name = "Payroll Schedule")]
        public string? PayrollSchedule { get; set; }

        public DateTime PayDate { get; set; }

        [ForeignKey("TaxYear")]
        public int TaxYearId { get; set; }
        public TaxYear? TaxYear { get; set; }

        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal HoursWorked { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal ContractualHours { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal OvertimeHours { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal HolidayHours { get; set; }

        [Column(TypeName = "money")]
        public decimal ContractualEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal HolidayEarning { get; set; }

        [Column(TypeName = "money")]
        public decimal OvertimeEarnings { get; set; }

        // National Insurance Scheme 
        [Column(TypeName = "money")]
        public decimal NISTax { get; set; }

        [Column(TypeName = "money")]
        public decimal NHTTax { get; set; }

        [Column(TypeName = "money")]
        public decimal EDUTax { get; set; }

        [Column(TypeName = "money")]
        public decimal IncomTax { get; set; }

        [Column(TypeName = "money")]
        public decimal? Loan { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalEarnings { get; set; }

        [Column(TypeName = "money")]
        public decimal TotalDeduction { get; set; }

        [Column(TypeName = "money")]
        public decimal NetSalary { get; set; }

        [Column(TypeName = "money")]
        public decimal AnnualGrossSalary { get; set; }

        [Column(TypeName = "money")]
        public decimal AnnualIncomTax { get; set; }

        [Column(TypeName = "money")]
        public decimal AnnualNISTax { get; set; }

        [Column(TypeName = "money")]
        public decimal AnnualEDUTax { get; set; }

        [Column(TypeName = "money")]
        public decimal AnnualNHTTas { get; set; }

        [Column(TypeName = "money")]
        public decimal AnnualNetSalary { get; set; }
    }
}

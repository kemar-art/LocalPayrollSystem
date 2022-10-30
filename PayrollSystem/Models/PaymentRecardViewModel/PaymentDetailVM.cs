using PayrollSystem.Data;
using System.ComponentModel.DataAnnotations;

namespace PayrollSystem.Models.PaymentRecardViewModel
{
    public class PaymentDetailVM
    {
        public int Id { get; set; }

        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }

        [Display(Name = "Employee")]
        public string? FullName { get; set; }

        [Display(Name = "Pay Month")]
        public string? PayMonth { get; set; }

        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }

        public string? PayrollSystem { get; set; }

        public string? Year { get; set; }

        [Display(Name = "Tax YearId")]
        public TaxYear? TaxYear { get; set; }
        public int TaxYearId { get; set; }

        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Hours Worked")]
        public decimal HoursWorked { get; set; }

        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { get; set; }

        [Display(Name = "Overtime Hours")]
        public decimal OvertimeHours { get; set; }

        [Display(Name = "Overtime Rate")]
        public decimal OvertimeRate { get; set; }

        [Display(Name = "Holiday Hours")]
        public decimal HolidayHours { get; set; }

        [Display(Name = "Contractual Earnings")]
        public decimal ContractualEarnings { get; set; }

        public decimal HolidayEarning { get; set; }

        [Display(Name = "Overtime Earnings")]
        public decimal OvertimeEarnings { get; set; }

        public string? NISNum { get; set; }
        public string? TRNNum { get; set; }

        // National Insurance Scheme Tax
        public decimal NISTax { get; set; }
        public decimal NHTTax { get; set; }
        public decimal EDUTax { get; set; }
        public decimal IncomTax { get; set; }
        public decimal? Loan { get; set; }

        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings { get; set; }

        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction { get; set; }

        [Display(Name = "Net Salary")]
        public decimal NetSalary { get; set; }

        [Display(Name = "Annual Gross Salary")]
        public decimal AnnualGrossSalary { get; set; }

        [Display(Name = "Annual Incom Tax")]
        public decimal AnnualIncomTax { get; set; }

        [Display(Name = "Annual National Insurance Scheme Tax")]
        public decimal AnnualNISTax { get; set; }

        [Display(Name = "Annual Education Tax")]
        public decimal AnnualEDUTax { get; set; }

        [Display(Name = "Annual National Housing Trust Tax")]
        public decimal AnnualNHTTas { get; set; }

        [Display(Name = "Annual Net Salary")]
        public decimal AnnualNetSalary { get; set; }
    }
}

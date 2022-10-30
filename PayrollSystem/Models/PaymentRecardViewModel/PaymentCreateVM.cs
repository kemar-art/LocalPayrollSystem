using PayrollSystem.Data;
using PayrollSystem.Data.Enums;
using PayrollSystem.Models.EmployeeViewModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Models.PaymentRecardViewModel
{
    public class PaymentCreateVM
    {
        public int Id { get; set; }

        [Display(Name = "Full Name")]
        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }

        public string? FullName { get; set; }

        [Display(Name = "Pay Month")]
        public string PayMonth { get; set; } = DateTime.Today.Month.ToString();

        [DataType(DataType.Date), Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; } = DateTime.Now;

        [Display(Name = "Tax Year")]
        public int TaxYearId { get; set; }
        public TaxYear? TaxYear { get; set; }

        //public string? TaxCode { get; set; }
        [Display(Name = "Hourly Rate")]
        public decimal HourlyRate { get; set; }

        [Display(Name = "Hours Worked")]
        public decimal HoursWorked { get; set; }

        [Display(Name = "Contractual Hours")]
        public decimal ContractualHours { get; set; }

        public string? NISNum { get; set; }
        public string? TRNNum { get; set; }

        //[Display(Name = "Overtime Hours")]
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

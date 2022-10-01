using PayrollSystem.Data;
using PayrollSystem.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PayrollSystem.Models.PaymentRecardViewModel
{
    public class PaymentCreateVM
    {
        public int Id { get; set; }

        public Employee? Employee { get; set; }
        public int EmployeeId { get; set; }

        [Display(Name = "Name")]
        public string? FullName { get; set; }

        [Display(Name = "Month")]
        public string? PayMonth { get; set; }

        [Display(Name = "Pay Date")]
        public DateTime PayDate { get; set; }

        //[Display(Name = "Pay Date")]
        //public PayrollSchedule PayrollSchedule { get; set; }

        public int TaxYearId { get; set; }
        public string? Year { get; set; }

        [Display(Name = "Total Earnings")]
        public decimal TotalEarnings { get; set; }

        [Display(Name = "Total Deduction")]
        public decimal TotalDeduction { get; set; }

        [Display(Name = "Net Pay")]
        public decimal NetSalary { get; set; }
    }
}

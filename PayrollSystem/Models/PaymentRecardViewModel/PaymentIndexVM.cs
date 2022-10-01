using PayrollSystem.Data;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PayrollSystem.Models.PaymentRecardViewModel
{
    public class PaymentIndexVM
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

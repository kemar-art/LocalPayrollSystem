using PayrollSystem.Data.Enums;
using PayrollSystem.Data;

namespace PayrollSystem.Models.EmployeeViewModel
{
    public class EmployeeDetailVM
    {
        public int Id { get; set; }
        public string? EmployeeNo { get; set; }
        public string? FullName { get; set; }
        public string? Address { get; set; }
        public string? Parish { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateTerminated { get; set; }
        public string? Designation { get; set; }
        public string? Email { get; set; }
        public string? TaxRegistrationNumber { get; set; }
        public string? NationalInsuranceScheme { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
        public PayrollSchedule PayrollSchedule { get; set; }
        public Loan Loan { get; set; }
    }
}

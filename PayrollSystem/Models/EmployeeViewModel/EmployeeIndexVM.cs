using PayrollSystem.Data.Enums;

namespace PayrollSystem.Models.EmployeeViewModel.EmployeeIndexVM
{
    public class EmployeeIndexVM
    {
        public int Id { get; set; }
        public string? EmployeeNo { get; set; }
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public string? ImageUrl { get; set; }
        public DateTime DateJoined { get; set; }
        public DateTime DateTerminated { get; set; }
        public JobTitle JobTitle { get; set; }
        public string? Address { get; set; }
    }
}

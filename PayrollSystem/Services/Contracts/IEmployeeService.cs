using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollSystem.Data;
using PayrollSystem.Models.EmployeeViewModel;

namespace PayrollSystem.Services.Contracts
{
    public interface IEmployeeService
    {
        Task CreateAsync(Employee enwEmployee);
        Employee GetById(int employeeId);
        Task UpdateAsync(Employee employee);
        Task UpdateAsync(int id);
        Task DeleteAsync(int employeeId);
        /*decimal LoanPayment(int id, decimal totalAmount);*/
        IEnumerable<Employee> GetAll();
        IEnumerable<SelectListItem> GetAllEmployeesForPayroll();
    }
}

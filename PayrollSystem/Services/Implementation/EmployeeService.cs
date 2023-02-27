using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PayrollSystem.Data;
using PayrollSystem.Data.Enums;
using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPaymentService _paymentService;

        public EmployeeService(ApplicationDbContext context, IPaymentService paymentService)
        {
            _context = context;
            _paymentService = paymentService;
        }

        public async Task CreateAsync(Employee enwEmployee)
        {
            await _context.Employees.AddAsync(enwEmployee);
            await _context.SaveChangesAsync();
        }

        public Employee GetById(int employeeId) =>
            _context.Employees.Where(e => e.Id == employeeId).FirstOrDefault();

        public IEnumerable<Employee> GetAll() => _context.Employees;

        public async Task UpdateAsync(Employee employee)
        {
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(int id)
        {
            var employee = GetById(id);
            _context.Update(employee);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int employeeId)
        {
            var employee = GetById(employeeId);
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
        }

        /*public decimal LoanPayment(int id, decimal totalAmount)
        {
            /*var employee = GetById(id);
            if (employee.Loan == Loan.Yes && totalAmount >= _paymentService.NetPay(decimal totalEarnings, decimal totalDeuction))
            {

            }
            throw new NotImplementedException();
        }*/

        public IEnumerable<SelectListItem> GetAllEmployeesForPayroll()
        {
            return GetAll().Select(emp => new SelectListItem()
            {
                Text = emp.FullName,
                Value = emp.Id.ToString()
            });
        }
    }
}

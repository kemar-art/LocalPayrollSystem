using Microsoft.EntityFrameworkCore;
using PayrollSystem.Data;
using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _context;

        public EmployeeService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Employee enwEmployee)
        {
            await _context.Employees.AddAsync(enwEmployee);
            await _context.SaveChangesAsync();
        }

        public Employee GetById(int employeeId) =>
            _context.Employees.Where(e =>e.Id == employeeId).FirstOrDefault();

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

        public decimal Loan(int id, decimal totalAmount)
        {
            throw new NotImplementedException();
        }
    }
}

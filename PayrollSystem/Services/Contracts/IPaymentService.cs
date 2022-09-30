using Microsoft.AspNetCore.Mvc.Rendering;
using PayrollSystem.Data;
using System;

namespace PayrollSystem.Services.Contracts
{
    public interface IPaymentService
    {
        Task CreateAsync(PaymentRecord paymentRecord);
        PaymentRecord GetById(int id);
        IEnumerable<PaymentRecord> GetAll();
        IEnumerable<SelectListItem> GetAllTaxYear();
        decimal OvertimeHours(decimal hoursWorked, decimal contractualHours);
        decimal OvertimeRate(decimal hourlyRate);
        decimal OvertimeEarnings(decimal overtimeRate, decimal overtimeHours);
        decimal ContractualEarnings(decimal contractualHours, decimal hoursWorked, decimal hourlyRate);
        decimal TotalEarnings(decimal overtimeEarnings, decimal contractualEarnings);
        decimal TotalDeduction(decimal nisTax, decimal nhtTax, decimal eduTax, decimal incomTax, decimal loan);
        decimal NetPay(decimal totalEarnings, decimal totalDeuction);
    }
}
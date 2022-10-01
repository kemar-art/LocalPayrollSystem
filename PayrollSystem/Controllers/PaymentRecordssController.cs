using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Data;
using PayrollSystem.Data.Enums;
using PayrollSystem.Models.PaymentRecardViewModel;
using PayrollSystem.Services;
using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Controllers
{
    public class PaymentRecordssController : Controller
    {
        private readonly IPaymentService _paymentService;
        private readonly IEmployeeService _employeeService;
        private readonly IIncomTaxService _taxService;
        private readonly INationalHousingtrustTaxService _nhtTaxService;
        private readonly INationalInsuranceSchemeTaxService _nisTaxService;
        private readonly IEducationTaxService _eduTaxService;
        private decimal overtimeHours;
        private decimal contractualEarnings;
        private decimal overtimeEarnings;
        private decimal totalEarnings;
        private decimal nisTax;
        private decimal eduTax;
        private decimal incomTax;
        private decimal loan;
        private decimal nhtTax;
        private decimal totalDeduction;

        public PaymentRecordssController(IPaymentService paymentService, IEmployeeService employeeService, 
            IIncomTaxService taxService, IEducationTaxService eduTaxService,
            INationalInsuranceSchemeTaxService nisTaxService,
            INationalHousingtrustTaxService nhtTaxService)
        {
            _paymentService = paymentService;
            _employeeService = employeeService;
            _taxService = taxService;
            _nhtTaxService = nhtTaxService;
            _nisTaxService = nisTaxService;
            _eduTaxService = eduTaxService;
        }
        // GET: PaymentRecordssController
        public IActionResult Index()
        {
            var payRecards = _paymentService.GetAll().Select(pay => new PaymentIndexVM
            {
                Id = pay.Id,
                EmployeeId = pay.EmployeeId,
                FullName = pay.FullName,
                PayDate = pay.PayDate,
                PayMonth = pay.PayMonth,
                TaxYearId = pay.TaxYearId,
                Year = _paymentService.GetTaxYearById(pay.TaxYearId).YearOfTax,
                TotalEarnings = pay.TotalEarnings,
                TotalDeduction = pay.TotalDeduction,
                NetSalary = pay.NetSalary,
                Employee = pay.Employee
            });

            return View(payRecards);
        }

        // GET: PaymentRecordssController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentRecordssController/Create
        public IActionResult Create()
        {
            ViewBag.employees = _employeeService.GetAllEmployeesForPayroll();
            ViewBag.taxYears = _paymentService.GetAllTaxYear();
            var model = new PaymentCreateVM();
            return View(model);
        }

        // POST: PaymentRecordssController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(PaymentCreateVM model)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    var payrecard =  new PaymentRecord()
                    {
                        Id = model.Id,
                        EmployeeId = model.EmployeeId,
                        FullName = _employeeService.GetById(model.EmployeeId).FullName,
                        NISNum = _employeeService.GetById(model.EmployeeId).NationalInsuranceScheme,
                        TRNNum = _employeeService.GetById(model.EmployeeId).TaxRegistrationNumber,
                        PayrollSchedule = _employeeService.GetById(model.EmployeeId).PayrollSchedule.ToString(),
                        PayDate = model.PayDate,
                        PayMonth = model.PayMonth,
                        TaxYear = model.TaxYear,
                        HourlyRate = model.HourlyRate,
                        HolidayHours = model.HolidayHours,
                        ContractualHours = model.ContractualHours,
                        OvertimeHours = overtimeHours = _paymentService.OvertimeHours(model.HolidayHours, model.ContractualHours),
                        ContractualEarnings = contractualEarnings =_paymentService.ContractualEarnings(model.ContractualHours, model.HolidayHours, model.HourlyRate),
                        OvertimeEarnings = overtimeEarnings = _paymentService.OvertimeEarnings(_paymentService.OvertimeRate(model.HourlyRate), overtimeHours),
                        TotalEarnings = totalEarnings = _paymentService.TotalEarnings(overtimeEarnings, contractualEarnings),
                        NISTax = nisTax = _nisTaxService.NISTaxContibution(totalEarnings),
                        NHTTax = nhtTax = _nhtTaxService.NHTTaxContribution(totalEarnings),
                        EDUTax = eduTax =_eduTaxService.EDUTaxContibution(totalEarnings),
                        IncomTax = incomTax = _taxService.IncomeTaxContibution(totalEarnings),
                        Loan = loan = _employeeService.LoanPayment(model.EmployeeId, totalEarnings),
                        TotalDeduction = totalDeduction = _paymentService.TotalDeduction(nisTax, nhtTax, eduTax, incomTax, loan),
                        NetSalary = _paymentService.NetPay(totalEarnings, totalDeduction)
                    };

                    await _paymentService.CreateAsync(payrecard);
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }

            ViewBag.employees = _employeeService.GetAllEmployeesForPayroll();
            ViewBag.taxYears = _paymentService.GetAllTaxYear();
            return View();
        }

        // GET: PaymentRecordssController/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentRecordssController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PaymentRecordssController/Delete/5
        public IActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentRecordssController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

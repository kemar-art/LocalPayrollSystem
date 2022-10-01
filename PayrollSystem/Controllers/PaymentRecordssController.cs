using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PayrollSystem.Models.PaymentRecardViewModel;
using PayrollSystem.Services.Contracts;

namespace PayrollSystem.Controllers
{
    public class PaymentRecordssController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentRecordssController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
        // GET: PaymentRecordssController
        public ActionResult Index()
        {
            var payRecards = _paymentService.GetAll().Select(pay => new PaymentCreateVM
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
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PaymentRecordssController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentRecordssController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: PaymentRecordssController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PaymentRecordssController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PaymentRecordssController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
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

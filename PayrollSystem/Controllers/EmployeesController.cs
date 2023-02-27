using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using PayrollSystem.Data;
using PayrollSystem.Models;
using PayrollSystem.Models.EmployeeViewModel.EmployeeIndexVM;
using PayrollSystem.Models.EmployeeViewModel;
using PayrollSystem.Services.Contracts;
using PayrollSystem.Data.Enums;
using PayrollSystem.Services.Implementation;

namespace PayrollSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public EmployeesController(IEmployeeService employeeService, IMapper mapper, IWebHostEnvironment hostingEnvironment)
        {
            _employeeService = employeeService;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
        }

        // GET: Employees
        public IActionResult Index()
        {
            List<EmployeeIndexVM> employees = _employeeService.GetAll().Select(employee => new EmployeeIndexVM
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                ImageUrl = employee.ImageUrl,
                FullName = employee.FullName,
                Gender = employee.Gender,
                JobTitle = employee.JobTitle,
                Address = employee.Address,
                DateJoined = employee.DateJoined,
                DateTerminated = employee.DateTerminated
            }).ToList();
            return View(employees);
        }

        // GET: Employees/Details/5
        public IActionResult Detail(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }
            EmployeeDetailVM model = new EmployeeDetailVM()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FullName = employee.FullName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                PhoneNumber = employee.PhoneNumber,
                DateJoined = employee.DateJoined,
                NationalInsuranceScheme = employee.NationalInsuranceScheme,
                TaxRegistrationNumber = employee.TaxRegistrationNumber,
                PaymentMethod = employee.PaymentMethod,
                PayrollSchedule = (PayrollSchedule)employee.PayrollSchedule,
                Loan = employee.Loan,
                Address = employee.Address,
                Parish = employee.Parish,
                JobTitle = employee.JobTitle,
                DateTerminated = employee.DateTerminated,
                ImageUrl = employee.ImageUrl
            };
            return View(model);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            var model = new EmployeeCreateVM();
            return View(model);
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeCreateVM model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var employee = new Employee
                    {
                        Id = model.Id,
                        EmployeeNo = model.EmployeeNo,
                        FirstName = model.FirstName,
                        MiddleName = model.MiddleName,
                        LastName = model.LastName,
                        FullName = model.FullName,
                        Gender = model.Gender,
                        Email = model.Email,
                        DOB = model.DOB,
                        PhoneNumber = model.PhoneNumber,
                        DateJoined = model.DateJoined,
                        NationalInsuranceScheme = model.NationalInsuranceScheme,
                        TaxRegistrationNumber = model.TaxRegistrationNumber,
                        PaymentMethod = model.PaymentMethod,
                        Loan = model.Loan,
                        PayrollSchedule = model.PayrollSchedule,
                        EmploymentType = model.EmploymentType,
                        JobTitle = model.JobTitle,
                        RateAmount = model.RateAmount,
                        Department = model.Department,
                        Address = model.Address,
                        Parish = model.Parish,
                    };
                    if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                    {
                        var uploadDir = @"images/employees";
                        var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                        var extension = Path.GetExtension(model.ImageUrl.FileName);
                        var webRootPath = _hostingEnvironment.WebRootPath;
                        fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                        var path = Path.Combine(webRootPath, uploadDir, fileName);
                        await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                        employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                    }
                    await _employeeService.CreateAsync(employee);
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception)
                {

                     string? message ="This did now work";
                }
                /*var employee = new Employee
                {
                    Id = model.Id,
                    EmployeeNo = model.EmployeeNo,
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    FullName = model.FullName,
                    Gender = model.Gender,
                    Email = model.Email,
                    DOB = model.DOB,
                    PhoneNumber = model.PhoneNumber,
                    DateJoined = model.DateJoined,
                    NationalInsuranceScheme = model.NationalInsuranceScheme,
                    TaxRegistrationNumber = model.TaxRegistrationNumber,
                    PaymentMethod = model.PaymentMethod,
                    Loan = model.Loan,
                    PayrollSchedule = model.PayrollSchedule,
                    EmploymentType = model.EmploymentType,
                    JobTitle = model.JobTitle,
                    RateAmount = model.RateAmount,
                    Department = model.Department,
                    Address = model.Address,
                    Parish = model.Parish,
                };
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employees";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeService.CreateAsync(employee);
                return RedirectToAction(nameof(Index));*/
            }
            return View(model);
        }

        // GET: Employees/Edit/5
        public IActionResult Edit(int id)
        {
            var employee = _employeeService.GetById(id);
            if (employee == null)
            {
                return NotFound();
            }

            var model = new EmployeeEditVM()
            {
                Id = employee.Id,
                EmployeeNo = employee.EmployeeNo,
                FirstName = employee.FirstName,
                MiddleName = employee.MiddleName,
                LastName = employee.LastName,
                Gender = employee.Gender,
                Email = employee.Email,
                DOB = employee.DOB,
                PhoneNumber = employee.PhoneNumber,
                DateJoined = employee.DateJoined,
                NationalInsuranceScheme = employee.NationalInsuranceScheme,
                TaxRegistrationNumber = employee.TaxRegistrationNumber,
                PaymentMethod = employee.PaymentMethod,
                Loan = employee.Loan,
                PayrollSchedule = (PayrollSchedule)employee.PayrollSchedule,
                EmploymentType = employee.EmploymentType,
                JobTitle = employee.JobTitle,
                RateAmount = (decimal)employee.RateAmount,
                Department = employee.Department,
                Address = employee.Address,
                Parish = employee.Parish,
            };
            return View(model);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditVM model)
        {
            if (ModelState.IsValid)
            {
                var employee = _employeeService.GetById(model.Id);
                if (employee == null)
                {
                    return NotFound();
                }
                employee.EmployeeNo = model.EmployeeNo;
                employee.FirstName = model.FirstName;
                employee.MiddleName = model.MiddleName;
                employee.LastName = model.LastName;
                employee.Gender = model.Gender;
                employee.Email = model.Email;
                employee.DOB = model.DOB;
                employee.PhoneNumber = model.PhoneNumber;
                employee.DateJoined = model.DateJoined;
                employee.DateTerminated = model.DateTerminated;
                employee.NationalInsuranceScheme = model.NationalInsuranceScheme;
                employee.TaxRegistrationNumber = model.TaxRegistrationNumber;
                employee.PaymentMethod = model.PaymentMethod;
                employee.PayrollSchedule = model.PayrollSchedule;
                employee.RateAmount = model.RateAmount;
                employee.Department = model.Department;
                employee.EmploymentType = model.EmploymentType;
                employee.JobTitle = model.JobTitle;
                employee.Loan = model.Loan;
                employee.Address = model.Address;
                employee.Parish = model.Parish;
                employee.JobTitle = model.JobTitle;
                if (model.ImageUrl != null && model.ImageUrl.Length > 0)
                {
                    var uploadDir = @"images/employees";
                    var fileName = Path.GetFileNameWithoutExtension(model.ImageUrl.FileName);
                    var extension = Path.GetExtension(model.ImageUrl.FileName);
                    var webRootPath = _hostingEnvironment.WebRootPath;
                    fileName = DateTime.UtcNow.ToString("yymmssfff") + fileName + extension;
                    var path = Path.Combine(webRootPath, uploadDir, fileName);
                    await model.ImageUrl.CopyToAsync(new FileStream(path, FileMode.Create));
                    employee.ImageUrl = "/" + uploadDir + "/" + fileName;
                }
                await _employeeService.UpdateAsync(employee);
                return RedirectToAction(nameof(Index));

            }
            return View(model);
        }

        // GET: Employees/Delete/5
        public IActionResult Delete(int id)
        {
            var emopployee = _employeeService.GetById(id);
            if (emopployee == null)
            {
                return NotFound();
            }
            var model = new EmployeeDeleteVM()
            {
                Id = emopployee.Id,
                FullName = emopployee.FullName,
                Email = emopployee.Email
            };
            return View(model);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(EmployeeDeleteVM model)
        {
            await _employeeService.DeleteAsync(model.Id);
            return RedirectToAction(nameof(Index));
        }

       /*private bool EmployeeExists(int id)
        {
          return (_context.Employees?.Any(e => e.Id == id)).GetValueOrDefault();
        }*/
    }
}

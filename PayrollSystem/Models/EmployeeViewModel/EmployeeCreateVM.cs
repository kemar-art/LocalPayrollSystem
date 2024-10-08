﻿using PayrollSystem.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace PayrollSystem.Models.EmployeeViewModel
{
    public class EmployeeCreateVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Emloyee Number is required"), RegularExpression(@"^[A-Z]{3,3}[0-9]{7,7}$")]
        public string? EmployeeNo { get; set; }

        [Required(ErrorMessage = "First Name is required"), Display(Name = "First Name"), MaxLength(50)]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required"), Display(Name = "Last Name"), MaxLength(50)]
        public string? LastName { get; set; }

        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Display(Name = "Middle Name")]
        public string? Employment { get; set; }

        public string? FullName { get { return FirstName + (string.IsNullOrEmpty(MiddleName) ? " " : (" " + (char?)MiddleName[0] + ". ").ToUpper()) + LastName; } }

        [Required(ErrorMessage = "Address is required")]
        public string? Address { get; set; }

        [Required(ErrorMessage = "Parish is required")]
        public string? Parish { get; set; }

        [Required, Display(Name = "Contact Number")]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Gender { get; set; }

        [Display(Name = "Photo")]
        public IFormFile? ImageUrl { get; set; }

        [DataType(DataType.Date), Display(Name = ("D.O.B"))]
        public DateTime DOB { get; set; }

        [DataType(DataType.Date), Display(Name = ("Start Date"))]
        public DateTime DateJoined { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Email address is required"), DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Tax Registration Number is required"), Display(Name = "T.R.N")]
        public string? TaxRegistrationNumber { get; set; }

        [Required(ErrorMessage = "National Insurance Scheme Number is required"), Display(Name = "N.I.S")]
        public string? NationalInsuranceScheme { get; set; }

        [Required]
        [Display(Name = ("Payment Method"))]
        public PaymentMethod PaymentMethod { get; set; }

        [Required]
        [Display(Name = ("Payment Schedule"))]
        public PayrollSchedule PayrollSchedule { get; set; }

        public Loan Loan { get; set; }

        [Required]
        [Display(Name = ("Job Title"))]
        public JobTitle JobTitle { get; set; }

        [Required]
        [Display(Name = ("Department"))]
        public Department Department { get; set; }


        [Required]
        [Display(Name = ("Employment Type"))]
        public EmploymentType EmploymentType { get; set; }

        [Required]
        [Display(Name = ("Hourly/Salary Amount"))]
        public decimal RateAmount { get; set; }


    }
}

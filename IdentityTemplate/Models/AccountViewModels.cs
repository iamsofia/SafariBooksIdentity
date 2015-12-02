using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IdentityTemplate.Models
{
   
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Key]
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        //TODO:  Add any fields that you need for creating a new user
        //For example, first name
        [Required]
        [Display(Name = "First Name")]
        public string FName { get; set; }

        [Display(Name = "Middle Initial")]
        public string MI { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LName { get; set; }

        [Required]
        [Display(Name = "Street Address")]
        public string Address { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Zip Code")]
        public int Zip { get; set; }

        [Required]
        [PhoneAttribute]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

    }

    public class RegisterEmpViewModel : RegisterViewModel
    {

        //public enum EmployeeTypes { Employee, Manager };
        //public EmployeeTypes EmployeeType { get; set; }
        //[Key]
        //[Required]
        //[EmailAddress]
        //[Display(Name = "Email")]
        //public string EmpEmail { get; set; }

        public bool IsManager { get; set; }
    }




    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class EditProfileViewModel
    {

    }
}

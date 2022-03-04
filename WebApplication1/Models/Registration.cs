using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace WebApplication1.Models
{
    public class Registration
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Field can't be empty")]

        public string Firstname { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        public string Lastname { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone Number")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$",
                   ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [MembershipPassword(MinRequiredNonAlphanumericCharacters = 1, MinNonAlphanumericCharactersError = "Your password needs to contain at least one symbol (!, @, #, etc).",
        ErrorMessage = "Your password must be 6 characters long and contain at least one symbol (!, @, #, etc).")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
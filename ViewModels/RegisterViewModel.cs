using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Planifiqator.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        public string Nume { get; set; }
        [Required]
        [EmailAddress(ErrorMessage ="The email is invalid")]
        public string Email { get; set; }
        [Required]
        [MinLength(8, ErrorMessage ="Password must contain at least 8 characters")]
        public string Parola { get; set; }
    }
}

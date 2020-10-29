using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentskiDom.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Morate unijeti korisničko ime.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Morate unijeti lozinku.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}

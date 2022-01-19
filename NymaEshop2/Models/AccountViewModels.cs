using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NymaEshop2.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [EmailAddress]
        [Display(Name ="ایمیل")]
        public string Email { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز")]
        public string Password { get; set; }


        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [Display(Name ="تکرار رمز")]
        [Compare("Password")]
        public string Repassword { get; set; }
    }




    public class LoginViewModel
    {

        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [EmailAddress]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }



        [Required(ErrorMessage = "لطفا {0} را وارد کنید")]
        [MaxLength(300)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز")]
        public string Password { get; set; }



        [Display(Name = "مرا به خاطر بسپار")]
        public bool Remeberme { set; get; }
    }
}

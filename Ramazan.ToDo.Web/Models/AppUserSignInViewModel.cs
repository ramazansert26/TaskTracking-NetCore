using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ramazan.ToDo.Web.Models
{
    public class AppUserSignInViewModel
    {
        [Required(ErrorMessage = "Kullanıcı Adı Boş geçilemez")]
        [Display(Name = "Kullanıcı Adı:")]
        public string UserName { get; set; }
        [Display(Name = "Parola:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola alanı Boş geçilemez")]
        public string Password { get; set; }
        [Display(Name = "Beni Hatırla")]
        public bool RememberMe { get; set; }
    }
}

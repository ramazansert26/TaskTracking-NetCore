using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ramazan.ToDo.Web.Models
{
    public class AppUserAddViewModel
    {
        [Required(ErrorMessage ="Kullanıcı Adı Boş geçilemez")]
        [Display(Name ="Kullanıcı Adı:")]
        public string UserName { get; set; }
        [Display(Name = "Parola:")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Parola alanı Boş geçilemez")]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Parola Tekrar")]
        [Compare("Password",ErrorMessage ="Parolalar eşleşmiyor")]
        public string ConfirmPassword { get; set; }
        [EmailAddress(ErrorMessage = "Geçersiz email")]
        [Display(Name = "Email:")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Ad alanı Boş geçilemez")]
        [Display(Name = "Ad:")]
        public string Name { get; set; }
        [Display(Name = "Soyad:")]
        [Required(ErrorMessage = "Soyad alanı Boş geçilemez")]
        public string Surname { get; set; }
    }
}

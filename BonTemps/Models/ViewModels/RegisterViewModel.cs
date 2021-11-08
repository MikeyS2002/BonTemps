using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BonTemps.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Naam")]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DisplayName("Wachtwoord")]
        [DataType(DataType.Password)]
        [StringLength(100, ErrorMessage = "Het {0} moet ten miste{2} karakters lang zijn.", MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Herhaal wachtwoord")]
        [Compare("Password", ErrorMessage = "De wachtwoorden komen niet overeen.")]
        public string ConfirmPassword { get; set; }
        [DisplayName("Rol")]
        public string RoleName { get; set; }
    }
}

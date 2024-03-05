using System.ComponentModel.DataAnnotations;

namespace Backend.ViewModels
{
    public class RegisterVM
    {
        [Display(Prompt = "Username")]
        [StringLength(maximumLength: 15, MinimumLength = 3)]
        public string Username { get; set; }
        [Display(Prompt = "Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Prompt = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "Confirm password", Prompt = "Confirm password")]
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        [Display(Name = "Terms")]
        [Required(ErrorMessage = "You must accept our terms")]
        //[DefaultValue(true)]
        public bool IsTermsAccepted { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace partnerportal.Models
{
    public class ClmResetPasswordModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{6,}$", ErrorMessage = "Password needs to be minimum 6 characters, at least 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

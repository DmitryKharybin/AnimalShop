using System.ComponentModel.DataAnnotations;

namespace AnimalShop.Models
{
    public class Register
    {

        [Required(ErrorMessage = "Please enter UserName")]
        [StringLength(100, ErrorMessage = "User Name must be between 4 and 100 characters", MinimumLength = 4)]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [StringLength(100, ErrorMessage = "Password must be at least 8 character long", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[\W]).*$", ErrorMessage = "Password must contain At least: 1 Upper case Key , 1 Lower case Key , 1 numeric Key , 1 special key")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}


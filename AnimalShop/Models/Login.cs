using System.ComponentModel.DataAnnotations;

namespace AnimalShop.Models
{
    public class Login
    {

        [Required(ErrorMessage = "Please enter UserName")]
        public required string Username { get; set; }

        [Required(ErrorMessage = "Please enter password")]
        [DataType(DataType.Password)]
        public required string Password { get; set; }
    }
}

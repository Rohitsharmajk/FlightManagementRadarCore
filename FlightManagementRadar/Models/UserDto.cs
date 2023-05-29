using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FlightManagementRadar.Models
{
    public class UserDto
    {
        [Key]
        [MinLength(2, ErrorMessage = "Username Length should be atleast 2")]
        [Display(Name = "User Name")]
        public String UserName { get; set; }=String.Empty;

        [MinLength(6, ErrorMessage = "Password Length should be atleast 6")]
        [Display(Name = "Password")]
        public String Password { get; set; } =String.Empty;
    }
}

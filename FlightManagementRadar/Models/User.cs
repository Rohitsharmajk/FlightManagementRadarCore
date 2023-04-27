using System.ComponentModel.DataAnnotations;

namespace FlightManagementRadar.Models
{
    public class User
    {
        [Key]
        public String UserName { get; set; } = String.Empty;
        [Required]
        public byte[] PasswordHash { get; set; }=new byte[0];
        [Required]
        public byte[] PasswordSalt { get; set; } = new byte[0];
    }
}

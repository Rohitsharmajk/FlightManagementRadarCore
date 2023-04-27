using FlightManagementRadar.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace flightmanagementradar.models
{
    public class CheckIn_Detail
    {
        [Display(Name = "boarding id")]
        [Key]
        public int Boarding_Id { get; set; }
        public int FlightId { get; set; }
        public string Name { get; set; }=String.Empty;
        public int Phonenum { get; set; }
        public string Email { get; set; } = String.Empty;
        public int Age { get; set; }
        public string Gender { get; set; }  = String.Empty; 
        public string Username { get; set; } = String.Empty;
        public bool isCheckedIn { get; set; }

        public  User? userDetail { get; set; }
        public  Flight_Data? flightData { get; set; }
    }
}

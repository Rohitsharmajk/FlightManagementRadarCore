using System.ComponentModel.DataAnnotations;

namespace FlightManagementRadar.Models
{
    public class Flight_Data
    {
        [Key]
        public int Flight_ID { get; set; }
        [Required]
        public string Flight_Name { get; set; } = string.Empty;
        [Required]
        public string Source { get; set; } = string.Empty;
        [Required]
        public string Destination { get; set; } = string.Empty;
        [Required]
        public DateTime Boarding_Time { get; set; }
        [Required]
        public int Fare { get; set; }
    }
}

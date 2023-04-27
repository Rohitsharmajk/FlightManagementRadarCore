namespace FlightManagementRadar.Models
{
    public class BoardingDetails
    {
        public String Name { get; set; }=String.Empty;
        public String Gender { get; set; } = String.Empty;
        public int Age { get; set; }
        public int BoardingId { get; set; }
        public int FlightId { get; set; }
    }
}

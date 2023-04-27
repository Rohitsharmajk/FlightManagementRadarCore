using flightmanagementradar.models;

namespace FlightManagementRadar.Models
{
    public class PassengerBookingDetails
    {
        public int FlightId { get; set; }
        public List<PassengerDetails> passengers { get; set;}
    }
}

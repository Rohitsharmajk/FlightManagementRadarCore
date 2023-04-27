using flightmanagementradar.models;
using FlightManagementRadar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlightManagementRadar.Controllers
{
    [Authorize]
    public class ValidateBookingIDController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly FlightManagementContext _context;

        public ValidateBookingIDController(IConfiguration configuration, FlightManagementContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        
        [HttpPost("checkin")]
        public async Task<ActionResult> ValidateCheck(int BoardingID)
        {
                CheckIn_Detail passenger = _context.CheckIn_Details.SingleOrDefault(m => m.Boarding_Id == BoardingID && m.isCheckedIn==false);
                if (passenger!=null && !passenger.isCheckedIn)
                {
                     passenger.isCheckedIn = true;
                    _context.SaveChanges();
                    return Ok("Checked in successfully!");
                }
            return BadRequest("Boarding Id not found Or Already Checked In... Please Recheck!");
        }

        [HttpPost("bookinghistory")]
        public async Task<ActionResult> BookingHistory()
        {
            //var list = _context.CheckIn_Details.Where(x => x.Username.Equals(AccountController.Username));
            

            var list =
            from x in _context.CheckIn_Details
            where x.Username.Equals(AccountController.Username)
            select new { x.FlightId,x.Boarding_Id,x.Age,x.Gender,x.Name,x.Phonenum };

            if (list == null || list.Count() > 0) Ok("No records found!");

            return Ok(list);
        }
    }
}

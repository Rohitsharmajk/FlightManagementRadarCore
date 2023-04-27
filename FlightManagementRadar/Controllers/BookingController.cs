using FlightManagementRadar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FlightManagementRadar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly FlightManagementContext _context;

        public BookingController(IConfiguration configuration, FlightManagementContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost("getdetails")]
        public async Task<ActionResult> GetDetails()
        {
                List<string> beg = _context.Flight_Datas.Select(x => x.Source).Distinct().ToList();
                List<string> dest = _context.Flight_Datas.Select(x => x.Destination).Distinct().ToList();
               
                return Ok(new {Source=beg,Destination=dest});
        }
        [HttpPost("bookflight")]
        public async Task<ActionResult> BookFlight(string Source, string Destination, DateTime Date)
        {
            if (Date < System.DateTime.Now)
            {
                return BadRequest("Please enter a valid date!");
            }
                List<Flight_Data> list = _context.Flight_Datas.Where(x => x.Source.Equals(Source) && x.Destination.Equals(Destination) && x.Boarding_Time.Date >= Date.Date && x.Boarding_Time.Month>=Date.Month && x.Boarding_Time.Year>=Date.Month).OrderBy(x => x.Boarding_Time).ToList();
            return Ok(new { Flights = list });
        }
    }
}

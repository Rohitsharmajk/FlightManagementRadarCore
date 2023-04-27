using flightmanagementradar.models;
using FlightManagementRadar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using FlightManagementRadar.Services;

namespace FlightManagementRadar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class Passenger_details : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly FlightManagementContext _context;
        private readonly IMailService _mailService;


        public Passenger_details(IConfiguration configuration, FlightManagementContext context, IMailService _MailService)
        {
            _configuration = configuration;
            _context = context;
            _mailService = _MailService;
        }
        [HttpPost("bookpay")]
        public async Task<ActionResult> Book_pay(PassengerBookingDetails details)
        {
            Random obj1 = new Random();

            List<BoardingDetails> list = new List<BoardingDetails>();
            foreach (var obj2 in details.passengers)
            {
                int boardingID = obj1.Next(11111, 99999);
                list.Add(new BoardingDetails { Name=obj2.Name,
                    Gender=obj2.Gender,
                    Age=obj2.Age,
                    BoardingId= boardingID,
                    FlightId=details.FlightId});

                _context.CheckIn_Details.Add(new CheckIn_Detail()
                {
                    Name = obj2.Name,
                    Age = obj2.Age,
                    Gender = obj2.Gender,
                    Boarding_Id = boardingID,
                    Email = obj2.Email,
                    FlightId = details.FlightId,
                    Phonenum = obj2.Phone,
                    Username = AccountController.Username,
                    isCheckedIn = false
                }) ;

                MailData maildata = new MailData();
                maildata.EmailToId = obj2.Email;
                maildata.EmailToName = obj2.Name;
                maildata.EmailBody = "Thank you for booking with us, your ticket with boarding id:" + boardingID + " has been confirmed,\n please exibit the former at the time of boarding.\nwe wish you a jubilant journey";
                maildata.EmailSubject = "Radarflights ticket confirmation";
                _mailService.SendMail(maildata);

            }

            _context.SaveChanges();

            TicketDetails tickets = new TicketDetails()
            { Mesaage = $"Thank you for booking your flight with us at RDAR booking.We will be contacting you regarding your flight details  respectively.NOTE:Your boarding pass has been sent to your registered email for future reference, please exhibit the same at the time of check in",
                tickets = list,
            };
            
            return Ok(tickets);
        }
    }
}

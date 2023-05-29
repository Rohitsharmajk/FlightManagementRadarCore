using FlightManagementRadar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using FlightManagementRadar.Controllers;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace FlightManagementRadar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly FlightManagementContext _context;

        public AdminController(IConfiguration configuration, FlightManagementContext context)
        {
            _configuration = configuration;
            _context = context;
        }
        [HttpPost("addFlight")]
        public async Task<ActionResult> AddFlight(int flight_ID, string flight_Name, string source, string destination, string boarding_Time, int fare)
        {
            bool flag = _context.Flight_Datas.Any(x => x.Flight_ID == flight_ID);
            if (flag)
            {
                return BadRequest("Flight with same id already exists");
            }
            Random obj1 = new Random();
            _context.Flight_Datas.Add(new Flight_Data()
            {
                Flight_ID = obj1.Next(111, 999),
                Flight_Name = flight_Name,
                Source = source,
                Destination = destination,
                Boarding_Time = DateTime.Parse(boarding_Time),
                Fare = fare
            }); ;
            await _context.SaveChangesAsync();
            return Ok("Flight Added successfully");
        }
        [AllowAnonymous]
        [HttpPost("adminLogin")]
        public async Task<ActionResult> AdminLogin(UserDto obj)
        {

            UserDto user = _context.AdminUsers.SingleOrDefault(x=>x.UserName == obj.UserName);
            if (user==null)
            {
                return BadRequest("User not found!");
            }
           if(user.Password!=obj.Password)  
                return BadRequest("Wrong Password!");

            String token = CreateToken(obj);

            //return Ok(token);
            //Username = request.UserName;
            return Ok(token);
        }
        private String CreateToken(UserDto user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserName),
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
                _configuration["JWT:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            String jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return jwt;
        }

        [HttpGet("getAllFlights")]
        public async Task<ActionResult> GetAllFlights()
        {

            return Ok(_context.Flight_Datas.ToList());
        }
        [HttpGet("deleteFlight")]
        public async Task<ActionResult> DeleteFlight(int id)
        {

            Flight_Data fli = _context.Flight_Datas.SingleOrDefault(x => x.Flight_ID == id);
            _context.Flight_Datas.Remove(fli);
            await _context.SaveChangesAsync();
            return Ok("Flight Deleted Successfully!");
        }

        [HttpPost("updateFlight")]
        public async Task<ActionResult> UpdateFlight(int flight_ID, string flight_Name, string source, string destination, string boarding_Time, int fare)
        {

            Flight_Data? fl = _context.Flight_Datas.SingleOrDefault(x=>x.Flight_ID==flight_ID);
            fl.Flight_Name= flight_Name;
            fl.Fare= fare;
            fl.Source= source;
            fl.Destination= destination;
            fl.Boarding_Time = DateTime.Parse(boarding_Time);

            await _context.SaveChangesAsync();
            
            return Ok("Details Update Successfully");
        }

    }
}

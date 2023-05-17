using FlightManagementRadar.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace FlightManagementRadar.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class AccountController : Controller
    {
        // FlightManagementContext ctx = new FlightManagementContext();
        // GET: Account
        public static String Username = null;
        private readonly IConfiguration _configuration;
        private readonly FlightManagementContext _context;

        public AccountController(IConfiguration configuration, FlightManagementContext context) 
        {
            _configuration = configuration;
            _context = context;
        }
        //API Functions
        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> Register(UserDto request)
        {
            //checked if user already present and add in database
            bool isPresent = _context.Users.Any(user => user.UserName == request.UserName);

            if (!isPresent)
            {
                CreatePasswordHash(request.Password, out byte[] passwordHash, out byte[] passwordSalt);
                User user = new User() { UserName = request.UserName, PasswordHash = passwordHash, PasswordSalt = passwordSalt };
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("User successfully Added"!);
            }

            return BadRequest("User Already Present!");
        }
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login(UserDto request)
        {
            //check for if username present in database
            User? user = _context.Users.FirstOrDefault(user => user.UserName.Equals(request.UserName));

            if (user == null) return BadRequest("User Not Found!");


            //verify password in database and send his hash and salt
            if (!VerifyPasswordHash(request.Password, user.PasswordHash, user.PasswordSalt))
            {
                // return BadRequest("Wrong password");
                return BadRequest("Wrong Password!");
            }

            String token = CreateToken(user);

            //return Ok(token);
            Username= request.UserName;
            return Ok(token);
        }
        private String CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, user.UserName),
                new Claim(ClaimTypes.Role, user.Role),
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

        private void CreatePasswordHash(String password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(String password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}

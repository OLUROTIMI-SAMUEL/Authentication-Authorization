using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization; 

namespace Authentication_Authorization_InASP.NET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly jwtAuthenticationManager jwtAuthenticationManager;

        public WeatherForecastController(jwtAuthenticationManager jwtAuthenticationManager)
        {
                this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

      //  private readonly ILogger<WeatherForecastController> _logger;

        
        [Authorize]
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [AllowAnonymous]
        [HttpPost("Authorize")]

        public IActionResult AuthUser([FromBody] user usr)
        {
            var token = jwtAuthenticationManager.Authenticate(usr.UserName, usr.Password);
            //var token = jwtAuthenticationManager.Authenticate(usr.UserName, usr.Password);
            if(token == null)
                
            {
                return Unauthorized();
            }
            return Ok(token);

           
        }
    }
    public class user
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
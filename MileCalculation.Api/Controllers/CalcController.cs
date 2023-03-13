using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MileCalculation.Api.Helpers.MileCalculator;
using MileCalculation.Api.Services.HttpService;
using System;
using System.Threading.Tasks;

namespace MileCalculation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalcController : ControllerBase
    {
        private readonly CustomConnection connectionCTeleport;
        public CalcController()
        {
            connectionCTeleport = new CustomConnection(Services.HttpService.Enums.UriType.CTeleport, false);
        }

        /// <summary>
        /// Verilen IATA kodlarına göre iki hava meydanı arası mil hesaplaması yapar.
        /// </summary>
        [HttpGet, Route("MileCalculate/{iataCode1}/{iataCode2}")]
        [Produces("application/json")]
        public async Task<IActionResult> GetAllCategory([FromRoute] string iataCode1, string iataCode2)
        {
            var iata1 = await connectionCTeleport.Get(iataCode1.ToUpper());
            var iata2 = await connectionCTeleport.Get(iataCode2.ToUpper());

            if (iata1 == null ||  iata2 == null) 
               return BadRequest("Please enter a valid IATA code");


            var iata1Coordiante = new Helpers.MileCalculator.Concrete.Coordinate(iata1.location.lat, iata1.location.lon);
            var iata2Coordiante = new Helpers.MileCalculator.Concrete.Coordinate(iata2.location.lat, iata2.location.lon);

            var result = Math.Ceiling((MileCalculator.CalculateMile(iata1Coordiante, iata2Coordiante)));

            return Ok($"The distance between SAW and ADB is {result} Miles");
        }
    }
}

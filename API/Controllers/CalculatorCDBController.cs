using API.Data.Inputs;
using API.Interfaces.Services;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/v1/calculator")]
    [ApiController]
    public class CalculatorCDBController : ControllerBase
    {
        private readonly ICalculatorCDBService service;
        public CalculatorCDBController(ICalculatorCDBService service)
        {
            this.service = service;
        }

        [HttpGet(Name = "CalculateCDB")]
        [Produces(typeof(CalculatedCDB))]
        public async Task<IActionResult> Get([FromQuery] CalculateCDBQuery query)
        {
            var result = await service.CalculateCDB(query);
            return Ok(result);
        }

    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Core_Api_Versioning.Controllers
{
    
    [ApiController]
    [Route("api/Test")]
    [ApiVersion("1.0")]
    [ApiVersion("2.0")]

    public class TestController : ControllerBase
    {
        [HttpGet("Get")]     
        [MapToApiVersion("1.0")]
        public IActionResult Get()
        {
            return new OkObjectResult("test from v1 controller");
        }

        [HttpGet("Get_From_V2")]
        [MapToApiVersion("2.0")]
        public IActionResult Get_From_V2()
        {
            return new OkObjectResult("test from v2 controller");
        }
    }
}

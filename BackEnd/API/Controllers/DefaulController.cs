using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("/")]
    public class DefaultController : ControllerBase
    {

        [HttpGet]
        public string Get()
        {
            return "Proyecto Instituto";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace webapi.Controllers
{
    [Produces("application/json")]
    [Route("api/v1")]
    [ApiController]
    public class IndexController : ControllerBase
    { 
        [HttpGet()]
        public object Index()
        {

            string status = "ok";
            string message = "Version 1";
            string data = null;

            return new
            {
                status = status,
                message = message,
                data = data,
            };
        }
    }
}

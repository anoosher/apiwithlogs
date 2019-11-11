using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace apiwithlogs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        

         private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger=logger;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            

            Random rnd = new Random();

            for (int i = 0; i < 1000; i++)
            {
                var rand = rnd.Next(1,6);
                var randNames = rnd.Next(1,3);
                var UserId = Enum.GetName(typeof(Names), randNames);

                switch(rand){
                    case 1:
                        _logger.LogInformation("test info log. User Id is {UserId} " ,UserId);
                        break;
                    case 2:
                        _logger.LogCritical("test critical log. User Id is {UserId} " ,UserId);
                        break;
                        case 3:
                        _logger.LogDebug("test debug log. User Id is {UserId} " ,UserId);
                        break;
                        case 4:
                        _logger.LogWarning("test warning log. User Id is {UserId} " ,UserId);
                        break;
                        case 5:
                        _logger.LogError("test error {ExceptionDetails} . User Id is {UserId} " , "Exception details" ,UserId );
                        break;
                        case 6:
                        _logger.LogTrace("test trace log. User Id is {UserId} " ,UserId);
                        break;
                    default:
                        _logger.LogInformation("test log. User Id is {UserId} " ,UserId);
                        break;        
                        }

            }

            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

    public enum Names
    {
        Anusha =1,
        Dinusha = 2,
        Hashini = 3,
    }
}



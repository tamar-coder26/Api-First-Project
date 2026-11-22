using Microsoft.AspNetCore.Mvc;
using Zxcvbn;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //fix: Renamed the class to PasswordsController; the route stays api/Passwords
    public class PasswordsController : ControllerBase
    {
        //In C#, the file name should match the type it declares: rename this file to PasswordsController.cs
        // GET: api/<Passwordr>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<Passwordr>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Passwordr>
        [HttpPost]
        public IActionResult Post([FromBody] string pass)
        {
            var resulte = Zxcvbn.Core.EvaluatePassword(pass);
            return Ok(resulte.Score);
        }

        // PUT api/<Passwordr>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Passwordr>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

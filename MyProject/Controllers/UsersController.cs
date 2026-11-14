using Microsoft.AspNetCore.Mvc;
//fix: removed the unused using System.Runtime.Intrinsics.Arm
using System.Text.Json;
using Service;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserService userservice = new UserService();
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "China", "Japan", "Israel" };
        }

        static string filePath = "User.txt";
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public ActionResult<Users> Get(int id)
            {

            //Why is GET by id not implemented? The assignment asks it to return the user with this id (or NotFound / NoContent)
            return NotFound() ;
            }
        
        //POST api/<UsersController>
        
        //public ActionResult<Users> Post([FromBody] Users user)
        //{
        //    int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
        //    user.id = numberOfUsers + 1;
        //    string userJson = JsonSerializer.Serialize(user);
        //    System.IO.File.AppendAllText(filePath, userJson +
        //    Environment.NewLine);
        //    return Ok(user);
        //}
        [HttpPost]
        public ActionResult<Users> Post([FromBody] Users user)
        {
              
           return userservice.AddUser(user);
        }
        [HttpPost ("Login")]
        public ActionResult<Users> PostLog([FromBody] LogUsers loginUser)
        {
            return userservice.GetUser(loginUser);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        //The assignment asks PUT to return Ok(): change void to IActionResult and return Ok() at the end
        public void Put(int id, [FromBody] Users putuser)
        {
             userservice.Update(id, putuser);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}

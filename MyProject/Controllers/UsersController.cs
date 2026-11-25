using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.Arm;
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
        Iservice userservice;
        public UsersController(Iservice iuserservice)
        {
            userservice = iuserservice;
        }
        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "China", "Japan", "Israel" };
        }

        static string filePath = "User.txt";
        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Users>> Get(int id)
            {
             return await userservice.GetById(id);
             //return NotFound() ;
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
        public Task<ActionResult<Users>> Post([FromBody] Users user)
        {
              
           return userservice.AddUser(user);
        }
        [HttpPost ("Login")]
        public Task<ActionResult<Users>> PostLog([FromBody] LogUsers loginUser)
        {
            return userservice.GetUser(loginUser);
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
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

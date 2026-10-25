using Microsoft.AspNetCore.Mvc;
using MyProject.wwwroot;
using System.Runtime.Intrinsics.Arm;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MyProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
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
                using (StreamReader reader = System.IO.File.OpenText(filePath))
                {
                    string? currentUserInFile;
                    while ((currentUserInFile = reader.ReadLine()) != null)
                    {
                        Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                        if (user.Id == id)
                            return user;
                    }
                }
                return NotFound();

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

            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return CreatedAtAction(nameof(Get),new {id=user.Id}, user);
        }
        [HttpPost ("Login")]
        public ActionResult<Users> PostLog([FromBody] LogUsers loginUser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.useremail == loginUser.logemail && user.password == loginUser.logpassword)
                        return Ok(user);
                }
            }
            return NotFound();
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Users putuser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }
               if(textToReplace != string.Empty)
               {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(putuser));
                System.IO.File.WriteAllText(filePath, text);
               }
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {

        }
    }
}

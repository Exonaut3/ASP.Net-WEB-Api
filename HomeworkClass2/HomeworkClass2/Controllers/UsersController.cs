using Homework.Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HomeworkClass2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Database.Usernames;
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id <= 0 || id > Database.Usernames.Count())
            {
                return NotFound();
            }
            return Database.Usernames[id-1];
        }

        [HttpPost]
        public ActionResult Post(string username)
        {
            if (String.IsNullOrEmpty(username))
            {
                return BadRequest();
            }
            Database.Usernames.Add(username);
            return StatusCode(StatusCodes.Status201Created);
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            if (id <= 0 || id > Database.Usernames.Count())
            {
                return NotFound();
            }
            var removedUser = Database.Usernames[id-1];
            Database.Usernames.Remove(removedUser);
            return StatusCode(StatusCodes.Status200OK);
        }

    }
}

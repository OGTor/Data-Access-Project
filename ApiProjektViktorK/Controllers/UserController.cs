using DbContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiProjektViktorK.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UserController : Controller
    {
        [HttpGet()]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csUser>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult Seed(int count = 50) // Set default count to 50
        {
            var users = new List<csUser>();
            var sg = new csSeedGenerator();

            for (int i = 0; i < count; i++)
            {
                var user = new csUser().Seed(sg);
                users.Add(user);
            }

            return Ok(users);
        }
        [HttpGet("AllUsersWithComments")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csUser>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult GetAllUsersWithComments()
        {
            // For this example, I'm retrieving users from the seeded data instead of a database.
            var result = Seed(50); // You might want to adjust the number or retrieve from a database in real scenarios.

            if (result is OkObjectResult okResult && okResult.Value is List<csUser> users)
            {
                // In this example, users already have their associated comments from the Seed method.
                // So, we don't need additional logic to associate comments with users.

                return Ok(users.Select(u => new
                {
                    u.UserId,
                    u.UserName,
                    u.Email,
                    Comments = u.Comments.Select(c => new
                    {
                        c.Comment,
                        Sight = c.Sight.SightName  // Just an example if you'd like to include the name of the sight for the comment.
                    }).ToList()
                }));
            }

            return BadRequest("Unable to generate users and their comments.");
        }



    }

}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace ApiProjektViktorK.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CommentController : Controller
    {
        [HttpGet()]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(csComments))]
        [ProducesResponseType(400, Type = typeof(string))]
        public async Task<IActionResult> Seed(string count)
        {
            var sg = new csSeedGenerator();
            var comment = new csComments().Seed(sg);

            return Ok(comment);
        }
    }
}
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace ApiProjektViktorK.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SightController : ControllerBase
    {
        [HttpGet("Seed")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csSights>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult Seed(int count = 10) // Default to seeding 10, adjust as needed
        {
            var sights = new List<csSights>();
            var sg = new csSeedGenerator();

            for (int i = 0; i < count; i++)
            {
                var sight = new csSights().Seed(sg);
                sights.Add(sight);
                // If you later wish to store these in a database, you can uncomment the related code and adjust accordingly.
            }

            return Ok(sights);
        }

        [HttpGet("filtered")]
        public ActionResult<IEnumerable<csSights>> GetFilteredSights(
               string? category = null,
               string? sightName = null,
               string? description = null,
               string? country = null,
               string? city = null)
        {
            // For this example, I'm going to retrieve sights from the seeded data instead of a database
            var result = Seed(10);

            if (result is OkObjectResult okResult && okResult.Value is List<csSights> sights)
            {
                var query = sights.AsQueryable();

                if (!string.IsNullOrEmpty(category))
                    query = query.Where(s => s.Category.Contains(category));

                if (!string.IsNullOrEmpty(sightName))
                    query = query.Where(s => s.SightName.Contains(sightName));

                if (!string.IsNullOrEmpty(description))
                    query = query.Where(s => s.Description.Contains(description));

                if (!string.IsNullOrEmpty(country))
                    query = query.Where(s => s.Address.Country.Contains(country));

                if (!string.IsNullOrEmpty(city))
                    query = query.Where(s => s.Address.City.Contains(city));

                return Ok(query.ToList());
            }

            return BadRequest("Unable to generate sights for filtering.");
        }

        [HttpGet("WithoutComments")]
        public ActionResult<IEnumerable<csSights>> GetSightsWithoutComments()
        {
            // For this example, I'm going to retrieve sights from the seeded data instead of a database
            var result = Seed(10);

            if (result is OkObjectResult okResult && okResult.Value is List<csSights> sights)
            {
                var sightsWithoutComments = sights.Where(s => s.Comments == null || !s.Comments.Any()).ToList();

                return Ok(sightsWithoutComments);
            }

            return BadRequest("Unable to generate sights for filtering.");
        }


    }
}




//[HttpGet()]
//[ActionName("Unseed")]
//[ProducesResponseType(200, Type = typeof(csSights))]
//[ProducesResponseType(400, Type = typeof(string))]
//public async Task<IActionResult> Unseed(string count)
//{
//    var sight = new csSights().Unseed();

//    return Ok(sight);
//}
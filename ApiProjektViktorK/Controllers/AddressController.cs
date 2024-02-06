using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;

namespace ApiProjektViktorK.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AddressController : Controller
    {
        [HttpGet()]
        [ActionName("Seed")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<csAddress>))]
        [ProducesResponseType(400, Type = typeof(string))]
        public IActionResult Seed(int count = 100) // Set default count to 100
        {
            //Ändra
            var addresses = new List<csAddress>();
            var sg = new csSeedGenerator();

            for (int i = 0; i < count; i++)
            {
                var address = new csAddress().Seed(sg);
                addresses.Add(address);
            }

            return Ok(addresses);
        }
    }
}
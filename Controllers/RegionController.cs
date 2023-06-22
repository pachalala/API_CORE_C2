using Microsoft.AspNetCore.Mvc;
using RES_API.Models;

namespace RES_API.Controllers
{


    [Route("[controller]")]
    [ApiController]

    public class RegionesController : Controller
    {
        private readonly SppContext _db;

        public RegionesController(SppContext context)
        {
            _db = context;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var lista = _db.Regions.OrderBy(x => x.CodRegion).Select(


             (p) => new {
                 
                id =   p.CodRegion,
                 p.Nombre
                

             })


                    .Take(50).ToList();
                
                
              




            return StatusCode(StatusCodes.Status200OK, lista);


        }

    }
}

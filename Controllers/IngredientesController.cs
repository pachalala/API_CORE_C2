using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RES_API.Models;

namespace Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IngredientesController : ControllerBase
    {
        TestContext _db;

 

        public IngredientesController(TestContext db)
        {

            _db = db;

        }
 




    [HttpGet]
    public async Task<IActionResult> Get()
    {



       var lista =   _db.Ingredientes.OrderBy(x => x.Id).Select(

           p => new { p.Id, p.Nombre , cantidad =  0, chek =  0


           }

            ).ToList();


            return StatusCode(StatusCodes.Status200OK, lista);

    }
    }
}

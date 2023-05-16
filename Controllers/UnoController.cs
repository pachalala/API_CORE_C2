using Microsoft.AspNetCore.Mvc;
using RES_API.Models;
using Negocio;

namespace RES_API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class UnoController : Controller
    {


        TestContext _db;

        public UnoController(TestContext db) {

            _db = db;
        
        }

 


        [HttpGet]
        public  async Task<IActionResult> Get() { 
        
           
           
            List<Plato> lista = _db.Platos.OrderBy(x => x.Id).ToList();


            return StatusCode (StatusCodes.Status200OK, lista)   ;

        }
    }
}

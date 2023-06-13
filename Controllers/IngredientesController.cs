using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RES_API.Models;
using static Controllers.AccesoController;

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

            var res = @"

[
  {
    ""id"": 1,
    ""nombre"": ""fideos"",
    ""cantidad"": 0,
    ""chek"": 0
  },
  {
    ""id"": 2,
    ""nombre"": ""carne molida x"",
    ""cantidad"": 0,
    ""chek"": 0
  },
  {
    ""id"": 3,
    ""nombre"": ""salsa tomate"",
    ""cantidad"": 0,
    ""chek"": 0
  }
]

";

            return StatusCode(StatusCodes.Status200OK, res);



            var lista =   _db.Ingredientes.OrderBy(x => x.Id).Select(

           p => new { p.Id, p.Nombre , cantidad =  0, chek =  0
 
           }

            ).ToList();


            return StatusCode(StatusCodes.Status200OK, lista);

    }
    


    [HttpGet]
    [Route("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {

            Ingrediente ingre = _db.Ingredientes.Find(id); // .fin.OrderBy(x => x.Id).Select(

            /*
             p => new {
                 p.Id,
                 p.Nombre,
                 cantidad = 0,
                 chek = 0

             }

              ).ToList();
            */

        return StatusCode(StatusCodes.Status200OK, ingre);

    }




        [HttpPut]
       
        public async Task<IActionResult> Put([FromBody]  Ingrediente request)
        {

            Ingrediente ingre = _db.Ingredientes.Find(request.Id); // .fin.OrderBy(x => x.Id).Select(
            ingre.Nombre = request.Nombre;

            _db.Update(ingre);
            _db.SaveChanges();

            /*
             p => new {
                 p.Id,
                 p.Nombre,
                 cantidad = 0,
                 chek = 0

             }

              ).ToList();
            */

            return StatusCode(StatusCodes.Status200OK, "OK");

        }

    }

}

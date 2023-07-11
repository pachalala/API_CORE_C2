using Microsoft.AspNetCore.Mvc;
using Models;
using Negocio;


using RES_API.Controllers;
using RES_API.Models;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccesoController : Controller
    {
        private readonly SppContext _db;

        public AccesoController(SppContext context)
        {
            _db = context;
        }

        public class Req_Usuario_AD{
            public string usuario { get; set; } 
            public string clave { get; set; }
        }



        [HttpPost]
       
        public async Task<IActionResult> get([FromBody] Req_Usuario_AD request )
        {

        //    return StatusCode(StatusCodes.Status200OK, "{ \"res\":1,\"msg\":\"OK\", \"usuario\":{ \"nombre\":\"PEPITO TEST\", \"user\":\"usuario_1\" }}");


            Usuario_AD _usuario = new Usuario_AD();

             
            
            try
            {
                _usuario = Acceso.accesos("FOSIS", request.usuario, request.clave);

                var res = _db.UsuUsuarios.Where(u => request.usuario == u.UsuLogin).First();
                
             //   if ((res.UsuIdrol == 1) || (res.UsuIdrol == 11))  // PERFIL MESA O ADMIN
                     return StatusCode(StatusCodes.Status200OK, "{ \"res\":1,\"msg\":\"OK\", \"usuario\":{ \"nombre\":\"" + _usuario.Nombre + "\", \"user\":\"" + _usuario.User+ "\" }}");
             //   else

               //     return StatusCode(StatusCodes.Status200OK, "{\"res\":-1,\"msg\": \"Perfil incorrecto\"}");

            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, "{\"res\":-1,\"msg\": \"Usuario o clave incorrectas\"}");

                //return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }


        }
    }
}

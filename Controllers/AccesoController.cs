using Microsoft.AspNetCore.Mvc;
using Models;
using Negocio;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccesoController : Controller
    {
   

        public class Req_Usuario_AD{
            public string usuario { get; set; } 
            public string clave { get; set; }
        }



        [HttpPost]
       
        public async Task<IActionResult> get([FromBody] Req_Usuario_AD request )
        {
            Usuario_AD _usuario = new Usuario_AD();

            try
            {
                _usuario = Acceso.accesos("FOSIS", request.usuario, request.clave);
                return StatusCode(StatusCodes.Status200OK, "{ \"res\":1,\"msg\":\"OK\", \"usuario\":{ \"nombre\":\"" + _usuario.Nombre + "\", \"user\":\"" + _usuario.User+ "\" }}");
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status200OK, "{\"res\":-1,\"msg\": \"Usuario o clave incorrectas\"}");

                //return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);

            }


        }
    }
}

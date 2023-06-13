using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RES_API.Models;

namespace RES_API.Controllers
{

    [Route("[controller]")]
    [ApiController]

    public class UsuariosController : Controller
    {
        private readonly SppContext _db;

        public UsuariosController(SppContext context)
        {
            _db = context;
        }

        // GET: Usuarios
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var lista = _db.UsuUsuarios.OrderBy(x => x.UsuNombre).ToList();


            return StatusCode(StatusCodes.Status200OK, lista);


        }


        [HttpPost]
        public async Task<IActionResult> Find([FromBody] UsuUsuario parametro)
        {
            /*
            Ingrediente ingre = _db.UsuUsuarios.Find ()
            ingre.Nombre = request.Nombre;

            _db.Update(ingre);
            _db.SaveChanges();
            */

            /*
             p => new {
                 p.Id,
                 p.Nombre,
                 cantidad = 0,
                 chek = 0

             }

              ).ToList();
            */

            int i = 1;
            var resultados = _db.UsuUsuarios.Where(
                
                u =>
           
                 u.UsuLogin.Contains(parametro.UsuLogin) && 
                 u.UsuRut.Contains(parametro.UsuRut)  &&

                

            //     (u.UsuIdrol != -1 ? u.UsuIdrol == parametro.UsuIdrol : false) &&
                  u.UsuNombre.Contains(parametro.UsuNombre)
              //  (u.UsuRegion != -1 ? u.UsuRegion == parametro.UsuRegion :false )



                    ).Select(

            
             (p  )=> new {
               
                 p.UsuIdrol,
                 p.UsuLogin,
                 p.UsuNombre,
                 p.UsuRegion,
                 p.UsuRut

             }) 
                    
                    
                    .Take(50).ToList();


            return StatusCode(StatusCodes.Status200OK,resultados

        );

        }



        /*

        [HttpGet]
        [Route("{login:Guid}")]
        public async Task<IActionResult> Get(string id)
          {
            if (id == null || _db.UsuUsuarios == null)
            {
                return NotFound();
            } 
            var usuUsuario = await _db.UsuUsuarios
                .FirstOrDefaultAsync(m => m.UsuLogin == id);
            if (usuUsuario == null)
            {
                return NotFound();
            }
            return StatusCode(StatusCodes.Status200OK, usuUsuario);
 
        }



        // GET: Usuarios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
         
        public async Task<IActionResult> Create([Bind("UsuLogin,UsuRut,UsuIdrol,UsuNombre,UsuPasswd,UsuEnable,UsuRegion,UsuUltimoacceso,UsuCambioclave,UsuNuevo")] UsuUsuario usuUsuario)
        {
            if (ModelState.IsValid)
            {
                _db.Add(usuUsuario);
                await _db.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuUsuario);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _db.UsuUsuarios == null)
            {
                return NotFound();
            }

            var usuUsuario = await _db.UsuUsuarios.FindAsync(id);
            if (usuUsuario == null)
            {
                return NotFound();
            }
            return View(usuUsuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPut]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UsuLogin,UsuRut,UsuIdrol,UsuNombre,UsuPasswd,UsuEnable,UsuRegion,UsuUltimoacceso,UsuCambioclave,UsuNuevo")] UsuUsuario usuUsuario)
        {
            if (id != usuUsuario.UsuLogin)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(usuUsuario);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UsuUsuarioExists(usuUsuario.UsuLogin))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(usuUsuario);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _db.UsuUsuarios == null)
            {
                return NotFound();
            }

            var usuUsuario = await _db.UsuUsuarios
                .FirstOrDefaultAsync(m => m.UsuLogin == id);
            if (usuUsuario == null)
            {
                return NotFound();
            }

            return View(usuUsuario);
        }

        // POST: Usuarios/Delete/5
         public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_db.UsuUsuarios == null)
            {
                return Problem("Entity set 'SppContext.UsuUsuarios'  is null.");
            }
            var usuUsuario = await _db.UsuUsuarios.FindAsync(id);
            if (usuUsuario != null)
            {
                _db.UsuUsuarios.Remove(usuUsuario);
            }
            
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuUsuarioExists(string id)
        {
          return (_db.UsuUsuarios?.Any(e => e.UsuLogin == id)).GetValueOrDefault();
        }
        */
    }
    }

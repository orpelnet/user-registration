using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using UsuariosRegistration.API.User.DTO;
using UsuariosRegistration.API.User.Service;

namespace UsuariosRegistration.API.User.Application
{
    [Route("usuarios")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService UsuariosService;

        public UsuariosController(IUsuarioService UsuariosService)
        {
            this.UsuariosService = UsuariosService;
        }

        [HttpPost]
        public ActionResult<UsuarioDTO> Create([FromBody] UsuarioDTO Usuario)
        {
            try
            {
                var result = UsuariosService.Create(Usuario);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        public ActionResult<UsuarioResponse> GetAll()
        {
            try
            {
                var result = UsuariosService.GetAll();

                if (result is null || result.Usuarios.Count <= 0) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{UsuariosId}")]
        public ActionResult<UsuarioDTO> Get(int UsuariosId)
        {
            try
            {
                var result = UsuariosService.Get(UsuariosId);

                if (result is null) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{UsuariosId}")]
        public ActionResult<bool> Delete(int UsuariosId)
        {
            try
            {
                var result = UsuariosService.Delete(UsuariosId);

                if (!result) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public ActionResult<bool> Update([FromBody] UsuarioDTO usuarios)
        {
            try
            {
                var result = UsuariosService.Update(usuarios);

                if (!result) return NotFound();

                return Ok(result);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(409, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
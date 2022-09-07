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
        public async Task<ActionResult<UsuarioDTO>> Create([FromBody] UsuarioDTO Usuarios)
        {
            try
            {
                var result = await UsuariosService.Create(Usuarios);

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

        public async Task<ActionResult<UsuarioResponse>> GetAll()
        {
            try
            {
                var result = await UsuariosService.GetAll();

                if (result is null || result.Usuarioss.Count <= 0) return NotFound();

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
        public async Task<ActionResult<UsuarioDTO>> Get(int UsuariosId)
        {
            try
            {
                var result = await UsuariosService.Get(UsuariosId);

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
        public async Task<ActionResult<bool>> Delete(int UsuariosId)
        {
            try
            {
                var result = await UsuariosService.Delete(UsuariosId);

                if (result) return NotFound();

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
        public async Task<ActionResult<UsuarioDTO>> Update([FromBody] UsuarioDTO Usuarios)
        {
            try
            {
                var result = await UsuariosService.Update(Usuarios);

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
    }
}
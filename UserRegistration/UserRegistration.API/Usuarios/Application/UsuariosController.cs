using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UsuariosRegistration.API.Usuarios.DTO;
using UsuariosRegistration.API.Usuarios.Service;

namespace UsuariosRegistration.API.Usuarios.Application
{
    [Route("usuarios")]
    public class UsuariosController : Controller
    {
        private readonly IUsuarioService usuariosService;

        public UsuariosController(IUsuarioService usuariosService)
        {
            this.usuariosService = usuariosService;
        }

        [HttpPost]
        public ActionResult<UsuarioDTO> Create([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var result = usuariosService.Create(usuario);

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

        public ActionResult<List<UsuarioDTO>> GetAll()
        {
            try
            {
                var result = usuariosService.GetAll();

                if (result is null || result.Count <= 0) return NotFound();

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
                var result = usuariosService.Get(UsuariosId);

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
                var result = usuariosService.Delete(UsuariosId);

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
        public ActionResult<bool> Update([FromBody] UsuarioDTO usuario)
        {
            try
            {
                var result = usuariosService.Update(usuario);

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
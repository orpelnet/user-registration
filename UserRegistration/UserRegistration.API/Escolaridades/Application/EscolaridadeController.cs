using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UserRegistration.API.Escolaridades.DTO;
using UserRegistration.API.Escolaridades.Service;

namespace UserRegistration.API.Escolaridades.Application
{
    [Route("escolaridades")]
    public class EscolaridadeController : Controller
    {
        private readonly IEscolaridadeService escolaridadeService;

        public EscolaridadeController(IEscolaridadeService escolaridadeService)
        {
            this.escolaridadeService = escolaridadeService;
        }

        public ActionResult<List<EscolaridadeDTO>> GetAll()
        {
            try
            {
                var result = escolaridadeService.GetAll();

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
    }
}
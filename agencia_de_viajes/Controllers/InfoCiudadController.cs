using Application.Exceptions;
using Application.Interfaces.IInfoCiudad;
using Application.Request;
using Application.Request.InfoCiudad;
using Application.Response.Ciudad;
using Application.Response.InfoCiudad;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoCiudadController : ControllerBase
    {
        private readonly IInfoCiudadService _services;

        public InfoCiudadController(IInfoCiudadService services)
        {
            _services = services;
        }

        [HttpPost]
        [ProducesResponseType(typeof(InfoCiudadResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult crearInfoCiudad(InfoCiudadRequest request)
        {
            try
            {
                var result = _services.CrearInfoCiudad(request);
                return new JsonResult(result) { StatusCode = 201};
            }
            catch (DatoInvalidoException e)
            {
                return BadRequest(new { message = "Ingreso una ciudad inexistente" });
            }
            
            
        }
    }
}

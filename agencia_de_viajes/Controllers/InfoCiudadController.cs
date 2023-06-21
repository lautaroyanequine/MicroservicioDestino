using Application.Exceptions;
using Application.Interfaces.IInfoCiudad;
using Application.Request;
using Application.Request.InfoCiudad;
using Application.Response.Ciudad;
using Application.Response.InfoCiudad;
using Azure.Core;
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
        public IActionResult CrearInfoCiudad(InfoCiudadRequest request)
        {
            try
            {
                var result = _services.CrearInfoCiudad(request);
                return new JsonResult(result) { StatusCode = 201 };
            }
            catch (DatoInvalidoException e)
            {
                return BadRequest(new { message = "Ingreso una ciudad inexistente" });
            }


        }

        [HttpGet("{id_ciudad}")]
        [ProducesResponseType(typeof(InfoCiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        public IActionResult ConseguirInfoDeCiudad(int id_ciudad)
        {
            var result = _services.GetPorCiudad(id_ciudad);

            if (result == null)
            {
                return new JsonResult(new BadRequest { Message = "no existe informacion sobre esa ciudad" }) { StatusCode = 404 };
            }

            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<InfoCiudadResponse>), 200)]
        public IActionResult GetAllInfoCiudad()
        {
            var result = _services.GetAllInfoCiudad();

            if (result == null)
            {
                return new JsonResult(new BadRequest { Message = "no existe informacion sobre ciudades" }) { StatusCode = 200 };
            }

            return new JsonResult(result) { StatusCode = 200 };
        }


        [HttpPut("{id}")]
        [ProducesResponseType(typeof(InfoCiudadResponse), 200)]
        public IActionResult ModificarInfoCiudad(int id, InfoCiudadRequest request)
        {
            var result = _services.EditarInfoCiudad(id, request);

            return new JsonResult(result) { StatusCode = 200 };

        }


        [HttpDelete("{id}")]
        public IActionResult EliminarInfo(int id)
        {
            var result = _services.EliminarInfoCiudad(id);

            return new JsonResult(result) { StatusCode = 200 };
        }
    }
}

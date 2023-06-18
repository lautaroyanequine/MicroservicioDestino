using Application.Exceptions;
using Application.Interfaces.IViajeCiudad;
using Application.Request;
using Application.Request.ViajeCiudad;
using Application.Response.Ciudad;
using Application.Response.ViajeCiudad;
using Microsoft.AspNetCore.Mvc;

namespace Destinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ViajeCiudadController : ControllerBase
    {
        private readonly IViajeCiudadService _service;
        public ViajeCiudadController(IViajeCiudadService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(ViajeCiudadResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult CreateViajeCiudad(ViajeCiudadRequest request)
        {
            try
            {
                var result = _service.CreateViajeCiudad(request);
                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };

            }
            catch (ElementoInexistenteException ciudadInexistente)
            {
                return Conflict(new { message = "No se pudo crear porque no existe la ciudad" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ViajeCiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public IActionResult GetViajeCiudadById(int id)
        {
            try
            {
                var result = _service.GetViajeCiudadById(id);
                return new JsonResult(result);

            }

            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "No se encontro el elemento solicitado" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Hubo un error en los parametros ingresados" });

            }





        }

        [HttpGet]
        [ProducesResponseType(typeof(ViajeCiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetAll(int? viajeId, string? localizacion)
        {
            try
            {
                var result = _service.GetViajeCiudadList(viajeId, localizacion);
                return new JsonResult(result);

            }

            catch (Exception e)
            {
                return BadRequest(new { message = "Algun parametro ingresado es invalido" });

            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ViajeCiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteViajeCiudad(int id)
        {
            try
            {
                var result = _service.RemoveViajeCiudad(id);
                return new JsonResult(result);
            }
            catch (ElementoInexistenteException elementoInexistente)
            { return BadRequest(new { message = "No existe el elemento que quiere eliminar" }); }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]


        public IActionResult UpdateViajeCiudad(int id, ViajeCiudadRequest request)
        {
            try
            {
                var result = _service.UpdateViajeCiudad(id, request);
                return new JsonResult(result);
            }


            catch (IdInvalidoException idInvalido)
            {
                return NotFound(new { message = "La ciudad que desea ingresar no existe" });
            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }

        }

    }
}

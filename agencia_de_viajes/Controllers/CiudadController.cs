using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Request.Ciudad;
using Application.Response.Ciudad;
using Microsoft.AspNetCore.Mvc;

namespace Destinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CiudadController : ControllerBase
    {
        private readonly ICiudadService _service;

        public CiudadController(ICiudadService service) { _service = service; }

        [HttpPost]
        [ProducesResponseType(typeof(CiudadResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult CreateCiudad(CiudadRequest request)
        {
            try
            {
                var result = _service.CreateCiudad(request);
                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };

            }
            catch (ElementoYaExisteException ciudadExistente)
            {
                return Conflict(new { message = "No se pudo crear porque ya existe la ciudad" });

            }
            catch (ElementoInexistenteException e)
            {
                return BadRequest(new { message = "Ingreso una provincia inexistente" });

            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(CiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetAll([FromQuery] string? orden = "ASC", string? nombre = null, string? provincia = null, string? pais = null)
        {
            try
            {
                var result = _service.GetCiudadList(orden, nombre, provincia, pais);
                return new JsonResult(result);

            }
            catch (DatoInvalidoException ex)
            {
                return BadRequest(new { message = "El valor del orden es inválido. Solo se permite 'ASC' o 'DESC" });

            }
            catch (IdInvalidoException elementoInexistente)
            {
                return BadRequest(new { message = "No hay Ciudades de la provincia ingresada" });

            }
            catch (ElementoInexistenteException elementoInexistente)
            {
                return BadRequest(new { message = "No hay Ciudades del pais ingresado" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Algun parametro ingresado es invalido" });

            }

        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(CiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public IActionResult GetCiudadById(int id)
        {
            try
            {
                var result = _service.GetCiudadById(id);
                return new JsonResult(result);

            }

            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "No se encontro la ciudad solicitada" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Hubo un error en los parametros ingresados" });

            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(CiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteCiudad(int id)
        {
            try
            {
                var result = _service.RemoveCiudad(id);
                return new JsonResult(result);
            }
            catch (ElementoInexistenteException elementoInexistente)
            { return BadRequest(new { message = "No existe la ciudad que quiere eliminar" }); }
        }



        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]


        public IActionResult UpdateCiudad(int id, CiudadRequest request)
        {
            try
            {
                var result = _service.UpdateCiudad(id, request);
                return new JsonResult(result);
            }

            catch (ElementoYaExisteException elementoInexistente)
            {
                return Conflict(new { message = "Ya existe la ciudad  que desea ingresar" });
            }
            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "La ciudad que desea modificar no existe" });
            }
            catch (IdInvalidoException idInvalido)
            {
                return BadRequest(new { message = "La Provincia que se le quiere asignar no existe" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }

        }
    }
}

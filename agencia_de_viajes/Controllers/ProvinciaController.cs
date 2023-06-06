using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Request.Provincia;
using Application.Response.Provincia;
using Microsoft.AspNetCore.Mvc;

namespace Destinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciaController : ControllerBase
    {
        private readonly IProvinciaService _service;

        public ProvinciaController(IProvinciaService service) { _service = service; }



        [HttpPost]
        [ProducesResponseType(typeof(ProvinciaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult CreateProvincia(ProvinciaRequest request)
        {
            try
            {
                var result = _service.CreateProvincia(request);
                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };

            }
            catch (ElementoYaExisteException provinciaExistente)
            {
                return Conflict(new { message = "No se pudo crear porque ya existe la provincia" });

            }
            catch (ElementoInexistenteException e)
            {
                return BadRequest(new { message = "Ingreso un pais inexistente" });

            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProvinciaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetAll([FromQuery] string? orden = "ASC", string? nombre = null, string? pais = null)
        {
            try
            {
                var result = _service.GetProvinciaList(orden,nombre,pais);
                return new JsonResult(result);

            }
            catch (DatoInvalidoException ex)
            {
                return BadRequest(new { message = "El valor del orden es inválido. Solo se permite 'ASC' o 'DESC" });

            }
            catch (IdInvalidoException elementoInexistente)
            {
                return BadRequest(new { message = "No hay provincias del pais ingresado" });

            }

            catch (Exception e)
            {
                return BadRequest(new { message = "Algun parametro ingresado es invalido" });

            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(ProvinciaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public IActionResult GetProvinciaById(int id)
        {
            try
            {
                var result = _service.GetProvinciaById(id);
                return new JsonResult(result);

            }

            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "No se encontro la provincia solicitada" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Hubo un error en los parametros ingresados" });

            }





        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(ProvinciaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteProvincia(int id)
        {
            try
            {
                var result = _service.RemoveProvincia(id);
                return new JsonResult(result);
            }
            catch (ElementoInexistenteException elementoInexistente)
            { return BadRequest(new { message = "No existe la provincia que quiere eliminar" }); }
        }



        [HttpPut("{id}")]
        [ProducesResponseType(typeof(ProvinciaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]


        public IActionResult UpdateProvincia(int id, ProvinciaRequest request)
        {
            try
            {
                var result = _service.UpdateProvincia(id, request);
                return new JsonResult(result);
            }

            catch (ElementoYaExisteException elementoInexistente)
            {
                return Conflict(new { message = "Ya existe la provincia  que desea ingresar" });
            }
            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "La provincia que desea modificar no existe" });
            }
            catch (IdInvalidoException idInvalido)
            {
                return BadRequest(new { message = "El pais que se le quiere asignar no existe" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }

        }


    }
}

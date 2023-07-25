using Application.Exceptions;
using Application.Interfaces.IPais;
using Application.Request;
using Application.Request.Pais;
using Application.Response.Pais;
using Microsoft.AspNetCore.Mvc;

namespace Destinos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisController : ControllerBase
    {
        private readonly IPaisService _service;

        public PaisController(IPaisService service)
        {
            _service = service;
        }

        [HttpPost]
        [ProducesResponseType(typeof(PaisResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult CreatePais(PaisRequest request)
        {
            try
            {
                var result = _service.CreatePais(request);
                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };

            }
            catch (ElementoYaExisteException paisExistente)
            {
                return Conflict(new { message = "No se pudo crear porque ya existe el pais" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }
        }

        [HttpGet]
        [ProducesResponseType(typeof(PaisResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetAll([FromQuery] string? orden = "ASC", string? nombre = null)
        {
            try
            {
                var result = _service.GetPaisList(orden, nombre);
                return new JsonResult(result);

            }
            catch (DatoInvalidoException ex)
            {
                return BadRequest(new { message = "El valor del orden es inválido. Solo se permite 'ASC' o 'DESC" });

            }

            catch (Exception e)
            {
                return BadRequest(new { message = "El tipo de mercaderia ingresado no existe" });

            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PaisResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public IActionResult GetPaisById(int id)
        {
            try
            {
                var result = _service.GetPaisById(id);
                return new JsonResult(result);

            }

            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "No se encontro el pais solicitado" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Hubo un error en los parametros ingresados" });

            }





        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(PaisResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeletePais(int id)
        {
            try
            {
                var result = _service.RemovePais(id);
                return new JsonResult(result);
            }
            catch (ElementoInexistenteException elementoInexistente)
            { return BadRequest(new { message = "No existe el pais que quiere eliminar" }); }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(PaisResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]


        public IActionResult UpdatePais(int id, PaisRequest request)
        {
            try
            {
                var result = _service.UpdatePais(id, request);
                return new JsonResult(result);
            }

            catch (ElementoYaExisteException elementoInexistente)
            {
                return Conflict(new { message = "Ya existe el pais que desea ingresar" });
            }
            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "El pais que desea modificar no existe" });
            }
            catch (IdInvalidoException)
            {
                return BadRequest(new { message = "Él pais que quiere ingresar no existe" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }

        }

    }
}

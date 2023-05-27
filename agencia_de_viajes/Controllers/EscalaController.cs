using Application.Exceptions;
using Application.Interfaces;
using Application.Request;
using Application.Request.Ciudad;
using Application.Request.Escala;
using Application.Response.Ciudad;
using Application.Response.Escala;
using Microsoft.AspNetCore.Mvc;

namespace Destinos.Controllers
{
    [Route("api/Destinos/[controller]")]
    [ApiController]
    public class EscalaController : ControllerBase
    {
        private readonly IEscalaService _service;
        public EscalaController(IEscalaService service) { _service = service; }


        [HttpPost]
        [ProducesResponseType(typeof(EscalaResponse), 201)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult CreateEscala(EscalaRequest request)
        {
            try
            {
                var result = _service.CreateEscala(request);
                return new JsonResult(result) { StatusCode = StatusCodes.Status201Created };

            }
            catch(HoraInvalidaException h)
            {
                return BadRequest(new { message = "El formato de horario que se espera es : 13:45 11/05/2023" });

            }
            catch(IdInvalidoException i)
            {
                return BadRequest(new { message = "Ingreso un viaje  inexistente" });

            }

            catch (ElementoInexistenteException e)
            {
                return BadRequest(new { message = "Ingreso una ciudad inexistente" });

            }
        }


        [HttpGet("{id}")]
        [ProducesResponseType(typeof(EscalaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]

        public IActionResult GetEscalaById(int id)
        {
            try
            {
                var result = _service.GetEscalaById(id);
                return new JsonResult(result);

            }

            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "No se encontro la escala solicitada" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Hubo un error en los parametros ingresados" });

            }
        }


        [HttpGet]
        [ProducesResponseType(typeof(EscalaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        public IActionResult GetAll()
        {
            try
            {
                var result = _service.GetEscalaList();
                return new JsonResult(result);

            }

            catch (Exception e)
            {
                return BadRequest(new { message = "Algun parametro ingresado es invalido" });

            }
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(EscalaResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 409)]
        public IActionResult DeleteEscala(int id)
        {
            try
            {
                var result = _service.RemoveEscala(id);
                return new JsonResult(result);
            }
            catch (ElementoInexistenteException elementoInexistente)
            { return BadRequest(new { message = "No existe la escala que quiere eliminar" }); }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(CiudadResponse), 200)]
        [ProducesResponseType(typeof(BadRequest), 400)]
        [ProducesResponseType(typeof(BadRequest), 404)]
        [ProducesResponseType(typeof(BadRequest), 409)]


        public IActionResult Update(int id, EscalaRequest request)
        {
            try
            {
                var result = _service.UpdateEscala(id, request);
                return new JsonResult(result);
            }

          
            catch (ElementoInexistenteException elementoInexistente)
            {
                return NotFound(new { message = "La escala que desea modificar no existe" });
            }
            catch (IdInvalidoException idInvalido)
            {
                return BadRequest(new { message = "La ciudad que se le quiere asignar no existe" });

            }
            catch (HoraInvalidaException h)
            {
                return BadRequest(new { message = "El formato de horario que se espera es : 13:45 11/05/2023" });

            }
            catch (Exception e)
            {
                return BadRequest(new { message = "Ingreso un parametro invalido" });

            }

        }
    }
}

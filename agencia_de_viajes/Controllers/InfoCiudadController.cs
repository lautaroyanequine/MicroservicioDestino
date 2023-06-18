using Application.Interfaces.IInfoCiudad;
using Application.Request.InfoCiudad;
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
        public IActionResult crearInfoCiudad(InfoCiudadRequest request)
        {
            var result = _services.CrearInfoCiudad(request);
            return Ok(result);
        }
    }
}

using Application.Exceptions;
using Application.Interfaces.ICiudad;
using Application.Interfaces.IInfoCiudad;
using Application.Request.InfoCiudad;
using Application.Response.InfoCiudad;
using Domain.Entities;

namespace Application.UseCase.InfoCiudades
{
    public class InfoCiudadService : IInfoCiudadService
    {
        private readonly IInfoCiudadCommand _command;
        private readonly IInfoCiudadQuery _query;
        private readonly ICiudadService _ciudadService;

        public InfoCiudadService(IInfoCiudadCommand command, IInfoCiudadQuery query, ICiudadService ciudadService)
        {
            _command = command;
            _query = query;
            _ciudadService = ciudadService;
        }

        public InfoCiudadResponse CrearInfoCiudad(InfoCiudadRequest request)
        {
            var infoCiudadResponse = new InfoCiudad
            {
                CiudadId = request.Ciudad_Id,
                Descripcion = request.Descripcion,
                ImagenUrl = request.Imagen
            };

           var city = _ciudadService.GetCiudadById(request.Ciudad_Id);

            if(city == null) { throw new DatoInvalidoException(); };

            var newInfoCiudad = _command.CreateInfoCiudad(infoCiudadResponse);
            return GetById(newInfoCiudad.InfoCiudadId);
        }

        public InfoCiudadResponse EditarInfoCiudad(int id, InfoCiudadRequest request)
        {
            var infoCiudadFound = _query.GetById(id);

            if (infoCiudadFound != null)
            {
                infoCiudadFound.Descripcion = request.Descripcion;
                infoCiudadFound.ImagenUrl = request.Imagen;

                var update = _command.UpdateInfoCiudad(id, infoCiudadFound);
                return GetById(update.InfoCiudadId);
            };

            return null;
        }

        public InfoCiudadResponse EliminarInfoCiudad(int id)
        {
            var infoCiudadEliminar = _query.GetById(id);

            if (infoCiudadEliminar != null)
            {
                _command.DeleteInfoCiudad(id);

                return new InfoCiudadResponse
                {
                    Id = infoCiudadEliminar.InfoCiudadId,
                    Ciudad = _ciudadService.GetCiudadById(infoCiudadEliminar.CiudadId).Nombre,
                    Descripcion = infoCiudadEliminar.Descripcion,
                    Imagen = infoCiudadEliminar.ImagenUrl
                };
            }

            return null;
        }

        public List<InfoCiudadResponse> GetAllInfoCiudad()
        {

            List<InfoCiudad> infoCiudades = _query.GetAll();
            List<InfoCiudadResponse> infoCiudadResponses = new List<InfoCiudadResponse>();

            foreach (var info in infoCiudades)
            {
                var response = GetById(info.InfoCiudadId);
                infoCiudadResponses.Add(response);
            }

            return infoCiudadResponses;
        }

        public InfoCiudadResponse GetById(int id)
        {
            var infoCiudadFound = _query.GetById(id);

            if (infoCiudadFound != null)
            {
                return new InfoCiudadResponse
                {
                    Id = infoCiudadFound.InfoCiudadId,
                    Ciudad = _ciudadService.GetCiudadById(infoCiudadFound.CiudadId).Nombre,
                    Descripcion = infoCiudadFound.Descripcion,
                    Imagen = infoCiudadFound.ImagenUrl
                };
            }

            return null;
        }
    }
}

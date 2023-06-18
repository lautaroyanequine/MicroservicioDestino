using Application.Exceptions;
using Application.Interfaces.IPais;
using Application.Interfaces.IProvincia;
using Application.Request.Provincia;
using Application.Response.Pais;
using Application.Response.Provincia;
using Domain.Entities;

namespace Application.UseCase
{
    public class ProvinciaService : IProvinciaService
    {
        private readonly IProvinciaQuery _query;
        private readonly IProvinciaCommand _command;
        private readonly IPaisQuery _queryPais;

        public ProvinciaService(IProvinciaQuery query, IProvinciaCommand command, IPaisQuery queryPais)
        {
            _query = query;
            _command = command;
            _queryPais = queryPais;
        }

        public ProvinciaResponse CreateProvincia(ProvinciaRequest request)
        {
            if (!(_query.GetProvincia(request.Nombre.ToUpper()) == null) && _query.GetProvincia(request.Nombre).PaisId == request.PaisId) throw new ElementoYaExisteException();

            if (_queryPais.GetPais(request.PaisId) == null) throw new ElementoInexistenteException();


            var provincia = new Provincia
            {
                Nombre = request.Nombre,
                PaisId = request.PaisId,
                Pais = _queryPais.GetPais(request.PaisId)

            };

            _command.InsertProvincia(provincia);
            return new ProvinciaResponse
            {
                Id = provincia.ProvinciaId,
                Nombre = request.Nombre,
                Pais = new PaisResponse
                {
                    Id = provincia.PaisId,
                    Nombre = _queryPais.GetPais(request.PaisId).Nombre,
                    Codigo = _queryPais.GetPais(request.PaisId).Codigo

                }
            };
        }

        public ProvinciaResponse GetProvinciaById(int provinciaId)
        {
            var provincia = _query.GetProvincia(provinciaId);
            if (provincia != null)
            {
                return new ProvinciaResponse
                {
                    Id = provincia.PaisId,
                    Nombre = provincia.Nombre,
                    Pais = new PaisResponse
                    {
                        Id = provincia.PaisId,
                        Nombre = _queryPais.GetPais(provincia.PaisId).Nombre,
                        Codigo = _queryPais.GetPais(provincia.PaisId).Codigo

                    }
                };
            }
            else throw new ElementoInexistenteException();
        }


        public List<ProvinciaResponse> GetProvinciaList(string? orden = "ASC", string? nombre = null, string pais = null)
        {
            if (orden.ToUpper() != "ASC" && orden.ToUpper() != "DESC") throw new DatoInvalidoException();
            if (pais != null)
            {
                if (_queryPais.GetPais(pais) == null) throw new IdInvalidoException();

            }

            var provincias = _query.GetProvinciaList(orden, nombre, pais);
            var provinciasResponse = new List<ProvinciaResponse>();

            foreach (var provincia in provincias)
            {
                provinciasResponse.Add(new ProvinciaResponse
                {
                    Id = provincia.ProvinciaId,
                    Nombre = provincia.Nombre,
                    Pais = new PaisResponse
                    {
                        Id = provincia.PaisId,
                        Nombre = _queryPais.GetPais(provincia.PaisId).Nombre,
                        Codigo = _queryPais.GetPais(provincia.PaisId).Codigo



                    }
                });
            }
            return provinciasResponse;
        }

        public ProvinciaResponse RemoveProvincia(int provinciaId)
        {
            var provincia = _command.RemoveProvincia(provinciaId);
            if (provincia == null) throw new ElementoInexistenteException();
            return new ProvinciaResponse
            {
                Id = provincia.ProvinciaId,
                Nombre = provincia.Nombre,
                Pais = new PaisResponse
                {
                    Id = provincia.PaisId,
                    Nombre = _queryPais.GetPais(provincia.PaisId).Nombre,
                    Codigo = _queryPais.GetPais(provincia.PaisId).Codigo


                }
            };
        }

        public ProvinciaResponse UpdateProvincia(int provinciaId, ProvinciaRequest request)
        {

            if (_query.GetProvincia(request.Nombre.ToUpper()) != null) throw new ElementoYaExisteException();
            if (_queryPais.GetPais(request.PaisId) == null) throw new IdInvalidoException();

            var provincia = _command.UpdateProvincia(provinciaId, request);
            if (provincia == null) throw new ElementoInexistenteException();
            return new ProvinciaResponse
            {
                Id = provincia.ProvinciaId,
                Nombre = provincia.Nombre,
                Pais = new PaisResponse
                {
                    Id = provincia.PaisId,
                    Nombre = _queryPais.GetPais(provincia.PaisId).Nombre,
                    Codigo = _queryPais.GetPais(provincia.PaisId).Codigo


                }
            };
        }
    }
}

﻿using Application.Exceptions;
using Application.Interfaces.ICiudad;
using Application.Interfaces.IPais;
using Application.Interfaces.IProvincia;
using Application.Request.Ciudad;
using Application.Response.Ciudad;
using Application.Response.Pais;
using Application.Response.Provincia;
using Domain.Entities;

namespace Application.UseCase
{
    public class CiudadService : ICiudadService
    {
        private readonly ICiudadCommand _command;
        private readonly ICiudadQuery _query;
        private readonly IProvinciaQuery _queryProvincia;
        private readonly IPaisQuery _queryPais;



        public CiudadService(ICiudadCommand command, ICiudadQuery query, IProvinciaQuery queryProvincia, IPaisQuery queryPais)
        {
            _command = command;
            _query = query;
            _queryProvincia = queryProvincia;
            _queryPais = queryPais;
        }

        public CiudadResponse CreateCiudad(CiudadRequest request)
        {
            if (!(_query.GetCiudad(request.Nombre.ToUpper()) == null) && _query.GetCiudad(request.Nombre).ProvinciaId == request.ProvinciaId) throw new ElementoYaExisteException();
            if (_queryProvincia.GetProvincia(request.ProvinciaId) == null) throw new ElementoInexistenteException();

            var ciudad = new Ciudad
            {
                Nombre = request.Nombre,
                ProvinciaId = request.ProvinciaId,
                Provincia = _queryProvincia.GetProvincia(request.ProvinciaId)

            };

            _command.InsertCiudad(ciudad);
            return new CiudadResponse
            {
                Id = ciudad.CiudadId,
                Nombre = request.Nombre,
                Provincia = new ProvinciaResponse
                {
                    Id = ciudad.ProvinciaId,
                    Nombre = _query.GetCiudad(ciudad.CiudadId).Provincia.Nombre,
                    Pais = new PaisResponse
                    {
                        Id = _queryProvincia.GetProvincia(ciudad.ProvinciaId).PaisId,
                        Nombre = _queryProvincia.GetProvincia(ciudad.ProvinciaId).Pais.Nombre,
                        Codigo = _queryProvincia.GetProvincia(ciudad.ProvinciaId).Pais.Codigo

                    }
                }
            };
        }

        public CiudadResponse GetCiudadById(int ciudadId)
        {
            var ciudad = _query.GetCiudad(ciudadId);
            if (ciudad != null)
            {
                return new CiudadResponse
                {
                    Id = ciudad.CiudadId,
                    Nombre = ciudad.Nombre,
                    Provincia = new ProvinciaResponse
                    {
                        Id = ciudad.ProvinciaId,
                        Nombre = _query.GetCiudad(ciudad.CiudadId).Provincia.Nombre,
                        Pais = new PaisResponse
                        {
                            Id = _queryProvincia.GetProvincia(ciudad.ProvinciaId).PaisId,
                            Nombre = _queryProvincia.GetProvincia(ciudad.ProvinciaId).Pais.Nombre
                        }
                    }
                };
            }

            else throw new ElementoInexistenteException();
        }

        public List<CiudadResponse> GetCiudadList(string? orden = "ASC", string? nombre = null, string? provincia = null, string? pais = null)
        {
            if (orden.ToUpper() != "ASC" && orden.ToUpper() != "DESC") throw new DatoInvalidoException();
            if (provincia != null)
            {
                if (_queryProvincia.GetProvincia(provincia) == null) throw new IdInvalidoException();
            }
            if (pais != null)
            {
                if (_queryPais.GetPais(pais) == null) throw new ElementoInexistenteException();

            }

            var ciudades = _query.GetCiudadList(orden, nombre, provincia, pais);
            var ciudadesResponse = new List<CiudadResponse>();

            foreach (var ciudad in ciudades)
            {
                ciudadesResponse.Add(new CiudadResponse
                {
                    Id = ciudad.CiudadId,
                    Nombre = ciudad.Nombre,
                    Provincia = new ProvinciaResponse
                    {
                        Id = ciudad.ProvinciaId,
                        Nombre = _query.GetCiudad(ciudad.CiudadId).Provincia.Nombre,
                        Pais = new PaisResponse
                        {
                            Id = _queryProvincia.GetProvincia(ciudad.ProvinciaId).PaisId,
                            Nombre = _queryProvincia.GetProvincia(ciudad.ProvinciaId).Pais.Nombre,
                            Codigo = _queryProvincia.GetProvincia(ciudad.ProvinciaId).Pais.Codigo

                        }
                    }
                });
            }
            return ciudadesResponse;
        }

        public CiudadResponse RemoveCiudad(int ciudadId)
        {
            var ciudadEliminada = _query.GetCiudad(ciudadId);
            if (ciudadEliminada == null) throw new ElementoInexistenteException();
            var ciudadResponse = new CiudadResponse
            {
                Id = ciudadEliminada.CiudadId,
                Nombre = ciudadEliminada.Nombre,
                Provincia = new ProvinciaResponse
                {
                    Id = ciudadEliminada.ProvinciaId,
                    Nombre = _query.GetCiudad(ciudadEliminada.CiudadId).Provincia.Nombre,
                    Pais = new PaisResponse
                    {
                        Id = _queryProvincia.GetProvincia(ciudadEliminada.ProvinciaId).PaisId,
                        Nombre = _queryProvincia.GetProvincia(ciudadEliminada.ProvinciaId).Pais.Nombre,
                        Codigo = _queryProvincia.GetProvincia(ciudadEliminada.ProvinciaId).Pais.Codigo

                    }
                }
            };
            _command.RemoveCiudad(ciudadId);
            return ciudadResponse;
        }

        public CiudadResponse UpdateCiudad(int ciudadId, CiudadRequest request)
        {

            if (_query.GetCiudad(request.Nombre.ToUpper()) != null) throw new ElementoYaExisteException();
            if (_queryProvincia.GetProvincia(request.ProvinciaId) == null) throw new IdInvalidoException();

            var ciudad = _command.UpdateCiudad(ciudadId, request);
            if (ciudad == null) throw new ElementoInexistenteException();
            return new CiudadResponse
            {
                Id = ciudad.CiudadId,
                Nombre = ciudad.Nombre,
                Provincia = new ProvinciaResponse
                {
                    Id = ciudad.ProvinciaId,
                    Nombre = _query.GetCiudad(ciudad.CiudadId).Provincia.Nombre,
                    Pais = new PaisResponse
                    {
                        Id = _queryProvincia.GetProvincia(ciudad.ProvinciaId).PaisId,
                        Nombre = _queryProvincia.GetProvincia(ciudad.ProvinciaId).Pais.Nombre,
                        Codigo = _queryProvincia.GetProvincia(ciudad.ProvinciaId).Pais.Codigo

                    }
                }
            };
        }
    }
}

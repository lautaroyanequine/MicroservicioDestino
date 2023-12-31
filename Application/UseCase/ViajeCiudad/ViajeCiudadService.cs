﻿using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.ICiudad;
using Application.Interfaces.IPais;
using Application.Interfaces.IProvincia;
using Application.Interfaces.IViajeCiudad;
using Application.Request.ViajeCiudad;
using Application.Response.Ciudad;
using Application.Response.Pais;
using Application.Response.Provincia;
using Application.Response.ViajeCiudad;
using Domain.Entities;

namespace Application.UseCase
{
    public class ViajeCiudadService : IViajeCiudadService
    {
        private readonly IViajeCiudadQuery _query;
        private readonly IViajeCiudadCommand _command;
        private readonly ICiudadQuery _queryCiudad;
        private readonly IPaisQuery _queryPais;
        private readonly IProvinciaQuery _queryProvincia;
        private readonly IClientViaje _clientViaje;




        public ViajeCiudadService(IViajeCiudadQuery query, IViajeCiudadCommand command, ICiudadQuery queryCiudad, IProvinciaQuery queryProvincia, IPaisQuery queryPais, IClientViaje clientViaje)
        {
            _query = query;
            _command = command;
            _queryCiudad = queryCiudad;
            _queryProvincia = queryProvincia;
            _queryPais = queryPais;
            _clientViaje = clientViaje;
        }

        public ViajeCiudadResponse CreateViajeCiudad(ViajeCiudadRequest request)
        {
            if (_queryCiudad.GetCiudad(request.CiudadId) == null) throw new ElementoInexistenteException();

            //var response = _clientViaje.ObtenerViaje(request.ViajeId);


            var viajeCiudad = new ViajeCiudad
            {
                CiudadId = request.CiudadId,
                ViajeId = request.ViajeId,
                Ciudad = _queryCiudad.GetCiudad(request.CiudadId),
                Tipo = request.Tipo
            };
            _command.InsertViajeCiudad(viajeCiudad);
            return new ViajeCiudadResponse
            {
                Id = viajeCiudad.ViajeCiudadId,
                Ciudad = new CiudadResponse
                {
                    Id = viajeCiudad.CiudadId,
                    Nombre = viajeCiudad.Ciudad.Nombre,
                    Provincia = new ProvinciaResponse
                    {

                        Id = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).ProvinciaId,
                        Nombre = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).Nombre,
                        Pais = new PaisResponse
                        {
                            Id = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).PaisId,
                            Nombre = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Nombre,
                            Codigo = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Codigo

                        }
                    }

                },
                ViajeId = viajeCiudad.ViajeId
            };
        }

        public ViajeCiudadResponse GetViajeCiudadById(int viajeCiudadId)
        {
            var viajeCiudad = _query.GetViajeCiudad(viajeCiudadId);
            if (viajeCiudad != null)
            {
                return new ViajeCiudadResponse
                {
                    Id = viajeCiudad.ViajeCiudadId,
                    Ciudad = new CiudadResponse
                    {
                        Id = viajeCiudad.CiudadId,
                        Nombre = viajeCiudad.Ciudad.Nombre,
                        Provincia = new ProvinciaResponse
                        {

                            Id = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).ProvinciaId,
                            Nombre = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).Nombre,
                            Pais = new PaisResponse
                            {
                                Id = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).PaisId,
                                Nombre = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Nombre,
                                Codigo = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Codigo

                            }
                        }

                    },
                    ViajeId = viajeCiudad.ViajeId
                };

            }
            else throw new ElementoInexistenteException();
        }

        public List<ViajeCiudadResponse> GetViajeCiudadList(int? viajeId, string? localizacion)
        {
            var viajesCiudades = _query.GetViajeCiudadList(viajeId, localizacion);
            var viajesCiudadesResponse = new List<ViajeCiudadResponse>();

            foreach (var viajeCiudad in viajesCiudades)
            {
                viajesCiudadesResponse.Add(new ViajeCiudadResponse
                {


                    Id = viajeCiudad.ViajeCiudadId,
                    Ciudad = new CiudadResponse
                    {
                        Id = viajeCiudad.CiudadId,
                        Nombre = viajeCiudad.Ciudad.Nombre,
                        Provincia = new ProvinciaResponse
                        {

                            Id = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).ProvinciaId,
                            Nombre = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).Nombre,
                            Pais = new PaisResponse
                            {
                                Id = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).PaisId,
                                Nombre = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Nombre,
                                Codigo = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Codigo

                            }
                        }

                    },
                    ViajeId = viajeCiudad.ViajeId,
                    Tipo = viajeCiudad.Tipo
                });
            }
            return viajesCiudadesResponse;
        }

        public ViajeCiudadResponse RemoveViajeCiudad(int viajeCiudadId)
        {
            var viajeCiudad = _command.RemoveViajeCiudad(viajeCiudadId);
            if (viajeCiudad == null) throw new ElementoInexistenteException();
            return new ViajeCiudadResponse
            {
                Id = viajeCiudad.ViajeCiudadId,
                Ciudad = new CiudadResponse
                {
                    Id = viajeCiudad.CiudadId,
                    Nombre = _queryCiudad.GetCiudad(viajeCiudad.CiudadId).Nombre,
                    Provincia = new ProvinciaResponse
                    {

                        Id = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).ProvinciaId,
                        Nombre = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).Nombre,
                        Pais = new PaisResponse
                        {
                            Id = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).PaisId,
                            Nombre = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Nombre,
                            Codigo = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Codigo

                        }
                    }

                },
                ViajeId = viajeCiudad.ViajeId
            };
        }

        public ViajeCiudadResponse UpdateViajeCiudad(int viajeCiudadId, ViajeCiudadRequest request)
        {

            if (_queryCiudad.GetCiudad(request.CiudadId) == null) throw new IdInvalidoException();

            var response = _clientViaje.ObtenerViaje(request.ViajeId);


            var viajeCiudad = _command.UpdateViajeCiudad(viajeCiudadId, request);
            if (viajeCiudad == null) throw new ElementoInexistenteException();
            return new ViajeCiudadResponse
            {
                Id = viajeCiudad.ViajeCiudadId,
                Ciudad = new CiudadResponse
                {
                    Id = viajeCiudad.CiudadId,
                    Nombre = viajeCiudad.Ciudad.Nombre,
                    Provincia = new ProvinciaResponse
                    {

                        Id = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).ProvinciaId,
                        Nombre = _queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).Nombre,
                        Pais = new PaisResponse
                        {
                            Id = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).PaisId,
                            Nombre = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Nombre,
                            Codigo = _queryPais.GetPais(_queryProvincia.GetProvincia(viajeCiudad.Ciudad.ProvinciaId).PaisId).Codigo

                        }
                    }

                },
                ViajeId = viajeCiudad.ViajeId
            };

        }
    }
}

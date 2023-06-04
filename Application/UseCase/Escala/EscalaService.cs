using Application.Exceptions;
using Application.Interfaces;
using Application.Request.Escala;
using Application.Response.Ciudad;
using Application.Response.Escala;
using Application.Response.Pais;
using Application.Response.Provincia;
using Domain.Entities;
using System.Globalization;

namespace Application.UseCase
{
    public class EscalaService : IEscalaService
    {
        private readonly IEscalaQuery _query;
        private readonly IEscalaCommand _command;
        private readonly ICiudadQuery _ciudadQuery;
        private readonly IClientViaje _clientViaje;

        public EscalaService(IEscalaQuery query, IEscalaCommand command, ICiudadQuery ciudadQuery, IClientViaje clientViaje)
        {
            _query = query;
            _command = command;
            _ciudadQuery = ciudadQuery;
            _clientViaje = clientViaje;
        }

        public EscalaResponse CreateEscala(EscalaRequest request)
        {
            string format = "H:mm dd/MM/yyyy";
            DateTime horaLlegada,horaSalida;
            if ((!DateTime.TryParseExact(request.HoraLlegada, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out horaLlegada)) || !(DateTime.TryParseExact(request.HoraSalida, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out horaSalida)))
                throw new HoraInvalidaException();
          
            
            


            if( _ciudadQuery.GetCiudad(request.CiudadId)==null) throw new ElementoInexistenteException();

            var response = _clientViaje.ObtenerViaje(request.ViajeId);

            var escala = new Escala
            {
                NombreParada = request.NombreParada,
                HoraLlegada = horaLlegada,
                HoraSalida = horaSalida,
                ViajeId= request.ViajeId,
                CiudadId = request.CiudadId,
                Ciudad= _ciudadQuery.GetCiudad(request.CiudadId)

            };

            _command.InsertEscala(escala);
            return new EscalaResponse
            {
                Id = escala.EscalaId,
                NombreParada = escala.NombreParada,
               HoraLlegada= escala.HoraLlegada,
               HoraSalida= escala.HoraSalida,
               ViajeId= escala.ViajeId,
               Ciudad = new CiudadResponse
               {
                   Id = escala.CiudadId,
                   Nombre= escala.Ciudad.Nombre,
                   Provincia= new ProvinciaResponse
                   {
                       Id= escala.Ciudad.ProvinciaId,
                       Nombre=escala.Ciudad.Provincia.Nombre,
                       Pais= new PaisResponse
                       {
                           Id= escala.Ciudad.Provincia.PaisId,
                           Nombre = escala.Ciudad.Provincia.Pais.Nombre,
                          
                       }
                   }
               }
            };
        }

        public EscalaResponse GetEscalaById(int escalaId)
        {
            var escala = _query.GetEscala(escalaId);
            if (escala != null)
            {
                return new EscalaResponse
                {
                    Id = escala.EscalaId,
                    NombreParada = escala.NombreParada,
                    HoraLlegada = escala.HoraLlegada,
                    HoraSalida = escala.HoraSalida,
                    ViajeId = escala.ViajeId,
                    Ciudad = new CiudadResponse
                    {
                        Id = escala.CiudadId,
                        Nombre = escala.Ciudad.Nombre,
                        Provincia = new ProvinciaResponse
                        {
                            Id = escala.Ciudad.ProvinciaId,
                            Nombre = escala.Ciudad.Provincia.Nombre,
                            Pais = new PaisResponse
                            {
                                Id = escala.Ciudad.Provincia.PaisId,
                                Nombre = escala.Ciudad.Provincia.Pais.Nombre,

                            }
                        }
                    }
                };
            }
            else throw new ElementoInexistenteException();

        }

        public List<EscalaResponse> GetEscalaList()
        {
            var escalas = _query.GetEscalaList();
            var escalasResponse = new List<EscalaResponse>();

            foreach (var escala in escalas)
            {
                escalasResponse.Add(new EscalaResponse
                {
                    Id = escala.EscalaId,
                    NombreParada = escala.NombreParada,
                    HoraLlegada = escala.HoraLlegada,
                    HoraSalida = escala.HoraSalida,
                    ViajeId = escala.ViajeId,
                    Ciudad = new CiudadResponse
                    {
                        Id = escala.CiudadId,
                        Nombre = escala.Ciudad.Nombre,
                        Provincia = new ProvinciaResponse
                        {
                            Id = escala.Ciudad.ProvinciaId,
                            Nombre = escala.Ciudad.Provincia.Nombre,
                            Pais = new PaisResponse
                            {
                                Id = escala.Ciudad.Provincia.PaisId,
                                Nombre = escala.Ciudad.Provincia.Pais.Nombre,

                            }
                        }
                    }
                });
            }
            return escalasResponse;
        }

        public EscalaResponse RemoveEscala(int escalaId)
        {
            var escalaEliminada = _query.GetEscala(escalaId);
            if (escalaEliminada == null) throw new ElementoInexistenteException();
            var escalaResponse = new EscalaResponse
            {
                Id = escalaEliminada.EscalaId,
                NombreParada = escalaEliminada.NombreParada,
                HoraLlegada = escalaEliminada.HoraLlegada,
                HoraSalida = escalaEliminada.HoraSalida,
                ViajeId = escalaEliminada.ViajeId,
                Ciudad = new CiudadResponse
                {
                    Id = escalaEliminada.CiudadId,
                    Nombre = escalaEliminada.Ciudad.Nombre,
                    Provincia = new ProvinciaResponse
                    {
                        Id = escalaEliminada.Ciudad.ProvinciaId,
                        Nombre = escalaEliminada.Ciudad.Provincia.Nombre,
                        Pais = new PaisResponse
                        {
                            Id = escalaEliminada.Ciudad.Provincia.PaisId,
                            Nombre = escalaEliminada.Ciudad.Provincia.Pais.Nombre,

                        }
                    }
                }
            };
            _command.RemoveEscala(escalaId);
            return escalaResponse;
        }

        public EscalaResponse UpdateEscala(int escalaId, EscalaRequest request)
        {
           
            if (_ciudadQuery.GetCiudad(request.CiudadId) == null) throw new IdInvalidoException();

            string format = "H:mm dd/MM/yyyy";
            DateTime horaLlegada, horaSalida;
            if ((!DateTime.TryParseExact(request.HoraLlegada, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out horaLlegada)) || !(DateTime.TryParseExact(request.HoraSalida, format, CultureInfo.InvariantCulture, DateTimeStyles.None, out horaSalida)))
            throw new HoraInvalidaException();

            var response = _clientViaje.ObtenerViaje(request.ViajeId);


            var escala = _command.UpdateEscala(escalaId, request,horaLlegada,horaSalida);
            if (escala == null) throw new ElementoInexistenteException();
            return new EscalaResponse
            {
                Id = escala.EscalaId,
                NombreParada = escala.NombreParada,
                HoraLlegada = escala.HoraLlegada,
                HoraSalida = escala.HoraSalida,
                ViajeId = escala.ViajeId,
                Ciudad = new CiudadResponse
                {
                    Id = escala.CiudadId,
                    Nombre = escala.Ciudad.Nombre,
                    Provincia = new ProvinciaResponse
                    {
                        Id = escala.Ciudad.ProvinciaId,
                        Nombre = escala.Ciudad.Provincia.Nombre,
                        Pais = new PaisResponse
                        {
                            Id = escala.Ciudad.Provincia.PaisId,
                            Nombre = escala.Ciudad.Provincia.Pais.Nombre,

                        }
                    }
                }
            };
        }
    }
}

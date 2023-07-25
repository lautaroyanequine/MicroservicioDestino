using Application.Exceptions;
using Application.Interfaces.IPais;
using Application.Request.Pais;
using Application.Response.Pais;
using Domain.Entities;
using Newtonsoft.Json;

namespace Application.UseCase
{
    public class PaisService : IPaisService
    {
        private readonly IPaisCommand _command;
        private readonly IPaisQuery _query;

        public PaisService(IPaisCommand command, IPaisQuery query)
        {
            _command = command;
            _query = query;
        }


        public  PaisResponse CreatePais(PaisRequest request)
        {

            if (!(_query.GetPais(request.Nombre.ToUpper()) == null)) throw new ElementoYaExisteException();

            var pais = new Pais
            {
                Nombre = request.Nombre,
                Codigo = request.Codigo
            };
            _command.InsertPais(pais);
            return new PaisResponse
            {
                Id = pais.PaisId,
                Nombre = request.Nombre,
                Codigo = pais.Codigo

            };

        }

        public PaisResponse GetPaisById(int paisId)
        {
            var pais = _query.GetPais(paisId);
            if (pais != null)
            {
                return new PaisResponse { Id = pais.PaisId, Nombre = pais.Nombre, Codigo = pais.Codigo };
            }
            else throw new ElementoInexistenteException();
        }

        public List<PaisResponse> GetPaisList(string? orden = "ASC", string? nombre = null)
        {
            if (orden.ToUpper() != "ASC" && orden.ToUpper() != "DESC") throw new DatoInvalidoException();

            var paises = _query.GetPaisList(orden, nombre);
            var paisesResponses = new List<PaisResponse>();

            foreach (var pais in paises)
            {
                paisesResponses.Add(new PaisResponse
                {
                    Id = pais.PaisId,
                    Nombre = pais.Nombre,
                    Codigo = pais.Codigo
                });
            }
            return paisesResponses;


        }

        public PaisResponse RemovePais(int paisId)
        {
            var pais = _command.RemovePais(paisId);
            if (pais == null) throw new ElementoInexistenteException();
            return new PaisResponse
            {
                Id = pais.PaisId,
                Nombre = pais.Nombre,
                Codigo = pais.Codigo

            };
        }

        public PaisResponse UpdatePais(int paisId, PaisRequest request)
        {


            if (_query.GetPais(request.Nombre.ToUpper()) != null) throw new ElementoYaExisteException();
            var pais = _command.UpdatePais(paisId, request);
            if (pais == null) throw new ElementoInexistenteException();
            return new PaisResponse
            {
                Id = pais.PaisId,
                Nombre = pais.Nombre,
                Codigo = pais.Codigo

            };

        }
    }
}

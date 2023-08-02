using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.ICiudad;
using Application.Interfaces.IPais;
using Application.Interfaces.IProvincia;
using Application.Interfaces.IViajeCiudad;
using Application.Request.ViajeCiudad;
using Application.Response.ViajeCiudad;
using Application.UseCase;
using Domain.Entities;
using FluentAssertions;
using Moq;

namespace TestDestinos
{
    public class ViajeCiudadTests
    {
        private readonly Mock<IViajeCiudadCommand> mockViajeCiudadCommand;
        private readonly Mock<IViajeCiudadQuery> mockViajeCiudadQuery;
        private readonly Mock<ICiudadQuery> mockCiudadQuery;
        private readonly Mock<IProvinciaQuery> mockProvinciaQuery;
        private readonly Mock<IPaisQuery> mockPaisQuery;
        private readonly Mock<IClientViaje> mockClientViaje;
        private readonly ViajeCiudadService viajeCiudadService;

        public ViajeCiudadTests()
        {
            mockViajeCiudadCommand = new Mock<IViajeCiudadCommand>();
            mockViajeCiudadQuery = new Mock<IViajeCiudadQuery>();
            mockCiudadQuery = new Mock<ICiudadQuery>();
            mockProvinciaQuery = new Mock<IProvinciaQuery>();
            mockPaisQuery = new Mock<IPaisQuery>();
            mockClientViaje = new Mock<IClientViaje>();

            viajeCiudadService = new ViajeCiudadService(mockViajeCiudadQuery.Object, mockViajeCiudadCommand.Object, mockCiudadQuery.Object, mockProvinciaQuery.Object, mockPaisQuery.Object, mockClientViaje.Object);
        }


        [Fact]
        public void CreateViajeCiudad_WithValidRequest_ReturnsCreateViajeCiudadResponse()
        {
            //Arrange
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var paisEspaña = new Pais { PaisId = 2, Nombre = "España", Codigo = "ESP" };

            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=paisArgentina },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=paisArgentina},
                new Provincia { ProvinciaId = 3, Nombre = "Madrid", PaisId = 2 ,Pais=paisEspaña}

            };
            var ciudades = new List<Ciudad>
            {

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = 1 },
            };

            var request = new ViajeCiudadRequest { ViajeId = 1, CiudadId = 1, Tipo = "Destino" };

            mockCiudadQuery.Setup(x => x.GetCiudad(request.CiudadId)).Returns((Ciudad)ciudades[0]);
            mockProvinciaQuery.Setup(x => x.GetProvincia(1)).Returns((Provincia)provincias[1]);
            mockPaisQuery.Setup(x => x.GetPais(1)).Returns((Pais)paisArgentina);

            var viajeCiudad = new ViajeCiudad() { CiudadId = request.CiudadId, ViajeId = request.ViajeId, Ciudad = ciudades[0], Tipo = request.Tipo };

            mockViajeCiudadCommand.Setup(x => x.InsertViajeCiudad(viajeCiudad))
                .Callback<ViajeCiudad>(vc => viajeCiudad = vc);

            //Act
            ViajeCiudadResponse result = viajeCiudadService.CreateViajeCiudad(request);

            result.Should().NotBeNull();
            result.ViajeId.Should().Be(request.ViajeId);
            result.Ciudad.Should().NotBeNull();
            result.Ciudad.Id.Should().Be(ciudades[0].CiudadId);
            result.Ciudad.Nombre.Should().Be(ciudades[0].Nombre);
            result.Ciudad.Provincia.Should().NotBeNull();
            result.Ciudad.Provincia.Id.Should().Be(provincias[1].ProvinciaId);
            result.Ciudad.Provincia.Nombre.Should().Be(provincias[1].Nombre);
            result.Ciudad.Provincia.Pais.Should().NotBeNull();
            result.Ciudad.Provincia.Pais.Id.Should().Be(paisArgentina.PaisId);
            result.Ciudad.Provincia.Pais.Nombre.Should().Be(paisArgentina.Nombre);
            result.Ciudad.Provincia.Pais.Codigo.Should().Be(paisArgentina.Codigo);
            result.Id.Should().Be(viajeCiudad.ViajeCiudadId);

        }



        [Fact]
        public void CreateViajeCiudad_ThrowElementoInexistenteException()
        {
            var request = new ViajeCiudadRequest { ViajeId = 1, CiudadId = 1, Tipo = "Destino" };

            mockCiudadQuery.Setup(q => q.GetCiudad(request.CiudadId)).Returns((Ciudad)null);
            // Act & Assert
            Assert.Throws<ElementoInexistenteException>(() => viajeCiudadService.CreateViajeCiudad(request));
        }

        [Fact]
        public void GetViajeCiudadById_ReturnViajeCiudadResponse()
        {

            //Arrange

            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var paisEspaña = new Pais { PaisId = 2, Nombre = "España", Codigo = "ESP" };

            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=paisArgentina },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=paisArgentina},
                new Provincia { ProvinciaId = 3, Nombre = "Madrid", PaisId = 2 ,Pais=paisEspaña}

            };
            var ciudades = new List<Ciudad>
            {

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = 1 },
            };

            var viajeCiudad = new ViajeCiudad() { ViajeCiudadId = 1, CiudadId = 1, ViajeId = 1, Ciudad = ciudades[0], Tipo = "Destino" };
            mockViajeCiudadQuery.Setup(x => x.GetViajeCiudad(1)).Returns(viajeCiudad);
            mockCiudadQuery.Setup(x => x.GetCiudad(viajeCiudad.CiudadId)).Returns((Ciudad)ciudades[0]);
            mockProvinciaQuery.Setup(x => x.GetProvincia(viajeCiudad.Ciudad.ProvinciaId)).Returns((Provincia)provincias[1]);
            mockPaisQuery.Setup(x => x.GetPais(viajeCiudad.Ciudad.Provincia.PaisId)).Returns((Pais)paisArgentina);
            //Act

            ViajeCiudadResponse result = viajeCiudadService.GetViajeCiudadById(1);

            result.Should().NotBeNull();
            result.ViajeId.Should().Be(viajeCiudad.ViajeId);
            result.Ciudad.Should().NotBeNull();
            result.Ciudad.Id.Should().Be(ciudades[0].CiudadId);
            result.Ciudad.Nombre.Should().Be(ciudades[0].Nombre);
            result.Ciudad.Provincia.Should().NotBeNull();
            result.Ciudad.Provincia.Id.Should().Be(provincias[1].ProvinciaId);
            result.Ciudad.Provincia.Nombre.Should().Be(provincias[1].Nombre);
            result.Ciudad.Provincia.Pais.Should().NotBeNull();
            result.Ciudad.Provincia.Pais.Id.Should().Be(paisArgentina.PaisId);
            result.Ciudad.Provincia.Pais.Nombre.Should().Be(paisArgentina.Nombre);
            result.Ciudad.Provincia.Pais.Codigo.Should().Be(paisArgentina.Codigo);
            result.Id.Should().Be(viajeCiudad.ViajeCiudadId);
        }

        [Fact]
        public void GetViajeCiudadById_ThrowElementoInexistenteException()
        {
            //Arrange

            mockViajeCiudadQuery.Setup(q => q.GetViajeCiudad(It.IsAny<int>())).Returns((ViajeCiudad)null);

            // Act Assert
            Assert.Throws<ElementoInexistenteException>(() => viajeCiudadService.GetViajeCiudadById(It.IsAny<int>()));


        }

        [Fact]
        public void RemoveViajeCiudad_WithValidRequest_ReturnsRemoveViajeCiudadResponse()
        {
            //Arrange
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var paisEspaña = new Pais { PaisId = 2, Nombre = "España", Codigo = "ESP" };

            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=paisArgentina },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=paisArgentina},
                new Provincia { ProvinciaId = 3, Nombre = "Madrid", PaisId = 2 ,Pais=paisEspaña}

            };
            var ciudades = new List<Ciudad>
            {

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = 1 },
            };

            var viajeCiudad = new ViajeCiudad() { ViajeCiudadId = 1, CiudadId = 1, ViajeId = 1, Ciudad = ciudades[0], Tipo = "Escala" };


            mockCiudadQuery.Setup(x => x.GetCiudad(viajeCiudad.Ciudad.CiudadId)).Returns((Ciudad)ciudades[0]);
            mockProvinciaQuery.Setup(x => x.GetProvincia(viajeCiudad.Ciudad.Provincia.ProvinciaId)).Returns((Provincia)provincias[1]);
            mockPaisQuery.Setup(x => x.GetPais(viajeCiudad.Ciudad.Provincia.Pais.PaisId)).Returns((Pais)paisArgentina);


            mockViajeCiudadCommand.Setup(x => x.RemoveViajeCiudad(1)).Returns((ViajeCiudad)viajeCiudad);

            //Act
            ViajeCiudadResponse result = viajeCiudadService.RemoveViajeCiudad(1);

            result.ViajeId.Should().Be(viajeCiudad.ViajeId);
            result.Ciudad.Should().NotBeNull();
            result.Ciudad.Id.Should().Be(ciudades[0].CiudadId);
            result.Ciudad.Nombre.Should().Be(ciudades[0].Nombre);
            result.Ciudad.Provincia.Should().NotBeNull();
            result.Ciudad.Provincia.Id.Should().Be(provincias[1].ProvinciaId);
            result.Ciudad.Provincia.Nombre.Should().Be(provincias[1].Nombre);
            result.Ciudad.Provincia.Pais.Should().NotBeNull();
            result.Ciudad.Provincia.Pais.Id.Should().Be(paisArgentina.PaisId);
            result.Ciudad.Provincia.Pais.Nombre.Should().Be(paisArgentina.Nombre);
            result.Ciudad.Provincia.Pais.Codigo.Should().Be(paisArgentina.Codigo);
            result.Id.Should().Be(viajeCiudad.ViajeCiudadId);

        }



        [Fact]
        public void RemoveViajeCiudad_ThrowElementoInexistenteException()
        {
            //Arrange
            mockViajeCiudadCommand.Setup(q => q.RemoveViajeCiudad(It.IsAny<int>())).Returns((ViajeCiudad)null);

            Assert.Throws<ElementoInexistenteException>(() => viajeCiudadService.RemoveViajeCiudad(1));

        }


        //[Fact]
        [Fact]
        public void UpdateViajeCiudad_WithValidRequest_ReturnsUpdateViajeCiudadResponse()
        {
            //Arrange
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var paisEspaña = new Pais { PaisId = 2, Nombre = "España", Codigo = "ESP" };

            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=paisArgentina },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=paisArgentina},
                new Provincia { ProvinciaId = 3, Nombre = "Madrid", PaisId = 2 ,Pais=paisEspaña}

            };
            var ciudades = new List<Ciudad>
            {

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = 1 },
            };

            var request = new ViajeCiudadRequest { ViajeId = 1, CiudadId = 1, Tipo = "Destino" };

            mockCiudadQuery.Setup(x => x.GetCiudad(request.CiudadId)).Returns((Ciudad)ciudades[0]);
            mockProvinciaQuery.Setup(x => x.GetProvincia(1)).Returns((Provincia)provincias[1]);
            mockPaisQuery.Setup(x => x.GetPais(1)).Returns((Pais)paisArgentina);


            mockViajeCiudadCommand.Setup(x => x.UpdateViajeCiudad(1, request))
                .Returns(new ViajeCiudad { ViajeCiudadId = 1, CiudadId = request.CiudadId, ViajeId = request.ViajeId, Ciudad = ciudades[0], Tipo = request.Tipo });

            //Act
            ViajeCiudadResponse result = viajeCiudadService.UpdateViajeCiudad(1, request);

            result.Should().NotBeNull();
            result.ViajeId.Should().Be(request.ViajeId);
            result.Ciudad.Should().NotBeNull();
            result.Ciudad.Id.Should().Be(ciudades[0].CiudadId);
            result.Ciudad.Nombre.Should().Be(ciudades[0].Nombre);
            result.Ciudad.Provincia.Should().NotBeNull();
            result.Ciudad.Provincia.Id.Should().Be(provincias[1].ProvinciaId);
            result.Ciudad.Provincia.Nombre.Should().Be(provincias[1].Nombre);
            result.Ciudad.Provincia.Pais.Should().NotBeNull();
            result.Ciudad.Provincia.Pais.Id.Should().Be(paisArgentina.PaisId);
            result.Ciudad.Provincia.Pais.Nombre.Should().Be(paisArgentina.Nombre);
            result.Ciudad.Provincia.Pais.Codigo.Should().Be(paisArgentina.Codigo);
            result.Id.Should().Be(1);

        }



        [Fact]
        public void UpdateViajeCiudad_ThrowElementoInexistenteException()
        {
            //Arrange
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var paisEspaña = new Pais { PaisId = 2, Nombre = "España", Codigo = "ESP" };

            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=paisArgentina },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=paisArgentina},
                new Provincia { ProvinciaId = 3, Nombre = "Madrid", PaisId = 2 ,Pais=paisEspaña}

            };
            var ciudades = new List<Ciudad>
            {

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = 1 },
            };

            var request = new ViajeCiudadRequest { ViajeId = 1, CiudadId = 1, Tipo = "Destino" };

            mockCiudadQuery.Setup(x => x.GetCiudad(request.CiudadId)).Returns((Ciudad)ciudades[0]);
            mockViajeCiudadCommand.Setup(x => x.UpdateViajeCiudad(request.CiudadId, request)).Returns((ViajeCiudad)null);



            //Act Y assert
            Assert.Throws<ElementoInexistenteException>(() => viajeCiudadService.UpdateViajeCiudad(1, request));
        }

        [Fact]
        public void UpdateViajeCiudad_ThrowIdInvalidoException()
        {
            //Arrange
            var request = new ViajeCiudadRequest { ViajeId = 1, CiudadId = 1, Tipo = "Destino" };
            mockCiudadQuery.Setup(x => x.GetCiudad(It.IsAny<int>())).Returns((Ciudad)null);


            //Act Y assert
            Assert.Throws<IdInvalidoException>(() => viajeCiudadService.UpdateViajeCiudad(1, request));
        }




        [Fact]
        public void GetViajeCiudadList_ReturnsViajeCiudadResponses()
        {
             // Arrange
            
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var paisEspaña = new Pais { PaisId = 2, Nombre = "España", Codigo = "ESP" };

            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=paisArgentina },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=paisArgentina},
                new Provincia { ProvinciaId = 3, Nombre = "Madrid", PaisId = 2 ,Pais=paisEspaña}

            };
            var ciudades = new List<Ciudad>
            {
                new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = provincias[2].ProvinciaId },
            };
            var viajeCiudades = new List<ViajeCiudad>
            {
                new ViajeCiudad {ViajeCiudadId = 1, ViajeId = 1,CiudadId = 1,Ciudad=ciudades[0],Tipo ="Origen"},
                new ViajeCiudad {ViajeCiudadId = 2, ViajeId = 1,CiudadId = 2,Ciudad=ciudades[1],Tipo ="Destino"},
                new ViajeCiudad {ViajeCiudadId = 3, ViajeId = 2,CiudadId = 3,Ciudad=ciudades[2],Tipo ="Origen"},
                new ViajeCiudad {ViajeCiudadId = 1, ViajeId = 2,CiudadId = 4,Ciudad=ciudades[3],Tipo ="Destino"}
            };

            mockViajeCiudadQuery.Setup(x => x.GetViajeCiudadList(null, null)).Returns((List<ViajeCiudad>)viajeCiudades.OrderBy(v => v.ViajeId).ToList());


            mockCiudadQuery.Setup(x => x.GetCiudad(It.IsAny<int>())).Returns((int ciudadId) =>
            {
                var ciudad = ciudades.FirstOrDefault(c => c.CiudadId == ciudadId);
                if (ciudad != null)
                {
                    ciudad.Provincia = provincias.FirstOrDefault(p => p.ProvinciaId == ciudad.ProvinciaId);
                }
                return ciudad;
            });
            mockProvinciaQuery.Setup(x => x.GetProvincia(It.IsAny<int>())).Returns((int provinciaId) => provincias.FirstOrDefault(p => p.ProvinciaId == provinciaId));
            mockPaisQuery.Setup(x => x.GetPais(It.IsAny<int>())).Returns((int paisId) => paisId == 1 ? paisArgentina : paisEspaña);


            // Act
            var result = viajeCiudadService.GetViajeCiudadList(null, null);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(viajeCiudades.Count);

            for (int i = 0; i < viajeCiudades.Count; i++)
            {
                var expectedViajeCiudad = viajeCiudades[i];
                var actualViajeCiudad = result[i];

                actualViajeCiudad.Id.Should().Be(expectedViajeCiudad.ViajeCiudadId);
                actualViajeCiudad.ViajeId.Should().Be(expectedViajeCiudad.ViajeId);
                actualViajeCiudad.Tipo.Should().Be(expectedViajeCiudad.Tipo);
                actualViajeCiudad.Ciudad.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Id.Should().Be(expectedViajeCiudad.Ciudad.CiudadId);
                actualViajeCiudad.Ciudad.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Provincia.Id.Should().Be(expectedViajeCiudad.Ciudad.Provincia.ProvinciaId);
                actualViajeCiudad.Ciudad.Provincia.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Pais.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Provincia.Pais.Id.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.PaisId);
                actualViajeCiudad.Ciudad.Provincia.Pais.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Pais.Codigo.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.Codigo);
            }
        }


        [Fact]
        public void GetViajeCiudadList_WithViajeIdFilter_ReturnsViajeCiudadResponses()
        {
            // Arrange

            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var paisEspaña = new Pais { PaisId = 2, Nombre = "España", Codigo = "ESP" };

            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=paisArgentina },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=paisArgentina},
                new Provincia { ProvinciaId = 3, Nombre = "Madrid", PaisId = 2 ,Pais=paisEspaña}

            };
            var ciudades = new List<Ciudad>
            {
                new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = provincias[2].ProvinciaId },
            };
            var viajeCiudades = new List<ViajeCiudad>
            {
                new ViajeCiudad {ViajeCiudadId = 1, ViajeId = 1,CiudadId = 1,Ciudad=ciudades[0],Tipo ="Origen"},
                new ViajeCiudad {ViajeCiudadId = 2, ViajeId = 1,CiudadId = 2,Ciudad=ciudades[1],Tipo ="Destino"},
                new ViajeCiudad {ViajeCiudadId = 3, ViajeId = 2,CiudadId = 3,Ciudad=ciudades[2],Tipo ="Origen"},
                new ViajeCiudad {ViajeCiudadId = 4, ViajeId = 2,CiudadId = 4,Ciudad=ciudades[3],Tipo ="Destino"}
            };

            mockViajeCiudadQuery.Setup(x => x.GetViajeCiudadList(1, null)).Returns((List<ViajeCiudad>)viajeCiudades
                .Where(p => p.ViajeId == 1)
                .OrderBy(v => v.ViajeId).ToList());


            mockCiudadQuery.Setup(x => x.GetCiudad(It.IsAny<int>())).Returns((int ciudadId) =>
            {
                var ciudad = ciudades.FirstOrDefault(c => c.CiudadId == ciudadId);
                if (ciudad != null)
                {
                    ciudad.Provincia = provincias.FirstOrDefault(p => p.ProvinciaId == ciudad.ProvinciaId);
                }
                return ciudad;
            });
            mockProvinciaQuery.Setup(x => x.GetProvincia(It.IsAny<int>())).Returns((int provinciaId) => provincias.FirstOrDefault(p => p.ProvinciaId == provinciaId));
            mockPaisQuery.Setup(x => x.GetPais(It.IsAny<int>())).Returns((int paisId) => paisId == 1 ? paisArgentina : paisEspaña);


            // Act
            var result = viajeCiudadService.GetViajeCiudadList(1, null);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);

            for (int i = 0; i < result.Count; i++)
            {
                var expectedViajeCiudad = viajeCiudades[i];
                var actualViajeCiudad = result[i];

                actualViajeCiudad.Id.Should().Be(expectedViajeCiudad.ViajeCiudadId);
                actualViajeCiudad.ViajeId.Should().Be(expectedViajeCiudad.ViajeId);
                actualViajeCiudad.Tipo.Should().Be(expectedViajeCiudad.Tipo);
                actualViajeCiudad.Ciudad.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Id.Should().Be(expectedViajeCiudad.Ciudad.CiudadId);
                actualViajeCiudad.Ciudad.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Provincia.Id.Should().Be(expectedViajeCiudad.Ciudad.Provincia.ProvinciaId);
                actualViajeCiudad.Ciudad.Provincia.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Pais.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Provincia.Pais.Id.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.PaisId);
                actualViajeCiudad.Ciudad.Provincia.Pais.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Pais.Codigo.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.Codigo);
            }
        }
        [Fact]
        public void GetViajeCiudadList_WithLocalizacionFilter_ReturnsViajeCiudadResponses()
        {
            // Arrange

            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var paisEspaña = new Pais { PaisId = 2, Nombre = "España", Codigo = "ESP" };

            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=paisArgentina },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=paisArgentina},
                new Provincia { ProvinciaId = 3, Nombre = "Madrid", PaisId = 2 ,Pais=paisEspaña}

            };
            var ciudades = new List<Ciudad>
            {
                new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[0], ProvinciaId = provincias[0].ProvinciaId },
                new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = provincias[2].ProvinciaId },
            };
            var viajeCiudades = new List<ViajeCiudad>
            {
                new ViajeCiudad {ViajeCiudadId = 1, ViajeId = 1,CiudadId = 1,Ciudad=ciudades[0],Tipo ="Origen"},
                new ViajeCiudad {ViajeCiudadId = 2, ViajeId = 1,CiudadId = 2,Ciudad=ciudades[1],Tipo ="Destino"},
                new ViajeCiudad {ViajeCiudadId = 3, ViajeId = 2,CiudadId = 3,Ciudad=ciudades[2],Tipo ="Origen"},
                new ViajeCiudad {ViajeCiudadId = 4, ViajeId = 2,CiudadId = 4,Ciudad=ciudades[3],Tipo ="Destino"}
            };

            string localizacionFiltro = "Argentina";

            mockViajeCiudadQuery.Setup(x => x.GetViajeCiudadList(It.IsAny<int?>(), It.IsAny<string>()))
      .Returns((int? viajeId, string localizacion) =>
      {
          var filteredViajeCiudades = viajeCiudades;

          if (!string.IsNullOrEmpty(localizacion))
          {
              filteredViajeCiudades = filteredViajeCiudades.Where(vc =>
                  vc.Ciudad.Nombre.ToLower().Contains(localizacion.ToLower()) ||
                  vc.Ciudad.Provincia.Nombre.ToLower().Contains(localizacion.ToLower()) ||
                  vc.Ciudad.Provincia.Pais.Nombre.ToLower().Contains(localizacion.ToLower())
              ).ToList();
          }

          return filteredViajeCiudades.OrderBy(v => v.ViajeId).ToList();
      });

            mockCiudadQuery.Setup(x => x.GetCiudad(It.IsAny<int>())).Returns((int ciudadId) =>
            {
                var ciudad = ciudades.FirstOrDefault(c => c.CiudadId == ciudadId);
                if (ciudad != null)
                {
                    ciudad.Provincia = provincias.FirstOrDefault(p => p.ProvinciaId == ciudad.ProvinciaId);
                }
                return ciudad;
            });
            mockProvinciaQuery.Setup(x => x.GetProvincia(It.IsAny<int>())).Returns((int provinciaId) => provincias.FirstOrDefault(p => p.ProvinciaId == provinciaId));
            mockPaisQuery.Setup(x => x.GetPais(It.IsAny<int>())).Returns((int paisId) => paisId == 1 ? paisArgentina : paisEspaña);


            // Act
            var result = viajeCiudadService.GetViajeCiudadList(null, "Argentina");

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            for (int i = 0; i < result.Count; i++)
            {
                var expectedViajeCiudad = viajeCiudades[i];
                var actualViajeCiudad = result[i];

                actualViajeCiudad.Id.Should().Be(expectedViajeCiudad.ViajeCiudadId);
                actualViajeCiudad.ViajeId.Should().Be(expectedViajeCiudad.ViajeId);
                actualViajeCiudad.Tipo.Should().Be(expectedViajeCiudad.Tipo);
                actualViajeCiudad.Ciudad.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Id.Should().Be(expectedViajeCiudad.Ciudad.CiudadId);
                actualViajeCiudad.Ciudad.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Provincia.Id.Should().Be(expectedViajeCiudad.Ciudad.Provincia.ProvinciaId);
                actualViajeCiudad.Ciudad.Provincia.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Pais.Should().NotBeNull();
                actualViajeCiudad.Ciudad.Provincia.Pais.Id.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.PaisId);
                actualViajeCiudad.Ciudad.Provincia.Pais.Nombre.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.Nombre);
                actualViajeCiudad.Ciudad.Provincia.Pais.Codigo.Should().Be(expectedViajeCiudad.Ciudad.Provincia.Pais.Codigo);
            }
        }

    }
}

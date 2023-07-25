using Application.Exceptions;
using Application.Interfaces.ICiudad;
using Application.Interfaces.IPais;
using Application.Interfaces.IProvincia;
using Application.Interfaces.IProvincia;
using Application.Request.Ciudad;
using Application.Request.Provincia;
using Application.Response.Ciudad;
using Application.Response.Provincia;
using Application.UseCase;
using Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace TestDestinos
{
    public class CiudadServiceTests
    {
        private readonly Mock<ICiudadCommand> mockCiudadCommand;
        private readonly Mock<ICiudadQuery> mockCiudadQuery;
        private readonly Mock<IProvinciaQuery> mockProvinciaQuery;
        private readonly Mock<IPaisQuery> mockPaisQuery;


        private readonly CiudadService ciudadService;

        public CiudadServiceTests()
        {
            mockCiudadCommand = new Mock<ICiudadCommand>();
            mockCiudadQuery = new Mock<ICiudadQuery>();
            mockProvinciaQuery = new Mock<IProvinciaQuery>();
            mockPaisQuery = new Mock<IPaisQuery>();


            ciudadService = new CiudadService(mockCiudadCommand.Object, mockCiudadQuery.Object, mockProvinciaQuery.Object, mockPaisQuery.Object);
        }

        [Fact]
        public void CreateCiudad_WithValidRequest_ReturnsCreatedCiudadResponse()
        {

            //Arrange
            var request = new CiudadRequest{ Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 2, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudad = new Ciudad();


            mockCiudadQuery.Setup(q => q.GetCiudad(request.Nombre.ToUpper())).Returns((Ciudad)null);
            mockProvinciaQuery.Setup(q => q.GetProvincia(request.ProvinciaId)).Returns((Provincia)provincia);

            mockCiudadCommand.Setup(q => q.InsertCiudad(It.IsAny<Ciudad>()))
                .Callback<Ciudad>(c => ciudad = c);
                


            // Act
            CiudadResponse result = ciudadService.CreateCiudad(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(ciudad.CiudadId);
            result.Nombre.Should().Be(request.Nombre);
            result.Provincia.Should().NotBeNull();
            result.Provincia.Id.Should().Be(provincia.ProvinciaId);
            result.Provincia.Nombre.Should().Be(provincia.Nombre);
            result.Provincia.Pais.Id.Should().Be(paisArgentina.PaisId);

        }

        [Fact]
        public void CreateCiudad_ThrowElementoYaExisteException()
        {
            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 2, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudadÝaExistente = new Ciudad { CiudadId = 2, Nombre = "Quilmes", ProvinciaId = 1 };

            mockCiudadQuery.Setup(q => q.GetCiudad(request.Nombre.ToUpper())).Returns((Ciudad)ciudadÝaExistente);
            mockCiudadQuery.Setup(q => q.GetCiudad(request.Nombre)).Returns((Ciudad)ciudadÝaExistente);

            mockProvinciaQuery.Setup(q => q.GetProvincia(request.ProvinciaId)).Returns((Provincia)provincia);

            // Act & Assert
                   Assert.Throws<ElementoYaExisteException>(() => ciudadService.CreateCiudad(request));
        }

        [Fact]
        public void CreateCiudad_ThrowElementoInexistenteException()
        {
            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 2, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudadÝaExistente = new Ciudad { CiudadId = 2, Nombre = "Quilmes", ProvinciaId = 1 };

            mockCiudadQuery.Setup(q => q.GetCiudad(request.Nombre.ToUpper())).Returns((Ciudad)null );
            mockCiudadQuery.Setup(q => q.GetCiudad(request.Nombre)).Returns((Ciudad)ciudadÝaExistente);

            mockProvinciaQuery.Setup(q => q.GetProvincia(request.ProvinciaId)).Returns((Provincia)null);

            // Act & Assert
            Assert.Throws<ElementoInexistenteException>(() => ciudadService.CreateCiudad(request));
        }


        [Fact]
        public void GetCiudadById_ExistinCiudad_ReturnsCiudadResponse()
        {
            //Arrange
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 2, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudad = new Ciudad {CiudadId = 1, Nombre = "Quilmes", ProvinciaId = 1 ,Provincia=provincia};
         


            mockCiudadQuery.Setup(q => q.GetCiudad(1)).Returns((Ciudad)ciudad);
            mockProvinciaQuery.Setup(q => q.GetProvincia(ciudad.ProvinciaId)).Returns(provincia);

            // Act
            CiudadResponse result = ciudadService.GetCiudadById(1);
            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(ciudad.CiudadId);
            result.Nombre.Should().Be(ciudad.Nombre);
            result.Provincia.Id.Should().Be(ciudad.ProvinciaId);
            result.Provincia.Nombre.Should().Be(provincia.Nombre);
            result.Provincia.Pais.Id.Should().Be(paisArgentina.PaisId);
        }
        [Fact]
        public void GetCiudadById_NoExistingCiudad_ThrowElementoInexistenteException()
        {
            //Arrange

            mockCiudadQuery.Setup(q => q.GetCiudad(It.IsAny<int>())).Returns((Ciudad)null);

            // Act Assert
            Assert.Throws<ElementoInexistenteException>(() => ciudadService.GetCiudadById(It.IsAny<int>()));


        }

        [Fact]
        public void RemoveCiudad_ReturnCiudadResponse()
        {


            // Arrange
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 2, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudad = new Ciudad { CiudadId=1, Nombre = "Quilmes", ProvinciaId = 1 ,Provincia=provincia};

            mockCiudadQuery.Setup(q => q.GetCiudad(1)).Returns((Ciudad)ciudad);
            mockCiudadCommand.Setup(q => q.RemoveCiudad(1)).Returns((Ciudad)ciudad);
            mockProvinciaQuery.Setup(q => q.GetProvincia(1)).Returns(provincia);

            // Act

            CiudadResponse result = ciudadService.RemoveCiudad(1);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(ciudad.CiudadId);
            result.Nombre.Should().Be(ciudad.Nombre);
            result.Provincia.Id.Should().Be(ciudad.ProvinciaId);
            result.Provincia.Nombre.Should().Be(provincia.Nombre);
            result.Provincia.Pais.Id.Should().Be(paisArgentina.PaisId);
        }

        [Fact]
        public void RemoveCiudad_ThrowElementoInexistenteException()
        {
            //Arrange
            mockCiudadCommand.Setup(q => q.RemoveCiudad(It.IsAny<int>())).Returns((Ciudad)null);

            Assert.Throws<ElementoInexistenteException>(() => ciudadService.RemoveCiudad(1));

        }


        [Fact]
        public void UpdateCiudad_ReturnCiudadResponse()
        {
            // Arrange
            var ciudadRequest = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudad = new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincia, ProvinciaId = 1 };

            mockCiudadQuery.Setup(q => q.GetCiudad(It.IsAny<int>())).Returns((Ciudad)ciudad);
            mockCiudadQuery.Setup(q => q.GetCiudad(ciudadRequest.Nombre.ToUpper())).Returns((Ciudad)null);
            mockProvinciaQuery.Setup(q => q.GetProvincia(ciudadRequest.ProvinciaId)).Returns((Provincia)provincia);

            mockCiudadCommand.Setup(q => q.UpdateCiudad(1, ciudadRequest))
                .Returns(new Ciudad {CiudadId = ciudad.CiudadId, Nombre = ciudadRequest.Nombre, ProvinciaId = ciudadRequest.ProvinciaId ,Provincia=provincia});


            //Act
            CiudadResponse result = ciudadService.UpdateCiudad(1, ciudadRequest);


            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Nombre.Should().Be(ciudadRequest.Nombre);
            result.Provincia.Should().NotBeNull();
            result.Provincia.Id.Should().Be(ciudadRequest.ProvinciaId);
            result.Provincia.Nombre.Should().Be(provincia.Nombre);
            result.Provincia.Pais.Id.Should().Be(provincia.PaisId);
        }

        [Fact]
        public void UpdateCiudad_ThrowElementoYaExisteExceptio()
        {
            //Arrange
            var ciudadRequest = new CiudadRequest { Nombre = "Solano", ProvinciaId = 1 };
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudad = new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincia, ProvinciaId = 1 };
           
            mockCiudadQuery.Setup(q => q.GetCiudad(It.IsAny<int>())).Returns((Ciudad)ciudad);

            mockCiudadQuery.Setup(q => q.GetCiudad(It.IsAny<string>())).Returns((Ciudad)ciudad);

            //Act Y assert
            Assert.Throws<ElementoYaExisteException>(() => ciudadService.UpdateCiudad(1, ciudadRequest));
        }
        [Fact]
        public void UpdateCiudad_ThrowElementoInexistenteException()
        {
            //Arrange
            var ciudadRequest = new CiudadRequest { Nombre = "Solano", ProvinciaId = 1 };
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };

            mockCiudadQuery.Setup(q => q.GetCiudad(It.IsAny<int>())).Returns((Ciudad)null);


            //Act Y assert
            Assert.Throws<ElementoInexistenteException>(() => ciudadService.UpdateCiudad(1, ciudadRequest));
        }
        [Fact]
        public void UpdateCiudad_ThrowIdInvalidoException()
        {
            //Arrange
            var ciudadRequest = new CiudadRequest { Nombre = "Solano", ProvinciaId = 1 };
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudad = new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincia, ProvinciaId = 1 };

            mockCiudadQuery.Setup(q => q.GetCiudad(It.IsAny<int>())).Returns((Ciudad)ciudad);

            mockCiudadQuery.Setup(q => q.GetCiudad(It.IsAny<string>())).Returns((Ciudad)null);
            mockProvinciaQuery.Setup(mockPaisQuery => mockPaisQuery.GetProvincia(ciudadRequest.ProvinciaId)).Returns((Provincia)null);

            //Act Y assert
            Assert.Throws<IdInvalidoException>(() => ciudadService.UpdateCiudad(1, ciudadRequest));
        }


        [Fact]
        public void GetCiudadList_WithValidOrdenAsc_ReturnsFilteredAndOrderedProvinciaResponses()
        {
            // Arrange

            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudades = new List<Ciudad>
            {

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincia, ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincia, ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincia, ProvinciaId = 1 },

            };

            mockCiudadQuery.Setup(x => x.GetCiudadList("ASC",null,null,null)).Returns(ciudades.OrderBy(p => p.Nombre).ToList());

            // Act
            List<CiudadResponse> result = ciudadService.GetCiudadList("ASC", null, null,null);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            result[0].Id.Should().Be(3);
            result[0].Nombre.Should().Be("Florencio Varela");
            result[0].Provincia.Id.Should().Be(1);

            result[1].Id.Should().Be(2);
            result[1].Nombre.Should().Be("Quilmes");
            result[1].Provincia.Id.Should().Be(1);

            result[2].Id.Should().Be(1);
            result[2].Nombre.Should().Be("Solano");
            result[2].Provincia.Id.Should().Be(1);
        }

        [Fact]
        public void GetCiudadList_WithNombreFilter_ReturnsFilteredCiudadList()
        {
            var paisArgentina = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1, Pais = paisArgentina };
            var ciudades = new List<Ciudad>
            {

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincia, ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincia, ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincia, ProvinciaId = 1 },

            };

            mockCiudadQuery.Setup(x => x.GetCiudadList("ASC", "Solano", null, null))
                .Returns(ciudades.Where(c => c.Nombre.StartsWith("Solano")) .OrderBy(p => p.Nombre).ToList());



            List<CiudadResponse> result = ciudadService.GetCiudadList("ASC", "Solano", null, null);

            // Assert
            
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(1);
            result[0].Nombre.Should().Be("Solano");
            result[0].Provincia.Id.Should().Be(1);
        }

        [Fact]
        public void GetCiudadList_WithProvinciaFilter_ReturnsFilteredCiudadList()
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

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = 1 },

            };
            mockCiudadQuery.Setup(x => x.GetCiudadList("ASC", null, "Buenos", null))
            .Returns(ciudades.Where(c => c.Provincia.Nombre.StartsWith("Buenos")).OrderBy(p => p.Nombre).ToList());
            mockProvinciaQuery.Setup(x => x.GetProvincia("Buenos")).Returns((Provincia)provincias[1]);
            //Act

            List<CiudadResponse> result = ciudadService.GetCiudadList("ASC", null, "Buenos", null);



            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);
            result[0].Id.Should().Be(3);
            result[0].Nombre.Should().Be("Florencio Varela");
            result[0].Provincia.Id.Should().Be(1);

            result[1].Id.Should().Be(2);
            result[1].Nombre.Should().Be("Quilmes");
            result[1].Provincia.Id.Should().Be(1);

            result[2].Id.Should().Be(1);
            result[2].Nombre.Should().Be("Solano");
            result[2].Provincia.Id.Should().Be(1);
        }

        [Fact]
        public void GetCiudadList_WithPaisFilter_ReturnsFilteredPaisList()
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

               new Ciudad { CiudadId = 1, Nombre = "Solano", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 2, Nombre = "Quilmes", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 3, Nombre = "Florencio Varela", Provincia = provincias[1], ProvinciaId = 1 },
               new Ciudad { CiudadId = 4, Nombre = "Madrid", Provincia = provincias[2], ProvinciaId = 3 },

            };
            mockCiudadQuery.Setup(x => x.GetCiudadList("ASC", null, null, "Espa"))
            .Returns(ciudades.Where(c => c.Provincia.Pais.Nombre.StartsWith("Espa")).OrderBy(p => p.Nombre).ToList());
            mockPaisQuery.Setup(z => z.GetPais("Espa")).Returns((Pais)paisEspaña);
            //Act

            List<CiudadResponse> result = ciudadService.GetCiudadList("ASC", null, null, "Espa");



            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(4);
            result[0].Nombre.Should().Be("Madrid");
            result[0].Provincia.Id.Should().Be(3);
            result[0].Provincia.Pais.Id.Should().Be(2);


        }


        [Fact]
        public void GetCiudadList_WithInvalidOrden_ThrowDatoInvalidoException()
        {
            Assert.Throws<DatoInvalidoException>(() => ciudadService.GetCiudadList("aaaaa"));

        }


        [Fact]
        public void GetCiudadList_WithInvalidPais_ThrowIdElementoInexistenteException()
        {
            mockPaisQuery.Setup(q => q.GetPais(It.IsAny<string>())).Returns((Pais)null);

            Assert.Throws<ElementoInexistenteException>(() => ciudadService.GetCiudadList("ASC", null,null, "PaisNoValido"));
        }
        [Fact]
        public void GetCiudadList_WithInvalidProvincia_ThrowIdInvalidoException()
        {
            mockPaisQuery.Setup(q => q.GetPais(It.IsAny<string>())).Returns((Pais)null);

            Assert.Throws<IdInvalidoException>(() => ciudadService.GetCiudadList("ASC", null, "provinciaNoValida", null));
        }
    }
}

using Application.Exceptions;
using Application.Interfaces.IPais;
using Application.Interfaces.IProvincia;
using Application.Request.Provincia;
using Application.Response.Provincia;
using Application.UseCase;
using Domain.Entities;
using FluentAssertions;
using Moq;

namespace TestDestinos
{
    public class ProvinciaServiceTests
    {
        private readonly Mock<IProvinciaCommand> mockProvinciaCommand;
        private readonly Mock<IProvinciaQuery> mockProvinciaQuery;
        private readonly Mock<IPaisQuery> mockPaisQuery;

        private readonly ProvinciaService provinciaService;

        public ProvinciaServiceTests()
        {
            mockProvinciaCommand = new Mock<IProvinciaCommand>();
            mockProvinciaQuery = new Mock<IProvinciaQuery>();
            mockPaisQuery = new Mock<IPaisQuery>();

            provinciaService = new ProvinciaService(mockProvinciaQuery.Object, mockProvinciaCommand.Object, mockPaisQuery.Object);
        }

        [Fact]
        public void CreateProvincia_WithValidRequest_ReturnsCreatedProvinciaResponse()
        {

            //Arrange
            var request = new ProvinciaRequest { Nombre = "Buenos Aires", PaisId = 1 };
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };


            mockPaisQuery.Setup(q => q.GetPais(request.PaisId)).Returns(pais);

            var provincia = new Provincia();
            mockProvinciaCommand.Setup(c => c.InsertProvincia(It.IsAny<Provincia>()))
            .Callback<Provincia>(p => provincia = p);

            // Act
            ProvinciaResponse result = provinciaService.CreateProvincia(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(provincia.ProvinciaId);
            result.Nombre.Should().Be(request.Nombre);
            result.Pais.Should().NotBeNull();
            result.Pais.Id.Should().Be(pais.PaisId);
            result.Pais.Nombre.Should().Be(pais.Nombre);
            result.Pais.Codigo.Should().Be(pais.Codigo);

        }

        [Fact]
        public void CreateProvincia_WithExistingProvinciaNameAndMatchingPais_ThrowsElementoYaExisteException()
        {
            // Arrange
            var request = new ProvinciaRequest { Nombre = "Buenos Aires", PaisId = 1 };
            var existingProvincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 };
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };

            mockProvinciaQuery.Setup(q => q.GetProvincia(request.Nombre.ToUpper())).Returns(existingProvincia);
            mockProvinciaQuery.Setup(q => q.GetProvincia(request.Nombre)).Returns(existingProvincia);
            mockPaisQuery.Setup(q => q.GetPais(request.PaisId)).Returns(pais);

            // Act & Assert
            Assert.Throws<ElementoYaExisteException>(() => provinciaService.CreateProvincia(request));
        }
        [Fact]
        public void CreateProvincia_WithInvalidPaisId_ThrowsElementoInexistenteException()
        {
            // Arrange
            var request = new ProvinciaRequest { Nombre = "Buenos Aires", PaisId = 1 };

            mockPaisQuery.Setup(q => q.GetPais(request.PaisId)).Returns((Pais)null);

            // Act & Assert
            Assert.Throws<ElementoInexistenteException>(() => provinciaService.CreateProvincia(request));
        }

        [Fact]
        public void GetProvinciaById_ExistingProvincia_ReturnsProvinciaResponse()
        {
            //Arrange
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 };
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };


            mockProvinciaQuery.Setup(q => q.GetProvincia(1)).Returns((Provincia)provincia);
            mockPaisQuery.Setup(q => q.GetPais(1)).Returns(pais);

            // Act
            ProvinciaResponse result = provinciaService.GetProvinciaById(1);
            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(provincia.ProvinciaId);
            result.Nombre.Should().Be(provincia.Nombre);

            result.Pais.Should().NotBeNull();
            result.Pais.Id.Should().Be(pais.PaisId);
            result.Pais.Nombre.Should().Be(pais.Nombre);
            result.Pais.Codigo.Should().Be(pais.Codigo);
        }
        [Fact]
        public void GetProvinciaById_NoExistingProvincia_ThrowElementoInexistenteException()
        {
            //Arrange
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 };


            mockProvinciaQuery.Setup(q => q.GetProvincia(1)).Returns((Provincia)null);

            // Act Assert
            Assert.Throws<ElementoInexistenteException>(() => provinciaService.GetProvinciaById(1));


        }

        [Fact]
        public void RemoveProvincia_ReturnProvinciaResponse()
        {


            // Arrange

            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 };
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };


            mockProvinciaCommand.Setup(q => q.RemoveProvincia(1)).Returns((Provincia)provincia);
            mockPaisQuery.Setup(q => q.GetPais(1)).Returns(pais);

            // Act

            ProvinciaResponse result = provinciaService.RemoveProvincia(1);

            // Assert
            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(provincia.ProvinciaId);
            result.Nombre.Should().Be(provincia.Nombre);

            result.Pais.Should().NotBeNull();
            result.Pais.Id.Should().Be(pais.PaisId);
            result.Pais.Nombre.Should().Be(pais.Nombre);
            result.Pais.Codigo.Should().Be(pais.Codigo);
        }

        [Fact]
        public void RemoveProvincia_ThrowElementoInexistenteException()
        {
            //Arrange
            mockProvinciaCommand.Setup(q => q.RemoveProvincia(It.IsAny<int>())).Returns((Provincia)null);

            Assert.Throws<ElementoInexistenteException>(() => provinciaService.RemoveProvincia(1));

        }


        [Fact]
        public void UpdateProvincia_ReturnProvinciaResponse()
        {
            // Arrange

            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 };
            var provinciaRequest = new ProvinciaRequest { Nombre = "Chubut", PaisId = 1 };
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };

            mockProvinciaQuery.Setup(q => q.GetProvincia(provinciaRequest.Nombre.ToUpper())).Returns((Provincia)null);
            mockPaisQuery.Setup(q => q.GetPais(provinciaRequest.PaisId)).Returns(pais);
            mockProvinciaCommand.Setup(q => q.UpdateProvincia(1, provinciaRequest))
                .Returns(new Provincia { PaisId = pais.PaisId, Nombre = provinciaRequest.Nombre, ProvinciaId = provincia.ProvinciaId });


            //Act
            ProvinciaResponse result = provinciaService.UpdateProvincia(1, provinciaRequest);


            //Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(1);
            result.Nombre.Should().Be(provinciaRequest.Nombre);
            result.Pais.Should().NotBeNull();
            result.Pais.Id.Should().Be(provinciaRequest.PaisId);
            result.Pais.Nombre.Should().Be(pais.Nombre);
            result.Pais.Codigo.Should().Be(pais.Codigo);
        }

        [Fact]
        public void UpdateProvincia_ThrowElementoYaExisteExceptio()
        {
            //Arrange
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 };
            var provinciaRequest = new ProvinciaRequest { Nombre = "Chubut", PaisId = 1 };


            mockProvinciaQuery.Setup(q => q.GetProvincia(It.IsAny<string>())).Returns((Provincia)provincia);

            //Act Y assert
            Assert.Throws<ElementoYaExisteException>(() => provinciaService.UpdateProvincia(1, provinciaRequest));
        }

        [Fact]
        public void UpdateProvincia_ThrowIdInvalidoException()
        {
            //Arrange
            var provincia = new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 };
            var provinciaRequest = new ProvinciaRequest { Nombre = "Chubut", PaisId = 1 };

            mockPaisQuery.Setup(q => q.GetPais(It.IsAny<int>())).Returns((Pais)null);
            //Act Y assert
            Assert.Throws<IdInvalidoException>(() => provinciaService.UpdateProvincia(1, provinciaRequest));
        }

        [Fact]
        public void UpdateProvincia_ThrowElementoInexistenteException()
        {
            // Arrange
            var request = new ProvinciaRequest { Nombre = "Chubut", PaisId = 1 };
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };


            mockPaisQuery.Setup(q => q.GetPais(request.PaisId)).Returns(pais);

            mockProvinciaCommand.Setup(c => c.UpdateProvincia(1, request)).Returns((Provincia)null);

            // Act & Assert
            Assert.Throws<ElementoInexistenteException>(() => provinciaService.UpdateProvincia(1, request));
        }



        [Fact]
        public void GetProvinciaList_WithValidOrdenAsc_ReturnsFilteredAndOrderedProvinciaResponses()
        {
            // Arrange
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1,Pais=pais },
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1,Pais=pais },
            };
            mockPaisQuery.Setup(q => q.GetPais(1)).Returns(pais);
            mockProvinciaQuery.Setup(q => q.GetProvinciaList("ASC", null, null)).Returns(provincias.OrderBy(p => p.Nombre).ToList());


            // Act
            List<ProvinciaResponse> result = provinciaService.GetProvinciaList("ASC", null, null);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Id.Should().Be(1);
            result[0].Nombre.Should().Be("Buenos Aires");
            result[1].Id.Should().Be(2);
            result[1].Nombre.Should().Be("Chubut");

        }

        [Fact]
        public void GetProvinciaList_WithNombreFilter_ReturnsFilteredProvinciaList()
        {
            // Arrange
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1, Pais = pais},
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1,Pais=pais },
            };
            mockPaisQuery.Setup(q => q.GetPais(1)).Returns((Pais)pais);
            mockProvinciaQuery.Setup(q => q.GetProvinciaList("ASC", "Bue", null))
            .Returns(provincias.Where(p => p.Nombre.StartsWith("Bue")).OrderBy(p => p.Nombre).ToList());


            List<ProvinciaResponse> result = provinciaService.GetProvinciaList("ASC", "Bue", null);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(1);
            result[0].Id.Should().Be(1);
            result[0].Nombre.Should().Be("Buenos Aires");

        }
        [Fact]
        public void GetProvinciaList_WithPaisFilter_ReturnsFilteredProvinciaList()
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

            mockPaisQuery.Setup(q => q.GetPais("Argentina")).Returns(paisArgentina);
            mockPaisQuery.Setup(q => q.GetPais("España")).Returns(paisEspaña);

            mockProvinciaQuery.Setup(q => q.GetProvinciaList("ASC", null, "Argentina"))
                .Returns(provincias.Where(p => p.Pais.Nombre.StartsWith("Argentina")).OrderBy(p => p.Nombre).ToList());

            // Act
            List<ProvinciaResponse> result = provinciaService.GetProvinciaList("ASC", null, "Argentina");

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Id.Should().Be(1);
            result[0].Nombre.Should().Be("Buenos Aires");
            result[1].Nombre.Should().Be("Chubut");
        }
        [Fact]
        public void GetProvinciaList_WithValidOrdenDesc_ReturnsFilteredAndOrderedProvinciaResponses()
        {
            // Arrange
            var pais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincias = new List<Provincia>
            {
                new Provincia { ProvinciaId = 2, Nombre = "Chubut", PaisId = 1 ,Pais=pais},
                new Provincia { ProvinciaId = 1, Nombre = "Buenos Aires", PaisId = 1 ,Pais=pais},
            };
            mockPaisQuery.Setup(q => q.GetPais(1)).Returns((Pais)pais);
            mockProvinciaQuery.Setup(q => q.GetProvinciaList("DESC", null, null)).Returns(provincias.OrderByDescending(p => p.Nombre).ToList());


            // Act
            List<ProvinciaResponse> result = provinciaService.GetProvinciaList("DESC", null, null);

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[1].Id.Should().Be(1);
            result[1].Nombre.Should().Be("Buenos Aires");
            result[0].Id.Should().Be(2);
            result[0].Nombre.Should().Be("Chubut");

        }

        [Fact]
        public void GetProvinciaList_WithInvalidOrden_ThrowDatoInvalidoException()
        {
            Assert.Throws<DatoInvalidoException>(() => provinciaService.GetProvinciaList("aaaaa"));

        }
        [Fact]
        public void GetProvinciaList_WithInvalidPais_ThrowIdInvalidoException()
        {
            mockPaisQuery.Setup(q => q.GetPais(It.IsAny<string>())).Returns((Pais)null);

            Assert.Throws<IdInvalidoException>(() => provinciaService.GetProvinciaList("ASC", null, "PaisNoValido"));
        }
    }
}

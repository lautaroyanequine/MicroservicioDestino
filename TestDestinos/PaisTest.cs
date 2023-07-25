using Application.Exceptions;
using Application.Interfaces.IPais;
using Application.Request.Pais;
using Application.Response.Pais;
using Application.UseCase;
using Domain.Entities;
using FluentAssertions;
using Moq;

namespace TestDestinos
{
    public class PaisServiceTests
    {
        private readonly Mock<IPaisCommand> mockPaisCommand;
        private readonly Mock<IPaisQuery> mockPaisQuery;
        private readonly PaisService paisService;

        public PaisServiceTests()
        {
            mockPaisCommand = new Mock<IPaisCommand>();
            mockPaisQuery = new Mock<IPaisQuery>();
            paisService = new PaisService(mockPaisCommand.Object, mockPaisQuery.Object);
        }

        [Fact]
        public void CreatePais_ReturnCorrectResponse()
        {

            //Arrange
            var request = new PaisRequest { Nombre = "Test", Codigo = "Test Codigo" };
            var pais = new Pais { PaisId = 1,Nombre = "Test", Codigo = "Test Codigo" };

            mockPaisCommand.Setup(q => q.InsertPais(It.IsAny<Pais>()))
                .Callback<Pais>(p => pais.PaisId = p.PaisId);

            // Act
            PaisResponse result = paisService.CreatePais(request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(pais.PaisId);
            result.Nombre.Should().Be(request.Nombre);
            result.Codigo.Should().Be(request.Codigo);
        }

        [Fact]
        public void CreatePais_WithPaisExist_ThrowsElementoYaExisteException()
        {
            //Arrange
            var request = new PaisRequest { Nombre = "Argentina", Codigo = "ARG" };
            var existingPais = new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" };
            mockPaisQuery.Setup(q => q.GetPais(request.Nombre.ToUpper())).Returns(existingPais);

            // Act & Assert
            Assert.Throws<ElementoYaExisteException>(() => paisService.CreatePais(request));
        }



        [Fact]
        public void GetPaisById_ExistingPais_ReturnsPaisResponse()
        {
            // Arrange
            int paisId = 1;
            Pais expectedPais = new Pais { PaisId = paisId, Nombre = "Argentina", Codigo = "ARG" };

            mockPaisQuery.Setup(q => q.GetPais(It.IsAny<int>())).Returns(expectedPais);


            // Act
            PaisResponse result = paisService.GetPaisById(paisId);

            // Assert
            result.Id.Should().Be(expectedPais.PaisId);
            result.Nombre.Should().Be(expectedPais.Nombre);
            result.Codigo.Should().Be(expectedPais.Codigo);

        }

        [Fact]
        public void GetPaisById_NonExistingPais_ThrowsElementoInexistenteException()
        {
            // Arrange

            mockPaisQuery.Setup(q => q.GetPais(It.IsAny<int>())).Returns((Pais)null);

            // Act & Assert
            Assert.Throws<ElementoInexistenteException>(() => paisService.GetPaisById(1));
        }

        [Fact]
        public void GetPaisList_WithValidOrdenAndNombre_ReturnsFilteredAndOrderedPaisResponses()
        {
            // Arrange


            List<Pais> paises = new List<Pais>
            {
                new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" },
                new Pais { PaisId = 2, Nombre = "Australia", Codigo = "AUS" },
                new Pais { PaisId = 3, Nombre = "Austria", Codigo = "AUT" },
                new Pais { PaisId = 4, Nombre = "Brasil", Codigo = "BRA" },
            };

            mockPaisQuery.Setup(q => q.GetPaisList("DESC", "A")).Returns(paises.Where(p => p.Nombre.StartsWith("A")).OrderByDescending(p => p.Nombre).ToList());

            // Act
            List<PaisResponse> result = paisService.GetPaisList("DESC", "A");

            // Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(3);

            result[0].Nombre.Should().Be("Austria");
            result[0].Codigo.Should().Be("AUT");

            result[1].Nombre.Should().Be("Australia");
            result[1].Codigo.Should().Be("AUS");
            result[2].Nombre.Should().Be("Argentina");
            result[2].Codigo.Should().Be("ARG");
        }

        [Fact]
        public void GetPaisList_WithInvalidOrden_ThrowsDatoInvalidoException()
        {
            // Arrange
            string orden = "INVALID";

            // Act & Assert
            Assert.Throws<DatoInvalidoException>(() => paisService.GetPaisList(orden));
        }

        [Fact]
        public void GetPaisList_WithNullOrden_ReturnsDefaultOrderedPaisResponses()
        {
            // Arrange

            List<Pais> paises = new List<Pais>
            {
                new Pais { PaisId = 1, Nombre = "Argentina", Codigo = "ARG" },
                new Pais { PaisId = 2, Nombre = "Australia", Codigo = "AUS" },
                new Pais { PaisId = 3, Nombre = "Austria", Codigo = "AUT" },
                new Pais { PaisId = 4, Nombre = "Brasil", Codigo = "BRA" },
            };

            mockPaisQuery.Setup(q => q.GetPaisList("ASC", null)).Returns(paises.OrderBy(p => p.Nombre).ToList());

            // Act
            List<PaisResponse> result = paisService.GetPaisList("ASC");

            // Assert

            result.Should().NotBeNull();
            result.Should().HaveCount(4);
            result[0].Nombre.Should().Be("Argentina");
            result[0].Codigo.Should().Be("ARG");
            result[1].Nombre.Should().Be("Australia");
            result[1].Codigo.Should().Be("AUS");
            result[2].Nombre.Should().Be("Austria");
            result[2].Codigo.Should().Be("AUT");
            result[3].Nombre.Should().Be("Brasil");
            result[3].Codigo.Should().Be("BRA");



        }

        [Fact]
        public void UpdatePais_WithNonExistingNombre_ReturnsUpdatedPaisResponse()
        {
            // Arrange
            int paisId = 1;
            string nuevoNombre = "Nuevo País";
            string nuevoCodigo = "NUE";
            PaisRequest request = new PaisRequest { Nombre = nuevoNombre, Codigo = nuevoCodigo };

            mockPaisQuery.Setup(q => q.GetPais(nuevoNombre.ToUpper())).Returns((Pais)null);
            mockPaisCommand.Setup(c => c.UpdatePais(paisId, request)).Returns(new Pais { PaisId = paisId, Nombre = nuevoNombre, Codigo = nuevoCodigo });

            // Act
            PaisResponse result = paisService.UpdatePais(paisId, request);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(paisId);
            result.Nombre.Should().Be(nuevoNombre);
            result.Codigo.Should().Be(nuevoCodigo);

            mockPaisQuery.Verify(q => q.GetPais(nuevoNombre.ToUpper()), Times.Once);
            mockPaisCommand.Verify(c => c.UpdatePais(paisId, request), Times.Once);
        }
        [Fact]
        public void UpdatePais_WithExistingNombre_ThrowsElementoYaExisteException()
        {
            // Arrange
            int paisId = 1;
            string nombreExistente = "Argentina";
            string nuevoCodigo = "NUE";
            PaisRequest request = new PaisRequest { Nombre = nombreExistente, Codigo = nuevoCodigo };

            mockPaisQuery.Setup(q => q.GetPais(nombreExistente.ToUpper())).Returns(new Pais()); // Configurar el mock para devolver un país no nulo

            // Act & Assert
            Assert.Throws<ElementoYaExisteException>(() => paisService.UpdatePais(paisId, request));
        }

        [Fact]
        public void UpdatePais_WithNullPais_ThrowsElementoInexistenteException()
        {
            // Arrange
            int paisId = 1;
            string nombreNoExistente = "NoExistente";
            string nuevoCodigo = "NUE";
            PaisRequest request = new PaisRequest { Nombre = nombreNoExistente, Codigo = nuevoCodigo };

            mockPaisCommand.Setup(c => c.UpdatePais(paisId, request)).Returns((Pais)null); // Configurar el mock para devolver null

            // Act & Assert
            Assert.Throws<ElementoInexistenteException>(() => paisService.UpdatePais(paisId, request));
        }

        [Fact]
        public void RemovePais_WithNullPais_ReturnPaisResponse()
        {
            // Arrange
            int paisId = 1;
            string nombreNoExistente = "NoExistente";
            string nuevoCodigo = "NUE";

            mockPaisCommand.Setup(c => c.RemovePais(paisId)).Returns((Pais)null); // Configurar el mock para devolver null

            // Act & Assert
            Assert.Throws<ElementoInexistenteException>(() => paisService.RemovePais(paisId));
        }

        [Fact]
        public void RemovePais_WithNotNullPais_ThrowsElementoInexistenteException()
        {
            // Arrange
            int paisId = 1;
            string nombreNoExistente = "NoExistente";
            string nuevoCodigo = "NUE";

            mockPaisCommand.Setup(c => c.RemovePais(paisId)).Returns((Pais)null); // Configurar el mock para devolver null

            // Act & Assert
            Assert.Throws<ElementoInexistenteException>(() => paisService.RemovePais(paisId));
        }


        [Fact]
        public void RemovePais_WithExistingPais_ReturnsRemovedPaisResponse()
        {
            // Arrange
            int paisId = 1;
            var existingPais = new Pais { PaisId = paisId, Nombre = "Argentina", Codigo = "ARG" };

            mockPaisCommand.Setup(c => c.RemovePais(paisId)).Returns(existingPais);

            // Act
            PaisResponse result = paisService.RemovePais(paisId);

            // Assert
            result.Should().NotBeNull();
            result.Id.Should().Be(existingPais.PaisId);
            result.Nombre.Should().Be(existingPais.Nombre);
            result.Codigo.Should().Be(existingPais.Codigo);
            mockPaisCommand.Verify(c => c.RemovePais(paisId), Times.Once);
        }
    }
}
using Application.Exceptions;
using Application.Interfaces.IPais;
using Application.Request.Pais;
using Application.Response.Pais;
using Application.UseCase;
using Azure;
using Destinos.Controllers;
using Domain.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace TestDestinos
{
    public class PaisControllerTests
    {
        private readonly Mock<IPaisService> mockPaisService;
        private readonly PaisController paisController;

        public PaisControllerTests()
        {
            mockPaisService = new Mock<IPaisService>();
            paisController = new PaisController(mockPaisService.Object);
        }

        [Fact]
        public void CreatePais_ReturnCorrectResponse()
        {

            //Arrange
            var request = new PaisRequest { Nombre = "Test", Codigo = "Test Codigo" };
            var response = new PaisResponse { Id = 1, Nombre = request.Nombre, Codigo = request.Codigo };

            mockPaisService.Setup(mock => mock.CreatePais(request)).Returns(response);

            //Act
            var result = paisController.CreatePais(request);


            //Assert

            var jsonResult = Assert.IsType<JsonResult>(result);
            jsonResult.StatusCode.Should().Be(201);

            var jsonResponse = jsonResult.Value.Should().BeOfType<PaisResponse>().Subject;
            jsonResponse.Id.Should().Be(response.Id);
            jsonResponse.Nombre.Should().Be(response.Nombre);
            jsonResponse.Codigo.Should().Be(response.Codigo);
        }


        [Fact]
        public void CreatePais_ShouldReturnConflictElementoYaExisteException()
        {
            //Arrange
            var request = new PaisRequest { Nombre = "Test", Codigo = "Test Codigo" };
            var response = new PaisResponse { Id = 1, Nombre = request.Nombre, Codigo = request.Codigo };
            var expectedErrorMessage = "No se pudo crear porque ya existe el pais";

            mockPaisService.Setup(mock => mock.CreatePais(request)).Throws(new ElementoYaExisteException());

            //Act
            var result = paisController.CreatePais(request);


            //Assert
            var conflictResult = Assert.IsType<ConflictObjectResult>(result);
            conflictResult.StatusCode.Should().Be(409);

            var errorMessage = conflictResult.Value.GetType().GetProperty("message").GetValue(conflictResult.Value).ToString();
            errorMessage.Should().Be(expectedErrorMessage);
        }

        [Fact]
        public void CreatePais_ShouldReturnBadRequst()
        {
            //Arrange
            var request = new PaisRequest { Nombre = "Test", Codigo = "Test Codigo" };
            var response = new PaisResponse { Id = 1, Nombre = request.Nombre, Codigo = request.Codigo };
            var expectedErrorMessage = "Ingreso un parametro invalido";

            mockPaisService.Setup(mock => mock.CreatePais(request)).Throws(new Exception());

            //Act
            var result = paisController.CreatePais(request);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void GetAllPais_ReturnPaisList()
        {
            //Arrange

            List<PaisResponse> paises = new List<PaisResponse>
                    {
                        new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" },
                        new PaisResponse { Id = 2, Nombre = "Australia", Codigo = "AUS" },
                        new PaisResponse { Id = 3, Nombre = "Austria", Codigo = "AUT" },
                        new PaisResponse { Id = 4, Nombre = "Brasil", Codigo = "BRA" },
                    };
            mockPaisService.Setup(x => x.GetPaisList("ASC", null))
                .Returns(paises.OrderBy(p => p.Nombre)
                .ToList());

            //Act
            var result = paisController.GetAll("ASC", null);

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);

            var jsonResponse = jsonResult.Value.Should().BeOfType<List<PaisResponse>>().Subject;
            jsonResponse[0].Id.Should().Be(1);
            jsonResponse[0].Nombre.Should().Be("Argentina");
            jsonResponse[0].Codigo.Should().Be("ARG");
            jsonResponse[1].Id.Should().Be(2);
            jsonResponse[1].Nombre.Should().Be("Australia");
            jsonResponse[1].Codigo.Should().Be("AUS");
            jsonResponse[2].Nombre.Should().Be("Austria");
            jsonResponse[2].Codigo.Should().Be("AUT");
            jsonResponse[3].Nombre.Should().Be("Brasil");
            jsonResponse[3].Codigo.Should().Be("BRA");

        }
        [Fact]
        public void GetAllPais_ShouldReturnBadRequst()
        {
            //Arrange

            var expectedErrorMessage = "El tipo de mercaderia ingresado no existe";

            mockPaisService.Setup(mock => mock.GetPaisList("ASC", null)).Throws(new Exception());

            //Act
            var result = paisController.GetAll();


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }
        [Fact]
        public void GetAllPais_ShouldReturnBadRequstDatoInvalidoException()
        {
            //Arrange

            var expectedErrorMessage = "El valor del orden es inválido. Solo se permite 'ASC' o 'DESC";

            mockPaisService.Setup(mock => mock.GetPaisList("AssssssssSC", null)).Throws(new DatoInvalidoException());

            //Act
            var result = paisController.GetAll("AssssssssSC", null);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void GetPaisById_ReturnPais()
        {
            // Arrange
            int paisId = 1;
            PaisResponse expectedPais = new PaisResponse { Id = paisId, Nombre = "Argentina", Codigo = "ARG" };


            mockPaisService.Setup(x => x.GetPaisById(1))
                .Returns(expectedPais);

            //Act
            var result = paisController.GetPaisById(1);

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);

            var jsonResponse = jsonResult.Value.Should().BeOfType<PaisResponse>().Subject;
            jsonResponse.Id.Should().Be(1);
            jsonResponse.Nombre.Should().Be("Argentina");
            jsonResponse.Codigo.Should().Be("ARG");


        }

        [Fact]
        public void GetPaisById_ShouldReturnBadRequst()
        {
            //Arrange

            var expectedErrorMessage = "Hubo un error en los parametros ingresados";

            mockPaisService.Setup(x => x.GetPaisById(1)).Throws(new Exception());
            //Act
            var result = paisController.GetPaisById(1);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void GetPaisById_ShouldReturnBadRequst404()
        {
            //Arrange

            var expectedErrorMessage = "No se encontro el pais solicitado";

            mockPaisService.Setup(x => x.GetPaisById(1)).Throws(new ElementoInexistenteException());
            //Act
            var result = paisController.GetPaisById(1);


            //Assert
            var badResult = Assert.IsType<NotFoundObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void RemovePais_ReturnPais()
        {
            // Arrange
            int paisId = 1;
            PaisResponse expectedPais = new PaisResponse { Id = paisId, Nombre = "Argentina", Codigo = "ARG" };


            mockPaisService.Setup(x => x.RemovePais(1))
                .Returns(expectedPais);

            //Act
            var result = paisController.DeletePais(1);

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);

            var jsonResponse = jsonResult.Value.Should().BeOfType<PaisResponse>().Subject;
            jsonResponse.Id.Should().Be(1);
            jsonResponse.Nombre.Should().Be("Argentina");
            jsonResponse.Codigo.Should().Be("ARG");


        }

        [Fact]
        public void RemovePais_ShouldReturnBadRequst404()
        {
            //Arrange

            var expectedErrorMessage = "No existe el pais que quiere eliminar";

            mockPaisService.Setup(x => x.RemovePais(1)).Throws(new ElementoInexistenteException());
            //Act
            var result = paisController.DeletePais(1);


            //Assert
            var badResult = Assert.IsType<NotFoundObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void UpdatePais_ReturnPais()
        {
            // Arrange
            int paisId = 1;
            PaisRequest request = new PaisRequest { Nombre = "Brasil", Codigo = "BRA" };
            PaisResponse expectedPais = new PaisResponse { Id = paisId, Nombre =request.Nombre, Codigo = request.Codigo };


            mockPaisService.Setup(x => x.UpdatePais(1,request))
                .Returns(expectedPais);

            //Act
            var result = paisController.UpdatePais(1,request);

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            jsonResult.StatusCode.Should().Be(200);

            var jsonResponse = jsonResult.Value.Should().BeOfType<PaisResponse>().Subject;
            jsonResponse.Should().NotBeNull();
            jsonResponse.Id.Should().Be(1);
            jsonResponse.Nombre.Should().Be("Brasil");
            jsonResponse.Codigo.Should().Be("BRA");


        }


        [Fact]
        public void UpdatePais_ShouldReturnBadRequst()
        {
            //Arrange
            int paisId = 1;
            PaisRequest request = new PaisRequest { Nombre = "Brasil", Codigo = "BRA" };
            PaisResponse expectedPais = new PaisResponse { Id = paisId, Nombre = request.Nombre, Codigo = request.Codigo };
            var expectedErrorMessage = "Ingreso un parametro invalido";

            mockPaisService.Setup(x => x.UpdatePais(1, request)).Throws(new Exception());
            //Act
            var result = paisController.UpdatePais(1, request);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void UpdatePais_ShouldReturnBadRequstElementoYaExisteExcpetion()
        {
            //Arrange
            int paisId = 1;
            PaisRequest request = new PaisRequest { Nombre = "Brasil", Codigo = "BRA" };
            PaisResponse expectedPais = new PaisResponse { Id = paisId, Nombre = request.Nombre, Codigo = request.Codigo };
            var expectedErrorMessage = "Ya existe el pais que desea ingresar";

            mockPaisService.Setup(x => x.UpdatePais(1, request)).Throws(new ElementoYaExisteException());
            //Act
            var result = paisController.UpdatePais(1, request);


            //Assert
            var badResult = Assert.IsType<ConflictObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status409Conflict);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void UpdatePais_ShouldReturnBadRequstElementoInexistentenException()
        {
            //Arrange
            int paisId = 1;
            PaisRequest request = new PaisRequest { Nombre = "Brasil", Codigo = "BRA" };
            PaisResponse expectedPais = new PaisResponse { Id = paisId, Nombre = request.Nombre, Codigo = request.Codigo };
            var expectedErrorMessage = "El pais que desea modificar no existe";

            mockPaisService.Setup(x => x.UpdatePais(1, request)).Throws(new ElementoInexistenteException());
            //Act
            var result = paisController.UpdatePais(1, request);


            //Assert
            var badResult = Assert.IsType<NotFoundObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void UpdatePais_ShouldReturnBadRequstIdInvalidoException()
        {
            //Arrange
            int paisId = 1;
            PaisRequest request = new PaisRequest { Nombre = "Brasil", Codigo = "BRA" };
            PaisResponse expectedPais = new PaisResponse { Id = paisId, Nombre = request.Nombre, Codigo = request.Codigo };
            var expectedErrorMessage = "Él pais que quiere ingresar no existe";

            mockPaisService.Setup(x => x.UpdatePais(1, request)).Throws(new IdInvalidoException());
            //Act
            var result = paisController.UpdatePais(1, request);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }
        
    }
}

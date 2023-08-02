using Application.Exceptions;
using Application.Interfaces.ICiudad;
using Application.Interfaces.IPais;
using Application.Request.Ciudad;
using Application.Request.Pais;
using Application.Response.Ciudad;
using Application.Response.Pais;
using Application.Response.Provincia;
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
    public class CiudadControllerTests
    {
        private readonly Mock<ICiudadService> mockCiudadService;
        private readonly CiudadController CiudadController;

        public CiudadControllerTests()
        {
            mockCiudadService = new Mock<ICiudadService>();
            CiudadController = new CiudadController(mockCiudadService.Object);
        }

        
        [Fact]
        public void CreatePais_ReturnCorrectResponse()
        {

            //Arrange

            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };


            var response = new CiudadResponse {Id=1,Nombre=request.Nombre, Provincia=provincia};
            mockCiudadService.Setup(x => x.CreateCiudad(request)).Returns(response);


            //Act
            var result = CiudadController.CreateCiudad(request);


            //Assert

            var jsonResult = Assert.IsType<JsonResult>(result);
            jsonResult.StatusCode.Should().Be(201);

            var jsonResponse = jsonResult.Value.Should().BeOfType<CiudadResponse>().Subject;
            jsonResponse.Id.Should().Be(response.Id);
            jsonResponse.Nombre.Should().Be(response.Nombre);
            jsonResponse.Provincia.Nombre.Should().Be(provincia.Nombre);
        }


        [Fact]
        public void CreateCiudads_ShouldReturnConflictElementoYaExisteException()
        {
            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage = "No se pudo crear porque ya existe la ciudad";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.CreateCiudad(request)).Throws( new ElementoYaExisteException());
            //Act
            var result = CiudadController.CreateCiudad(request);


            //Assert
            var conflictResult = Assert.IsType<ConflictObjectResult>(result);
            conflictResult.StatusCode.Should().Be(409);

            var errorMessage = conflictResult.Value.GetType().GetProperty("message").GetValue(conflictResult.Value).ToString();
            errorMessage.Should().Be(expectedErrorMessage);
        }

        [Fact]
        public void CreateCiudad_ShouldReturnBadRequst()
        {
            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage = "Ingreso una provincia inexistente";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.CreateCiudad(request)).Throws(new ElementoInexistenteException());

            //Act
            var result = CiudadController.CreateCiudad(request);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void GetAllCiudades_ReturnCiudadesList()
        {
            //Arrange
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse {Id = 1, Nombre = "Buenos Aires", Pais = paisArgentina };
            var ciudades = new List<CiudadResponse>
            {

               new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provincia },
               new CiudadResponse { Id = 2, Nombre = "Quilmes", Provincia = provincia },
               new CiudadResponse { Id = 3, Nombre = "Florencio Varela", Provincia = provincia}

            };

            mockCiudadService.Setup(x => x.GetCiudadList("ASC", null, null, null))
                .Returns(ciudades.OrderBy(n => n.Nombre)
                .ToList());

            //Act
            var result = CiudadController.GetAll("ASC", null,null,null);

            //Assert
            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);

            var jsonResponse = jsonResult.Value.Should().BeOfType<List<CiudadResponse>>().Subject;
            jsonResponse[0].Id.Should().Be(3);
            jsonResponse[0].Nombre.Should().Be("Florencio Varela");
            jsonResponse[0].Provincia.Nombre.Should().Be("Buenos Aires");
            jsonResponse[1].Id.Should().Be(2);
            jsonResponse[1].Nombre.Should().Be("Quilmes");
            jsonResponse[1].Provincia.Nombre.Should().Be("Buenos Aires");
            jsonResponse[2].Nombre.Should().Be("Solano");
            jsonResponse[1].Provincia.Nombre.Should().Be("Buenos Aires");
      

        }


        [Fact]
        public void GetAllCiudades_ShouldReturnBadRequst()
        {
            //Arrange
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentina };
            var ciudades = new List<CiudadResponse>
            {

               new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provincia },
               new CiudadResponse { Id = 2, Nombre = "Quilmes", Provincia = provincia },
               new CiudadResponse { Id = 3, Nombre = "Florencio Varela", Provincia = provincia}

            };
            var expectedErrorMessage = "El valor del orden es inválido. Solo se permite 'ASC' o 'DESC";
            mockCiudadService.Setup(x => x.GetCiudadList("ASC", null, null, null))
                .Throws(new DatoInvalidoException());


            //Act
            var result = CiudadController.GetAll("ASC", null, null, null);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void GetAllCiudades_ShouldReturnBadRequstIdInvalidoException()
        {
            //Arrange
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentina };
            var ciudades = new List<CiudadResponse>
            {

               new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provincia },
               new CiudadResponse { Id = 2, Nombre = "Quilmes", Provincia = provincia },
               new CiudadResponse { Id = 3, Nombre = "Florencio Varela", Provincia = provincia}

            };
            var expectedErrorMessage = "No hay Ciudades de la provincia ingresada";
            mockCiudadService.Setup(x => x.GetCiudadList("ASC", null, null, null))
                .Throws(new IdInvalidoException());


            //Act
            var result = CiudadController.GetAll("ASC", null, null, null);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void GetAllCiudades_ShouldReturnBadRequstElementoInexistenteException()
        {
            //Arrange
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentina };
            var ciudades = new List<CiudadResponse>
            {

               new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provincia },
               new CiudadResponse { Id = 2, Nombre = "Quilmes", Provincia = provincia },
               new CiudadResponse { Id = 3, Nombre = "Florencio Varela", Provincia = provincia}

            };
            var expectedErrorMessage = "No hay Ciudades del pais ingresado";
            mockCiudadService.Setup(x => x.GetCiudadList("ASC", null, null, null))
                .Throws(new ElementoInexistenteException());


            //Act
            var result = CiudadController.GetAll("ASC", null, null, null);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void GetAllCiudades_ShouldReturnBadRequstException()
        {
            //Arrange
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentina };
            var ciudades = new List<CiudadResponse>
            {

               new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provincia },
               new CiudadResponse { Id = 2, Nombre = "Quilmes", Provincia = provincia },
               new CiudadResponse { Id = 3, Nombre = "Florencio Varela", Provincia = provincia}

            };
            var expectedErrorMessage = "Algun parametro ingresado es invalido";
            mockCiudadService.Setup(x => x.GetCiudadList("ASC", null, null, null))
                .Throws(new Exception());


            //Act
            var result = CiudadController.GetAll("ASC", null, null, null);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void GetCiudadById_ShouldReturnBadRequst()
        {
            
            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage = "Hubo un error en los parametros ingresados";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.GetCiudadById(1)).Throws(new Exception());

            //Act
            var result = CiudadController.GetCiudadById(1);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }
        [Fact]
        public void GetCiudadById_ShouldReturnNotFound()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage = "No se encontro la ciudad solicitada";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.GetCiudadById(1)).Throws(new ElementoInexistenteException());

            //Act
            var result = CiudadController.GetCiudadById(1);


            //Assert
            var badResult = Assert.IsType<NotFoundObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }
        [Fact]
        public void GetCiudadById_ReturnCiudadResponse()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.GetCiudadById(1)).Returns(response);

            //Act
            var result = CiudadController.GetCiudadById(1);


            //Assert
         

            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);

            var jsonResponse = jsonResult.Value.Should().BeOfType<CiudadResponse>().Subject;
            jsonResponse.Id.Should().Be(1);
            jsonResponse.Nombre.Should().Be("Quilmes");
      
        }

        [Fact]
        public void RemoveCiudad_ReturnCiudadResponse()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.RemoveCiudad(1)).Returns(response);

            //Act
            var result = CiudadController.DeleteCiudad(1);


            //Assert


            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);

            var jsonResponse = jsonResult.Value.Should().BeOfType<CiudadResponse>().Subject;
            jsonResponse.Id.Should().Be(1);
            jsonResponse.Nombre.Should().Be("Quilmes");

        }
        [Fact]
        public void RemoveCiudad_ShouldReturnNotFound()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage = "No existe la ciudad que quiere eliminar";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.RemoveCiudad(1)).Throws(new ElementoInexistenteException());

            //Act
            var result = CiudadController.DeleteCiudad(1);


            //Assert
            var badResult = Assert.IsType<NotFoundObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

          [Fact]
        public void UpdateCiudad_ReturnCiudadResponse()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.UpdateCiudad(1,request)).Returns(response);

            //Act
            var result = CiudadController.UpdateCiudad(1,request);


            //Assert


            var jsonResult = Assert.IsType<JsonResult>(result);
            Assert.Equal(200, jsonResult.StatusCode);

            var jsonResponse = jsonResult.Value.Should().BeOfType<CiudadResponse>().Subject;
            jsonResponse.Id.Should().Be(1);
            jsonResponse.Nombre.Should().Be("Quilmes");

        }
        [Fact]
        public void UpdateCiudad_ShouldReturnNotFound()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage = "La ciudad que desea modificar no existe";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.UpdateCiudad(1,request)).Throws(new ElementoInexistenteException());

            //Act
            var result = CiudadController.UpdateCiudad(1,request);


            //Assert
            var badResult = Assert.IsType<NotFoundObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status404NotFound);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }
        [Fact]
        public void UpdateCiudad_ShouldBadRequestElementoYaExisteException()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage = "Ya existe la ciudad  que desea ingresar";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.UpdateCiudad(1, request)).Throws(new ElementoYaExisteException());

            //Act
            var result = CiudadController.UpdateCiudad(1, request);


            //Assert
            var badResult = Assert.IsType<ConflictObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status409Conflict);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }

        [Fact]
        public void UpdateCiudad_ShouldBadRequestIdInvalidoException()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage ="La Provincia que se le quiere asignar no existe";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.UpdateCiudad(1, request)).Throws(new IdInvalidoException());

            //Act
            var result = CiudadController.UpdateCiudad(1, request);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }
        [Fact]
        public void UpdateCiudad_ShouldBadRequest()
        {

            //Arrange
            var request = new CiudadRequest { Nombre = "Quilmes", ProvinciaId = 1 };
            var paisArgentina = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provincia = new ProvinciaResponse { Id = 2, Nombre = "Buenos Aires", Pais = paisArgentina };

            var expectedErrorMessage = "Ingreso un parametro invalido";
            var response = new CiudadResponse { Id = 1, Nombre = request.Nombre, Provincia = provincia };
            mockCiudadService.Setup(x => x.UpdateCiudad(1, request)).Throws(new Exception());

            //Act
            var result = CiudadController.UpdateCiudad(1, request);


            //Assert
            var badResult = Assert.IsType<BadRequestObjectResult>(result);
            badResult.StatusCode.Should().Be(StatusCodes.Status400BadRequest);

            var errorMessage = badResult.Value.GetType().GetProperty("message")?.GetValue(badResult.Value) as string;
            errorMessage.Should().Be(expectedErrorMessage);

        }
       
    }
}

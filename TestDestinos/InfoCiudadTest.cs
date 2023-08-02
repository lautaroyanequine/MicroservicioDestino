using Application.Exceptions;
using Application.Interfaces;
using Application.Interfaces.ICiudad;
using Application.Interfaces.IInfoCiudad;
using Application.Interfaces.IPais;
using Application.Interfaces.IProvincia;
using Application.Interfaces.IViajeCiudad;
using Application.Request.InfoCiudad;
using Application.Request.ViajeCiudad;
using Application.Response.Ciudad;
using Application.Response.InfoCiudad;
using Application.Response.Pais;
using Application.Response.Provincia;
using Application.Response.ViajeCiudad;
using Application.UseCase;
using Application.UseCase.InfoCiudades;
using Domain.Entities;
using FluentAssertions;
using Moq;

namespace TestDestinos
{
    public class InfoCiudadTests
    {
        private readonly Mock<IInfoCiudadCommand> mockInfoCiudadCommand;
        private readonly Mock<IInfoCiudadQuery> mockInfoCiudadQuery;
        private readonly Mock<ICiudadService> mockCiudadService;
        private readonly Mock<IInfoCiudadService> mockInfoCiudadService;

        private readonly InfoCiudadService infoCiudadService;

        public InfoCiudadTests()
        {
            mockInfoCiudadCommand = new Mock<IInfoCiudadCommand>();
            mockInfoCiudadQuery = new Mock<IInfoCiudadQuery>();
            mockCiudadService = new Mock<ICiudadService>();

            mockInfoCiudadService = new Mock<IInfoCiudadService>();

            infoCiudadService = new InfoCiudadService(mockInfoCiudadCommand.Object,mockInfoCiudadQuery.Object,mockCiudadService.Object);
        }


        [Fact]
        public void CreateInfoCiudad_WithValidRequest_ReturnsInfoCiudadResponse()
        {
            //Arrange
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };

            mockInfoCiudadCommand.Setup(x => x.CreateInfoCiudad(It.IsAny<InfoCiudad>()))
                .Returns((InfoCiudad)response);
            mockInfoCiudadQuery.Setup(x => x.GetById(response.InfoCiudadId)).Returns(response);

            mockCiudadService.Setup(x => x.GetCiudadById(request.Ciudad_Id)).Returns(ciudadResponse);

            var infoCiudadResponse = new InfoCiudadResponse { Id = response.InfoCiudadId, Ciudad = ciudadResponse.Nombre, Descripcion = response.Descripcion, Imagen = response.ImagenUrl };
            mockInfoCiudadService.Setup(x => x.GetById(response.InfoCiudadId)).Returns(infoCiudadResponse);

            // Act
            var result = infoCiudadService.CrearInfoCiudad(request);

            // Assert
            result.Should().NotBeNull();
            result.Ciudad.Should().Be(ciudadResponse.Nombre);
            result.Descripcion.Should().Be(request.Descripcion);
            result.Imagen.Should().Be(request.Imagen);
        }

        [Fact]
        public void CrearInfoCiudad_WithInvalidCiudadId_ThrowsDatoInvalidoException()
        {
            // Arrange
            var request = new InfoCiudadRequest
            {
                Ciudad_Id = 1,
                Descripcion = "Test Descripcion",
                Imagen = "Test Imagen"
            };

            mockCiudadService.Setup(x => x.GetCiudadById(request.Ciudad_Id)).Returns((CiudadResponse)null);

            // Act
            Action act = () => infoCiudadService.CrearInfoCiudad(request);

            // Assert
            act.Should().Throw<DatoInvalidoException>();
        }

        [Fact]
        public void UpdateInfoCiudad_WithValidRequest_ReturnsUpdateInfoCiudadResponse()
        {
            //Arrange
            int id = 1;
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };

            mockInfoCiudadQuery.Setup(x => x.GetById(id)).Returns(response);

            mockInfoCiudadCommand.Setup(x => x.UpdateInfoCiudad(id, response))
                .Returns(new InfoCiudad { InfoCiudadId = 1, CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen });

            mockInfoCiudadQuery.Setup(x => x.GetById(response.InfoCiudadId)).Returns(response);

            mockCiudadService.Setup(x => x.GetCiudadById(request.Ciudad_Id)).Returns(ciudadResponse);

            var infoCiudadResponse = new InfoCiudadResponse { Id = response.InfoCiudadId, Ciudad = ciudadResponse.Nombre, Descripcion = response.Descripcion, Imagen = response.ImagenUrl };
            mockInfoCiudadService.Setup(x => x.GetById(response.InfoCiudadId)).Returns(infoCiudadResponse);


            //Act
            var result = infoCiudadService.EditarInfoCiudad(id, request);

            //Assert
            result.Should().NotBeNull();
            result.Ciudad.Should().Be(ciudadResponse.Nombre);
            result.Descripcion.Should().Be(request.Descripcion);
            result.Imagen.Should().Be(request.Imagen);

        }
        [Fact]
        public void UpdateInfoCiudad_ReturnNull()
        {
            //Arrange
            int id = 1;
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };

            mockInfoCiudadQuery.Setup(x => x.GetById(id)).Returns((InfoCiudad)null);

            //Act
            var result = infoCiudadService.EditarInfoCiudad(id, request);
            result.Should().BeNull();
        

        }

        [Fact]
        public void RemoveInfoCiudad_WithValidRequest_ReturnsRemoveInfoCiudadResponse()
        {
            

            //Arrange
            int id = 1;
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };

            mockInfoCiudadQuery.Setup(x => x.GetById(id)).Returns(response);

            mockInfoCiudadCommand.Setup(x => x.DeleteInfoCiudad(id))
                .Returns(response);

            mockInfoCiudadQuery.Setup(x => x.GetById(response.InfoCiudadId)).Returns(response);

            mockCiudadService.Setup(x => x.GetCiudadById(request.Ciudad_Id)).Returns(ciudadResponse);

            //Act
            var result = infoCiudadService.EliminarInfoCiudad(id);

            //Assert
            result.Should().NotBeNull();
            result.Ciudad.Should().Be(ciudadResponse.Nombre);
            result.Descripcion.Should().Be(request.Descripcion);
            result.Imagen.Should().Be(request.Imagen);
        }
        [Fact]
        public void RemoveInfoCiudad_ReturnNull()
        {
            //Arrange
            int id = 1;
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };

            mockInfoCiudadQuery.Setup(x => x.GetById(id)).Returns((InfoCiudad)null);

            //Act
            var result = infoCiudadService.EliminarInfoCiudad(id);
            result.Should().BeNull();


        }

        [Fact]
        public void GetByIdInfoCiudad_ReturnNull()
        {
            //Arrange
            int id = 1;
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };

            mockInfoCiudadQuery.Setup(x => x.GetById(id)).Returns((InfoCiudad)null);

            //Act
            var result = infoCiudadService.GetById(id);
            //Assert
            result.Should().BeNull();


        }
        [Fact]
        public void GetByCiudad_ReturnNull()
        {
            //Arrange
            int id = 1;
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };

            mockInfoCiudadQuery.Setup(x => x.GetByCiudad(id)).Returns((InfoCiudad)null);

            //Act
            var result = infoCiudadService.GetPorCiudad(id);
            //Assert
            result.Should().BeNull();


        }

        [Fact]
        public void GetByCiudad_ReturnsInfoCiudad()
        {
            //arrange
            int id = 1;
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };

            mockInfoCiudadQuery.Setup(x => x.GetById(id)).Returns(response);

            mockInfoCiudadCommand.Setup(x => x.DeleteInfoCiudad(id))
                .Returns(response);

            mockInfoCiudadQuery.Setup(x => x.GetById(response.InfoCiudadId)).Returns(response);
            mockInfoCiudadQuery.Setup(x => x.GetByCiudad(ciudadResponse.Id)).Returns(response);

            mockCiudadService.Setup(x => x.GetCiudadById(request.Ciudad_Id)).Returns(ciudadResponse);
            //Act
            var result = infoCiudadService.GetPorCiudad(ciudadResponse.Id);

            //Assert
            result.Should().NotBeNull();
            result.Ciudad.Should().Be(ciudadResponse.Nombre);
            result.Descripcion.Should().Be(request.Descripcion);
            result.Imagen.Should().Be(request.Imagen);
        }

        [Fact]
        public void GetInfoCiudadList_ReturnsInfoCiudadResponses()
        {
            //Arrange
            int id = 1;
            var paisArgentinaResponse = new PaisResponse { Id = 1, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse = new ProvinciaResponse { Id = 1, Nombre = "Buenos Aires", Pais = paisArgentinaResponse };
            var ciudadResponse = new CiudadResponse { Id = 1, Nombre = "Solano", Provincia = provinciaResponse };
            var request = new InfoCiudadRequest { Ciudad_Id = 1, Descripcion = "Test Descripcion", Imagen = "Test Imagen" };
            var response = new InfoCiudad { InfoCiudadId=1, CiudadId = request.Ciudad_Id, Descripcion = request.Descripcion, ImagenUrl = request.Imagen };


            var paisArgentinaResponse2 = new PaisResponse { Id = 2, Nombre = "Argentina", Codigo = "ARG" };
            var provinciaResponse2 = new ProvinciaResponse { Id = 2, Nombre = "Córdoba", Pais = paisArgentinaResponse2 };
            var ciudadResponse2 = new CiudadResponse { Id = 2, Nombre = "Córdoba Capital", Provincia = provinciaResponse2 };
           
            var request2 = new InfoCiudadRequest { Ciudad_Id = 2, Descripcion = "Test Descripcion2", Imagen = "Test Imagen2" };
            var response2 = new InfoCiudad { InfoCiudadId=2, CiudadId = request2.Ciudad_Id, Descripcion = request2.Descripcion, ImagenUrl = request2.Imagen };

            var infoCiudades = new List<InfoCiudad> { response,response2   };
            mockInfoCiudadQuery.Setup(x => x.GetAll()).Returns((List<InfoCiudad>)infoCiudades.ToList());

            mockInfoCiudadQuery.Setup(x => x.GetById(response.InfoCiudadId)).Returns(response);
            mockInfoCiudadQuery.Setup(x => x.GetById(response2.InfoCiudadId)).Returns(response2);


            mockCiudadService.Setup(x => x.GetCiudadById(It.Is<int>(id => id == 1))).Returns(ciudadResponse);
            mockCiudadService.Setup(x => x.GetCiudadById(It.Is<int>(id => id == 2))).Returns(ciudadResponse2);
            //Act
            var result = infoCiudadService.GetAllInfoCiudad();

            //Assert
            result.Should().NotBeNull();
            result.Should().HaveCount(2);
            result[0].Id.Should().Be(response.InfoCiudadId);
            result[0].Ciudad.Should().Be(ciudadResponse.Nombre);
            result[0].Descripcion.Should().Be(response.Descripcion);
            result[0].Imagen.Should().Be(response.ImagenUrl);
            result[1].Id.Should().Be(response2.InfoCiudadId);
            result[1].Ciudad.Should().Be(ciudadResponse2.Nombre);
            result[1].Descripcion.Should().Be(response2.Descripcion);
            result[1].Imagen.Should().Be(response2.ImagenUrl);

        }
    }


}
  





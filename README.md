# Microservicio de Destinos para Agencia de Viajes

Este repositorio alberga un microservicio  dentro de un proyecto web desarrollado en equipo como parte de una asignatura universitaria,el proyecto completo tenia como fin desarrollar una agencia de viajes. El microservicio se centra en proporcionar información detallada y actualizada sobre los destinos de viaje disponibles, brindando a los usuarios una experiencia interactiva y eficiente para explorar y planificar sus aventuras.


### Backend 

El backend se desarrolló utilizando C# y .NET 6 en forma de API. Aplicamos la arquitectura hexagonal, dividiendo el sistema en las capas de Infraestructura, Aplicación y Dominio. Esta organización proporcionó una estructura sólida y mantenible para el proyecto.

### Patrones y Prácticas Modernas

Implementamos patrones de CQRS para optimizar la comunicación con la base de datos, mejorando la eficiencia y escalabilidad del sistema. Utilizamos inyección de dependencia para gestionar las relaciones entre los componentes de manera modular y eficiente.

### Base de Datos Robusta

Optamos por SQL Server y la metodología Code First de Entity Framework para crear una base de datos sólida. Esto permitió una gestión eficiente de los datos y su sincronización con el dominio de la aplicación.

### Comunicación Efectiva con el Frontend

El backend se comunica con el frontend mediante APIs cuidadosamente definidas y documentadas utilizando OpenAPI. Esto asegura una comunicación fluida y un claro entendimiento de los puntos de integración.

### Pruebas Unitarias

El microservicio se sometió a un riguroso proceso de pruebas unitarias para garantizar su calidad y funcionalidad. Esto asegura que el sistema funcione correctamente en diversas situaciones y mejora la confiabilidad del producto final.

## Repositorio y Uso

Este repositorio contiene todo el código fuente y los archivos necesarios para el microservicio de destinos de la agencia de viajes. Puedes clonar el repositorio y explorar tanto el backend como las APIs. Para obtener la experiencia completa, se recomienda clonar y ejecutar localmente debido a las limitaciones de recursos en los hosting gratuitos utilizados para el proyecto.


## Resultado y Contribuciones

Este microservicio fue parte de un proyecto grupal desarrollado como parte de una asignatura universitaria, lo que agregó un valor educativo significativo. Si estás interesado en contribuir, las solicitudes de extracción son bienvenidas.

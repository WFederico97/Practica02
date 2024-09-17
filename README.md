# API para Manejo de Artículos en C# con .NET

Este proyecto proporciona una API CRUD (Crear, Leer, Actualizar, Eliminar) para gestionar artículos en un sistema. Utiliza un patrón de diseño basado en repositorios que abstrae la lógica de acceso a datos de la lógica de negocios, y emplea procedimientos almacenados para manipular datos en la base de datos.

## Estructura del Proyecto

La solución está organizada de la siguiente manera:

- **Models**: Contiene las clases de los modelos de datos, como `Articulo`.
- **DTOs**: Contiene clases de transferencia de datos (Data Transfer Objects) como `ProductUpdateDTO`.
- **Repositories**: Contiene interfaces y sus implementaciones para el manejo de la lógica de acceso a datos.
- **Controllers**: Contiene los controladores API para manejar las solicitudes HTTP.

```
Practica02/
├── .gitattributes
├── .gitignore
├── appsettings.json
├── Practica02.http
├── Program.cs
├── README.md
├── Controllers/
│   ├── ArticulosController.cs
├── DTOs/
│   ├── ProductCreateDTO.cs
│   ├── ProductReadDTO.cs
│   ├── ProductUpdateDTO.cs
├── Models/
│   ├── Articulo.cs
├── Repositories/
│   ├── Implementations/
│   │   ├── AplicacionRepository.cs
│   ├── Interfaces/
│   │   ├── IAplicacion.cs

```

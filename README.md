# ZavCrudServer

Un crud sobre **"Visitas Web"**, integrando una arquitectura definida, con una API RESTful en ASP.NET Core

## Requerimientos

* **SQL Server 2017** o posterior
* **.NET Core SDK 3.0** <https://dotnet.microsoft.com/download>
  * Descargar el **SDK** en la opción **Build Apps**
  * Instalar
* **Visual Studio 2019 IDE** o algún editor como **"vscode"** que cumpla con el soporte de **.NET Core** y **C# 8** o posterior

## Ejecución del proyecto

* Clonar proyecto con git en el ambiente local
* Si es desde el IDE de Visual Studio:
  * Abrir solución
  * Click derecho en el proyecto **Crud.API**
    * Establecer como proyecto de inicio
    * Ejecutar proyecto
* Si es desde un editor como **vscode** con el SDK ya instalado, ejecutar lo siguiente en la línea de comandos:

```shell
donet run --project Crud.Api
```

### Comprobación del proyecto

<<<<<<< HEAD
Ya estando en ejecución el proyecto, abrir en el browser con la siguiente url: <http://localhost:5000/api/visita> (como lo indica la linea de comandos en el puerto 5000) o si es desde un puerto diferente desde el IDE de Visual Studio, se visualizaran una lista de datos tomados desde el API por medio de una base de datos creada automáticamente. La base de datos es creada con el motor **MSSQL** y el ORM **EntityFramework Core**, está situada en la ruta:
=======
Ya estando en ejecución el proyecto, abrir en el browser la siguiente url: <http://localhost:5000/api/visita> (como lo indica la linea de comandos en el puerto 5000), se visualizaran una lista de datos tomados desde el API por medio de una base de datos creada automáticamente. La base de datos es creada con el motor **MSSQL** y el ORM **EntityFramework Core**, está situada en la ruta:
>>>>>>> 3ac9bc714f4f8d8eee28214f253c3bf92e01153a

* Crud.API/App_Data/CrudDB.mdf
* Crud.API/App_Data/CrudDB_log.ldf

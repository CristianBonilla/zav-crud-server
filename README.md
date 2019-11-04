# ZavCrudServer

Un crud sobre **"Visitas Web"**, integrando una arquitectura definida, con una API RESTful en ASP.NET Core

## Requerimientos

* **SQL Server 2017** o posterior
* **.NET Core SDK 3.0** <https://dotnet.microsoft.com/download>
  * Descargar el **SDK** en la opción **Build Apps**
  * Instalar
* **Visual Studio IDE** o algún editor como **"vscode"** que cumpla con el soporte de **.NET Core** y **C# 8** o posterior

## Comando de ejecución

Una vez clonado el proyecto en el ambiente local y el SDK instalado, ejecutar lo siguiente en la línea de comandos:

```shell
donet run --project Crud.Api
```

### Comprobación del proyecto

Ya estando en ejecución el proyecto, abrir en el browser la siguiente url: <http://localhost:5000/api/visita> (como lo indica la linea de comandos en el puerto 5000), se visualizaran una lista de datos tomados desde el API por medio de una base de datos creada automáticamente. La base de datos es creada con el motor **MSSQL** y el ORM **EntityFramework Core**, está situada en la ruta:

* Crud.API/App_Data/CrudDB.mdf
* Crud.API/App_Data/CrudDB_log.ldf

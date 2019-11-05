# ZavCrudServer

Un crud sobre **"Visitas Web"**, integrando una arquitectura definida, con una API RESTful en ASP.NET Core

## Requerimientos

* **SQL Server 2017** o posterior
* **.NET Core SDK 3.0** <https://dotnet.microsoft.com/download>
  * Descargar el **SDK** en la opción **Build Apps**
  * Instalar
* **Visual Studio 2019 IDE** o algún editor como **"vscode"** que cumpla con el soporte de **.NET Core** y **C# 8**

### Ejecución del proyecto

* Clonar proyecto con git en el ambiente local
* Si es desde el IDE de Visual Studio:
  * Abrir solución
  * Click derecho en el proyecto **Crud.API**
    * Click en Establecer como proyecto de inicio
    * Click en Ver > Ver en el Explorador <http://localhost:8215/api/visita>
* Si es desde un editor como **vscode** con el SDK ya instalado, ejecutar lo siguiente en la línea de comandos:

```shell
donet run -p Crud.API
```

>Esperar a que esté en ejecución el proyecto para luego abrir en el browser o en la app de **postman** con la siguiente url: <http://localhost:5000/api/visita> (como lo indica la linea de comandos en el puerto 5000)

### Comprobación del proyecto

Se visualizaran una lista de datos tomados desde el API por medio de una base de datos creada automáticamente.
La base de datos es creada con el motor **MSSQL** y el ORM **EntityFramework Core**, está situada en la ruta:

* Crud.API/App_Data/CrudDB.mdf
* Crud.API/App_Data/CrudDB_log.ldf

# CRUD Api Rest

Esta aplicación ofrece:
- API Rest CRUD para entidad Usuarios (JSON/XML).
- Formularios CRUD que consumen el anterior API Rest.

 ## Requisitos
 - Visual Studio 2015 entrerprise

## ¿Cómo ejecutar la aplicación?

 1. Descargar la solución (proyecto). Para ello pulsar en el botón Clone or Download - Download ZIP
 2. Extraer el fichero en la ubicación deseada.
 3. Abrir Visual Studio, Archivo - Abrir Solución y buscar en el directorio descomprimido el fichero Aplicacion_Meteorologia.sln
 4. Las migraciones de la base de datos, tanto creacion como precargar se deberían ejecutar automaticamente. Si no se ejecutaran automaticamente, Ejecutar migraciones Base de datos.
 Herramientas - Administrador de Paquetes Nuget - Consola del Administrador de Paquetes
    Enable-Migrations
    Add-Migration Initial
    Update-Database


 5. Lanzar la aplicacion desde Visual Studio pulsando F5 o clicando en el boton de play.
   5.1 *En el alta de usuarios, para establecer la ubicación, en el combo se debe escribir la localidad, seguida del pais, (ejem: León,ES), la API buscará automaticamente dicha ubicación.
 6. Conectarse con el navegador a http://localhost:54313

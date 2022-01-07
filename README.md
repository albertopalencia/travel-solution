# travel-solution

Página web con .NET 5 

# Primeros Pasos Para correr la aplicacion

# Base de datos:
 * vaya al proyecto de WebApi ubicado en la carpeta src/presentation, estando alli ubicar el archivo appsettings.json y cambiar la siguiente
   cadena ConnectionStrings -> Travel por la cadena de la base de datos donde quiera que se genere las tablas.
   para que se corra la actualizacion de la base de datos
 * Migracion: para ejecutar la migracion es necesario ir a tools o herramientas Nuget Package Managed y Nuget Package Console, antes de escribir el comando debemos mirar si tenemos seleccionado el proyecto webapi, si es asi debemos escribir en la consola el comando update-database 
 
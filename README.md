# Sistema de inscripcion de materias con registro y login por usuario

Este Sistema permita registrar e iniciar sesion a diferentes estudiantes. hay ciertas reglas de negocio donde 
no se puede inscriobir mas de 3 asignaturas. no puede ver clases con el mismo profesor, podra mostrar los registros de los demas estudiantes y podra ver los estudiantes
que estan en las misma materias o asignaturas.

# Tecnologias
.NET6,
Entity Framework  Core,
Mysql,
swagger en desarrollo e insomnia,
Angular 18,
node 22.12.0,
Boostrap CDN,


#configuracion

 Clonar el repositorio del proyecto
 https://github.com/andresmel/interrapidisimo
 cd interrapidisimo
 encontrara los dos proyectos web-api y web-app
 web-api limpiar y recompilar
 web-app npm install
 encontrara el script universidad.sql con el cual podra crear la base de datos y las tablas asignadas.
 en web-api debera cambiar en el appsetting.json la cadena de coneccion a base de datos con el usuario y contrasena del usuario de su  BD
 "ConnectionStrings": {
  "universidad": "server=localhost;database=universidad;user=root;password="
}

#arquitectura
El proyecto fue creado con una arquitectura de capas. esta integrada con interfazes para separar responsabilidades y definir contratos, metodos que deben utilizarse y sus parametros,
permite cambiar la implementacion sin afectar controllers services y/o repositories

Ayuda en la practica de testing  y mockear las interfaces

escalabilidad y mantenibilidad


#autor 
Andres Melo



 
 
 
 

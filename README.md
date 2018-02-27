# ExamenClaroVideo
Este repositorio es un diseño de prueba

Introduccion:
Este repositorio contiene una ejemplo del patrón MVVM para la plataforma universal de Windows (UWP) en el Kit de desarrollo de software de Windows (SDK) para Windows 10. Este ejemplo de código se creo con las plantillas de la plataforma universal de Windows disponibles en Visual Studio, y diseñado para ejecutarse en dispositivos de escritorio, dispositivos móviles.

Detalles:
Este ejemplo esta pensado para consumir datos de un web service el cual contiene la información de un numero de películas y sus detalles, el cual se consume y se visualiza para simular una categoría. Al realizar peticiones estas son almacenadas en una base local para su registro. Ya que cuenta con un sistema offline y online. El cual al haber cambios en el acceso a internet, este cambia el origen de los recurso para que este pueda ser visualizado en caso de falla con el web service. Tanto los recursos mostrados como el buscador incorporado, pueden ser usados en Offline u Online. Esto pensado para la implementación de sqllite.


Instalacion: 
Estos ejemplos requieren Visual Studio 2017 Update 1 o posterior y el Kit de desarrollo de software de Windows (SDK) versión 15063 o superior para Windows 10.
La forma más sencilla de usar estas muestras sin utilizar Git es descargar el archivo zip que contiene la versión actual. A continuación, puede descomprimir todo el archivo y usar las muestras en Visual Studio 2017.
En Visual Studio 2017, el objetivo de la plataforma se establece por defecto en ARM, así que asegúrese de cambiarlo a x64 o x86 si desea probar en un dispositivo que no sea ARM.
Es importante antes de ejecutar el ejemplo, Limpiar y Compilar. Ya que en ocasiones no se generan las dependencias al implementar.

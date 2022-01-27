# AI-Software Evaluation

## Requisitos
- [VueJS 3.2.X CLI](https://v3.vuejs.org/guide/installation.html#release-notes) Instalado
- [Net Core 5.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/5.0) Instalado

&nbsp;
## 1.- Iniciar la aplicación de back end
El primer paso será ejecutar la aplicación del back end para que esta esté lista para recibir los datos.

&nbsp;
## 2.- Ejecutar las pruebas de Postman
> Se tendrán que ejecutar las pruebas de [Postman](https://www.postman.com/) debido a que estas también se encargan de inicializar la base de datos con información para el resto de la aplicación.

Los dos archivos se encuentran dentro de la carpeta: **back_end_docs**

- Las pruebas se encuentran en el archivo: **AI Software Test Suite.postman_collection.json** 

- La documentación se encuentra en el archivo **AI Software Api Documentation.postman_collection.json**



&nbsp;
## 3.- Setup del front end
Las dependencias del front end deberán ser instaladas antes de poder ejecutar la aplicación de VuejS
```
npm install
```

&nbsp;
## 4.- Ejecutar la aplicación de VueJS
Se tendrá que ejecutar el siguiente comando para iniciar el programa de VueJS

```
npm run serve
```

&nbsp;
# Consideraciones
## 1.- Web service
- El Web Service creará una nueva orden, durante la actualización, con el producto que falta en caso de que la cantidad del mismo producto sea menor a 5.
- El Web Service checará el SKU al momento de crear los productos.

&nbsp;
## 2.- Front End
- Los productos eliminados durante el proceso no podrán ser recuperados a menos de que estos sean actualizados mediante el Web Service.
# API-POLYGON-MVP

API-POLYGON-MVP es una aplicación backend desarrollada en ASP.NET Core que interactúa con la red Polygon (anteriormente Matic) para realizar transacciones y consultar información sobre la blockchain.

## Menú

- [API-POLYGON-MVP](#api-polygon-mvp)
  - [Menú](#menú)
  - [Descripción](#descripción)
  - [Contrato Utilizado en el Proyecto](#contrato-utilizado-en-el-proyecto)
    - [Comentarios sobre el Contrato:](#comentarios-sobre-el-contrato)
  - [Requisitos](#requisitos)
  - [Configuración](#configuración)
  - [Instalación y ejecución](#instalación-y-ejecución)
  - [Uso](#uso)
  - [Despliegue del Contrato](#despliegue-del-contrato)
  - [Creación de una Cuenta en MetaMask y Conexión a la Red Mumbai de Polygon](#creación-de-una-cuenta-en-metamask-y-conexión-a-la-red-mumbai-de-polygon)
  - [Configuración](#configuración-1)
  - [Creación de una Cuenta en Infura](#creación-de-una-cuenta-en-infura)
  - [Contribución](#contribución)


## Descripción

Este proyecto proporciona una API que permite enviar transacciones a la red Polygon y consultar información sobre transacciones utilizando el hash de transacción. Utiliza la biblioteca Nethereum para interactuar con la red Ethereum.


## Contrato Utilizado en el Proyecto

El contrato utilizado en este proyecto es un contrato simple de almacenamiento desarrollado en Solidity. Aquí está el código del contrato:

```solidity
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.7;

contract SimpleStorage {
    // Variable privada para almacenar los datos
    string private _storedData;

    // Función para actualizar el valor almacenado
    function set(string memory x) public {
        _storedData = x;
    }

    // Función para obtener el valor almacenado
    function get() public view returns (string memory) {
        return _storedData;
    }
}
```

### Comentarios sobre el Contrato:

- **SPDX-License-Identifier**: Esta línea especifica el tipo de licencia bajo la cual se publica el contrato. En este caso, se utiliza la licencia MIT, que es una licencia de código abierto que permite a los usuarios utilizar, modificar y distribuir el código con pocas restricciones.

- **pragma solidity ^0.8.7**: Esta declaración indica que el contrato está escrito para la versión 0.8.7 del compilador de Solidity o versiones superiores compatibles.

- **SimpleStorage**: Este es el nombre del contrato. Es un contrato simple que proporciona funciones para establecer y obtener un valor de cadena.

- **_storedData**: Esta es una variable privada que almacena el valor de cadena.

- **set**: Esta función permite actualizar el valor almacenado en `_storedData` a través de un parámetro de entrada.

- **get**: Esta función permite obtener el valor actualmente almacenado en `_storedData`.

El contrato proporciona una funcionalidad básica de almacenamiento de datos, lo que lo hace adecuado para propósitos de demostración y pruebas en este proyecto.


## Requisitos

- .NET Core 8.0 SDK
- Docker (opcional, para ejecutar la aplicación en contenedores)

## Configuración

Antes de ejecutar la aplicación, asegúrate de configurar las siguientes variables de entorno:

- `PolygonURL`: URL de la red Polygon a la que te conectarás.
- `PublicAddress`: Dirección pública de la cuenta utilizada para enviar transacciones.
- `PrivateKey`: Clave privada de la cuenta que utilizarás para enviar transacciones.
- `ContractAddress`: Dirección del contrato inteligente desplegado en la red Polygon.
- `ContractABI`: ABI del contrato inteligente en formato JSON.

Puedes obtener el ABI de tu contrato inteligente y configurarlo como una variable de entorno. Para desplegar el contrato, puedes usar Remix Ethereum IDE en [este enlace](https://remix.ethereum.org/).

## Instalación y ejecución

1. Clona el repositorio:

```bash
git clone https://github.com/tuusuario/API-POLYGON-MVP.git
cd API-POLYGON-MVP
```

2. Configura las variables de entorno mencionadas anteriormente.

3. Compila y ejecuta la aplicación:

```bash
dotnet run
```

Alternativamente, puedes ejecutar la aplicación en un contenedor Docker. Ejecuta los siguientes comandos:

```bash
docker build -t api-polygon-mvp .
docker run -d -p 80:80 --name api-polygon-mvp-container api-polygon-mvp
```

## Uso

Una vez que la aplicación esté en funcionamiento, puedes interactuar con ella a través de las siguientes rutas:

- `POST /api/data/save`: Envía una transacción a la red Polygon. Asegúrate de tener Matic en tu cuenta para pagar el gas.
- `GET /api/data/{transactionHash}`: Consulta información sobre una transacción utilizando su hash.

Para obtener Matic de prueba, puedes utilizar [este grifo](https://www.alchemy.com/faucets/polygon-mumbai).

## Despliegue del Contrato

Para desplegar el contrato inteligente, sigue estos pasos:

1. Abre Remix Ethereum IDE en [este enlace](https://remix.ethereum.org/).
2. Copia y pega el código fuente de tu contrato en el editor.
3. Compila y despliega el contrato utilizando Remix.
4. Una vez desplegado, copia la dirección del contrato y el ABI.

Luego, configura la dirección del contrato desplegado y el ABI como variables de entorno en tu aplicación.

## Creación de una Cuenta en MetaMask y Conexión a la Red Mumbai de Polygon

Para interactuar con la red Polygon y enviar transacciones desde tu aplicación, necesitarás una billetera Ethereum como MetaMask. Sigue estos pasos para crear una cuenta en MetaMask y conectarla a la red Mumbai de Polygon:

1. Instala la extensión MetaMask en tu navegador desde [MetaMask](https://metamask.io/).
2. Abre MetaMask y sigue las instrucciones para crear una nueva cuenta.
3. Guarda tu clave privada de forma segura. Esta clave te permitirá acceder a tu cuenta desde cualquier dispositivo.
4. Una vez que hayas creado tu cuenta de MetaMask, ve a [Chainlist.org](https://chainlist.org/).
5. En Chainlist, busca y selecciona la red "Mumbai Testnet" de Polygon.
6. Haz clic en "Connect to MetaMask" y sigue las instrucciones para conectar tu billetera MetaMask a la red Mumbai de Polygon.

Con tu cuenta de MetaMask conectada a la red Mumbai de Polygon y suficiente Matic en ella para pagar el gas, podrás interactuar con la red Polygon a través de la API.

## Configuración

Antes de ejecutar la aplicación, asegúrate de configurar las siguientes variables de entorno:

- `PolygonURL`: URL de la red Polygon a la que te conectarás. Puedes obtener esta URL al crear una cuenta en Infura y seleccionar la testnet de Polygon.
- `PrivateKey`: Clave privada de la cuenta que utilizarás para enviar transacciones. Esta clave se puede obtener de tu billetera Ethereum.
- `ContractAddress`: Dirección del contrato desplegado en la red Polygon. Puedes obtener esta dirección después de desplegar el contrato en Remix Ethereum IDE o cualquier otra herramienta de despliegue de contratos.

## Creación de una Cuenta en Infura

Para utilizar la testnet de Polygon a través de Infura, necesitarás crear una cuenta en Infura y seleccionar la testnet de Polygon como tu red preferida. Sigue estos pasos para crear una cuenta en Infura:

1. Ve al sitio web de [Infura](https://infura.io/).

2. Regístrate para obtener una cuenta gratuita o inicia sesión si ya tienes una cuenta.

3. Después de iniciar sesión, ve al panel de control de Infura.

4. Haz clic en "Create New Project" (Crear Nuevo Proyecto).

5. Selecciona "Polygon (Matic)" como la red para tu proyecto.

6. Completa el formulario con los detalles de tu proyecto y haz clic en "Create" (Crear).

7. Una vez creado el proyecto, podrás obtener la URL de la red Polygon (Matic) desde el panel de control de tu proyecto en Infura. Esta URL será utilizada como el valor de la variable de entorno `PolygonURL` en tu aplicación.

Una vez configurada tu cuenta en Infura y obtenida la URL de la red Polygon, podrás utilizarla en tu aplicación para interactuar con la testnet de Polygon.

## Contribución

¡Las contribuciones son bienvenidas! Si deseas contribuir a este proyecto, crea una nueva rama y presenta una solicitud de extracción.

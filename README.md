# API-POLYGON-POC

API-POLYGON-POC is a backend application developed in ASP.NET Core that interacts with the Polygon network (formerly Matic) to carry out transactions and consult information on the blockchain.

## Menu

- [API-POLYGON-POC](#api-polygon-poc)
  - [Menu](#menu)
  - [Description](#description)
  - [Contract Used in the Project](#contract-used-in-the-project)
    - [Comments on the Contract:](#comments-on-the-contract)
  - [Requirements](#requirements)
  - [Configuration](#configuration)
  - [Installation and Execution](#installation-and-execution)
  - [Usage](#usage)
  - [Contract Deployment](#contract-deployment)
  - [Creating an Account on MetaMask and Connecting to the Mumbai Polygon Network](#creating-an-account-on-metamask-and-connecting-to-the-mumbai-polygon-network)
  - [Configuration](#configuration-1)
  - [Creating an Account on Infura](#creating-an-account-on-infura)
  - [Contribution](#contribution)


## Description

This project provides an API that allows sending transactions to the Polygon network and consulting information on transactions using the transaction hash. It uses the Nethereum library to interact with the Ethereum network.


## Contract Used in the Project

The contract used in this project is a simple storage contract developed in Solidity. Here is the contract code:

```solidity
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.7;

contract SimpleStorage {
    // Private variable to store data
    string private _storedData;

    // Function to update the stored value
    function set(string memory x) public {
        _storedData = x;
    }

    // Function to get the stored value
    function get() public view returns (string memory) {
        return _storedData;
    }
}
```

### Comments on the Contract:

- **SPDX-License-Identifier**: This line specifies the type of license under which the contract is published. In this case, the MIT license is used, which is an open-source license that allows users to use, modify, and distribute the code with few restrictions.

- **pragma solidity ^0.8.7**: This statement indicates that the contract is written for version 0.8.7 of the Solidity compiler or higher compatible versions.

- **SimpleStorage**: This is the name of the contract. It is a simple contract that provides functions to set and get a string value.

- **_storedData**: This is a private variable that stores the string value.

- **set**: This function allows updating the stored value in `_storedData` through an input parameter.

- **get**: This function allows getting the currently stored value in `_storedData`.

The contract provides basic data storage functionality, making it suitable for demonstration and testing purposes in this project.


## Requirements

- .NET Core 8.0 SDK
- Docker (optional, to run the application in containers)

## Configuration

Before running the application, make sure to configure the following environment variables:

- `PolygonURL`: URL of the Polygon network you will connect to.
- `PublicAddress`: Public address of the account used to send transactions.
- `PrivateKey`: Private key of the account you will use to send transactions.
- `ContractAddress`: Address of the smart contract deployed on the Polygon network.
- `ContractABI`: Smart contract ABI in JSON format.

You can obtain the ABI of your smart contract and configure it as an environment variable. To deploy the contract, you can use Remix Ethereum IDE at [this link](https://remix.ethereum.org/).

## Installation and Execution

1. Clone the repository:

```bash
git clone https://github.com/yourusername/API-POLYGON-MVP.git
cd API-POLYGON-MVP
```

2. Configure the environment variables mentioned above.

3. Compile and run the application:

```bash
dotnet run
```

Alternatively, you can run the application in a Docker container. Execute the following commands:

```bash
docker build -t api-polygon-mvp .
docker run -d -p 5235:5235 --name api-polygon-mvp-container api-polygon-mvp
```

## Usage

Once the application is running, you can interact with it through the following routes:

- `POST /api/data/save`: Sends a transaction to the Polygon network. Make sure you have Matic in your account to pay for gas.
- `GET /api/data/{transactionHash}`: Consults information on a transaction using its hash.

To get test Matic, you can use [this faucet](https://www.alchemy.com/faucets/polygon-mumbai).

## Contract Deployment

To deploy the smart contract, follow these steps:

1. Open Remix Ethereum IDE at [this link](https://remix.ethereum.org/

).
2. Copy and paste your contract's source code into the editor.
3. Compile and deploy the contract using Remix.
4. Once deployed, copy the contract's address and ABI.

Then, configure the deployed contract's address and ABI as environment variables in your application.

## Creating an Account on MetaMask and Connecting to the Mumbai Polygon Network

To interact with the Polygon network and send transactions from your application, you will need an Ethereum wallet like MetaMask. Follow these steps to create an account on MetaMask and connect it to the Mumbai Polygon network:

1. Install the MetaMask extension in your browser from [MetaMask](https://metamask.io/).
2. Open MetaMask and follow the instructions to create a new account.
3. Securely save your private key. This key will allow you to access your account from any device.
4. Once you have created your MetaMask account, go to [Chainlist.org](https://chainlist.org/).
5. In Chainlist, search for and select the "Mumbai Testnet" network of Polygon.
6. Click on "Connect to MetaMask" and follow the instructions to connect your MetaMask wallet to the Mumbai Polygon network.

With your MetaMask account connected to the Mumbai Polygon network and enough Matic in it to pay for gas, you will be able to interact with the Polygon network through the API.

## Configuration

Before running the application, make sure to configure the following environment variables:

- `PolygonURL`: URL of the Polygon network you will connect to. You can obtain this URL by creating an account on Infura and selecting the Polygon testnet.
- `PrivateKey`: Private key of the account you will use to send transactions. This key can be obtained from your Ethereum wallet.
- `ContractAddress`: Address of the contract deployed on the Polygon network. You can obtain this address after deploying the contract on Remix Ethereum IDE or any other contract deployment tool.

## Creating an Account on Infura

To use the Polygon testnet through Infura, you will need to create an account on Infura and select the Polygon testnet as your preferred network. Follow these steps to create an account on Infura:

1. Go to the [Infura](https://infura.io/) website.

2. Sign up for a free account or log in if you already have an account.

3. After logging in, go to Infura's dashboard.

4. Click on "Create New Project" (Create New Project).

5. Select "Polygon (Matic)" as the network for your project.

6. Complete the form with your project details and click on "Create" (Create).

7. Once the project is created, you will be able to obtain the URL of the Polygon (Matic) network from your project's dashboard on Infura. This URL will be used as the value for the `PolygonURL` environment variable in your application.

Once your account on Infura is set up and you have obtained the URL of the Polygon network, you will be able to use it in your application to interact with the Polygon testnet.

## Contribution

Contributions are welcome! If you would like to contribute to this project, create a new branch and submit a pull request.

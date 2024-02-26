namespace Api_Polygon
{
    /// <summary>
    /// This function is used to configure the environment variables required for the application to run.
    /// It sets up the PolygonURL, PublicAddress, PrivateKey, ContractAddress, and ContractABI environment variables.
    /// These variables are necessary for interacting with the Polygon network and smart contracts.
    /// </summary>
    public static class EnvironmentConfig
    {
        public static void ConfigureEnvironmentVariables()
        {
            // Set up the environment variable at runtime
            Environment.SetEnvironmentVariable("PolygonURL", "");
            Environment.SetEnvironmentVariable("PublicAddress", "");
            Environment.SetEnvironmentVariable("PrivateKey", "");
            Environment.SetEnvironmentVariable("ContractAddress", "0x88590c420da62f47f8e686bbd0f858f2239bdd32");
            // We define the contract ABI as a JSON and configure it as an environment variable.
            string abiJson = @"
            [
                {
                    ""inputs"": [],
                    ""name"": ""get"",
                    ""outputs"": [
                        {
                            ""internalType"": ""string"",
                            ""name"": """",
                            ""type"": ""string""
                        }
                    ],
                    ""stateMutability"": ""view"",
                    ""type"": ""function""
                },
                {
                    ""inputs"": [
                        {
                            ""internalType"": ""string"",
                            ""name"": ""x"",
                            ""type"": ""string""
                        }
                    ],
                    ""name"": ""set"",
                    ""outputs"": [],
                    ""stateMutability"": ""nonpayable"",
                    ""type"": ""function""
                }
            ]";
            Environment.SetEnvironmentVariable("ContractABI", abiJson);
        }
    }
}

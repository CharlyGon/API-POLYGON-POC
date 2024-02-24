namespace Api_Polygon
{
     public static class EnvironmentConfig
    {
        public static void ConfigureEnvironmentVariables()
        {
            // Set up the environment variable at runtime
            Environment.SetEnvironmentVariable("PolygonURL", "");
            Environment.SetEnvironmentVariable("PublicAddress", "0xC588197Fc720439537D917E55E2e9fc65B0C7f89");
            Environment.SetEnvironmentVariable("PrivateKey", "");
            Environment.SetEnvironmentVariable("ContractAddress", "0x88590c420da62f47f8e686bbd0f858f2239bdd32");
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

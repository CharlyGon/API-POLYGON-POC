using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Api_Polygon
{
  public static class DataRoutes
    {
        public static void MapDataRoutes(this IEndpointRouteBuilder endpoints)
        {
            // Endpoint for the GET method
            endpoints.MapControllerRoute(
                name: "GetData",
                pattern: "api/data/{transactionHash}",
                defaults: new { controller = "Data", action = "Get" }
            );

             // Endpoint to save data to the blockchain
            endpoints.MapControllerRoute(
                name: "SaveDataToBlockchain",
                pattern: "api/data/save",
                defaults: new { controller = "Data", action = "SaveToBlockchain" }
            );
        }
    }
}

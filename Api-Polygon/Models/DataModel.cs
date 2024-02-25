using System.ComponentModel.DataAnnotations;

namespace Api_Polygon.Models
{
    /// <summary>
    /// This class represents the data model used to interact with the smart contract.
    /// It contains a single property, Message, which is required for the interaction.
    /// </summary>
     public class DataModel
    {
        [Required(ErrorMessage = "The Message field is mandatory.")]
        public string? Message { get; set; }
    }
}

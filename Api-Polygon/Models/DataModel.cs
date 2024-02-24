using System.ComponentModel.DataAnnotations;

namespace Api_Polygon.Models
{
     public class DataModel
    {
        [Required(ErrorMessage = "The Message field is mandatory.")]
        public string? Message { get; set; }
    }
}

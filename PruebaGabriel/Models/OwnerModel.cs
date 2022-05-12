using System.ComponentModel.DataAnnotations;

namespace PruebaGabriel.Models
{
    public class OwnerModel
    {
        [Key]
        public int IdOwner { get; set; }

        public string Name { get; set; } = string.Empty;
    }
}

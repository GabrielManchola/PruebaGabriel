using System.ComponentModel.DataAnnotations;

namespace PruebaGabriel.Models
{
    public class PropertyModel
    {
        [Key]
        public int IdProperty { get; set; }

        public int IdImagenProperty { get; set; }

        public string Adress { get; set; }

        public decimal Price { get; set; }

        public int IdOwner { get; set; }



    }
}

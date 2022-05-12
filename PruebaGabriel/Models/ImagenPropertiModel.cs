using System.ComponentModel.DataAnnotations;

namespace PruebaGabriel.Models
{
    public class ImagenPropertiModel
    {
        [Key]
        public int IdImagenProperty { get; set; }

        public string Photo { get; set; }

    }
}

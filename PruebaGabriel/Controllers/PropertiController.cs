using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaGabriel.Models;

namespace PruebaGabriel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiController : ControllerBase
    {
        private static List<PropertyModel> Propertys = new List<PropertyModel>()
       {
                new PropertyModel
                {
                    IdImagenProperty = 1,
                    IdOwner = 1,
                    Adress = "Funciona",
                    Price = 123
                }
        };


        [HttpGet]
        public async Task<ActionResult<List<PropertyModel>>> Get()
        {
            return Ok(Propertys);
        }
    }
}

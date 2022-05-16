using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaGabriel.Models;

namespace PruebaGabriel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertiController : ControllerBase
    {
        private readonly DataContext context;

        public PropertiController(DataContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<List<PropertyModel>>> Get()
        {
            return Ok(await context.Property.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<PropertyModel>>> AddProperty(PropertyModel modelo)
        {
            context.Property.Add(modelo);
            await context.SaveChangesAsync();

            return Ok(await context.Property.ToListAsync());
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<PropertyModel>> GetId(int id)
        {
            var property = await context.Property.FindAsync(id);
            if (property == null)
            {
                return BadRequest("Property not found.");
            }
            return Ok(property);
        }


        [HttpPut]
        public async Task<ActionResult<List<PropertyModel>>> UpdatePrice(PropertyModel modelo)
        {
            var dboproperty = await context.Property.FindAsync(modelo.IdProperty);
            if (dboproperty == null)
            {
                return BadRequest("Property not found.");
            }

           
            dboproperty.Price = modelo.Price;

            await context.SaveChangesAsync();
            return Ok(await context.Property.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<PropertyModel>>> Delete(int id)
        {
            var owner = await context.Property.FindAsync(id);
            if (owner == null)
            {
                return BadRequest("Property not found.");
            }

            context.Property.Remove(owner);
            await context.SaveChangesAsync();
            return Ok(await context.Property.ToListAsync());
        }


    }
}

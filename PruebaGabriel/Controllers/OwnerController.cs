using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PruebaGabriel.Models;

namespace PruebaGabriel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {


        private static List<OwnerModel> Owners = new List<OwnerModel>()
       {
                new OwnerModel
                {
                    IdOwner = 1,
                    Name = "Si funciona"
                }
        };
        private readonly DataContext context;

        public OwnerController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<OwnerModel>>> Get()
        {
            return Ok(await context.Owner.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<OwnerModel>>> AddOwner(OwnerModel modelo)
        {
            context.Owner.Add(modelo);
            await context.SaveChangesAsync();
            
            return Ok(await context.Owner.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OwnerModel>> GetId(int id)
        {
            var owner = await context.Owner.FindAsync(id);
            if(owner == null)
            {
                return BadRequest("Owner not found.");
            }
            return Ok(owner);
        }

        [HttpPut]
        public async Task<ActionResult<List<OwnerModel>>> UpdateOwner(OwnerModel modelo)
        {
            var dbowner = await context.Owner.FindAsync(modelo.IdOwner);
            if (dbowner == null)
            {
                return BadRequest("Owner not found.");
            }

            dbowner.Name = modelo.Name;
            dbowner.IdOwner = modelo.IdOwner;

            await context.SaveChangesAsync();
            return Ok(await context.Owner.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<OwnerModel>>> Delete(int id)
        {
            var owner = await context.Owner.FindAsync(id);
            if (owner == null)
            {
                return BadRequest("Owner not found.");
            }

            context.Owner.Remove(owner);
            await context.SaveChangesAsync();
            return Ok(await context.Owner.ToListAsync());
        }





    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjektWebAPI.Models;
using ProjektWebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace ProjektWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokeController : ControllerBase
    {

        private readonly PokeDbContext _context;

        public PokeController(PokeDbContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult<IEnumerable<PokeDTO>>> Get()
        {
            return await _context.Pokeapis.Select(t => t.ToDTO()).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokeDTO>> GetPoke(int id)
        {
            var poke = await _context.Pokeapis.FindAsync(id);

            if (poke == null)
            {
                return NotFound();
            }

            return poke.ToDTO();       
        
        }



        [HttpPost]
        public async Task<ActionResult<PokeDTO>> PostTodo(PokeDTO dto)
        {
            var poke = dto.ToModel();
            _context.Pokeapis.Add(poke);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPokeapi", new { id = poke.Id }, dto);
        }

    }
}

using jujutsu_kaisen.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace jujutsu_kaisen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChController : ControllerBase
    {
        private readonly CharacterContext _dbContext;
        public ChController(CharacterContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Character>>> GetCharacters()
        {
            if (_dbContext.Characters == null)
            {
                return NotFound();
            }
            return await _dbContext.Characters.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Character>> GetCharacters(int id)
        {
            if (_dbContext.Characters == null)
            {
                return NotFound();
            }
            var character = await _dbContext.Characters.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            return character;
        }
        [HttpPost]
        public async Task<ActionResult<Character>> PostCharacter(Character character)
        {
            _dbContext.Characters.Add(character);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCharacters), new { id = character.Id }, character);
        }
        [HttpPut]
        public async Task<ActionResult<Character>> PutCharacter(int id, Character character)
        {
            if (id != character.Id)
            {
                return BadRequest();
            }
            _dbContext.Entry(character).State = EntityState.Modified;

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CharacterAvailable(id))
                {
                    return NotFound(nameof(character));
                }
                else
                {
                    throw;
                }
            }
            return Ok();
        }

        private bool CharacterAvailable(int id)
        {
            return (_dbContext.Characters?.Any(x => x.Id == id)).GetValueOrDefault();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCharacters(int id )
        {
            if (_dbContext.Characters == null)
            {
                return NotFound();
            }
            var characters = await _dbContext.Characters.FindAsync(id);
            if(characters != null)
            {
                return NotFound();
            }
            _dbContext.Characters.Remove(characters);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
    }

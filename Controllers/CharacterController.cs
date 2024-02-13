using jujutsu_kaisen.Model;
using jujutsu_kaisen.Repository;
using jujutsu_kaisen.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace jujutsu_kaisen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterRepository _characterRepository;

        public CharacterController(ICharacterRepository characterRepository)
        {
            _characterRepository = characterRepository;
        }

        [HttpGet]
        public IEnumerable<Character> GetAll()
        {
            return _characterRepository.GetAll();
        }

        [HttpGet("{id}")]
        public ActionResult<Character> GetById(int id)
        {
            var character = _characterRepository.GetById(id);
            if (character == null)
            {
                return NotFound();
            }
            return character;
        }

        [HttpPost]
        public ActionResult<Character> Create(Character character)
        {
            var createdCharacter = _characterRepository.Create(character);
            return CreatedAtAction(nameof(GetById), new { id = createdCharacter.Id }, createdCharacter);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Character character)
        {
            try
            {
                _characterRepository.Update(id, character);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _characterRepository.Delete(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
using jujutsu_kaisen.Model;
using jujutsu_kaisen.Repository;
using Microsoft.AspNetCore.Mvc;

namespace jujutsu_kaisen.Service
{
    public class CharacterRepository : ICharacterRepository
    {
        private readonly List<Character> _characters;

        public CharacterRepository()
        {
            _characters = new List<Character>
            {
                new Character(1, "Satoru Gojo", false, Role.Attack, Status.Alive, "Infinity"),
                new Character(2, "jihed 2", false, Role.Defence, Status.Dead, "Ability 2"),
                new Character(3, "jihed 3", true, Role.Healer, Status.Alive, "Ability 3")
            };
        }

        public IEnumerable<Character> GetAll()
        {
            return _characters;
        }

        public Character Create(Character character)
        {
            character.Id = _characters.Count + 1;
            _characters.Add(character);
            return character;
        }

        public void Update(int id, Character character)
        {
            var existingCharacter = _characters.FirstOrDefault(c => c.Id == id);
            if (existingCharacter != null)
            {
                existingCharacter.Name = character.Name;
                existingCharacter.ReverseTechnique = character.ReverseTechnique;
                existingCharacter.Role = character.Role;
                existingCharacter.Status = character.Status;
                existingCharacter.Ability = character.Ability;
            }
            else
            {
                throw new InvalidOperationException("Character not found");
            }
        }

        public void Delete(int id)
        {
            var existingCharacter = _characters.FirstOrDefault(c => c.Id == id);
            if (existingCharacter != null)
            {
                _characters.Remove(existingCharacter);
            }
            else
            {
                throw new InvalidOperationException("Character not found");
            }
        }

        public ActionResult<Character> GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

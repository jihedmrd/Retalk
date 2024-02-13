using jujutsu_kaisen.Model;
using Microsoft.AspNetCore.Mvc;

namespace jujutsu_kaisen.Repository
{
    public interface ICharacterRepository
    {
        IEnumerable<Character> GetAll();
        Character Create(Character character);
        void Update(int id, Character character);
        void Delete(int id);
        ActionResult<Character> GetById(int id);
    }
}
using Microsoft.AspNetCore.Mvc.ApiExplorer;

namespace jujutsu_kaisen.Model
{
    public enum  Role
    {
        Attack,
        Defence,
        Healer
    }

    public enum Status
    {
        Dead, Alive
    }

    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ReverseTechnique { get; set; }
        public Role Role { get; set; }
        public Status Status { get; set; }
        public string Ability { get; set; }

        public Character(int id, string name, bool reverseTechnique, Role role, Status status, string ability)
        {
            Id = id;
            Name = name;
            ReverseTechnique = reverseTechnique;
            Role = role;
            Status = status;
            Ability = ability;
        }
    }
}
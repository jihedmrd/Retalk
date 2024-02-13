using Microsoft.EntityFrameworkCore;


namespace jujutsu_kaisen.Model
{
    public class CharacterContext : DbContext
    {
        public CharacterContext(DbContextOptions<CharacterContext> options) : base(options)
        {


        }

        public DbSet<Character> Characters { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>().HasData(
                new Character(1, "Character 1", true, Role.Attack, Status.Alive, "Ability 1"),
                new Character(2, "Character 2", false, Role.Defence, Status.Dead, "Ability 2"),
                new Character(3, "Character 3", true, Role.Healer, Status.Alive, "Ability 3")
            );

        }
    }
}
using System;

namespace TerminalRPG.Models
{
    public class Ninja : Human
    {
        public Ninja(string name) : base(name)
        {
            Dexterity = 18;
        }

        public override int Attack(Enemy target)
        {
            target.Health -= Dexterity*5;
            Console.WriteLine($"{Name} viciously ninjas {target.Name} for {Dexterity*5} damage!");
            Random dice = new Random();
            int d20 = dice.Next(1,21);
            if (d20 >= 17)
            {
                target.Health -= 10;
                Console.WriteLine($"{Name} rolls for extra damage! {d20}! 10 extra damage!");
            }
            else
            {
                Console.WriteLine($"{Name} rolls for extra damage! {d20}! No extra damage!");
            }
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
            return target.Health;
        }

        public void Steal(Enemy target)
        {
            int stealDmg = 30;
            target.Health -= stealDmg;
            health += stealDmg;
            Console.WriteLine($"{Name} viciously vampires {target.Name} for {stealDmg} HP!");
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
        }
    }
}
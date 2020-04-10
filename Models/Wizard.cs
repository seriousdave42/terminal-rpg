using System;

namespace TerminalRPG.Models
{
    public class Wizard : Human
    {
        public Wizard(string name) : base(name)
        {
            health = 50;
            Intelligence = 18;
        }

        public override int Attack(Enemy target)
        {
            target.Health = target.Health - Intelligence*5;
            Console.WriteLine($"{Name} viciously fireballs {target.Name} for {Intelligence*5} damage!");
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
            return target.Health;
        }

        public void Heal(Human target)
        {
            if (target.Health > 0)
            {
                target.Health += Intelligence*10;
                Console.WriteLine($"{Name} viciously heals {target.Name} for {Intelligence*10} HP!");
            }
            else
            {
                Console.WriteLine($"{target.Name} is too dead to be healed");
            }
        }
    }
}
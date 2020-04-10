using System;

namespace TerminalRPG.Models
{
    public class Samurai : Human
    {
        public Samurai(string name) : base(name)
        {
            health = 200;
        }

        public override int Attack(Enemy target)
        {   
            base.Attack(target);
            if (target.Health < 50 && target.Health > 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} bleeds out due to all the samurai stuff!");
                Console.WriteLine($"{target.Name} has perished!");
            }
            return target.Health;
        }

        public void Meditate()
        {
            if (health < 200)
            {
            health = 200;
            Console.WriteLine($"{Name} viciously meditates and returns to full health!");
            }
            else
            {
            Console.WriteLine($"{Name} viciously meditates, but is already at full health!");
            }
        }
    }
}
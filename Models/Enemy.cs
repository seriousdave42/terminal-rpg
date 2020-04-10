using System;

namespace TerminalRPG.Models
{
    public abstract class Enemy : Character
    {
        public Enemy(string name) : base(name)
        {
            health = 200;
        }

        public virtual void Attack(Human target)
        {
            target.Health = target.Health - this.Strength*5;
            Console.WriteLine($"{this.Name} viciously strikes {target.Name} for {this.Strength*5} damage!");
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
        }
    }
}
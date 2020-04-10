using System;

namespace TerminalRPG.Models

{
    public abstract class Human : Character
    {
        public Human(string name) : base(name)
        {
            
        }

        public virtual int Attack(Enemy target)
        {
            target.Health = target.Health - this.Strength*5;
            Console.WriteLine($"{this.Name} viciously strikes {target.Name} for {this.Strength*5} damage!");
            if (target.Health <= 0)
            {
                target.Health = 0;
                Console.WriteLine($"{target.Name} has perished!");
            }
            return target.Health;
        }

        

    }
}
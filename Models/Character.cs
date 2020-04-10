using System;

namespace TerminalRPG.Models
{
    public abstract class Character
    {
        public string Name;
        public int Strength;
        public int Intelligence;
        public int Dexterity;
        protected int health;
        protected int initiative;

        public int Health
        {
            get
            {
                return health;
            }
            set
            {
                health = value;
            }

        }

        public int Initiative
        {
            get
            {
                return initiative;
            }
        }

        public Character(string name)
        {
            Name = name;
            Strength = 12;
            Intelligence = 12;
            Dexterity = 12;
            health = 100;
        }

        public Character(string name, int str, int intel, int dex, int _health)
        {
            Name = name;
            Strength = str;
            Intelligence = intel;
            Dexterity = dex;
            health = _health;
        }
        
        public void RollForInit()
        {
            Random d20 = new Random();
            initiative = d20.Next(1,21) + (Dexterity-12)/3; 
        }

        public void PrintStats()
        {
            Console.WriteLine($"{Name}");
            Console.WriteLine("==============");
            Console.WriteLine($"STR: {Strength}");
            Console.WriteLine($"INT: {Intelligence}");
            Console.WriteLine($"DEX: {Dexterity}");
            Console.WriteLine($"HP: {health}");
            Console.WriteLine("");
        }
    }
}
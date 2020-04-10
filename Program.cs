using System;
using System.Collections.Generic;
using System.Reflection;
using TerminalRPG.Models;

namespace TerminalRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Terminal RPG! Prepare for disappointment! And adventure!");
            Console.WriteLine("===================================================================");
            Wizard ed = new Wizard ("Edward");
            Ninja spike = new Ninja("Spike");
            // Ninja faye = new Ninja("Faye");
            Samurai jet = new Samurai("Jet");
            Zombie zombie1 = new Zombie("Zombie 1");
            Zombie zombie2 = new Zombie("Zombie 2");
            Spider spider1 = new Spider("Spider 1");

            List<Human> party = new List<Human>() {ed, spike, jet};
            List<Enemy> enemies = new List<Enemy>() {zombie1, zombie2, spider1};
            List<Character> testList = new List<Character>() {ed, spike, jet, zombie1, zombie2, spider1};
            Character[] turnList = new Character [6] {ed, spike, jet, zombie1, zombie2, spider1};

            int round = 0;
            while (SumHealthParty(party) > 0 && SumHealthEnemies(enemies) > 0)
            {
                int turn = round % 6;
                if (turnList[turn].Health > 0)
                {
                    Console.WriteLine("");
                    EncounterStatus(turnList);
                    if (turnList[turn] is Ninja)
                    {
                        Ninja ninjaClone = (Ninja) turnList[turn];
                        Console.WriteLine($"{ninjaClone.Name}'s turn. (A)ttack or (S)teal?");
                        string Action = Console.ReadLine();
                        Console.WriteLine("Target name?");
                        string Target = Console.ReadLine();
                        if (Action == "A")
                        {
                            ninjaClone.Attack(enemies.Find(x => x.Name == Target));
                        }
                        else if (Action == "S")
                        {
                            ninjaClone.Steal(enemies.Find(x => x.Name == Target));
                        }
                        if (SumHealthEnemies(enemies) <= 0)
                        {
                            Console.WriteLine("All enemies vanquished! Congratulations!");
                        }
                    }
                    else if (turnList[turn] is Samurai)
                    {
                        Samurai samuraiClone = (Samurai) turnList[turn];
                        Console.WriteLine($"{samuraiClone.Name}'s turn. (A)ttack or (M)editate?");
                        string Action = Console.ReadLine();
                        if (Action == "A")
                        {
                            Console.WriteLine("Target name?");
                            string Target = Console.ReadLine();
                            samuraiClone.Attack(enemies.Find(x => x.Name == Target));
                        }
                        else if (Action == "M")
                        {
                            samuraiClone.Meditate();
                        }
                        if (SumHealthEnemies(enemies) <= 0)
                        {
                            Console.WriteLine("All enemies vanquished! Congratulations!");
                        }
                    }
                    else if (turnList[turn] is Wizard)
                    {
                        Wizard wizardClone = (Wizard) turnList[turn];
                        Console.WriteLine($"{wizardClone.Name}'s turn. (A)ttack or (H)eal?");
                        string Action = Console.ReadLine();
                        Console.WriteLine("Target name?");
                        string Target = Console.ReadLine();
                        if (Action == "A")
                        {
                            wizardClone.Attack(enemies.Find(x => x.Name == Target));
                        }
                        else if (Action == "H")
                        {
                            wizardClone.Heal(party.Find(x => x.Name == Target));
                        }
                        if (SumHealthEnemies(enemies) <= 0)
                        {
                            Console.WriteLine("All enemies vanquished! Congratulations!");
                        }
                    }
                    else if (turnList[turn] is Zombie)
                    {
                        Zombie zombieClone = (Zombie) turnList[turn];
                        Console.WriteLine($"{zombieClone.Name}'s turn.");
                        Random rand = new Random();
                        bool attacked = false;
                        while (!attacked)
                        {
                            int target = rand.Next(3);
                            if (party[target].Health > 0)
                            {
                                zombieClone.Attack(party[target]);
                                attacked = true;
                            }
                        }
                        Console.WriteLine("Please press \"Enter\" to continue");
                        string Action = Console.ReadLine();
                        if (SumHealthParty(party) <= 0)
                        {
                            Console.WriteLine("Your party was killed in self-defense! Congratulations!");
                        }
                    }
                    else if (turnList[turn] is Spider)
                    {
                        Spider spiderClone = (Spider) turnList[turn];
                        Console.WriteLine($"{spiderClone.Name}'s turn.");
                        Random rand = new Random();
                        bool attacked = false;
                        while (!attacked)
                        {
                            int target = rand.Next(3);
                            if (party[target].Health > 0)
                            {
                                spiderClone.Attack(party[target]);
                                attacked = true;
                            }
                        }
                        Console.WriteLine("Please press \"Enter\" to continue");
                        string Action = Console.ReadLine();
                        if (SumHealthParty(party) <= 0)
                        {
                            Console.WriteLine("Your party was killed in self-defense! Congratulations!");
                        }
                    }
                }
                round += 1;
            }
        }

        static int SumHealthParty(List<Human> group)
        {
            int totalHealth = 0;
            foreach (Human character in group)
            {
                totalHealth += character.Health;
            }
            return totalHealth;
        }

        static int SumHealthEnemies(List<Enemy> group)
        {
            int totalHealth = 0;
            foreach (Enemy character in group)
            {
                totalHealth += character.Health;
            }
            return totalHealth; 
        }

        static void EncounterStatus(Character[] turnList)
        {
            Console.WriteLine("Party");
            Console.WriteLine("========");
            foreach (Character character in turnList)
            {
                if (character is Human)
                {
                Console.WriteLine($"{character.Name}: {character.Health} HP");
                }
            }
            Console.WriteLine("");
            Console.WriteLine("Enemies");
            Console.WriteLine("========");
            foreach (Character character in turnList)
            {
                if (character is Enemy)
                {
                Console.WriteLine($"{character.Name}: {character.Health} HP");
                }
            }
            Console.WriteLine("");
        }
    }
}

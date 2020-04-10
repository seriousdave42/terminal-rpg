using System;
using System.Collections.Generic;
using TerminalRPG.Models;

namespace TerminalRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Terminal RPG! Prepare for disappointment! And adventure!");
            Console.WriteLine("===================================================================");
            Console.WriteLine("");
            // Wizard ed = new Wizard ("Edward");
            // Ninja spike = new Ninja("Spike");
            // Samurai jet = new Samurai("Jet");
            List<Human> party = new List<Human>();
            List<Enemy> enemies = new List<Enemy>();
            List<Character> turnList = new List<Character>();

            Console.WriteLine("Select your first party member's class: (N)inja (S)amurai (W)izard");
            string player1 = Console.ReadLine();
            Console.WriteLine("Enter your new hero's name:");
            string player1Name = Console.ReadLine();

            if (player1 == "N")
            {
                Ninja hero1 = new Ninja(player1Name);
                party.Add(hero1);
                turnList.Add(hero1);
            }
            else if (player1 == "S")
            {
                Samurai hero1 = new Samurai(player1Name);
                party.Add(hero1);
                turnList.Add(hero1);
            }
            else
            {
                Wizard hero1 = new Wizard(player1Name);
                party.Add(hero1);
                turnList.Add(hero1);
            }

            Console.WriteLine("Select your second party member's class: (N)inja (S)amurai (W)izard");
            string player2 = Console.ReadLine();
            Console.WriteLine("Enter your new hero's name:");
            string player2Name = Console.ReadLine();

            if (player2 == "N")
            {
                Ninja hero2 = new Ninja(player2Name);
                party.Add(hero2);
                turnList.Add(hero2);
            }
            else if (player2 == "S")
            {
                Samurai hero2 = new Samurai(player2Name);
                party.Add(hero2);
                turnList.Add(hero2);
            }
            else
            {
                Wizard hero2 = new Wizard(player2Name);
                party.Add(hero2);
                turnList.Add(hero2);
            }

            Console.WriteLine("Select your third party member's class: (N)inja (S)amurai (W)izard");
            string player3 = Console.ReadLine();
            Console.WriteLine("Enter your new hero's name:");
            string player3Name = Console.ReadLine();

            if (player3 == "N")
            {
                Ninja hero3 = new Ninja(player3Name);
                party.Add(hero3);
                turnList.Add(hero3);
            }
            else if (player3 == "S")
            {
                Samurai hero3 = new Samurai(player3Name);
                party.Add(hero3);
                turnList.Add(hero3);
            }
            else
            {
                Wizard hero3 = new Wizard(player3Name);
                party.Add(hero3);
                turnList.Add(hero3);
            }

            Zombie zombie1 = new Zombie("Zombie 1");
            enemies.Add(zombie1);
            turnList.Add(zombie1);
            Zombie zombie2 = new Zombie("Zombie 2");
            enemies.Add(zombie2);
            turnList.Add(zombie2);
            Spider spider1 = new Spider("Spider 1");
            enemies.Add(spider1);
            turnList.Add(spider1);

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

        static void EncounterStatus(List<Character> turnList)
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

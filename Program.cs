
using System;
using System.Collections.Generic;

namespace RandProbStat
{
    internal class Program
    {
        static Random random = new Random();

        static List<string> commonItems = new List<string>
        {
            "Wooden Sword",
            "Basic Shield",
            "Leather Boots"
        };

        static List<string> uncommonItems = new List<string>
        {
            "Iron Sword",
            "Iron Armor"
        };

        static List<string> rareItems = new List<string>
        {
            "Diamond Sword",
            "Enchanted Bow"
        };

        static List<string> legendaryItems = new List<string>
        {
            "Mythic Sword",
            "Mythic Chestplate"
        };

        static int totalRolls = 0;
        static int commonDrops = 0;
        static int uncommonDrops = 0;
        static int rareDrops = 0;
        static int legendaryDrops = 0;

        static void Main(string[] args)
        {
            bool playing = true;

            while (playing)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("1. Roll for loot");
                Console.WriteLine("2. View stats");
                Console.WriteLine("3. Quit");

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Choose an option: ");

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    RollLoot();
                }
                else if (choice == "2")
                {
                    ShowStatistics();
                }
                else if (choice == "3")
                {
                    playing = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }


        static void RollLoot()
        {
            int roll = random.Next(1, 101);

            totalRolls++;

            if (roll <= 60)
            {
                commonDrops++;
                DisplayDrop("Common", commonItems);
            }
            else if (roll <= 85)
            {
                uncommonDrops++;
                DisplayDrop("Uncommon", uncommonItems);
            }
            else if (roll <= 97)
            {
                rareDrops++;
                DisplayDrop("Rare", rareItems);
            }
            else
            {
                legendaryDrops++;
                DisplayDrop("Legendary", legendaryItems);
            }
        }

        static void ShowStatistics()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Total Rolls: {totalRolls}");

            DisplayStats("Common", commonDrops, 60);
            DisplayStats("Uncommon", uncommonDrops, 25);
            DisplayStats("Rare", rareDrops, 12);
            DisplayStats("Legendary", legendaryDrops, 3);

            Console.WriteLine();
        }

        static void DisplayStats(string rarity, int drops, double expectedChance)
        {
            double actualChance = 0;

            if (totalRolls > 0)
            {
                actualChance = (double)drops / totalRolls * 100;
            }

            Console.WriteLine($"{rarity}: {drops} drops , " + $"Actual: {actualChance:F2}% , " +$"Expected: {expectedChance}%");
        }

        static void DisplayDrop(string rarity, List<string> items)
        {
            int itemIndex = random.Next(items.Count);
            string item = items[itemIndex];

            if (rarity == "Common")
            {
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else if (rarity == "Uncommon")
            {
                Console.ForegroundColor = ConsoleColor.Green;
            }
            else if (rarity == "Rare")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
            }
            else if (rarity == "Legendary")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
            }

            Console.WriteLine($"\nYou received a {rarity} item!");
            Console.WriteLine($"Item: {item}");
            Console.WriteLine();
        }
    }
}

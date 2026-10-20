
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
            Console.WriteLine("Press enter to roll for loot");

            Console.ReadLine();

            RollLoot();

            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
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

        static void DisplayDrop(string rarity, List<string> items)
        {
            int itemIndex = random.Next(items.Count);
            string item = items[itemIndex];

            Console.WriteLine($"\nYou received a {rarity} item!");
            Console.WriteLine($"Item: {item}");
        }
    }
}

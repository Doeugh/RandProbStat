
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
                Console.WriteLine("3. Simulate rolls");
                Console.WriteLine("4. Remove an item");
                Console.WriteLine("5. Quit");

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
                    Console.Write("How many rolls would you like to simulate? ");

                    string input = Console.ReadLine();

                    if (int.TryParse(input, out int amount) && amount > 0)
                    {
                        SimulateRolls(amount);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a valid number");
                        Console.ResetColor();
                        Console.WriteLine();
                    }
                }
                else if (choice == "4")
                {
                    RemoveItem();
                }
                else if (choice == "5")
                {
                    playing = false;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid choice");
                    Console.WriteLine();
                }
            }
        }

        static void RollLoot()
        {
            totalRolls++;

            int level = GetLevel(totalRolls);
            int roll = random.Next(1, 101);

            string rarity = DetermineRarity(roll, level);

            if (rarity == "Common")
            {
                commonDrops++;
                DisplayDrop("Common", commonItems);
            }
            else if (rarity == "Uncommon")
            {
                uncommonDrops++;
                DisplayDrop("Uncommon", uncommonItems);
            }
            else if (rarity == "Rare")
            {
                rareDrops++;
                DisplayDrop("Rare", rareItems);
            }
            else if (rarity == "Legendary")
            {
                legendaryDrops++;
                DisplayDrop("Legendary", legendaryItems);
            }
        }

        static void SimulateRolls(int amount)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"\nSimulating {amount} rolls");
            Console.ResetColor();

            for (int i = 0; i < amount; i++)
            {
                totalRolls++;

                int level = GetLevel(totalRolls);
                int roll = random.Next(1, 101);

                string rarity = DetermineRarity(roll, level);

                if (rarity == "Common")
                {
                    commonDrops++;
                }
                else if (rarity == "Uncommon")
                {
                    uncommonDrops++;
                }
                else if (rarity == "Rare")
                {
                    rareDrops++;
                }
                else if (rarity == "Legendary")
                {
                    legendaryDrops++;
                }
            }

            ShowStatistics();
        }

        static int GetLevel(int rolls)
        {
            if (rolls <= 10)
            {
                return 1;
            }
            else if (rolls <= 25)
            {
                return 2;
            }
            else if (rolls <= 50)
            {
                return 3;
            }
            else
            {
                return 4;
            }
        }

        static string DetermineRarity(int roll, int level)
        {
            if (roll <= 60)
            {
                return "Common";
            }
            else if (roll <= 85 && level >= 2)
            {
                return "Uncommon";
            }
            else if (roll <= 97 && level >= 3)
            {
                return "Rare";
            }
            else if (level >= 4)
            {
                return "Legendary";
            }
            else
            {
                return "Common";
            }
        }


        static void RemoveItem()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nWhich rarity would you like to remove an item from?");

            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("1. Common");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("2. Uncommon");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("3. Rare");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("4. Legendary");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Choose a rarity: ");

            string choice = Console.ReadLine();

            List<string> selectedItems;

            if (choice == "1")
            {
                selectedItems = commonItems;
            }
            else if (choice == "2")
            {
                selectedItems = uncommonItems;
            }
            else if (choice == "3")
            {
                selectedItems = rareItems;
            }
            else if (choice == "4")
            {
                selectedItems = legendaryItems;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid rarity choice");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nAvailable items");
            Console.ResetColor();

            for (int i = 0; i < selectedItems.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {selectedItems[i]}");
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("Enter the number of the item to remove: ");
            Console.ResetColor();

            string input = Console.ReadLine();

            if (int.TryParse(input, out int itemNumber) && itemNumber >= 1 && itemNumber <= selectedItems.Count)
            {
                string removedItem = selectedItems[itemNumber - 1];

                selectedItems.RemoveAt(itemNumber - 1);

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\nRemoved {removedItem}");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid item number");
                Console.ResetColor();
            }

            Console.WriteLine();
        }


        static void ShowStatistics()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"Total Rolls: {totalRolls}");

            Console.ForegroundColor = ConsoleColor.Gray;
            DisplayStats("Common", commonDrops, 60);

            Console.ForegroundColor = ConsoleColor.Green;
            DisplayStats("Uncommon", uncommonDrops, 25);

            Console.ForegroundColor = ConsoleColor.Blue;
            DisplayStats("Rare", rareDrops, 12);

            Console.ForegroundColor = ConsoleColor.Yellow;
            DisplayStats("Legendary", legendaryDrops, 3);

            Console.ResetColor();
            Console.WriteLine();
        }

        static void DisplayStats(string rarity, int drops, double expectedChance)
        {
            double actualChance = 0;

            if (totalRolls > 0)
            {
                actualChance = (double)drops / totalRolls * 100;
            }

            Console.WriteLine($"{rarity}: {drops} drops , " + $"Actual: {actualChance:F2}% , " + $"Expected: {expectedChance}%");
        }

        static void DisplayDrop(string rarity, List<string> items)
        {
            if (items.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\nYou rolled {rarity}, but no items are available!");
                Console.WriteLine();
                return;
            }

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
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}

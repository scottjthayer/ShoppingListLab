using System;
using System.Collections.Generic;
using System.Linq;


namespace Shopping_List_Lab
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi! Welcome to Scott's Gas Station.\nTake a look at our menu.");
         
            var comparer = StringComparer.OrdinalIgnoreCase;
            Dictionary<string, double> MenuItems = new Dictionary<string, double>(comparer);
            MenuItems.Add("Pringles", 1.99);
            MenuItems.Add("Honeybun", 3.50);
            MenuItems.Add("Monster", 2.50);
            MenuItems.Add("Soda", 1.50);
            MenuItems.Add("Red Bull", 3.39);
            MenuItems.Add("Baja Blast", 1.89);
            MenuItems.Add("Protein Bar", 3.00);
            MenuItems.Add("Tall Boy", 2.50);
            MenuItems.Add("Chex Mix", 3.20);
            MenuItems.Add("Hot Cheetos", 2.00);
            MenuItems.Add("Reeses", 3.50);
            //empty cart lists 
            List<double> Price = new List<double>();
            List<string> Item = new List<string>();
            //continue shopping loop
            bool orderMore = true;
            while (orderMore == true)
            {
                DisplayMenu(MenuItems);
                string input = GetItem(MenuItems);
                Console.WriteLine($"Adding {input} to cart at ${MenuItems[input].ToString("#,##0.00")}\n");
                //storing items in cart
                Item.Add(input);
                Price.Add(MenuItems[input]);
                orderMore = GetYesOrNo("Would you like to order anything else?");
            }       
            //display receipt
            DisplayReceipt(Item, Price);
          
        }
        public static void DisplayReceipt(List<string> Item, List<double> Price)
        {
            Console.WriteLine("Thanks for your order!\n");
            Console.WriteLine("Here is your receipt\n");
            for (int i = 0; i < Item.Count; i++)
            {
                Console.WriteLine(string.Format("{0, -15} ${1,-15}", Item[i], Price[i].ToString("#,##0.00")));
            }
            double sum = Price.Sum();
            double avg = sum / Math.Round((double)Price.Count, 3);
            Console.WriteLine($"\nYour total cost is ${sum.ToString("#,##0.00")}");
            Console.WriteLine($"Average price per item in order was ${avg.ToString("#,##0.00")}.");
            Console.WriteLine("Thank you for shopping at Scott's Gas Station!");
        }
        public static string GetItem(Dictionary<string, double> Shop)
        {
            string result = "";
            while (true)
            {
                Console.WriteLine("Please enter an item name to order that item.");
                result = Console.ReadLine();
                //returns true if key exits
                if (Shop.ContainsKey(result))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Sorry, we don't have that item. Please enter a different item.\n");
                }
            }

            return result;
        }
        public static bool GetYesOrNo(string prompt)
        {
            while (true)
            {
                Console.WriteLine(prompt);
                Console.Write("Y/N? ");
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "y")
                {
                    return true;
                }
                else if (input == "n")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("That input is not valid, please try again.");
                }
            }
        }
        public static void DisplayMenu(Dictionary<string, double> Menu)
        {
            Console.WriteLine("Item\t\tPrice");
            Console.WriteLine("============================");

            foreach (KeyValuePair<string, double> kvp in Menu)
            {
                Menu.ToString();
                Console.WriteLine(string.Format("{0, -15} ${1,-15}", kvp.Key, kvp.Value.ToString("#,##0.00")));
            }
        }
    }
}

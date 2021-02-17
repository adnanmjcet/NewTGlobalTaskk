using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace NewTGlobalTask
{
    public class FileHandler
    {
        private const int Pos_itemNumber = 0;
        private const int Pos_ItemName = 1;
        private const int Pos_ItemPrice = 2;
        private const int Pos_itemType = 3;

        public Dictionary<string, VendingItem> GetVendingItems()
        {
            Dictionary<string, VendingItem> items = new Dictionary<string, VendingItem>();

            string file = string.Empty;
            if (File.Exists("vendingmachine.csv"))
            {
                file = "vendingmachine.csv";

                try
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (!sr.EndOfStream)
                        {
                            // Read the line
                            string line = sr.ReadLine();

                            string[] itemDetails = line.Split("|");

                            string itemName = itemDetails[Pos_ItemName];

                            if (!decimal.TryParse(itemDetails[Pos_ItemPrice], out decimal itemPrice))
                            {
                                itemPrice = 0M;
                            }

                            int itemsRemaining = 5;

                            VendingItem item;

                            switch (itemDetails[Pos_itemType])
                            {
                                case "Chip":
                                    item = new Chip(itemName, itemPrice, itemsRemaining);
                                    break;
                                case "Drink":
                                    item = new Drink(itemName, itemPrice, itemsRemaining);
                                    break;
                                default:
                                    item = new Chip(itemName, itemPrice, itemsRemaining);
                                    break;
                            }

                            items.Add(itemDetails[Pos_itemNumber], item);
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Error trying to open the input file.");
                }
            }
            else
            {
                items.Add("A1", new Drink("tasty Thursty Drink", 1M, 5));
                items.Add("A2", new Candy("Delicious Candy", 0.65M, 10));
                items.Add("A3", new Chip("Crunchy & Tasty", 0.50M, 15));
            }
            return items;
        }
    }
}

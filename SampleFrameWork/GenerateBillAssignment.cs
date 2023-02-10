using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SampleFrameWork;
using Utilities;

namespace SampleFrameWork
{

    class ItemsClass
    {
        int itemId;
        string itemName;
        int unitPrice;
        static List<ItemsClass> Items = new List<ItemsClass>();
        public static void addItems()
        {
            Random billno = new Random();
            string Holder = Utilities.Prompt("Enter the Customer name");
            DateTime date = DateTime.Now;
            // Console.WriteLine(date.ToShortDateString());
            Items.Add(new ItemsClass { itemId = 1, itemName = "rice", unitPrice = 100 });
            Items.Add(new ItemsClass { itemId = 2, itemName = "corn", unitPrice = 30 });
            Items.Add(new ItemsClass { itemId = 3, itemName = "Wheat", unitPrice = 80 });
            Items.Add(new ItemsClass { itemId = 4, itemName = "biscuit", unitPrice = 20 });
            Items.Add(new ItemsClass { itemId = 5, itemName = "Ragi", unitPrice = 50 });
            Items.Add(new ItemsClass { itemId = 6, itemName = "badam", unitPrice = 160 });
            Items.Add(new ItemsClass {itemId=7,itemName="horlics",unitPrice=100});
            Items.Add(new ItemsClass {itemId=8,itemName="Brush",unitPrice=120});
            Items.Add(new ItemsClass { itemId = 9, itemName = "Sponze", unitPrice = 50 });
            Items.Add(new ItemsClass {itemId=10,itemName="Broom",unitPrice=160});
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("ItemId \t     ItemName \t        ItemPrice");
            Console.WriteLine("---------------------------------------------");

            foreach (var item in Items)
            {
                Console.WriteLine($"{item.itemId} \t     {item.itemName}\t          {item.unitPrice}");
            }
            bool selection = true;
            do
            {
                int choice = Utilities.GetNumber("press 1 to BuyItems press 2 to Generate The bill");
                if (choice == 1)
                {
                    Console.WriteLine("enter the Itemid you want to buy");
                    int IdChoice = int.Parse(Console.ReadLine());
                    for (int i = 0; i < Items.Count; i++)
                    {
                        var data = Items[i];
                        if (data.itemId == IdChoice)
                        {
                            Console.WriteLine("enter the quantity");
                            int quantity = int.Parse(Console.ReadLine());
                            printClass.printingfunc(data.itemId, data.itemName, data.unitPrice, quantity);
                        }
                    }
                }
                else if (choice == 2)
                {
                    printClass.generatebill(billno, Holder, date);
                    Utilities.Prompt("press enter to clear");
                    Console.Clear();
                    ItemsClass.addItems();
                }
            } while (selection);


        }
    }
    class printClass
    {
        int showId;
        string showName;
        int showPrice;
        int showquantity;
        int showtotal;
        //int grandTotal;
        static int val;
        static List<printClass> showData = new List<printClass>();


        public static void printingfunc(int itemId, string itemName, int unitPrice, int quantity)
        {
            showData.Add(new printClass { showId = itemId, showName = itemName, showPrice = unitPrice, showquantity = quantity, showtotal = (quantity * unitPrice) });
            val += quantity * unitPrice;
           
        }

        public static void generatebill(Random billno, string hname, DateTime dte)
        {
            Console.WriteLine($"Holder Name:{hname}                            date:{dte}");
            Console.WriteLine($"Bill Number: {billno.Next(1,100)}");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("ItemID \t ItemName \t ItemPrice \t Quantity \t TotalAmount");
            Console.WriteLine("---------------------------------------------------------------------");
            foreach (var item in showData)
            {
                Console.WriteLine($"{item.showId}  \t   {item.showName}     \t     {item.showPrice}    \t    {item.showquantity}    \t    {item.showtotal}");
            }
            Console.WriteLine("---------------------------------------------------------------------");

            Console.WriteLine($"                                             Grand Total: {printClass.val}");

        }
    }
    class mainClass
    {
        static void Main(string[] args)
        {
            ItemsClass.addItems();
        }
    }
}


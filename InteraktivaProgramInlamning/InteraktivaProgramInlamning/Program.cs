using System;
using System.Collections.Generic;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteraktivaProgramInlamning
{
    public class Expense
    {
        public string Category;
        public string Name;
        public decimal Cost;



    }
    public class Program
    {
        public static void Main()
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
            List<Expense> expenses = new List<Expense>();

            ShowMenu("What do you want to do?", new[]
            {
                "Add Expense",
                "Show All Expense",
                "Show Sum By Category",
                "Remove Expense",
                "Remove All Expenses",
                "Exit"
            });
            Console.Clear();

            int select = 0;
            switch (select)
            {
                case 0:
                   expenses.Add(AddExpense());
                    break;
                default:
                    break;
            }



        }

        public static Expense AddExpense()
        {
            List<Expense> expenses = new List<Expense>();

            Expense e = new Expense();
            Console.Write("Name :");
            e.Name = Console.ReadLine();

            Console.Write("Price :");
            e.Cost = int.Parse(Console.ReadLine());

            ShowMenu("Catagory :", new[]
            {
                "Food",
                "Entertainment",
                "Other"
            });
            int select = 0;
            string category = "";
            switch (select)
            {
                case 0:
                    category += "Food";
                    break;
                case 1:
                    category += "Entertainment";
                    break;
                case 2:
                    category += "Other";
                    break;
            }

            e.Category = category;

            return e;
        

        }

        public static int ShowMenu(string prompt, string[] options)
        {
            if (options == null || options.Length == 0)
            {
                throw new ArgumentException("Cannot show a menu for an empty array of options.");
            }

            Console.WriteLine(prompt);

            int selected = 0;

            // Hide the cursor that will blink after calling ReadKey.
            Console.CursorVisible = false;

            ConsoleKey? key = null;
            while (key != ConsoleKey.Enter)
            {
                // If this is not the first iteration, move the cursor to the first line of the menu.
                if (key != null)
                {
                    Console.CursorLeft = 0;
                    Console.CursorTop = Console.CursorTop - options.Length;
                }

                // Print all the options, highlighting the selected one.
                for (int i = 0; i < options.Length; i++)
                {
                    var option = options[i];
                    if (i == selected)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    Console.WriteLine("- " + option);
                    Console.ResetColor();
                }

                // Read another key and adjust the selected value before looping to repeat all of this.
                key = Console.ReadKey().Key;
                if (key == ConsoleKey.DownArrow)
                {
                    selected = Math.Min(selected + 1, options.Length - 1);
                }
                else if (key == ConsoleKey.UpArrow)
                {
                    selected = Math.Max(selected - 1, 0);
                }
            }

            // Reset the cursor and return the selected option.
            Console.CursorVisible = true;
            return selected;
        }
    }

    [TestClass]
    public class ProgramTests
    {
        [TestMethod]
        public void ExampleTest()
        {

        }
    }
}

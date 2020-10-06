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
            while (true)
            {
                Console.WriteLine("");
                int select = ShowMenu("What do you want to do?", new[]
                 {
                   "Add Expense",
                   "Show All Expense",
                   "Show Sum By Category",
                   "Remove Expense",
                   "Remove All Expenses",
                   "Exit"
                });
                Console.Clear();
                switch (select)
                {
                    case 0:
                        expenses.Add(AddExpense());
                        Console.Clear();
                        Console.WriteLine("Expense added!");
                        break;
                    case 1:
                        ShowExpenses("This is all your expenses :", expenses);
                        break;
                    case 2:
                        Console.WriteLine();
                        break;
                    case 3:
                        expenses.RemoveAt(RemoveIndex(expenses));
                        Console.Clear();
                        Console.WriteLine("Expense removed!");
                        break;
                    case 4:
                         RemoveAll(expenses);
                        break;
                    case 5:
                        Console.WriteLine("Goodbye!!");
                        Environment.Exit(3000);
                        break;
                    default:
                        break;
                }

            }
        }

        public static void RemoveAll(List<Expense> expenses)
        {
            int select = ShowMenu("Are you sure?", new[]
            {
                "Yes",
                "No"
            });
            if (select == 0)
            {
                expenses.Clear();
                Console.WriteLine("All expenses have been removed!");
            }
            else
            {
                Console.WriteLine("Nothing have been removed!");
            }

        }

        // Skriver ut alla object av klassen expenses
        public static void ShowExpenses(string promt, List<Expense> expenses)
        {
            Console.WriteLine(promt);

            foreach (var e in expenses)
            {
                Console.WriteLine($"{e.Category}: {e.Cost} kr ({e.Category})");
            }
        }

        // Skriver ut värde samt returnerar ett index som användaren vill ta bort fron listan av objekt
        public static int RemoveIndex(List<Expense> expenses)
        {
            List<string> items = new List<string>();
            foreach (var e in expenses)
            {
                items.Add($"{e.Category}: {e.Cost} kr ({e.Category})");
            }


            int Selected = ShowMenu("What would you like to remove?", items.ToArray());
            return Selected;
        }
        // Skapa nya objekt av klassen Expenses
        public static Expense AddExpense()
        {

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

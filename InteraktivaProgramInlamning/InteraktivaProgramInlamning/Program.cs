using System;
using System.Globalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InteraktivaProgramInlamning
{
    public class Expense
    {
        public string Category;
        public decimal Cost;

    }
    public class Program
    {
        public static void Main()
        {
            // We need this to make sure we can always use periods for decimal points.
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;


            
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

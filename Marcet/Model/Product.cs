using System;
using System.Collections.Generic;
using System.Text;

namespace Marcet.Model
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        public static List<Product> products = new List<Product>();

        public Product (string name, double price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
        }               

        static string[] Tupes = { "food", "household chemicals", "hygiene products",
                     "entertainment", "others" };
        static char[] letters = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();

        public static void CreateNewProducts()
        {
            for (int i = 0; i < 9; i++)
            {
                Random rnd = new Random();
                string type = Tupes[rnd.Next(Tupes.Length)];

                int numLetters = rnd.Next(3, 12);
                string name = "";
                for (int j = 1; j <= numLetters; j++)
                {
                    int letterNum = rnd.Next(0, letters.Length - 1);
                    name += letters[letterNum];
                }
                double c = (double) rnd.Next(10, 500);
                double price = c/10; 
                Product product = new Product(name, price, type);
                products.Add(product);
            }
        }
        public override string ToString()
        {
            string name = Name;
            return name;
        }
    }
}

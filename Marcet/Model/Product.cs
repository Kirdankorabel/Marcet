using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Marcet.Model
{
    [Serializable]
    public class Product
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string Type { get; set; }

        private static string[] Tupes = { "food", "household chemicals", "hygiene products",
                      "entertainment", "others" };
        private static char[] letters = "qwertyuiopasdfghjklzxcvbnm".ToCharArray();

        public static List<Product> products = new List<Product>(); // перенести в другой класс

        protected Product (string name, double price, string type)
        {
            Name = name;
            Price = price;
            Type = type;
        }               

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
                double price = c / 10; 
                Product product = new Product(name, price, type);
                products.Add(product);
            }
            Save();
        }

        public static void Save()
        {
            var fomatter = new BinaryFormatter();
            using (var fs = new FileStream("products.dat", FileMode.OpenOrCreate))
            {
                fomatter.Serialize(fs, products);
            }
        }

        public static List<Product> Load()
        {
            var fomatter = new BinaryFormatter();
            using (var fs = new FileStream("products.dat", FileMode.OpenOrCreate))
            {
                if (fomatter.Deserialize(fs) is List<Product> products)
                {
                    return products;
                }
                else
                {
                    Console.WriteLine("Не Ok");
                    return null;
                }
            }
        }
    }
}

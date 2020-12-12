using System;
using System.Collections.Generic;
using System.Text;

namespace Marcet.Model
{
    [Serializable]
    public class PurchaseItem
    {
        public static Product BoughtProduct { get; set; }
        public static int Quantity { get; set; }
        public static double Price { get; set; }

        public PurchaseItem(Product boughtProduct, int quantity, double price)
        {
            BoughtProduct = boughtProduct;
            Quantity = quantity;
            Price = price;
        }

        public static double CalcPrice()
        {
            double price = Quantity * BoughtProduct.Price;
            return price;
        }

        public static PurchaseItem BoughtItem()
        {
            Product boughtProduct = BoughtProduct;
            Random rnd = new Random();
            Product product = Product.products[rnd.Next(Product.products.Count)];
            int quantity = rnd.Next(1, 5);
            double price = (double)quantity * product.Price;
            PurchaseItem p = new PurchaseItem(boughtProduct, quantity, price);
            BoughtProduct = boughtProduct;
            Console.WriteLine($"{product.Name} {product.Price} - {quantity}");
            Price = price;
            return p;
        }

    }
}

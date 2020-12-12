using System;
using System.Collections.Generic;
using System.Text;

namespace Marcet.Model
{
    [Serializable]
    public class PayCheck
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public List<PurchaseItem> PurchaseItems { get; set; }

        protected PayCheck(int id, DateTime dateTime, List<PurchaseItem> purchaseItems)
        {
            Id = id;
            DateTime = dateTime;
            PurchaseItems = purchaseItems;
        }

        public static PayCheck CreateCheck() 
        {
            List<PurchaseItem> purchaseItems = new List<PurchaseItem>();
            double totalPrise = 0;
            Random rnd = new Random();
            for (int i = 0; i < rnd.Next(1, 15); i++)
            {
                List < Product > products = Product.Load();
                var index = rnd.Next(products.Count);
                Product product = products[index];
                PurchaseItem p = BoughtItem(product); 
                totalPrise += p.Price;
                purchaseItems.Add(p);
            }
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{totalPrise} - {dateTime}");

            PayCheck payCheck = new PayCheck(1, dateTime, purchaseItems);
            return payCheck;
        }

        private static PurchaseItem BoughtItem(Product product)
        {
            Random rnd = new Random();
            int quantity = rnd.Next(1, 5);
            double price = (double)quantity * product.Price;
            PurchaseItem p = new PurchaseItem(product, quantity, price);
            Console.WriteLine($"{product.Name} {product.Price} - {quantity}");
            return p;
        }
    }
}

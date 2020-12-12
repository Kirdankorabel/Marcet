using Marcet.Model;
using System;
using System.Collections.Generic;

namespace Marcet
{
    class Program
    {
        static void Main(string[] args)
        {
            Product.CreateNewProducts();

            List<Product> products = Product.Load();
            //foreach (Product p in products)
            //{
            //    Console.WriteLine(p.Name);
            //}

            PurchaseHistory.payCheck();
            PurchaseHistory.payCheck();
            PurchaseHistory.payCheck();
            PurchaseHistory.payCheck();
            PurchaseHistory.payCheck();

            PurchaseHistory.Save();
            List<PayCheck> list = PurchaseHistory.Load();

            PurchaseHistory.MostBoughtProducts();

            Console.Read();

            //foreach (PayCheck p in list)
            //{
            //    Console.WriteLine(p.PurchaseItems.Count);
            //    foreach (PurchaseItem purchaseItem in p.PurchaseItems)
            //    {
            //        Console.WriteLine(purchaseItem.BoughtProduct.Name);
            //    }
            //}


        }
    }
}

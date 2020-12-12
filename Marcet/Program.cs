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

            PurchaseHistory.payCheck();
            PurchaseHistory.payCheck();
            PurchaseHistory.payCheck();
            PurchaseHistory.payCheck();
            PurchaseHistory.payCheck();

            PurchaseHistory.Save();
            List<PayCheck>  list = PurchaseHistory.Load();

            //foreach (PayCheck p in list)
            //{
            //    Console.WriteLine(p.PurchaseItems.Count);
            //    foreach (PurchaseItem purchaseItem in p.PurchaseItems) 
            //    {
            //        Console.WriteLine(purchaseItem.BoughtProduct.Name);
            //    }
            //}
            Console.WriteLine("Hello World!");

        }
    }
}

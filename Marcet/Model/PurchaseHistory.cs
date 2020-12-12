using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Marcet.Model
{
    public class PurchaseHistory
    {
        public static PayCheck PayCheck { get; set; }
        public static List<PayCheck> purchaseHistory = new List<PayCheck>();


        public static void payCheck()
        {
            PayCheck = PayCheck.CreateCheck(); 
            purchaseHistory.Add(PayCheck);
        }


        public static void MostBoughtProducts() // должно выдавать список из 5 самых популярных товаров 
        {
            List<PayCheck> purchaseHistor = Load();
            List<PurchaseItem> mostBoughtProducts = new List<PurchaseItem>();
            foreach (PayCheck payCheck in purchaseHistor)
            {
                foreach (PurchaseItem purchaseItem in payCheck.PurchaseItems)
                {
                    if (purchaseItem.ContaineProduct(mostBoughtProducts) == true)
                    {
                        purchaseItem.Quantity += purchaseItem.Quantity;
                        purchaseItem.Price += purchaseItem.Price;
                    }
                    else
                    {
                        mostBoughtProducts.Add(purchaseItem);
                    }
                }
            }

            SortByQuantity(mostBoughtProducts);
            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"имеем за неопределенное время {mostBoughtProducts[i].BoughtProduct.Name } - " +
                    $"{mostBoughtProducts[i].Quantity } - {mostBoughtProducts[i].Price }");
            }
        }

        public static void Save()
        {
            var fomatter = new BinaryFormatter();
            using (var fs = new FileStream("PurchaseHistory.dat", FileMode.OpenOrCreate))
            {
                fomatter.Serialize(fs, purchaseHistory);
            }
        }

        public static List<PayCheck> Load()
        {
            var fomatter = new BinaryFormatter();
            using (var fs = new FileStream("PurchaseHistory.dat", FileMode.OpenOrCreate))
            {
                if (fomatter.Deserialize(fs) is List<PayCheck> PurchaseHistory)
                {
                    Console.WriteLine("Load");
                    return PurchaseHistory;
                }
                else
                {
                    Console.WriteLine("Не Load");
                    return null;
                }
            }
        }

        private static void SortByQuantity(List<PurchaseItem> mostBoughtProducts)
        {
            for (int i = 0; i < mostBoughtProducts.Count; i++)
            {
                for( int j = i+1; j < mostBoughtProducts.Count; j++)
                {
                    if (mostBoughtProducts[i].Quantity < mostBoughtProducts[j].Quantity)
                    {
                        var t = mostBoughtProducts[i];
                        mostBoughtProducts[i] = mostBoughtProducts[j];
                        mostBoughtProducts[j] = t;
                    }
                }
            }
        }
    }
}

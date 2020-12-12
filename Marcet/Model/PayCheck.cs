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

        public PayCheck(int id, DateTime dateTime, List<PurchaseItem> purchaseItems)
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
                PurchaseItem p = PurchaseItem.BoughtItem(); 
                totalPrise += PurchaseItem.Price;
                purchaseItems.Add(p);
            }
            DateTime dateTime = DateTime.Now;
            Console.WriteLine($"{totalPrise} - {dateTime}");

            PayCheck payCheck = new PayCheck(1, dateTime, purchaseItems);
            return payCheck;
        }
    }
}

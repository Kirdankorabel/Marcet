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


        //public static void qwe()
        //{
        //    string type = Console.ReadLine();
        //    int MoneyForCategory = 0;
        //    foreach (PayCheck payCheck in purchaseHistory)
        //    {
        //        foreach (PurchaseItem purchaseItem in payCheck.PurchaseItems)
        //        {
        //            if (purchaseItem.BoughtProduct.Type == type) 
        //            {

        //            }
        //        }
        //    }
        //}

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
                    Console.WriteLine("Ok");
                    return PurchaseHistory;
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

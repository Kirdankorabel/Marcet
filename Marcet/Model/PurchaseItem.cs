using System;
using System.Collections.Generic;
using System.Text;

namespace Marcet.Model
{
    [Serializable]
    public class PurchaseItem
    {
        public Product BoughtProduct { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }

        public PurchaseItem(Product boughtProduct, int quantity, double price)
        {
            BoughtProduct = boughtProduct;
            Quantity = quantity;
            Price = price;
        }

        public double CalcPrice(Product boughtProduct) // сериализовать список продуктов??
        {
            double price = Quantity * boughtProduct.Price;
            return price;
        }

        public bool ContaineProduct(List<PurchaseItem> mostBoughtProducts)
        {
            foreach (PurchaseItem mostBoughtProduct in mostBoughtProducts)
            {
                if (mostBoughtProduct.BoughtProduct.Name == BoughtProduct.Name)
                {
                    return true;
                }               
            }
            return false;
        }
    }
}

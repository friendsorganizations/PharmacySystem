using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyServer
{
    public class StockDL
    {
        public static List<StockClass> stocklist = new List<StockClass>();
        public static void addProduct(StockClass product)
        {
            stocklist.Add(product);
        }
        public void deleteProduct(string name, string type)
        {

            int i = 0;

            foreach (StockClass sel in StockDL.stocklist)
            {



                if (sel.ItemName == name && sel.ItemType == type)

                {
                    i = StockDL.stocklist.IndexOf(sel);

                    break;

                }
            }



            stocklist.RemoveAt(i);


        }
        public List<StockClass> showProducts()
        {
            return stocklist;

        }
    }
}
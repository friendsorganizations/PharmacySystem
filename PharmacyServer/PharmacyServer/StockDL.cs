using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PharmacyServer
{
    public class StockDL
    {
        public static List<StockClass> stocklist = new List<StockClass>();
        public static List<StockClass> noty = new List<StockClass>();
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
        public void updateProduct(string name, string type, int price, int quantity, DateTime exp)
        {
            foreach (StockClass sel in stocklist)
            {
                if (sel.ItemName == name && sel.ItemType == type)

                {
                    sel.ItemPrice = price;
                    sel.ItemQuantity = quantity;
                    sel.ItemDate = exp;
                    break;

                }

            }

        }

        public static List<StockClass> searchByName(string name)
        {
            List<StockClass> namelist = new List<StockClass>();
            StockClass s = new StockClass();
            s.ItemName = name;
            foreach (StockClass l in stocklist)
            {
                if (l.ItemName == s.ItemName)
                {
                    namelist.Add(l);
                }
            }
            return namelist;

        }
        public static List<StockClass> searchByType(string type)
        {
            List<StockClass> typelist = new List<StockClass>();
            StockClass s = new StockClass();
            s.ItemType = type;
            foreach (StockClass l in stocklist)
            {
                if (l.ItemType == s.ItemType)
                {
                    typelist.Add(l);
                }
            }
            return typelist;

        }
        public static List<StockClass> searchByFormula(string formula)
        {
            List<StockClass> formulalist = new List<StockClass>();
            StockClass s = new StockClass();
            s.ItemFormula = formula;
            foreach (StockClass l in stocklist)
            {
                if (l.ItemFormula == s.ItemFormula)
                {
                    formulalist.Add(l);
                }
            }
            return formulalist;

        }
        public void updateStock(string name, string type, int quantity)
        {

            foreach (StockClass s in stocklist)
            {
                if (s.ItemName == name && s.ItemType == type)
                {
                    s.ItemQuantity = s.ItemQuantity - quantity;
                    break;
                }
            }

        }

        public List<StockClass> storeNotification()
        {

            ////  foreach(StockClass s in stocklist)
            //  {
            //      if (s.ItemDate <= DateTime.Now)
            //      {
            //          noty.Add(s);
            //      }
            //  }
        //    bool pr = false;
       //     int len = noty.Count-1, i, j;
            //for (i = 0; i < len; i++)
            //{

            //    for (j = i + 1; j < len; j++)
            //    {
            //        if (noty[i].ItemName == noty[j].ItemName && noty[i].ItemType == noty[j].ItemType)
            //        {
            //            pr = true;

            //        }
            //    }
            //}
          //  if (!pr)
          //  {
                foreach (StockClass k in StockDL.stocklist)
                {
                    if (k.ItemDate <= DateTime.Now)
                    {
                        noty.Add(k);
                    }
                }
         //   }
            return noty;

        }
        public List<StockClass> showNotification()
        {

            return StockDL.noty;

        }
        public void deleteNoty(int index)
        {
            StockDL.noty.RemoveAt(index);
        }
        public void undoupdateStock(string name, string type, int quantity)
        {
            int sel = 0;

            foreach (StockClass s in stocklist)
            {
                if (s.ItemName == name && s.ItemType == type)
                {
                    sel = StockDL.stocklist.IndexOf(s);
                    break;
                }
            }
            StockClass up = new StockClass();
            up = stocklist.ElementAt(sel);
            up.ItemQuantity = up.ItemQuantity + quantity;
        }

    }
}
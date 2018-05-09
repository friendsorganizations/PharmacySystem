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
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pharmacy_software
{
    public partial class Receipt : Form
    {
        public Receipt()
        {
            InitializeComponent();
        }
      
        private void Receipt_Load(object sender, EventArgs e)
        {
            label1.Text = "Pharmacy System";
            label2.Text = DateTime.Now.ToLongDateString();
            label3.Text = DateTime.Now.ToLongTimeString();

            localhost.Service1 s = new localhost.Service1();
            int total_bil = 0;
            foreach (localhost.OrderClass od in s.showorder())
            {
                total_bil = total_bil + od.Total1;

            }


        
            BindingSource w = new BindingSource();
            w.DataSource = s.showorder();
            dataGridView1.DataSource = w;
            label11.Text = "Name";
            label12.Text = "Price";
            label13.Text = "Type";
            label14.Text = "Quantity";
            label15.Text = "Total";
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            label16.Text = "Total  Customer  bill  is  : ";
            label17.Text = total_bil.ToString();
        }
    }
}

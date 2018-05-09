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
    public partial class Sell_product : Form
    {
        public Sell_product()
        {
            InitializeComponent();
        }

        private void Sell_product_Load(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {
            localhost.Service1 s = new localhost.Service1();
            BindingSource k = new BindingSource();
            k.DataSource = s.searchName(textBox12.Text);

            dataGridView1.DataSource = k;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            localhost.Service1 s = new localhost.Service1();
            BindingSource k = new BindingSource();
            k.DataSource = s.searchFormula(textBox3.Text);
            dataGridView1.DataSource = k;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            localhost.Service1 s = new localhost.Service1();
            BindingSource k = new BindingSource();
            k.DataSource = s.searchType(comboBox2.Text);
            dataGridView1.DataSource = k;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
        }
    }
}

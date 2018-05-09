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
        DataTable t = new DataTable();
        DataTable t2 = new DataTable();
        private void Sell_product_Load(object sender, EventArgs e)
        {
            t.Columns.Add("ExpiryDate", typeof(string));
            t.Columns.Add("Expiryspec", typeof(string));
            t.Columns.Add("ItemFormula", typeof(string));
            t.Columns.Add("ItemName", typeof(string));
            t.Columns.Add("ItemPrice", typeof(int));
            t.Columns.Add("ItemPricespec", typeof(int));
            t.Columns.Add("ItemQuantity", typeof(int));
            t.Columns.Add("Itemquantityspec", typeof(int));
            t.Columns.Add("ItemType", typeof(string));

            dataGridView1.DataSource = t;

            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;

            t2.Columns.Add("ItemName", typeof(string));
            t2.Columns.Add("ItemPrice", typeof(int));
            t2.Columns.Add("ItemPricespec", typeof(int));
            t2.Columns.Add("ItemType", typeof(string));
            t2.Columns.Add("Itemquantity", typeof(int));
            t2.Columns.Add("Itemquantityspec", typeof(int));
            t2.Columns.Add("ItemTotal1", typeof(int));
            t2.Columns.Add("ItemTotalspec", typeof(int));
            dataGridView4.DataSource = t2;


            localhost.Service1 w = new localhost.Service1();
            BindingSource s = new BindingSource();
            s.DataSource = w.showorder();
            dataGridView4.DataSource = s;
            dataGridView4.Columns[2].Visible = false;
            dataGridView4.Columns[4].Visible = false;
            dataGridView4.Columns[7].Visible = false;
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
        int selected_row;
        private void button2_Click(object sender, EventArgs e)
        {
            int per_tottal;
            selected_row = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView1.Rows[selected_row];
            localhost.Service1 s = new localhost.Service1();
            bool quant_spec = true;
            if (int.Parse(row.Cells[6].Value.ToString()) < int.Parse(textBox4.Text))
            {
                MessageBox.Show("Required quanitty is too large");
            }
            else
            {
                per_tottal = int.Parse(textBox4.Text) * int.Parse(row.Cells[4].Value.ToString());
                s.add_order(row.Cells[3].Value.ToString(), comboBox2.Text, int.Parse(textBox4.Text), quant_spec, int.Parse(row.Cells[4].Value.ToString()), quant_spec, per_tottal, quant_spec);
                t2.Rows.Add(row.Cells[3].Value.ToString(), int.Parse(row.Cells[4].Value.ToString()), quant_spec, comboBox2.Text, int.Parse(textBox4.Text), quant_spec, per_tottal, quant_spec);
                dataGridView4.DataSource = t2;

                s.update_Stock(row.Cells[3].Value.ToString(), row.Cells[8].Value.ToString(), int.Parse(textBox4.Text), quant_spec);
                BindingSource j = new BindingSource();
                j.DataSource = s.searchName(textBox12.Text);
                dataGridView1.DataSource = j;

                dataGridView1.Columns[1].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[7].Visible = false;

                dataGridView4.Columns[2].Visible = false;
                dataGridView4.Columns[5].Visible = false;
                dataGridView4.Columns[7].Visible = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void stockcellclick(object sender, DataGridViewCellEventArgs e)
        {
            selected_row = e.RowIndex;
            DataGridViewRow r = dataGridView1.Rows[selected_row];
            textBox1.Text = r.Cells[4].Value.ToString();

            comboBox2.Text = r.Cells[8].Value.ToString();
        }

        private void cmdDeleteOrder(object sender, EventArgs e)
        {
            selected_row = dataGridView4.CurrentCell.RowIndex;
            DataGridViewRow row = dataGridView4.Rows[selected_row];
         bool ind_spec = true;
            localhost.Service1 w = new localhost.Service1();
           w.deleteOrder(selected_row, ind_spec);

            w.undo_updateStock(row.Cells[0].Value.ToString(), row.Cells[3].Value.ToString(), int.Parse(row.Cells[6].Value.ToString()), ind_spec);

            BindingSource s = new BindingSource();
            s.DataSource = w.showorder();
            dataGridView4.DataSource = s;


            dataGridView4.Columns[2].Visible = false;
            dataGridView4.Columns[4].Visible = false;
            dataGridView4.Columns[7].Visible = false;
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 r = new Form1();
            this.Hide();
            r.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Receipt p = new Receipt();
            this.Hide();
            p.Show();
        }
    }
}

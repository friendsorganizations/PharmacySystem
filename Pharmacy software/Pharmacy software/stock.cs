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
    public partial class stock : Form
    {
        public stock()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 m = new Form1();
            this.Hide();
            m.Show();
        }
        DataTable t = new DataTable();
        int selected_row;
        private void stock_Load(object sender, EventArgs e)
        {
            
            sellToolStripMenuItem.Enabled = false;
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


            localhost.Service1 w = new localhost.Service1();
            BindingSource s = new BindingSource();
            s.DataSource = w.addexpNotify();
            dataGridView2.DataSource = s;
            dataGridView2.Columns[1].Visible = false;
            dataGridView2.Columns[5].Visible = false;
            dataGridView2.Columns[7].Visible = false;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dial = MessageBox.Show("Do you want to exit", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dial == DialogResult.Yes)
            {
                Application.Exit();
            }
          
        }

        private void button1_Click(object sender, EventArgs e)
        {

            localhost.Service1 s = new localhost.Service1();
            //   s.add(textBox1.Text,comboBox1.Text,textBox2.Text,int.Parse(textBox10.Text),pr,int.Parse(textBox9.Text),pr,DateTime.Parse(dateTimePicker1.Text),pr,)
            bool prc_spec = true;
            bool outer_sp = true;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            t.Rows.Add(dateTimePicker1.Value, outer_sp, textBox2.Text, textBox1.Text, int.Parse(textBox10.Text), outer_sp, int.Parse(textBox9.Text), outer_sp, comboBox1.Text);

            s.add(textBox1.Text, comboBox1.Text, textBox2.Text, int.Parse(textBox10.Text), prc_spec, int.Parse(textBox9.Text), prc_spec, DateTime.Parse(dateTimePicker1.Text), prc_spec);


            MessageBox.Show("Product added successfully");
            dataGridView1.DataSource = t;


        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            selected_row = dataGridView1.CurrentCell.RowIndex;
            DataGridViewRow r = dataGridView1.Rows[selected_row];
            localhost.Service1 w = new localhost.Service1();
            w.delete_product(r.Cells[3].Value.ToString(), r.Cells[8].Value.ToString());
            BindingSource s = new BindingSource();
            s.DataSource = w.showAll();
            dataGridView1.DataSource = s;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;
            MessageBox.Show("Deleted successfully");

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

        private void button2_Click(object sender, EventArgs e)
        {
            selected_row = dataGridView1.CurrentCell.RowIndex;

            DataGridViewRow newdata = dataGridView1.Rows[selected_row];
            bool pr = true;
            bool qr = true;
            bool dt = true;
            localhost.Service1 local = new localhost.Service1();

            local.update(newdata.Cells[3].Value.ToString(), newdata.Cells[8].Value.ToString(), int.Parse(textBox3.Text), pr, int.Parse(textBox4.Text), qr, DateTime.Parse(dateTimePicker2.Text), dt);

            BindingSource m = new BindingSource();
            m.DataSource = local.showAll();
            dataGridView1.DataSource = m;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;

        }

        private void cmdCellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected_row = e.RowIndex;
            DataGridViewRow r = dataGridView1.Rows[selected_row];

            textBox4.Text = r.Cells[6].Value.ToString();
            textBox3.Text = r.Cells[4].Value.ToString();
            dateTimePicker2.Text = r.Cells[0].Value.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            localhost.Service1 s = new localhost.Service1();
            BindingSource k = new BindingSource();
            k.DataSource = s.showAll();
            dataGridView1.DataSource = k;
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            dataGridView1.Columns[7].Visible = false;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click_1(object sender, EventArgs e)
        {

        }

        private void button5_Click_2(object sender, EventArgs e)
        {
            localhost.Service1 q = new localhost.Service1();
            selected_row = dataGridView2.CurrentCell.RowIndex;

            DataGridViewRow newdata = dataGridView2.Rows[selected_row];
            bool pr = true;
            bool qr = true;
            bool dt = true;
            localhost.Service1 local = new localhost.Service1();
            //    local.showexpNotify();
            //local.update( selected_row,pr,int.Parse(textBox3.Text), pr, int.Parse(textBox4.Text), pr);
            local.update(newdata.Cells[3].Value.ToString(), newdata.Cells[8].Value.ToString(), int.Parse(textBox5.Text), pr, int.Parse(textBox6.Text), qr, DateTime.Parse(dateTimePicker3.Text), dt);

            local.delexpNotify(selected_row, pr);


            BindingSource b = new BindingSource();
            b.DataSource = local.showexpNotify();
            dataGridView2.DataSource = b;
        }

        private void viewtabClick(object sender, EventArgs e)
        {
         
        }

        private void notifycellClick(object sender, DataGridViewCellEventArgs e)
        {
            selected_row = e.RowIndex;
            DataGridViewRow r = dataGridView2.Rows[selected_row];

            textBox6.Text = r.Cells[6].Value.ToString();
            textBox5.Text = r.Cells[4].Value.ToString();
            dateTimePicker3.Text = r.Cells[0].Value.ToString();
        }
    }
}

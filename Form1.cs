using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace pr4kar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void openChild(Panel pen, Form emptyF)
        {
            emptyF.TopLevel = false;
            emptyF.FormBorderStyle = FormBorderStyle.None;
            emptyF.Dock = DockStyle.Fill;
            pen.Controls.Add(emptyF);
            emptyF.BringToFront();
            emptyF.Show();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChild(panel2,new Dostavka());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Garantiya2());
        }

        private void button3_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Klient());
        }

        private void button4_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Sotrudnik());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            openChild(panel2, new Zayavka());
        }
    }
}

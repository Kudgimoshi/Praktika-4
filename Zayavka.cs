using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pr4kar
{
    public partial class Zayavka : Form
    {
        DataSet data;
        SqlDataAdapter Forg;
        SqlCommandBuilder FFNP;
        //Подключение к SQL Servery
        string connectionString = @"Data Source=DESKTOP-S2RGCRQ\KUDGIMOSHI; Initial Catalog=Remont_PC; Integrated Security=True";
        string sql = "SELECT * FROM Zayavka";
        public Zayavka()
        {
            InitializeComponent();
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.AllowUserToAddRows = false;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Forg = new SqlDataAdapter(sql, connection);

                data = new DataSet();
                Forg.Fill(data);
                dataGridView2.DataSource = data.Tables[0];
            }
        }

        void openchild(Panel pen, Form emptyF)
        {
            emptyF.TopLevel = false;
            emptyF.FormBorderStyle = FormBorderStyle.None;
            emptyF.Dock = DockStyle.Fill;
            pen.Controls.Add(emptyF);
            emptyF.BringToFront();
            emptyF.Show();

        }
    

        private void button8_Click(object sender, EventArgs e)
        {
            DataRow row = data.Tables[0].NewRow();
            data.Tables[0].Rows.Add(row);
        }
    

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Forg = new SqlDataAdapter(sql, connection);
                FFNP = new SqlCommandBuilder(Forg);
                Forg.InsertCommand = new SqlCommand("add_Zayavka", connection);
                Forg.InsertCommand.CommandType = CommandType.StoredProcedure;
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Nomer_zayavki", SqlDbType.Int, 0, "Nomer_zayavki"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Data_postuplenia_zayavki", SqlDbType.Date, 0, "Data_postuplenia_zayavki"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Data_nachala_rabot", SqlDbType.Date, 0, "Data_nachala_rabot"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Srok", SqlDbType.Int, 0, "Srok"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Cena", SqlDbType.Money, 0, "Cena"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Kod_sotrudnika", SqlDbType.Int, 0, "Kod_sotrudnika"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Kommentariy_klienta", SqlDbType.VarChar, 100, "Kommentariy_klienta"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Nomer_clienta", SqlDbType.Int, 0, "Nomer_clienta"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Kod_dostavki", SqlDbType.Int, 0, "Kod_dostavki"));
                Forg.Update(data);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openchild(panel1, new Zayavka());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

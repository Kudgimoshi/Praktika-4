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
    public partial class Sotrudnik : Form
    {
        DataSet data;
        SqlDataAdapter Forg;
        SqlCommandBuilder FFNP;
        //Подключение к SQL Servery
        string connectionString = @"Data Source=DESKTOP-S2RGCRQ\KUDGIMOSHI; Initial Catalog=Remont_PC; Integrated Security=True";
        string sql = "SELECT * FROM Sotrudnik";
        public Sotrudnik()
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
    

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            DataRow row = data.Tables[0].NewRow();
            data.Tables[0].Rows.Add(row);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            openchild(panel1, new Sotrudnik());
        }

        private void button6_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                Forg = new SqlDataAdapter(sql, connection);
                FFNP = new SqlCommandBuilder(Forg);
                Forg.InsertCommand = new SqlCommand("add_Sotrudnik", connection);
                Forg.InsertCommand.CommandType = CommandType.StoredProcedure;
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Kod_sotrudnika", SqlDbType.Int, 0, "Kod_sotrudnika"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Familia", SqlDbType.VarChar, 30, "Familia"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Imia", SqlDbType.VarChar, 30, "Imia"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Otchestvo", SqlDbType.VarChar, 30, "Otchestvo"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Data_rozhdenia", SqlDbType.Date, 0, "Data_rozhdenia"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Stazh", SqlDbType.Int, 0, "Stazh"));
                Forg.InsertCommand.Parameters.Add(new SqlParameter("@Dolzhnost", SqlDbType.VarChar, 50, "Dolzhnost"));
                Forg.Update(data);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                dataGridView2.Rows.Remove(row);
            }
        }

        private void Sotrudnik_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

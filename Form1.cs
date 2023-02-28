using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace vogue
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }
        string connString = @"Data Source = LAPTOP - GT5RMN2K\SQLEXPRESS; Initial Catalog = abonentK; Integrated Security = True;";
        private void loginbutton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connString); 
            connection.Open();
            //DB db = new DB();
            Form ufrm = new UserForm();
            Form wfrm = new WorkerForm();
            /*string loginUser = loginbox.Text;
            string passUser = passbox.Text;*/
            //DataTable table = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Номер WHERE НомерТелефона = @uL AND idВладельца = @uP", connection);
            command.Parameters.AddWithValue("@uL", loginbox.Text);
            command.Parameters.AddWithValue("@uP", passbox.Text);
            //command.ExecuteNonQuery();
            // закрытие соединения с БД
            //connection.Close();
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            connection.Close();
            if (ds.Tables[0].Rows.Count > 0) {
                ufrm.Show();
            }
            /*else if (loginUser == "worker") {
                wfrm.Show();
            }*/
            else {
                MessageBox.Show("Введите корректные данные");
            }
            //sqlConnection1.Close();
        }
    }
}

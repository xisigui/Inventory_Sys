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

namespace inventory_project
{
    public partial class Form1 : Form
    {
        public static string connectionString = @"Data Source=DESKTOP-U1UA2TS;Initial Catalog=Inventory_DB;Integrated Security=true";
        public static SqlConnection cnn = new SqlConnection(connectionString);
        public int userID = -1;
        public int checkUser(string username, string password){
            int numVal = -1;
            cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT user_id FROM user_table WHERE user_name=@username and password=@password", cnn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    numVal = (int)oReader["user_id"];
                }
            }
            cnn.Close();
            return numVal;
        }

        public void clearTextBoxes(){
            txtUsername.Text = null;
            txtPassword.Text = null;
        }

        public Form1()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }
        private void btn_exit_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            String username = txtUsername.Text;
            String password = txtPassword.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Invalid username or password");
            }
            else
            {
                userID = checkUser(username, password);
                if(userID < 0){
                    MessageBox.Show("Invalid username or password", "Invalid");
                }
                else{
                    clearTextBoxes();
                    this.Hide();
                    Form2 newForm2 = new Form2();
                    newForm2.Show();
                }
            }
        }
    }
}

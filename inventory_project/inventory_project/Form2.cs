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
    public partial class Form2 : Form
    {

        public static int primaryKey = -1;

        public Form2()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;
        }

        public class Product
        {
            public int barcodeID { get; set; }
            public string productDesc { get; set; }
            public int unitPrice { get; set; }
        }

        public void fillTable(int transactionID)
        {
            Form1.cnn.Open();
            SqlDataAdapter sqlDa = new SqlDataAdapter(
                "SELECT sale.primary_key, sale.transaction_id, sale.barcode_id, product.product_description, sale.quantity, sale.quantity*sale.unit_price as 'Sub Total' " +
                "FROM sale_transaction_details as sale, product_table as product " +
                "WHERE sale.transaction_id=@transaction AND sale.barcode_id = product.barcode_id; ", Form1.cnn);
            sqlDa.SelectCommand.Parameters.Add("@transaction", SqlDbType.Int).Value = transactionID;
            DataTable dtbl = new DataTable();
            sqlDa.Fill(dtbl);
            dgvTransaction.DataSource = dtbl;
            Form1.cnn.Close();
            dgvTransaction.Columns["primary_key"].Visible = false;
        }

        public int getTransactionID()
        {
            Form1.cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(DISTINCT transaction_id) FROM sale_transaction", Form1.cnn);
            var userID = cmd.ExecuteScalar().ToString();
            Form1.cnn.Close();
            int transactionID = Int32.Parse(userID);
            return transactionID;
        }

        public Product getProduct(int barcode)
        {
            Product matchingProduct = new Product();
            Form1.cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT barcode_id, product_description, unit_price FROM product_table WHERE barcode_id=@barcode", Form1.cnn);
            cmd.Parameters.AddWithValue("@barcode", barcode);
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    matchingProduct.barcodeID = (int)oReader["barcode_id"];
                    matchingProduct.productDesc = oReader["product_description"].ToString();
                    matchingProduct.unitPrice = (int)oReader["unit_price"];
                }
            }
            Form1.cnn.Close();
            return matchingProduct;
        }

        public Product getProduct(string productName)
        {
            Product matchingProduct = new Product();
            Form1.cnn.Open();
            SqlCommand cmd = new SqlCommand("SELECT barcode_id, product_description, unit_price FROM product_table WHERE product_description LIKE @productName", Form1.cnn);
            cmd.Parameters.AddWithValue("@productName", "%"+productName+"%");
            using (SqlDataReader oReader = cmd.ExecuteReader())
            {
                while (oReader.Read())
                {
                    matchingProduct.barcodeID = (int)oReader["barcode_id"];
                    matchingProduct.productDesc = oReader["product_description"].ToString();
                    matchingProduct.unitPrice = (int)oReader["unit_price"];
                }
            }
            Form1.cnn.Close();
            return matchingProduct;
        }

        public void addIntoCart(int transactionID, int barcodeID, int unitPrice, int quantity)
        {
            Form1.cnn.Open();
            SqlCommand insertNew = new SqlCommand("INSERT INTO sale_transaction_details VALUES (@transactionID, @barcodeID, @quantity, @price, GETDATE())", Form1.cnn);
            insertNew.Parameters.AddWithValue("@transactionID", transactionID);
            insertNew.Parameters.AddWithValue("@barcodeID", barcodeID);
            insertNew.Parameters.AddWithValue("@quantity", quantity);
            insertNew.Parameters.AddWithValue("@price", unitPrice);
            insertNew.ExecuteNonQuery();
            Form1.cnn.Close();
        }

        public void removeFromCart(int primaryKey){
            Form1.cnn.Open();
            SqlCommand insertNew = new SqlCommand("DELETE FROM sale_transaction_details WHERE primary_key=@primaryKey", Form1.cnn);
            insertNew.Parameters.AddWithValue("@primaryKey", primaryKey);
            insertNew.ExecuteNonQuery();
            Form1.cnn.Close();
        }

        public void clearAll(int transactionID)
        {
            Form1.cnn.Open();
            SqlCommand insertNew = new SqlCommand("DELETE FROM sale_transaction_details WHERE transaction_id=@transactionID", Form1.cnn);
            insertNew.Parameters.AddWithValue("@transactionID", transactionID);
            insertNew.ExecuteNonQuery();
            Form1.cnn.Close();
        }

        public void getNetTotal()
        {
            int sum = 0;
            for (int i = 0; i < dgvTransaction.Rows.Count; ++i)
            {
                sum += Convert.ToInt32(dgvTransaction.Rows[i].Cells[5].Value);
            }
            txtTotal.Text = sum.ToString();
        }

        public void checkOut(int transactionID, int grandTotal, int customerID)
        {
            Form1.cnn.Open();
            SqlCommand insertNew = new SqlCommand("INSERT INTO sale_transaction VALUES (@transactionID, @grandTotal, GETDATE(), @customerID)", Form1.cnn);
            insertNew.Parameters.AddWithValue("@transactionID", transactionID);
            insertNew.Parameters.AddWithValue("@grandTotal", grandTotal);
            insertNew.Parameters.AddWithValue("@customerID", customerID);
            insertNew.ExecuteNonQuery();
            Form1.cnn.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int transactionID = getTransactionID();
            int barcodeID;
            string productName;
            int quantity;
            Product newProduct = new Product();

            if (string.IsNullOrEmpty(txtQty.Text)){
                quantity = 1;
            }
            else{
                quantity = int.Parse(txtQty.Text);
            }

            if(!string.IsNullOrEmpty(txtBarcode.Text)){
                barcodeID = int.Parse(txtBarcode.Text);

                newProduct = getProduct(barcodeID);
                addIntoCart(transactionID, newProduct.barcodeID, newProduct.unitPrice, quantity);
                fillTable(transactionID);
                getNetTotal();
            }
            else if(!string.IsNullOrEmpty(txtName.Text)){
                productName = txtName.Text;

                newProduct = getProduct(productName);
                addIntoCart(transactionID, newProduct.barcodeID, newProduct.unitPrice, quantity);
                fillTable(transactionID);
                getNetTotal();
            }
            else{
                MessageBox.Show("Please enter Barcode ID or Product Name");
            }

            txtBarcode.Text = null;
            txtName.Text = null;
            txtQty.Text = null;
        }

        private void dgvTransaction_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            try
            {
                int index = e.RowIndex;
                DataGridViewRow selectedRow = dgvTransaction.Rows[index];
                primaryKey = (int) selectedRow.Cells[0].Value;
            }
            catch (Exception E)
            {

            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove item?", "Remove", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int transactionID = getTransactionID();
                if (Form2.primaryKey == -1)
                {
                    MessageBox.Show("Please select an item to remove", "Remove");
                }
                else
                {
                    removeFromCart(Form2.primaryKey);
                    Form2.primaryKey = -1;
                }
                fillTable(transactionID);
                getNetTotal();
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            int netTotal = int.Parse(txtTotal.Text);
            int transactionID = getTransactionID();
            int customerID = 1;
            checkOut(transactionID, netTotal, customerID);
            dgvTransaction.DataSource = null;
            txtTotal.Text = null;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            txtTotal.Enabled = false;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to remove all items?", "Clear All", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                int transactionID = getTransactionID();
                clearAll(transactionID);
                fillTable(transactionID);
                getNetTotal();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to close?", "Close", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                var formToShow = Application.OpenForms.Cast<Form>().FirstOrDefault(c => c is Form1);
                if (formToShow != null)
                {
                    formToShow.Show();
                    this.Close();
                }
            }
        }
    }
}

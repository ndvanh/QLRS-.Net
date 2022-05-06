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

namespace DALTdotNet
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void vbButton1_Click(object sender, EventArgs e)
        {
            string tk = txt1.Text;
            string mk = txt2.Text;
            string query = @"Select Count(*) from Dangnhap where Tk='" + tk + "' and Mk ='" + mk + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Dangnhap");
            if ((int)ds.Tables["Dangnhap"].Rows[0].ItemArray[0] == 1)
            {
                MessageBox.Show("Đăng nhập thành công");
                frmMain frm = new frmMain();
                frm.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!");
            }
        }

        private void vbButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

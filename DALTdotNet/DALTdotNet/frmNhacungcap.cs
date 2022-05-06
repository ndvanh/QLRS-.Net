using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DALTdotNet
{
    public partial class frmNhacungcap : Form
    {
        public frmNhacungcap()
        {
            InitializeComponent();
        }
        public void getdl()
        {
            string query = @"Select * from Nhacungcap";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Nhacungcap");
            dgv1.DataSource = ds.Tables["Nhacungcap"];


        }
        private void vbButton9_Click(object sender, EventArgs e)
        {
            DialogResult tb = MessageBox.Show("Bạn muốn đăng xuất?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (tb == DialogResult.OK)
            {
                /* Login frm = new Login();
                 frm.Show();
                 this.Hide();*/
                Application.Exit();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
        }

        private void vbButton4_Click(object sender, EventArgs e)
        {
            frmSanpham frm = new frmSanpham();
            frm.Show();
            this.Hide();
        }

        private void vbButton5_Click(object sender, EventArgs e)
        {
            frmHoadon frm = new frmHoadon();
            frm.Show();
            this.Hide();
        }

        private void vbButton6_Click(object sender, EventArgs e)
        {
            frmPhieunhap frm = new frmPhieunhap();
            frm.Show();
            this.Hide();
        }

        private void vbButton7_Click(object sender, EventArgs e)
        {
            frmKhachhang frm = new frmKhachhang();
            frm.Show();
            this.Hide();
        }

        private void vbButton8_Click(object sender, EventArgs e)
        {
            frmNhanvien frm = new frmNhanvien();
            frm.Show();
            this.Hide();
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
            int row = e.RowIndex;
            if (row >= 0)
            {

                txt1.Text = dgv1.Rows[row].Cells["Mancc"].Value.ToString();
                txt2.Text = dgv1.Rows[row].Cells["Tenncc"].Value.ToString();
                


            }
        }

        private void frmNhacungcap_Load(object sender, EventArgs e)
        {
            getdl();
            dgv1.Columns[0].HeaderText = "Mã nhà cung cấp";
            dgv1.Columns[1].HeaderText = "Tên nhà cung cấp";
        }

        private void vbButton10_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string ten = txt2.Text;
            string query = @"insert into Nhacungcap values('" + ma + "','" + ten + "')";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true && ma != "")
            {
                MessageBox.Show("Thêm nhà cung cấp thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Thêm nhà cung cấp thất bại");
            }
            /*if (txt1.Text.Trim().Length == 0)
            {
                MessageBox.Show("Bạn chưa nhập mã nhà cung cấp", "Thông báo");
                txt1.Focus();
                return;
            }*/
        }

        private void vbButton12_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string ten = txt2.Text;

            string query = @"update Nhacungcap set Tenncc='" + ten + "' where Mancc='" + ma + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Sửa thông tin thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Sửa thông tin thất bại");
            }
        }

        private void vbButton11_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string query = @"delete  from Nhacungcap where Mancc='" + ma + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Xóa nhà cung cấp thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Xóa nhà cung cấp thất bại");
            }
        }

        private void vbButton3_Click(object sender, EventArgs e)
        {
            frmNhacungcap frm = new frmNhacungcap();
            frm.Show();
            this.Hide();
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vbButton14_Click(object sender, EventArgs e)
        {
            string tim = txt3.Text;
            string query = @"select * from Nhacungcap where Tenncc = '" + tim + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Nhacungcap");
            dgv1.DataSource = ds.Tables["Nhacungcap"];
        }
    }
}

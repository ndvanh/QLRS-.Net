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
    public partial class frmKhachhang : Form
    {
        public frmKhachhang()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            frmMain frm = new frmMain();
            frm.Show();
            this.Hide();
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

        private void vbButton4_Click(object sender, EventArgs e)
        {
            frmSanpham frm = new frmSanpham();
            frm.Show();
            this.Hide();
        }

        private void vbButton3_Click(object sender, EventArgs e)
        {
            frmNhacungcap frm = new frmNhacungcap();
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

        private void vbButton8_Click(object sender, EventArgs e)
        {
            frmNhanvien frm = new frmNhanvien();
            frm.Show();
            this.Hide();
        }

        public void getdl()
        {
            string query = @"Select * from Khachhang";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Khachhang");
            dgv1.DataSource = ds.Tables["Khachhang"];


        }

        private void frmKhachhang_Load(object sender, EventArgs e)
        {
            getdl();
            dgv1.Columns[0].HeaderText = "Mã KH";
            dgv1.Columns[1].HeaderText = "Tên KH";
            dgv1.Columns[2].HeaderText = "Địa chỉ";
            dgv1.Columns[3].HeaderText = "SĐT";
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {

                txt1.Text = dgv1.Rows[row].Cells["Makhach"].Value.ToString();
                txt2.Text = dgv1.Rows[row].Cells["Tenkhach"].Value.ToString();
                txt3.Text = dgv1.Rows[row].Cells["Diachi"].Value.ToString();
                txt4.Text = dgv1.Rows[row].Cells["Sdt"].Value.ToString();
       
            }
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void vbButton10_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string ten = txt2.Text;
            string dc = txt3.Text;
            string sdt = txt4.Text;
            string query = @"insert into Khachhang values('" + ma + "','" + ten + "','" + dc + "','" + sdt + "')";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true && ma != "")
            {
                MessageBox.Show("Thêm khách hàng thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Thêm khách hàng thất bại");
            }
        }

        private void vbButton13_Click(object sender, EventArgs e)
        {
            txt1.Text = " ";
            txt2.Text = " ";
            txt3.Text = " ";
            txt4.Text = " ";
            txt5.Text = " ";
        }

        private void vbButton12_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string ten = txt2.Text;
            string dc = txt3.Text;
            string sdt = txt4.Text;
            string query = @"update Khachhang set Tenkhach='" + ten + "',Diachi='" + dc + "',Sdt='" + sdt + "'where Makhach='" + ma + "'";
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
            string query = @"delete  from Khachhang where Makhach='" + ma + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Xóa khách hàng thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Xóa khách hàng thất bại");
            }
        }

        private void vbButton14_Click(object sender, EventArgs e)
        {
            string tim = txt5.Text;
            string query = @"select * from Khachhang where Tenkhach = '" + tim + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Khachhang");
            dgv1.DataSource = ds.Tables["Khachhang"];
        }

        private void vbButton7_Click(object sender, EventArgs e)
        {
            frmKhachhang frm = new frmKhachhang();
            frm.Show();
            this.Hide();
        }
    }
}

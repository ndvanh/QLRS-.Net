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
    public partial class frmNhanvien : Form
    {
        public frmNhanvien()
        {
            InitializeComponent();
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

        private void vbButton7_Click(object sender, EventArgs e)
        {
            frmKhachhang frm = new frmKhachhang();
            frm.Show();
            this.Hide();
        }


        public void getdl()
        {
            string query = @"Select * from Nhanvien";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Nhanvien");
            dgv1.DataSource = ds.Tables["Nhanvien"];


        }
        public void getgt()
        {
            string query = @"Select distinct Gioitinh from Nhanvien";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Nhanvien");
            cb1.DataSource = ds.Tables["Nhanvien"];
            cb1.DisplayMember = "Gioitinh";
            cb1.ValueMember = "Gioitinh";
        }
        private void frmNhanvien_Load(object sender, EventArgs e)
        {
            getdl();
            getgt();
            dgv1.Columns[0].HeaderText = "Mã NV";
            dgv1.Columns[1].HeaderText = "Tên NV";
            dgv1.Columns[2].HeaderText = "Giới tính";
            dgv1.Columns[3].HeaderText = "Địa chỉ";
            dgv1.Columns[4].HeaderText = "SĐT";
            dgv1.Columns[5].HeaderText = "Ngày sinh";
            dgv1.Columns[6].HeaderText = "Chức vụ";
            
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {

                txt1.Text = dgv1.Rows[row].Cells["Manv"].Value.ToString();
                txt2.Text = dgv1.Rows[row].Cells["Tennv"].Value.ToString();
                cb1.SelectedValue = dgv1.Rows[row].Cells["Gioitinh"].Value.ToString();
                txt3.Text = dgv1.Rows[row].Cells["Diachi"].Value.ToString();
                txt4.Text = dgv1.Rows[row].Cells["Sdt"].Value.ToString();
                dtp1.Value = (DateTime)dgv1.Rows[row].Cells["Ngaysinh"].Value;
                txt5.Text = dgv1.Rows[row].Cells["Chucvu"].Value.ToString();



            }
        }
       
        private void vbButton13_Click(object sender, EventArgs e)
        {
            txt1.Text = " ";
            txt2.Text = " ";
            txt3.Text = " ";
            txt4.Text = " ";
            txt5.Text = " ";
            dtp1.Value = DateTime.Now;
            //cb1.SelectedValue = "";
        }

        private void vbButton10_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string ten = txt2.Text;
            string gt = cb1.SelectedValue.ToString();
            string dc = txt3.Text;
            string sdt = txt4.Text;
            string ngay = dtp1.Value.ToString();
            string cv = txt5.Text;
           
            string query = @"insert into Nhanvien values('" + ma + "','" + ten + "','" + gt + "','" + dc + "','" + sdt + "','" + ngay + "','" + cv + "')";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true && ma!="")
            {
                MessageBox.Show("Thêm nhân viên thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Thêm nhân viên thất bại");
            }
          
        }

        private void vbButton11_Click(object sender, EventArgs e)
        {

            string ma = txt1.Text;
            string query = @"delete  from Nhanvien where Manv='" + ma + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Xóa nhân viên thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên thất bại");
            }
        }

        private void vbButton12_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string ten = txt2.Text;
            string gt = cb1.SelectedValue.ToString();
            string dc = txt3.Text;
            string sdt = txt4.Text;
            string ngay = dtp1.Value.ToString();
            string cv = txt5.Text;

            string query = @"update Nhanvien set Tennv='" + ten + "',Gioitinh='" + gt + "',Diachi='" + dc + "',Sdt='" + sdt + "',Ngaysinh='" + ngay + "',Chucvu='" + cv + "' where Manv='" + ma + "'";
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

        private void vbButton14_Click(object sender, EventArgs e)
        {
            string tim = txt6.Text;
            string query = @"select * from Nhanvien where Tennv = '" + tim + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Nhanvien");
            dgv1.DataSource = ds.Tables["Nhanvien"];
        }

        private void vbButton8_Click(object sender, EventArgs e)
        {
            frmNhanvien frm = new frmNhanvien();
            frm.Show();
            this.Hide();
        }
    }
}

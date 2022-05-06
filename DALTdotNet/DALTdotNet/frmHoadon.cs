using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using app = Microsoft.Office.Interop.Excel.Application;
namespace DALTdotNet
{
    public partial class frmHoadon : Form
    {
        public frmHoadon()
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
                System.Windows.Forms.Application.Exit();
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

        private void vbButton6_Click(object sender, EventArgs e)
        {
            frmPhieunhap frm = new frmPhieunhap();
            frm.Show();
            this.Hide();
        }


        public void getdl1()
        {
            string query = @"Select * from Hoadon";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Hoadon");
            dgv1.DataSource = ds.Tables["Hoadon"];

        }
        public void getdl2()
        {
            string query = @"Select * from CTHoadon";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "CTHoadon");
            dgv2.DataSource = ds.Tables["CTHoadon"];

        }
        public void getnv()
        {
            string query = @"Select * from Nhanvien";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Nhanvien");
            cb1.DataSource = ds.Tables["Nhanvien"];
            cb1.DisplayMember = "Tennv";
            cb1.ValueMember = "Manv";
        }
        public void getsp()
        {
            string query = @"Select * from Sanpham";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Sanpham");
            cb2.DataSource = ds.Tables["Sanpham"];
            cb2.DisplayMember = "Tensp";
            cb2.ValueMember = "Masp";
        }
        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmHoadon_Load(object sender, EventArgs e)
        {
            getdl1();
            getdl2();
            getnv();
            getsp();
            dgv1.Columns[0].HeaderText = "Mã HĐ";
            dgv1.Columns[1].HeaderText = "Mã NV";
            dgv1.Columns[2].HeaderText = "Ngày bán";
            dgv1.Columns[3].HeaderText = "Mã khách";

            dgv2.Columns[0].HeaderText = "Mã HĐ";
            dgv2.Columns[1].HeaderText = "Mã SP";
            dgv2.Columns[2].HeaderText = "Số lượng";
            dgv2.Columns[3].HeaderText = "Đơn giá";
            dgv2.Columns[4].HeaderText = "Thành tiền";
            dgv2.Columns[5].HeaderText = "Ngày bán";
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {

                txt1.Text = dgv1.Rows[row].Cells["Mahd"].Value.ToString();
                cb1.SelectedValue = dgv1.Rows[row].Cells["Manv"].Value.ToString();
                dtp1.Value = (DateTime)dgv1.Rows[row].Cells["Ngayban"].Value;
                txt2.Text = dgv1.Rows[row].Cells["Makhach"].Value.ToString();
            }
        }

        private void dgv2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {

                txt4.Text = dgv2.Rows[row].Cells["Mahd"].Value.ToString();
                cb2.SelectedValue = dgv2.Rows[row].Cells["Masp"].Value.ToString();
                txt5.Text = dgv2.Rows[row].Cells["Soluong"].Value.ToString();
                txt6.Text = dgv2.Rows[row].Cells["Dongia"].Value.ToString();
                txt7.Text = dgv2.Rows[row].Cells["Thanhtien"].Value.ToString();
                dtp2.Value = (DateTime)dgv2.Rows[row].Cells["Ngayban"].Value;
            }
        }
        private void export(DataGridView g, string path, string name)
        {
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int i = 1; i < g.Columns.Count + 1; i++)
            {
                obj.Cells[1, i] = g.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < g.Rows.Count; i++)
            {
                for (int j = 0; j < g.Columns.Count; j++)
                {
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(path + name + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }

        private void vbButton18_Click(object sender, EventArgs e)
        {
            if (txt8.Text != "")
            {
                MessageBox.Show("In thành công");
                export(dgv2, @"C:\DoAndotNet\", txt8.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập mã hóa đơn");

            }
        }

        private void vbButton10_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string manv = cb1.SelectedValue.ToString();
            string ngay = dtp1.Value.ToString();
            string mak = txt2.Text;


            string query = @"insert into Hoadon values('" + ma + "','" + manv + "','" + ngay + "','" + mak + "')";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true && ma != "")
            {
                MessageBox.Show("Thêm hóa đơn thành công");
                getdl1();
            }
            else
            {
                MessageBox.Show("Thêm hóa đơn thất bại");
            }
        }

        private void vbButton15_Click(object sender, EventArgs e)
        {

            string ma = txt4.Text;
            string masp = cb2.SelectedValue.ToString();
            string sl = txt5.Text;
            string dg = txt6.Text;
            string tt = txt7.Text;
            string ngay = dtp2.Value.ToString();

            string query = @"insert into CTHoadon values('" + ma + "','" + masp + "','" + sl + "','" + dg + "','" + tt + "','" + ngay + "')";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true && ma != "")
            {
                MessageBox.Show("Tạo hóa đơn thành công");
                getdl2();
            }
            else
            {
                MessageBox.Show("Tạo hóa đơn thất bại");
            }
        }

        private void vbButton12_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string manv = cb1.SelectedValue.ToString();
            string ngay = dtp1.Value.ToString();
            string mak = txt2.Text;

            string query = @"update Hoadon set Manv='" + manv + "',Ngayban='" + ngay + "',Makhach='" + mak + "' where Mahd='" + ma + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Sửa thông tin thành công");
                getdl1();
            }
            else
            {
                MessageBox.Show("Sửa thông tin thất bại");
            }
        }

        private void vbButton16_Click(object sender, EventArgs e)
        {
            string ma = txt4.Text;
            string masp = cb2.SelectedValue.ToString();
            string sl = txt5.Text;
            string dg = txt6.Text;
            string tt = txt7.Text;
            string ngay = dtp2.Value.ToString();

            string query = @"update CTHoadon set Soluong='" + sl + "',Dongia='" + dg + "',Thanhtien='" + tt + "',Ngayban='" + ngay + "' where Mahd='" + ma + "' and Masp='" + masp + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Sửa thông tin thành công");
                getdl2();
            }
            else
            {
                MessageBox.Show("Sửa thông tin thất bại");
            }
        }

        private void vbButton11_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string query = @"delete  from Hoadon where Mahd='" + ma + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Xóa thành công");
                getdl1();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void vbButton17_Click(object sender, EventArgs e)
        {
            string ma = txt4.Text;
            string query = @"delete  from CTHoadon where Mahd='" + ma + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Xóa thành công");
                getdl2();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void vbButton14_Click(object sender, EventArgs e)
        {
            string tim = txt3.Text;
            string query = @"select * from Hoadon where Mahd = '" + tim + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Hoadon");
            dgv1.DataSource = ds.Tables["Hoadon"];
        }

        private void vbButton13_Click(object sender, EventArgs e)
        {
            string tim = txt8.Text;
            string query = @"select * from CTHoadon where Mahd = '" + tim + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "CTHoadon");
            dgv2.DataSource = ds.Tables["CTHoadon"];
        }

        private void vbButton19_Click(object sender, EventArgs e)
        {
            txt1.Text = " ";
            txt2.Text = " ";
            txt3.Text = " ";
            txt4.Text = " ";
            txt5.Text = " ";
            dtp1.Value = DateTime.Now;
            txt6.Text = "";
            txt7.Text = "";
            txt8.Text = "";
            txt9.Text = "";
            dtp2.Value = DateTime.Now;
        }

        private void vbButton20_Click(object sender, EventArgs e)
        {
            int tien = dgv2.Rows.Count;
            int sum = 0;
            for (int i = 0; i < tien - 1; i++)
            {
                sum += Convert.ToInt32(dgv2.Rows[i].Cells["Thanhtien"].Value.ToString());
            }
            txt9.Text = sum.ToString();
        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

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
    public partial class frmPhieunhap : Form
    {
        public frmPhieunhap()
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

        public void getdl()
        {
            string query = @"Select * from Phieunhap";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Phieunhap");
            dgv1.DataSource = ds.Tables["Phieunhap"];


        }
        public void getnc()
        {
            string query = @"Select * from Nhacungcap";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Nhacungcap");
            cb1.DataSource = ds.Tables["Nhacungcap"];
            cb1.DisplayMember = "Tenncc";
            cb1.ValueMember = "Mancc";
        }
        private void frmPhieunhap_Load(object sender, EventArgs e)
        {
            getdl();
            getnc();
            dgv1.Columns[0].HeaderText = "Mã PN";
            dgv1.Columns[1].HeaderText = "Mã NCC";
            dgv1.Columns[2].HeaderText = "Tên SP";
            dgv1.Columns[3].HeaderText = "Số lượng";
            dgv1.Columns[4].HeaderText = "Ngày nhập";
            dgv1.Columns[5].HeaderText = "Giá nhập";
      
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
            if (row >= 0)
            {

                txt1.Text = dgv1.Rows[row].Cells["Mapn"].Value.ToString();
                cb1.SelectedValue = dgv1.Rows[row].Cells["Mancc"].Value.ToString();
                txt2.Text = dgv1.Rows[row].Cells["Tensp"].Value.ToString();
                txt3.Text = dgv1.Rows[row].Cells["Soluong"].Value.ToString();
                dtp1.Value = (DateTime)dgv1.Rows[row].Cells["Ngay"].Value;
                txt4.Text = dgv1.Rows[row].Cells["Gianhap"].Value.ToString();
               
           
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
            txt6.Text = "";
            
        }

        private void vbButton10_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string manc = cb1.SelectedValue.ToString();
            string ten = txt2.Text;
            string sl = txt3.Text;
            string ngay = dtp1.Value.ToString();
            string gia = txt4.Text;
         
         
            string query = @"insert into Phieunhap values('" + ma + "','" + manc + "','" + ten + "','" + sl + "','" + ngay + "','" + gia + "')";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true && ma != "")
            {
                MessageBox.Show("Tạo phiếu nhập thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Tạo phiếu nhập thất bại");
            }
        }

        private void vbButton12_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string manc = cb1.SelectedValue.ToString();
            string ten = txt2.Text;
            string sl = txt3.Text;
            string ngay = dtp1.Value.ToString();
            string gia = txt4.Text;

            string query = @"update Phieunhap set Mancc='" + manc + "',Tensp='" + ten + "',Soluong='" + sl + "',Ngay='" + ngay + "',Gianhap='" + gia + "' where Mapn='" + ma + "'";
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
            string query = @"delete  from Phieunhap where Mapn='" + ma + "'";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true)
            {
                MessageBox.Show("Xóa thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Xóa thất bại");
            }
        }

        private void vbButton14_Click(object sender, EventArgs e)
        {
            string tim = txt5.Text;
            string query = @"select * from Phieunhap where Mapn = '" + tim + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Phieunhap");
            dgv1.DataSource = ds.Tables["Phieunhap"];
        }

        private void vbButton6_Click(object sender, EventArgs e)
        {
            frmPhieunhap frm = new frmPhieunhap();
            frm.Show();
            this.Hide();
        }

        private void export(DataGridView g , string path , string name)
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
                for (int j =0; j < g.Columns.Count; j++){
                    if (g.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = g.Rows[i].Cells[j].Value.ToString();
                    }
            }
            }
            obj.ActiveWorkbook.SaveCopyAs(path + name + ".xlsx");
            obj.ActiveWorkbook.Saved = true;
        }
        private void vbButton15_Click(object sender, EventArgs e)
        {
            if (txt6.Text != "")
            {
                MessageBox.Show("Xuất excel phiếu nhập thành công");
                export(dgv1, @"C:\DoAndotNet\", txt6.Text);
            }
            else
            {
                MessageBox.Show("Bạn chưa điền tên phiếu nhập");
            }
           
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

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
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
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

        private void vbButton8_Click(object sender, EventArgs e)
        {
            frmNhanvien frm = new frmNhanvien();
            frm.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void lbtime_Click(object sender, EventArgs e)
        {
            
        }

        private void lbgiay_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lbtime.Text = DateTime.Now.ToString("HH:mm");
            lbgiay.Text = DateTime.Now.ToString("ss");
            lbdate.Text = DateTime.Now.ToString("dd/ MM/ yyyy");
            lbthu.Text = DateTime.Now.ToString("dddd");
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            timer1.Start();
            getdl1();
            getdl2();

            dgv1.Columns[0].HeaderText = "Mã HĐ";
            dgv1.Columns[1].HeaderText = "Mã NV";
            dgv1.Columns[2].HeaderText = "Ngày bán";
            dgv1.Columns[3].HeaderText = "Mã khách";
            dgv2.Columns[0].HeaderText = "Mã HĐ";
            dgv2.Columns[1].HeaderText = "Mã SP";
            dgv2.Columns[2].HeaderText = "Số lượng";
            dgv2.Columns[3].HeaderText = "Đơn giá";
            dgv2.Columns[4].HeaderText = "Thành tiền";

        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

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

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void vbButton14_Click(object sender, EventArgs e)
        {
            string tim1 = dtp1.Value.ToString();
            string tim2 = dtp2.Value.ToString();
            string query = @"select * from Hoadon where Ngayban BETWEEN  '" + tim1 + "' AND '" + tim2 + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Hoadon");
            dgv1.DataSource = ds.Tables["Hoadon"];

            string query1 = @"select * from CTHoadon where Ngayban BETWEEN  '" + tim1 + "' AND '" + tim2 + "'";
            DataSet ds1 = cn.getdata(query1, "CTHoadon");
            dgv2.DataSource = ds1.Tables["CTHoadon"];
        }

        private void vbButton20_Click(object sender, EventArgs e)
        {
            int tien = dgv2.Rows.Count;
            int sum = 0;
            for (int i = 0; i < tien - 1; i++)
            {
                sum += Convert.ToInt32(dgv2.Rows[i].Cells["Thanhtien"].Value.ToString());
            }
            lba.Text = sum.ToString();
        }

        private void vbButton11_Click(object sender, EventArgs e)
        {
            int tien = dgv2.Rows.Count;
            int sum = 0;
            for (int i = 0; i < tien - 1; i++)
            {
                sum += Convert.ToInt32(dgv2.Rows[i].Cells["Soluong"].Value.ToString());
            }
            lbc.Text = sum.ToString();
        }
      
        private void vbButton10_Click(object sender, EventArgs e)
        {
           
            lbb.Text = dgv1.RowCount.ToString();
            
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void vbButton13_Click(object sender, EventArgs e)
        {
            lba.Text = "";
            lbb.Text = "";
            lbc.Text = "";
            dtp1.Value = DateTime.Now;
            dtp2.Value = DateTime.Now;
        }
    }
}

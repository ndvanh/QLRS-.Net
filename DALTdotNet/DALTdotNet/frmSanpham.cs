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
    public partial class frmSanpham : Form
    {
        public frmSanpham()
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

        private void txt7_TextChanged(object sender, EventArgs e)
        {
            txt7.Multiline = true;
            txt7.Height = 50;
            txt7.Width = 209;
        }

        public void getdl()
        {
            string query = @"Select * from Sanpham";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Sanpham");
            dgv1.DataSource = ds.Tables["Sanpham"];


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
        public void gettt()
        {
            string query = @"Select distinct Trangthai from Sanpham";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Sanpham");
            cb2.DataSource = ds.Tables["Sanpham"];
            cb2.DisplayMember = "Trangthai";
            cb2.ValueMember = "Trangthai";
        }

        private void frmSanpham_Load(object sender, EventArgs e)
        {
            getdl();
            getnc();
            gettt();
            dgv1.Columns[0].HeaderText = "Mã SP";
            dgv1.Columns[1].HeaderText = "Tên SP";
            dgv1.Columns[2].HeaderText = "Mã NCC";
            dgv1.Columns[3].HeaderText = "Số lượng";
            dgv1.Columns[4].HeaderText = "Giá nhập/KG";
            dgv1.Columns[5].HeaderText = "Giá bán/KG";
            dgv1.Columns[6].HeaderText = "Ảnh";
            dgv1.Columns[7].HeaderText = "Mô tả";
            dgv1.Columns[8].HeaderText = "Trạng thái";
            dgv1.Columns[9].HeaderText = "Mã PN";
        }

        private void dgv1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgv1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int row = e.RowIndex;
     
            if (row >= 0)
            {

                txt1.Text = dgv1.Rows[row].Cells["Masp"].Value.ToString();
                txt2.Text = dgv1.Rows[row].Cells["Tensp"].Value.ToString();
                cb1.SelectedValue = dgv1.Rows[row].Cells["Mancc"].Value.ToString();
                txt3.Text = dgv1.Rows[row].Cells["Soluong"].Value.ToString();
                txt4.Text = dgv1.Rows[row].Cells["Gianhap"].Value.ToString();
                txt5.Text = dgv1.Rows[row].Cells["Giaban"].Value.ToString();
                txt6.Text = dgv1.Rows[row].Cells["Anh"].Value.ToString();
                txt7.Text = dgv1.Rows[row].Cells["Mota"].Value.ToString();
                cb2.SelectedValue = dgv1.Rows[row].Cells["Trangthai"].Value.ToString();
                txt8.Text = dgv1.Rows[row].Cells["Mapn"].Value.ToString();
                pictureBox3.Image = Image.FromFile(txt6.Text);

            }
           
             //txt6.Text = Functions.GetFieldValues(sql);

        }
       
        private void ptb1_Click(object sender, EventArgs e)
        {
            
        }
       
        private void vbButton15_Click(object sender, EventArgs e)
        {

             OpenFileDialog dlgOpen = new OpenFileDialog();
             dlgOpen.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg)|*.jpg|GIF(*.gif)|*.gif|All files(*.*)|*.*";
             dlgOpen.FilterIndex = 2;
           //  dlgOpen.Title = "Chọn ảnh minh hoạ cho sản phẩm";
             if (dlgOpen.ShowDialog() == DialogResult.OK)
             {
                pictureBox3.Image = Image.FromFile(dlgOpen.FileName);
                 txt6.Text = dlgOpen.FileName;
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

        private void vbButton10_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string ten = txt2.Text;
            string manc = cb1.SelectedValue.ToString();
            string sl = txt3.Text;
            string gian = txt4.Text;
            string giab = txt5.Text;
            string anh = txt6.Text;
            string mota = txt7.Text;
            string tt = cb2.SelectedValue.ToString();
            string mapn = txt8.Text;


            string query = @"insert into Sanpham values('" + ma + "','" + ten + "','" + manc + "','" + sl + "','" + gian + "','" + giab+ "','" + anh + "','" + mota + "','" + tt + "','" + mapn + "')";
            ketnoi cn = new ketnoi();
            bool kq = cn.excute(query);
            if (kq == true && ma != "")
            {
                MessageBox.Show("Thêm sản phẩm thành công");
                getdl();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm thất bại");
            }
        }

        private void vbButton13_Click(object sender, EventArgs e)
        {
            txt1.Text = " ";
            txt2.Text = " ";
            txt3.Text = " ";
            txt4.Text = " ";
            txt5.Text = " ";
            txt6.Text = " ";
            txt7.Text = " ";
            txt8.Text = " ";
            txt9.Text = " ";
           
        }

        private void vbButton12_Click(object sender, EventArgs e)
        {
            string ma = txt1.Text;
            string ten = txt2.Text;
            string manc = cb1.SelectedValue.ToString();
            string sl = txt3.Text;
            string gian = txt4.Text;
            string giab = txt5.Text;
            string anh = txt6.Text;
            string mota = txt7.Text;
            string tt = cb2.SelectedValue.ToString();
            string mapn = txt8.Text;

            string query = @"update Sanpham set Tensp='" + ten + "',Mancc='" + manc + "',Soluong='" + sl + "',Gianhap='" + gian + "',Giaban='" + giab + "',Anh='" + anh + "',Mota='" + mota + "',Trangthai='" + tt + "',Mapn='" + mapn + "' where Masp='" + ma + "'";
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
            string query = @"delete  from Sanpham where Masp='" + ma + "'";
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
            string tim = txt9.Text;
            string query = @"select * from Sanpham where Tensp = '" + tim + "'";
            ketnoi cn = new ketnoi();
            DataSet ds = cn.getdata(query, "Sanpham");
            dgv1.DataSource = ds.Tables["Sanpham"];
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}

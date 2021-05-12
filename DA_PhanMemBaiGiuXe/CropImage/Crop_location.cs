using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu;
using Emgu.CV;
using Emgu.Util;
using System.IO;


namespace CropImage
{
    public partial class Crop_location : Form
    {
        FolderBrowserDialog folder_brower = new FolderBrowserDialog();
        DirectoryInfo dir;
        List<string> direct_img = new List<string>();
        Rectangle rect;
        public Crop_location()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            folder_brower = this.folderBrowserDialog1;
            this.ori_img.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            DialogResult rs = folder_brower.ShowDialog();
            if (rs == DialogResult.OK)
            {
                txtFilePath.Text = folder_brower.SelectedPath;
                dir = new DirectoryInfo(txtFilePath.Text);
                FileInfo[] files = dir.GetFiles("*.jpg");
                foreach (FileInfo file in files)
                {
                    direct_img.Add(file.Name);
                    this.listBox1.Items.Add(file.Name);

                }
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = listBox1.SelectedIndex;
            string file =direct_img[index];
            string path = dir +"\\"+ file;
            Bitmap bm = new Bitmap(path);
            ori_img.Image = (Image)bm;
        }

        int xCordinate, yCordinate,crop_imgH,crop_imgW;
        bool started_draw = false;

        private void ori_img_MouseDown(object sender, MouseEventArgs e)
        {
            xCordinate = e.X;
            yCordinate = e.Y;
            if (rect != null)
                rect = new Rectangle();
            started_draw = true;
        }

        private void ori_img_MouseUp(object sender, MouseEventArgs e)
        {

            getParam();
            Bitmap source = ori_img.Image as Bitmap;
            Bitmap cropped_img = source.Clone(rect, source.PixelFormat);
            crop_img.Image = cropped_img;
            started_draw = false;
        }

        private void ori_img_Paint(object sender, PaintEventArgs e)
        {
            if (started_draw)
            {
                Graphics g = e.Graphics;
                if(rect != null && rect.Width >0 && rect.Height >0)
                    e.Graphics.DrawRectangle(new Pen(Color.Green,2),rect);
              
            }
        }

        private void getParam()
        {
            txtX.Text = xCordinate.ToString();
            txtY.Text = yCordinate.ToString();
            txtW.Text = crop_imgW.ToString();
            txtH.Text = crop_imgH.ToString();
        }

        private void ori_img_MouseMove(object sender, MouseEventArgs e)
        {
            if (started_draw)
            {
                if (e.Button != MouseButtons.Left)
                    return;
                Point endPoint = e.Location;
                rect.Location = new Point(Math.Min(xCordinate, endPoint.X), Math.Min(yCordinate, endPoint.Y)); 
                crop_imgH = endPoint.Y - yCordinate;
                crop_imgW = endPoint.X - xCordinate;
                rect.Size = new Size(Math.Abs(crop_imgW), Math.Abs(crop_imgH));
                ori_img.Invalidate();
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                bool param_isvalid = true;
                foreach (Control ctr in tableLayoutPanel3.Controls)
                {
                    if (ctr.GetType() == typeof(TextBox))
                    {
                        TextBox text = ctr as TextBox;
                        if (text.Text.Trim().Length < 0)
                        {
                            param_isvalid = false;
                            break;
                        }
                    }
                }
                if (param_isvalid)
                {
                    try
                    {
                        string[] array = listBox1.Items.OfType<string>().ToArray();
                        int index = listBox1.SelectedIndex;
                        string info = listBox1.SelectedItem.ToString();
                        string getLocation_info = string.Format("{0} {1} {2} {3}",txtX.Text,txtY.Text,txtW.Text,txtH.Text);
                        string info_loca = info + " 1 "+ getLocation_info;
                        array[index] = info_loca;
                        listBox1.Items.Clear();
                        listBox1.Items.AddRange(array);
                        listBox1.ClearSelected();
                        index ++;
                        listBox1.SelectedIndex = index;
                        clearLocaCordinate();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }

        }

        private void clearLocaCordinate()
        {
            foreach (Control ctr in tableLayoutPanel3.Controls)
            {
                if (ctr.GetType() == typeof(TextBox))
                {
                    TextBox text = ctr as TextBox;
                    if (text.Text.Trim().Length > 0)
                    {

                        text.Clear();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string ten="";
            if (!checkData_isValid())
                return;
            if (SaveFileDialog.Show("Tên file muốn lưu", "Tên File",ref ten) == DialogResult.OK)
            {
                ten = ten;

                DialogResult rs = folder_brower.ShowDialog();
                if (rs == DialogResult.OK)
                {
                    string path = folder_brower.SelectedPath;
                    path = path + "\\" + ten +".txt";
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(path))
                        {
                            List<string> datas = listBox1.Items.OfType<string>().ToList();
                            foreach (string data in datas)
                                sw.WriteLine(data);
                        }
                        MessageBox.Show("Ghi file thanh cong");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            
            }
        }
        private bool checkData_isValid()
        {
            if (listBox1.Items.Count <= 0)
                return false;
            return true;
        }


    }
}

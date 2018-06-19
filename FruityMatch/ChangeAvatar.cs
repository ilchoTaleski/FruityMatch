using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruityMatch
{
    public partial class ChangeAvatar : Form
    {
        public Image selectedImage { get; set; }

        public ChangeAvatar()
        {
            InitializeComponent();
            selectedImage = null;
        }

        public void selectImage(PictureBox pic)
        {
            selectedImage = pic.Image;
            foreach (PictureBox pc in Controls.OfType<PictureBox>())
            {
                pc.BorderStyle = BorderStyle.None;
            }
            pic.BorderStyle = BorderStyle.FixedSingle;
            
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox1);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox2);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox3);
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox6);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox12);
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox11);
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox10);
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox9);
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox8);
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            selectImage(pictureBox7);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}

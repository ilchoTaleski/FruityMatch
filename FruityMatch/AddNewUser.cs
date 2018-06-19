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
    public partial class AddNewUser : Form
    {
        public String name { get; set; }
        public Image image { get; set; }
        public AddNewUser()
        {
            InitializeComponent();
            name = null;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            image = pictureBox1.Image;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeAvatar form = new ChangeAvatar();
            DialogResult result = form.ShowDialog();
            if(result == DialogResult.OK)
            {
                pictureBox1.Image = form.selectedImage;
                image = form.selectedImage;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                button2.Enabled = true;
            }
            else
            {
                button2.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            name = textBox1.Text;
            DialogResult = DialogResult.OK;
        }
    }
}

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
    public partial class ChangeUser : Form
    {
        public User selectedUser { get; set; }
        public List<User> users { get; set; }
        public UniqueIDGenerator ID { get; set; }
        public ChangeUser(List<User> users, UniqueIDGenerator ID, bool secondPlayer)
        {
            InitializeComponent();
            this.ID = ID;
            this.users = users;
            if (users.Count > 0)
            {
                foreach (User u in users)
                {
                    if (secondPlayer)
                    {
                        secondPlayer = false;
                        continue;
                    }
                    listBox1.Items.Add(u);
                }
                listBox1.SelectedIndex = 0;
                setUser((User)(listBox1.SelectedItem));
            }
        }

        public void setUser(User user)
        {
            pictureBox1.Image = user.avatar;
            winsNumber.Text = user.wins.ToString();
            lossesNumber.Text = user.losses.ToString();
            tiesNumber.Text = user.ties.ToString();
            name.Text = user.name;
            selectedUser = user;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = (User)listBox1.SelectedItem;
            if (user != null)
            {
                ChangeAvatar avatarForm = new ChangeAvatar();
                DialogResult result = avatarForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    user.avatar = avatarForm.selectedImage;
                    pictureBox1.Image = user.avatar;
                }
            }
        }

        private void name_TextChanged(object sender, EventArgs e)
        {
            if (name.Text != "")
            {
                done.Enabled = true;
                User user = (User)listBox1.SelectedItem;
                if(user != null)
                {
                    user.name = name.Text;
                }
            }
            else
            {
                done.Enabled = false;
            }
        }

        private void done_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setUser((User)listBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddNewUser addForm = new AddNewUser();
            DialogResult result = addForm.ShowDialog();
            if(result == DialogResult.OK)
            {
                User user = new User(addForm.name, ID.generateUniqueId());
                Form1.serializeID(ID);
                user.changeAvatar(addForm.image);
                listBox1.Items.Add(user);
                this.users.Add(user);
            }
        }
    }
}

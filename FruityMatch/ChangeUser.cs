using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                if (users.Count > 1) {
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
                else
                {
                    if (!secondPlayer)
                    {
                        listBox1.Items.Add(users[0]);
                        listBox1.SelectedIndex = 0;
                    }
                    else
                    {
                        done.Enabled = false;
                        removeButton.Enabled = false;
                        changeAvatarButton.Enabled = false;
                        InfoLabel.Visible = true;
                    }
                }
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
                if (listBox1.Items.Count > 0)
                {
                    done.Enabled = true;
                }
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
            if (listBox1.Items.Count > 0)
            {
                done.Enabled = true;
                removeButton.Enabled = true;
                changeAvatarButton.Enabled = true;
                InfoLabel.Visible = false;
                User u = (User)listBox1.SelectedItem;
                if (u != null)
                {
                    setUser(u);
                }
            }
            else
            {
                removeButton.Enabled = false;
                InfoLabel.Visible = true ;
                changeAvatarButton.Enabled = false;
            }
            
        }

        public void addNewUser()
        {
            AddNewUser addForm = new AddNewUser();
            DialogResult result = addForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                User user = new User(addForm.name, ID.generateUniqueId());
                Form1.serializeID(ID);
                user.changeAvatar(addForm.image);
                listBox1.Items.Add(user);
                this.users.Add(user);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            addNewUser();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 1)
            {
                RemovingUser rmv = new RemovingUser();
                DialogResult result = rmv.ShowDialog();
                if (result == DialogResult.OK)
                {
                    int ind = listBox1.SelectedIndex;
                    User user = ((User)listBox1.SelectedItem);


                    if (user != null )
                    {
                        
                            listBox1.Items.RemoveAt(ind);
                            listBox1.SelectedIndex = 0;
                            
                            this.users.RemoveAt(ind);
                            try
                            {
                                File.Delete(@".\Users\user" + user.uniqueID + ".fmu");
                            }
                            catch
                            {
                                MessageBox.Show("Operation Unsuccessful");
                            }
                        if (user.isDefault())
                        {
                            User user2 = (User)listBox1.SelectedItem;
                            user2.makeDefaultUser();
                        }
                       
                    }
                    else
                    {
                        MessageBox.Show("Must select user to delete");
                    }
                }
                
            } else
            {
                    MessageBox.Show("There is only one user created. If you want to remove it, " +
                    "add a second one and then try again.");
                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruityMatch
{
    public partial class Rankings : Form
    {
        public List<User> users { get; set; }
        public Rankings()
        {
            InitializeComponent();

            users = new List<User>();

            loadUsers();

            users.Sort((a,b) => b.points - a.points);

            showStats();

        }

        public void loadUsers()
        {
            String[] files = Directory.GetFiles(@".\Users");
            foreach (String s in files)
            {
                if (s == "\\Users\\desktop.ini")
                {
                    continue;
                }
                try
                {
                    using (FileStream fStream = new FileStream(s, FileMode.Open))
                    {
                        BinaryFormatter formatter = new BinaryFormatter();
                        User user = (User)formatter.Deserialize(fStream);
                        users.Add(user);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Something went wrong with loading the users. Check the location of your .exe file");
                }
            }
        }

        public void showStats()
        {
            int i = 1;
            foreach(User u in users)
            {
                addName(u, i);

                addImage(u, i);

                addPoints(u, i);

                addWins(u, i);
                addLosses(u, i);
                addTies(u, i);
                
                i++;
            }

            Invalidate(true);

            

        }

        public void addPoints(User u, int i)
        {
            Label pointsLabel = new Label();
            pointsLabel.Text = "Points: " + u.points;
            pointsLabel.Font = new Font(pointsLabel.Font.FontFamily, 13);
            pointsLabel.Font = new Font(pointsLabel.Font, FontStyle.Bold);
            pointsLabel.Location = new Point(140, 50 + 150 * (i - 1));
            pointsLabel.AutoSize = true;
            this.Controls.Add(pointsLabel);
        }

        public void addWins(User u, int i)
        {
            Label pointsLabel = new Label();
            pointsLabel.Text = "Wins: " + u.wins;
            pointsLabel.Font = new Font(pointsLabel.Font.FontFamily, 10);
            pointsLabel.Location = new Point(140, 80 + 150 * (i - 1));
            pointsLabel.AutoSize = true;
            this.Controls.Add(pointsLabel);
        }

        public void addLosses(User u, int i)
        {
            Label pointsLabel = new Label();
            pointsLabel.Text = "Losses: " + u.losses;
            pointsLabel.Font = new Font(pointsLabel.Font.FontFamily, 10);
            pointsLabel.Location = new Point(140, 100 + 150 * (i - 1));
            pointsLabel.AutoSize = true;
            this.Controls.Add(pointsLabel);
        }

        public void addTies(User u, int i)
        {
            Label pointsLabel = new Label();
            pointsLabel.Text = "Ties: " + u.ties;
            pointsLabel.Font = new Font(pointsLabel.Font.FontFamily, 10);
            pointsLabel.Location = new Point(140, 120 + 150 * (i - 1));
            pointsLabel.AutoSize = true;
            this.Controls.Add(pointsLabel);
        }

        public void addImage(User u, int i)
        {
            PictureBox avatarBox = new PictureBox();
            avatarBox.Image = u.avatar;
            avatarBox.Location = new Point(30, 10 + 150 * (i - 1));
            avatarBox.Width = 100;
            avatarBox.Height = 140;
            avatarBox.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(avatarBox);
        }

        public void addName(User u, int i)
        {
            Label nameLabel = new Label();
            nameLabel.Text = i.ToString() + ": " + u.name;
            nameLabel.ForeColor = Color.Maroon;
            nameLabel.Font = new Font(nameLabel.Font.FontFamily, 13);
            nameLabel.Location = new Point(140, 15 + 150 * (i - 1));
            nameLabel.AutoSize = true;
            this.Controls.Add(nameLabel);
        }

        public void Draw(Graphics g)
        {
            int counter = 0;
            foreach (User u in users)
            {
                g.DrawImage(u.avatar, 10, 10 + 150 * counter, 100, 140);
                counter++;
            }
        }

        private void Rankings_Paint(object sender, PaintEventArgs e)
        {
            //Draw(e.Graphics);
        }
    }
}

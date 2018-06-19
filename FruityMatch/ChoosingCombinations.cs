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
    public partial class ChoosingCombinations : Form
    {
        public List<Fruit> player1Comb, player2Comb;
        public Dictionary<String, PictureBox> indexses;
        public int temporaryPosition;
        public bool firstChooses { get; set; }
        public Dictionary<String, PictureBox> fruitPosition;
        public Dictionary<String, Fruit> fruits;
        public ChoosingCombinations()
        {
            InitializeComponent();
            this.BackgroundImage = Properties.Resources.choose;
            temporaryPosition = 0;
            indexses = new Dictionary<string, PictureBox>();
            fruitPosition = new Dictionary<String, PictureBox>();
            fruits = new Dictionary<string, Fruit>();
            player1Comb = new List<Fruit>();
            player2Comb = new List<Fruit>();
            
            fruitPosition.Add("orange", orangeMenu);
            fruitPosition.Add("apple", appleMenu);
            fruitPosition.Add("watermelon", watermelonMenu);
            fruitPosition.Add("plum", plumMenu);
            fruitPosition.Add("peach", peachMenu);
            fruitPosition.Add("lemon", lemonMenu);

            fruits.Add("orange", new Orange(0,0,0,0));
            fruits.Add("apple", new Apple(0, 0, 0, 0));
            fruits.Add("watermelon", new Watermelon(0, 0, 0, 0));
            fruits.Add("plum", new Plum (0, 0, 0, 0));
            fruits.Add("peach", new Peach(0, 0, 0, 0));
            fruits.Add("lemon", new Lemon(0, 0, 0, 0));

            indexses.Add("0", player1Box1);
            indexses.Add("1", player1Box2);
            indexses.Add("2", player1Box3);
            indexses.Add("3", player1Box4);

            indexses.Add("4", player2Box1);
            indexses.Add("5", player2Box2);
            indexses.Add("6", player2Box3);
            indexses.Add("7", player2Box4);

            firstChooses = true;

            groupBox3.Visible = false;
            button1.Enabled = false;
            button2.Enabled = false;

        //  this.Width = this.BackgroundImage.Width;
        //   this.Height = this.BackgroundImage.Height;

        }

        void setButtonVisibleIfReady()
        {
            if (firstChooses)
            {
                
                for (int i = 0; i < 4; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    //MessageBox.Show("")
                    if (pc.Image == null )
                    {
                        button1.Enabled = false;
                        return;
                    }
                }
                button1.Enabled = true;
            }
            else
            {
                for (int i = 4; i < 8; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    //MessageBox.Show("")
                    if (pc.Image == null)
                    {
                        button2.Enabled = false;
                        return;
                    }
                }
                button2.Enabled = true;
            }
        }

        private void orangeMenu_Click(object sender, EventArgs e)
        {
            if(firstChooses)
            {
                
                for(int i=0; i<4; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    //MessageBox.Show("")
                    if(pc.Image == null && orangeMenu.Image != null)
                    {
                        pc.Image = orangeMenu.Image;
                        pc.Image.Tag = "orange";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        orangeMenu.Image = null;
                        break;
                    }
                }

            } else
            {
                for (int i = 4; i < 8; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && orangeMenu.Image != null)
                    {
                        pc.Image = orangeMenu.Image;
                        pc.Image.Tag = "orange";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        orangeMenu.Image = null;
                        break;
                    }
                }
            }

            setButtonVisibleIfReady();

        }

        private void watermelonMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                for (int i = 0; i < 4; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && watermelonMenu.Image != null)
                    {
                        pc.Image = watermelonMenu.Image;
                        pc.Image.Tag = "watermelon";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        watermelonMenu.Image = null;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 4; i < 8; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && watermelonMenu.Image != null)
                    {
                        pc.Image = watermelonMenu.Image;
                        pc.Image.Tag = "watermelon";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        watermelonMenu.Image = null;
                        break;
                    }
                }
            }
            setButtonVisibleIfReady();
        }

        private void plumMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                for (int i = 0; i < 4; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && plumMenu.Image != null)
                    {
                        pc.Image = plumMenu.Image;
                        pc.Image.Tag = "plum";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        plumMenu.Image = null;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 4; i < 8; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && plumMenu.Image != null)
                    {
                        pc.Image = plumMenu.Image;
                        pc.Image.Tag = "plum";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        plumMenu.Image = null;
                        break;
                    }
                }
            }
            setButtonVisibleIfReady();
        }

        private void lemonMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                for (int i = 0; i < 4; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && lemonMenu.Image != null)
                    {
                        pc.Image = lemonMenu.Image;
                        pc.Image.Tag = "lemon";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        lemonMenu.Image = null;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 4; i < 8; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && lemonMenu.Image != null)
                    {
                        pc.Image = lemonMenu.Image;
                        pc.Image.Tag = "lemon";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        lemonMenu.Image = null;
                        break;
                    }
                }
            }
            setButtonVisibleIfReady();
        }

        private void appleMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                for (int i = 0; i < 4; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && appleMenu.Image != null)
                    {
                        pc.Image = appleMenu.Image;
                        pc.Image.Tag = "apple";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        appleMenu.Image = null;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 4; i < 8; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && appleMenu.Image != null)
                    {
                        pc.Image = appleMenu.Image;
                        pc.Image.Tag = "apple";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        appleMenu.Image = null;
                        break;
                    }
                }
            }
            setButtonVisibleIfReady();
        }

        private void peachMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                for (int i = 0; i < 4; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && peachMenu.Image != null)
                    {
                        pc.Image = peachMenu.Image;
                        pc.Image.Tag = "peach";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        peachMenu.Image = null;
                        break;
                    }
                }
            }
            else
            {
                for (int i = 4; i < 8; i++)
                {
                    PictureBox pc = indexses[i.ToString()];
                    if (pc.Image == null && peachMenu.Image != null)
                    {
                        pc.Image = peachMenu.Image;
                        pc.Image.Tag = "peach";
                        pc.SizeMode = PictureBoxSizeMode.StretchImage;
                        peachMenu.Image = null;
                        break;
                    }
                }
            }
            setButtonVisibleIfReady();
        }

        private void resetFruit(PictureBox playerBox)
        {
            if(playerBox.Image != null)
            {
               // MessageBox.Show(playerBox.Image.Tag.ToString());
                PictureBox fruitBox = fruitPosition[playerBox.Image.Tag.ToString()];
                fruitBox.Image = playerBox.Image;
                playerBox.Image = null;
            }
            setButtonVisibleIfReady();
        }

        private void player1Box1_Click(object sender, EventArgs e)
        {
            resetFruit(player1Box1);
        }

        private void player1Box2_Click(object sender, EventArgs e)
        {
            resetFruit(player1Box2);
        }

        private void player1Box3_Click(object sender, EventArgs e)
        {
            resetFruit(player1Box3);
        }

        private void player1Box4_Click(object sender, EventArgs e)
        {
            resetFruit(player1Box4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                PictureBox pc = indexses[i.ToString()];
                player1Comb.Add(fruits[pc.Image.Tag.ToString()]);
            }
            groupBox1.Visible = false;
            groupBox3.Visible = true;
            firstChooses = false;
            orangeMenu.Image = Properties.Resources.orange;
            plumMenu.Image = Properties.Resources.plum;
            peachMenu.Image = Properties.Resources.peach;
            appleMenu.Image = Properties.Resources.apple;
            lemonMenu.Image = Properties.Resources.lemon;
            watermelonMenu.Image = Properties.Resources.watermelon;

        }

        private void player2Box1_Click(object sender, EventArgs e)
        {
            resetFruit(player2Box1);
        }

        private void player2Box2_Click(object sender, EventArgs e)
        {
            resetFruit(player2Box2);
        }

        private void player2Box3_Click(object sender, EventArgs e)
        {
            resetFruit(player2Box3);
        }

        private void player2Box4_Click(object sender, EventArgs e)
        {
            resetFruit(player2Box4);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 4; i < 8; i++)
            {
                PictureBox pc = indexses[i.ToString()];
                player2Comb.Add(fruits[pc.Image.Tag.ToString()]);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }


}

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
        public ChoosingCombinations(String name1, String name2)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
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
            player2Info.Text = player2Info.Text.Replace("Player1", name1);
            player1Info.Text = player1Info.Text.Replace("Player2", name2);

            player1Info.Text  = player1Info.Text.Replace("Player1", name1);
            player2Info.Text = player2Info.Text.Replace("Player2", name2);
            groupBox1.Text = name1 + " sets the combination for " + name2 + " to guess";
            groupBox3.Text = name2 + " sets the combination for " + name1 + " to guess";
        }

        public void setButtonVisibleIfReady()
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
                    if (pc.Image == null)
                    {
                        button2.Enabled = false;
                        return;
                    }
                }
                button2.Enabled = true;
            }
        }

        public void addFruitInCombination(int startIndex, int endIndex, PictureBox menu, String tag)
        {
            for (int i = startIndex; i < endIndex; i++)
            {
                PictureBox pc = indexses[i.ToString()];
                if (pc.Image == null && menu.Image != null)
                {
                    pc.Image = menu.Image;
                    pc.Image.Tag = tag;
                    pc.SizeMode = PictureBoxSizeMode.StretchImage;
                    menu.Image = null;
                    break;
                }
            }

            setButtonVisibleIfReady();
        }

        private void orangeMenu_Click(object sender, EventArgs e)
        {
            if(firstChooses)
            {
                addFruitInCombination(0, 4, orangeMenu, "orange");
            } else
            {
                addFruitInCombination(4, 8, orangeMenu, "orange");
            }

        }

        private void watermelonMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                addFruitInCombination(0, 4, watermelonMenu, "watermelon");
            }
            else
            {
                addFruitInCombination(4, 8, watermelonMenu, "watermelon");
            }
            
        }

        private void plumMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                addFruitInCombination(0, 4, plumMenu, "plum");
            }
            else
            {
                addFruitInCombination(4, 8, plumMenu, "plum");
            }
        }

        private void lemonMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                addFruitInCombination(0, 4, lemonMenu, "lemon");
            }
            else
            {
                addFruitInCombination(4, 8, lemonMenu, "lemon");
            }
        }

        private void appleMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                addFruitInCombination(0, 4, appleMenu, "apple");
            }
            else
            {
                addFruitInCombination(4, 8, appleMenu, "apple");
            }
        }

        private void peachMenu_Click(object sender, EventArgs e)
        {
            if (firstChooses)
            {
                addFruitInCombination(0, 4, peachMenu, "peach");
            }
            else
            {
                addFruitInCombination(4, 8, peachMenu, "peach");
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                PictureBox pc = indexses[i.ToString()];
                player2Comb.Add(fruits[pc.Image.Tag.ToString()]);
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
            player1Info.Visible = false;
            player2Info.Visible = true;
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 4; i < 8; i++)
            {
                PictureBox pc = indexses[i.ToString()];
                player1Comb.Add(fruits[pc.Image.Tag.ToString()]);
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }


}

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
    public partial class RevealingCombinations : Form
    {
        public List<Fruit> player1Fruits { get; set; }
        public List<Fruit> player2Fruits { get; set; }
        public Dictionary<int, PictureBox> pictureBoxes { get; set; }

        public RevealingCombinations(Player p1, Player p2, String gameStatus)
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            player1Fruits = new List<Fruit>();
            player2Fruits = new List<Fruit>();
            pictureBoxes = new Dictionary<int, PictureBox>()
            {
                {0, pictureBox1 },
                {1, pictureBox2 },
                {2, pictureBox3 },
                {3, pictureBox4 },
                {4, pictureBox8 },
                {5, pictureBox7 },
                {6, pictureBox6 },
                {7, pictureBox5 }
            };
            this.label1.Text = gameStatus;
            groupBox1.Text = p1.name + " was guessing:";
            groupBox2.Text = p2.name + " was guessing:";
            int counter = 0;
            foreach (Fruit f in p1.combination)
            {
                player1Fruits.Add(f);
                pictureBoxes[counter].Image = f.globalFruitImage;
                counter++;
            }
            foreach (Fruit f in p2.combination)
            {
                player2Fruits.Add(f);
                pictureBoxes[counter].Image = f.globalFruitImage;
                counter++;
            }
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

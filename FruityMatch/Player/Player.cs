using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruityMatch
{
    public class Player
    {
        public bool turn { get; set; }
        public LittlePlates littlePlates {get; set; }
        public NapkinCollection napkins { get; set; }
        public bool isComputer { get; set; }
        public List<Fruit> combination;
        public Random rand { get; set; }
        public String previousGuess { get; set; }
        public AutomaticGame autoplay { get; set; }
        public String name { get; set; }
        public Player (bool turn, int playerID, List<Fruit> combination, String name)
        {
            this.combination = combination;
            this.turn = turn;
            this.isComputer = false;

            littlePlates = new LittlePlates(playerID);
            napkins = new NapkinCollection(playerID);
            rand = new Random();
            autoplay = new AutomaticGame();
            autoplay.setCombination(combination);
            this.name = name;
        }

        public void Draw(Graphics g)
        {
            //if (turn)
            //{
                littlePlates.Draw(g, turn);
            //}
            napkins.Draw(g);
        }

        public LittlePlate getPlate(int x, int y)
        {
            return littlePlates.getIfCollision(x, y);
        }

        public void incrementActiveRow()
        {
            this.littlePlates.activeRow++;
            this.napkins.activeRow++;
        }
        public void changeCanBeDrawn()
        {
            littlePlates.changeCanBeDrawn();
        }

        public List<LittlePlate> getCurrentPlates()
        {
            return littlePlates.plates[littlePlates.activeRow];
        }

        public Napkin getCurrentNapkin()
        {
            return napkins.napkins[napkins.activeRow];
        }
        

    }
}

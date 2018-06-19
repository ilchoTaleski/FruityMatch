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
        public AutomaticGame autoPlay { get; set; }
        public Random rand { get; set; }
        public Player (bool turn, int playerID, List<Fruit> combination)
        {
            this.combination = combination;
            this.turn = turn;
            this.isComputer = false;
            autoPlay = new AutomaticGame();
            autoPlay.addCombination(combination);

            littlePlates = new LittlePlates(playerID);
            napkins = new NapkinCollection(playerID);
            rand = new Random();
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

        public void guessCombination2_2()
        {
            if (this.littlePlates.activeRow == 0)
            {
                List<LittlePlate> firstRow = littlePlates.plates[0];
                int counter = 0;
                foreach (LittlePlate lp in firstRow)
                {
                    Fruit fruit = null;
                    int pos = rand.Next(0, 6);
                    switch (counter)
                    {
                        case 0:
                        case 1:
                            fruit = new Orange(35, 35, 0, 0); break;
                        case 2:
                        case 3:
                            fruit = new Watermelon(35, 35, 0, 0); break;
                    }
                    counter++;
                    fruit.MoveTo(lp.position.X, lp.position.Y);
                    lp.fruitOn = fruit;
                    //Thread.Sleep(500);
                }
            }
        }

        public void guessFruits()
        {
            autoPlay.guessCombination2_2(this.littlePlates);
            return;
            Dictionary<int, Fruit> combinationMap = new Dictionary<int, Fruit>
            {
                {0, this.combination[0] },
                {1, this.combination[1] },
                {2, this.combination[2] },
                {3, this.combination[3] }
            };
            Dictionary<int, Fruit> randomFruit = new Dictionary<int, Fruit>
            {
                {0, new Orange(35,35, 0,0) },
                {1, new Watermelon(35,35, 0,0) },
                {2, new Plum(35,35, 0,0) },
                {3, new Lemon(35,35, 0,0) },
                {4, new Apple(35,35, 0,0) },
                {5, new Peach(35,35, 0,0) }
            };
            if(this.littlePlates.activeRow == 0)
            {
                List<LittlePlate> firstRow = littlePlates.plates[0];
                foreach(LittlePlate lp in firstRow)
                {
                    Fruit fruit = null;
                    int pos = rand.Next(0,6);
                    switch (pos)
                    {
                        case 0: fruit = new Orange(35, 35, 0, 0); break;
                        case 1: fruit = new Watermelon(35, 35, 0, 0); break;
                        case 2: fruit = new Plum(35, 35, 0, 0); break;
                        case 3: fruit = new Lemon(35, 35, 0, 0); break;
                        case 4: fruit = new Apple(35, 35, 0, 0); break;
                        case 5: fruit = new Peach(35, 35, 0, 0); break;
                    }
                    fruit.MoveTo(lp.position.X, lp.position.Y);
                    lp.fruitOn = fruit;
                    //Thread.Sleep(500);
                }
            }
        }

    }
}

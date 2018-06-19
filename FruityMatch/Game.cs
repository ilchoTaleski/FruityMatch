using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class Game
    {
        public Fruit selectedFruit { get; set; }
        public FruitsDocument doc { get; set; }
        public Player player1 { get; set; }
        public Player player2 { get; set; }
        public Game(List<Fruit> player1, List<Fruit> player2)
        {
            doc = new FruitsDocument();
            List<Fruit> fruits = new List<Fruit>();
            fruits.Add(new Orange(5, 5, 5, 5));
            fruits.Add(new Plum(5, 5, 5, 5));
            fruits.Add(new Peach(5, 5, 5, 5));
            fruits.Add(new Watermelon(5, 5, 5, 5));
            selectedFruit = null;

            this.player1 = new Player(true, 0, player1);
            this.player2 = new Player(false, 1, player2);
            //this.player2.isComputer = true;
        }

        public Player getActivePlayer()
        {
            if (player1.turn) return player1;
            return player2;
        }

        public void Draw(Graphics g)
        {
            player1.Draw(g);
            player2.Draw(g);
            doc.Draw(g);
        }

        public void changeTurns()
        {
            player1.turn = !player1.turn;
            player2.turn = !player2.turn;
        }

        public LittlePlate getPlate(int x, int y)
        {
            return getActivePlayer().getPlate(x, y);
        }

        public int getActiveRow()
        {
            return getActivePlayer().littlePlates.activeRow;
        }

        public void incrementActiveRow()
        {
            getActivePlayer().incrementActiveRow();
            changeCanBeDrawn();
        }

        public Napkin getNapkin(int x, int y)
        {
            return getActivePlayer().napkins.getNapkinCollision(x, y, getActivePlayer().littlePlates.activeRow);
        }

        public String matchingCombination()
        {
            if (!getActivePlayer().littlePlates.checkAllMatch())
            {
                return null;
            }
            else
            {
                return getActivePlayer().littlePlates.Match(getActivePlayer().combination);
            }
        }

        public void changeCanBeDrawn()
        {
            getActivePlayer().changeCanBeDrawn();
        }
    }
}

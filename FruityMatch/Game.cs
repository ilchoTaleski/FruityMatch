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
        public String name1 { get; set; }
        public String name2 { get; set; }
        public User firstUser { get; set; }
        public User secondUser { get; set; }
        public int mode { get; set; }
        public Game(List<Fruit> player1, List<Fruit> player2, String player1Name, String player2Name, bool isComputer)
        {
            doc = new FruitsDocument();
            List<Fruit> fruits = new List<Fruit>();
            fruits.Add(new Orange(5, 5, 5, 5));
            fruits.Add(new Plum(5, 5, 5, 5));
            fruits.Add(new Peach(5, 5, 5, 5));
            fruits.Add(new Watermelon(5, 5, 5, 5));
            selectedFruit = null;

            mode = 1;

            name1 = player1Name;
            name2 = player2Name;
            this.player1 = new Player(true, 0, player1, name1);
            this.player2 = new Player(false, 1, player2, name2);
            this.player2.isComputer = isComputer;

        }

        public void setUsers(User first, User second)
        {
            firstUser = first;
            secondUser = second;
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
                getActivePlayer().previousGuess = getActivePlayer().littlePlates.Match(getActivePlayer().combination);
                return getActivePlayer().previousGuess;
            }
        }

        public void changeCanBeDrawn()
        {
            getActivePlayer().changeCanBeDrawn();
        }
        
        public List<LittlePlate> getCurrentPlates()
        {
            if (getActiveRow() < 10)
            {
                return getActivePlayer().littlePlates.plates[getActiveRow()];
            }
            return null;
        }

        public LittlePlate getNextActiveLittlePlate()
        {
            List<LittlePlate> temp = getCurrentPlates();
            if (temp != null)
            {
                foreach (LittlePlate lp in temp)
                {
                    if (lp.fruitOn == null)
                    {
                        return lp;
                    }
                }
            }
            return null;
        }

        public String gameStatus()
        {
            if (getActivePlayer() == player2)
            {
                if ((player1.previousGuess == "40" && player2.previousGuess == "40") || getActiveRow() +1 >= 10)
                {
                    firstUser.ties++;
                    secondUser.ties++;
                    firstUser.points += 5;
                    secondUser.points += 5;
                    return "It's a tie";
                    

                }
                else if (player1.previousGuess == "40")
                {
                    firstUser.wins++;
                    secondUser.losses++;
                    firstUser.points += 10;
                    return name1 + " wins";
                }
                else if (player2.previousGuess == "40")
                {
                    secondUser.wins++;
                    firstUser.losses++;
                    secondUser.points += 10;
                    return name2+ " wins";
                }
                else
                {
                    return "continue";
                }
            }
            return "continue";
        }

    }
}

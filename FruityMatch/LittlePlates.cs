using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class LittlePlates
    {
        public List<List<LittlePlate>> plates { get; set; }
        public int activeRow { get; set; }
        public int playerID { get; set; }
        public LittlePlates(int playerID)
        {
            plates = new List<List<LittlePlate>>();
            activeRow = 0;
            this.playerID = playerID;
            instantiateList();
        }

        public void instantiateList()
        {
            int x=0, y=0;
            if (playerID == 0)
            {
                x = 257;
               
            }else
            {
                x = 595;
               
            }
            y = 215;
            int dx = 41;
            int dy = 47;

            for (int i = 0; i < 10; i++)
            {
                List<LittlePlate> rowPlates = new List<LittlePlate>();
                for (int j = 0; j < 4; j++)
                {
                    LittlePlate littlePlate = new LittlePlate(x + j * dx, y + i * dy, i);
                    if (i == 0 )
                    {
                        littlePlate.canBeDrawn = true;
                    }
                    rowPlates.Add(littlePlate);

                }
                plates.Add(rowPlates);
            }
        }

        public void Draw (Graphics g, bool turn)
        {

            foreach(List<LittlePlate> list in plates)
            {
                foreach(LittlePlate l in list)
                {
                    l.Draw(g, turn);
                }
            }
        }

        public LittlePlate getIfCollision(int x, int y)
        {
           // for(int i=0; i<=activeRow; i++)
//{
                foreach (LittlePlate lp in plates[activeRow])
                {
                    if (lp.checkCollision(x, y))
                    {
                        return lp;
                    }
                }
     //       }
            
            return null;
        }

        public bool checkAllMatch()
        {
            List<LittlePlate> littlePlates = plates[activeRow];
            foreach(LittlePlate plate in littlePlates)
            {
                if(plate.fruitOn == null)
                {
                    return false;
                }
            }
            return true;
        }

        public String Match (List<Fruit> playerFruits)
        {
            if (checkAllMatch())
            {
                int counterPlaces = 0, counterFruitsOnly = 0;
                List<Fruit> copy = new List<Fruit>();

                List<LittlePlate> littlePlates = plates[activeRow];

                foreach (Fruit f in playerFruits)
                {
                    copy.Add(f);
                }
                for (int i = 0; i<4; i++)
                {
                    Fruit f1 = copy.ElementAt(i);
                    Fruit f2 = littlePlates.ElementAt(i).fruitOn;

                    if(f1.type == f2.type)
                    {
                        counterPlaces++;
                    }
                }

                for (int i = 0; i<4; i++)
                {
                    Fruit f2 = littlePlates.ElementAt(i).fruitOn;
                    
                    for (int j = 0; j<copy.Count; j++)
                    {
                        Fruit f1 = copy.ElementAt(j);
                        if (f1.type == f2.type)
                        {
                            counterFruitsOnly++;
                            copy.RemoveAt(j);
                            break;
                        }
                    }
                }
                counterFruitsOnly = counterFruitsOnly - counterPlaces;
                return counterPlaces.ToString() + counterFruitsOnly.ToString();
            }
            return null;
        }
        public void changeCanBeDrawn()
        {
            List<LittlePlate> littlePlates = plates[activeRow];
            foreach (LittlePlate l in littlePlates)
            {
                l.canBeDrawn = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruityMatch
{
    public class FruitsDocument
    {
        List<FruitCollection> allFruits { get; set; }
        public FruitsDocument()
        {
            allFruits = new List<FruitCollection>();
            List<Rectangle> plates = new List<Rectangle>();
            int x = Form1.getRatioX(70) ;
            int y = Form1.getRatioY(70);
            int width = Form1.getRatioX(80);
            int height = Form1.getRatioY(80);
            int diff = Form1.getRatioY(160);
            //MessageBox.Show(Form1.ratioY.ToString() + " " + Form1.ratioX);
            for(int i=0; i<6; i++)
            {
                if(i == 3)
                {
                    x = Form1.getRatioX(820); ;
                }
                if(i % 3 == 2)
                {
                    diff = Form1.getRatioY(150); ;
                } else
                {
                    diff = Form1.getRatioY(160); ;
                }
                Rectangle rec = new Rectangle(x, y + diff * (i % 3) + height * (i % 3), width, height);
                plates.Add(rec);
            }

            OrangeCollection oranges = new OrangeCollection(plates[0]);
            allFruits.Add(oranges);
            WatermelonCollection watermelons = new WatermelonCollection(plates[1]);
            allFruits.Add(watermelons);
            PlumCollection plums = new PlumCollection(plates[2]);
            allFruits.Add(plums);
            LemonCollection lemons = new LemonCollection(plates[3]);
            allFruits.Add(lemons);
            AppleCollection apples = new AppleCollection(plates[4]);
            allFruits.Add(apples);
            PeachCollection peaches = new PeachCollection(plates[5]);
            allFruits.Add(peaches);

        }

        public void Draw(Graphics g)
        {
            foreach(FruitCollection f in allFruits)
            {
                f.Draw(g);
            }
        }

        public Fruit fruitIfHit(int x, int y)
        {
            foreach(FruitCollection f in allFruits)
            {
                if(f.fruitIfHit(x, y) != null)
                {
                    return f.fruitIfHit(x, y);
                }
            }
            return null;
        }
        public FruitCollection getFruitCollection(Fruit.TYPE type)
        {
            switch (type)
            {
                case Fruit.TYPE.ORANGE:
                    return allFruits[0];
                case Fruit.TYPE.WATERMELON:
                    return allFruits[1];
                case Fruit.TYPE.PLUM:
                    return allFruits[2];
                case Fruit.TYPE.LEMON:
                    return allFruits[3];
                case Fruit.TYPE.APPLE:
                    return allFruits[4];
                case Fruit.TYPE.PEACH:
                    return allFruits[5];
                default:
                    return null;
            }
        }
    }
}

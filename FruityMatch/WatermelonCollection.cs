using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class WatermelonCollection:FruitCollection
    {
        Random rand;
        public WatermelonCollection(Rectangle rectangle) : base(rectangle)
        {
            rand = new Random();
            InitializeFruits();
        }

        public override void InitializeFruits()
        {
            for (int i = 0; i < 30; i++)
            {
                fruits.AddLast(createWatermelon());
            }
        }

        override
        public void AddFruitFirst()
        {
            Watermelon watermelon = createWatermelon();
            fruits.AddFirst(watermelon);

        }
        override
        public void AddFruitLast()
        {
            Watermelon watermelon = createWatermelon();
            fruits.AddLast(watermelon);

        }
        private Watermelon createWatermelon()
        {

            int width = rectangle.Width;
            int x = rand.Next(rectangle.X, rectangle.X + width);
            int height = rectangle.Height;
            int y = rand.Next(rectangle.Y, rectangle.Y + height);
            return new Watermelon(35, 35, x, y);
        }
    }
}


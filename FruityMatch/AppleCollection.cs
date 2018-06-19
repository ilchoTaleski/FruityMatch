using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class AppleCollection : FruitCollection
    {
        Random rand;
        public AppleCollection(Rectangle rectangle) : base(rectangle)
        {
            rand = new Random();
            InitializeFruits();
        }

        public override void InitializeFruits()
        {
            for (int i = 0; i < 30; i++)
            {
                fruits.AddLast(createApple());
            }
        }

        override
        public void AddFruitFirst()
        {
            Apple apple = createApple();
            fruits.AddFirst(apple);

        }
        override
        public void AddFruitLast()
        {
            Apple apple = createApple();
            fruits.AddLast(apple);

        }
        private Apple createApple()
        {

            int width = rectangle.Width;
            int x = rand.Next(rectangle.X, rectangle.X + width);
            int height = rectangle.Height;
            int y = rand.Next(rectangle.Y, rectangle.Y + height);
            return new Apple(35, 35, x, y);
        }
    }
}

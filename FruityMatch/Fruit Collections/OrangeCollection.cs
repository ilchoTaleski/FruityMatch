using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class OrangeCollection : FruitCollection
    {
        Random rand;
        public OrangeCollection(Rectangle rectangle):base(rectangle)
        {
            rand = new Random();
            InitializeFruits();
        }

        public override void InitializeFruits()
        {
            for (int i = 0; i<30; i++)
            {
                fruits.AddLast(createOrange());
            }
        }

        override
        public void AddFruitFirst()
        {
            Orange orange = createOrange();
            fruits.AddFirst(orange);
            
        }
        override
        public void AddFruitLast()
        {
            Orange orange = createOrange();
            fruits.AddLast(orange);

        }
        private Orange createOrange()
        {
            
            int width = rectangle.Width;
            int x = rand.Next(rectangle.X, rectangle.X + width);
            int height = rectangle.Height;
            int y = rand.Next(rectangle.Y, rectangle.Y + height);
            return new Orange(35, 35, x, y);
        }
    }
}

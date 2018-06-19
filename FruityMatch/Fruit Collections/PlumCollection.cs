using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class PlumCollection : FruitCollection
    {
        Random rand;
        public PlumCollection(Rectangle rectangle) : base(rectangle)
        {
            rand = new Random();
            InitializeFruits();
        }

        public override void InitializeFruits()
        {
            for (int i = 0; i < 30; i++)
            {
                fruits.AddLast(createPlum());
            }
        }

        override
        public void AddFruitFirst()
        {
            Plum plum = createPlum();
            fruits.AddFirst(plum);

        }
        override
       public void AddFruitLast()
        {
            Plum plum = createPlum();
            fruits.AddLast(plum);

        }
        private Plum createPlum()
        {

            int width = rectangle.Width;
            int x = rand.Next(rectangle.X, rectangle.X + width);
            int height = rectangle.Height;
            int y = rand.Next(rectangle.Y, rectangle.Y + height);
            return new Plum(35, 35, x, y);
        }
    }
}

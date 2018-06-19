using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class PeachCollection : FruitCollection

    {
        Random rand;
        public PeachCollection(Rectangle rectangle) : base(rectangle)
        {
            rand = new Random();
            InitializeFruits();
        }

        public override void InitializeFruits()
        {
            for (int i = 0; i < 30; i++)
            {
                fruits.AddLast(createPeach());
            }
        }

        override
        public void AddFruitFirst()
        {
            Peach peach = createPeach();
            fruits.AddFirst(peach);

        }
        override
        public void AddFruitLast()
        {
            Peach peach = createPeach();
            fruits.AddLast(peach);

        }
        private Peach createPeach()
        {

            int width = rectangle.Width;
            int x = rand.Next(rectangle.X, rectangle.X + width);
            int height = rectangle.Height;
            int y = rand.Next(rectangle.Y, rectangle.Y + height);
            return new Peach(35, 35, x, y);
        }
    }
}

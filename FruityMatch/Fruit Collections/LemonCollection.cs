using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class LemonCollection : FruitCollection
    {
        Random rand;
        public LemonCollection(Rectangle rectangle) : base(rectangle)
        {
            rand = new Random();
            InitializeFruits();
        }

        public override void InitializeFruits()
        {
            for (int i = 0; i < 30; i++)
            {
                fruits.AddLast(createLemon());
            }
        }

        override
        public void AddFruitFirst()
        {
            Lemon lemon = createLemon();
            fruits.AddFirst(lemon);

        }
        override
        public void AddFruitLast()
        {
            Lemon lemon = createLemon();
            fruits.AddLast(lemon);

        }
        private Lemon createLemon()
        {

            int width = rectangle.Width;
            int x = rand.Next(rectangle.X, rectangle.X + width);
            int height = rectangle.Height;
            int y = rand.Next(rectangle.Y, rectangle.Y + height);
            return new Lemon(35, 35, x, y);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public abstract class FruitCollection
    {
        public LinkedList<Fruit> fruits { get; set; }
        public Rectangle rectangle { get; set; }
        public enum type
        {
            ORANGE,
            WATERMELON,

        }
        public FruitCollection (Rectangle rectangle)
        {
            fruits = new LinkedList<Fruit>();
            
            this.rectangle = rectangle;
        }
        public abstract void InitializeFruits();
        public void Draw(Graphics g)
        {
            foreach (Fruit fruit in fruits)
            {
                fruit.Draw(g);
            }
        }
        public Fruit fruitIfHit(int x, int y)
        {
            for (int i = fruits.Count - 1; i >= 0; i--)
            {
                if (fruits.ElementAt(i).isHit(x, y))
                {
                    return fruits.ElementAt(i);
                }
            }
            return null;
        }

        public abstract void AddFruitFirst();
        public abstract void AddFruitLast();

    }
}

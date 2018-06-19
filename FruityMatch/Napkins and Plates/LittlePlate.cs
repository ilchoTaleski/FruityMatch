using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class LittlePlate
    {
        public static readonly int Radius = 15;
        public Point position { get; set; }
        public bool canBeDrawn { get; set; }
        public Fruit fruitOn { get; set; }
        public int row { get; set; }
        public LittlePlate(int x, int y, int row)
        {
            this.position = new Point(x, y);
            fruitOn = null;
            canBeDrawn = false;
            this.row = row;
        }
        public bool checkCollision(int x, int y)
        {
            double distance = Math.Sqrt((position.X - x) * (position.X - x) + (position.Y - y) * (position.Y - y));
            return distance <= Radius;
        }
        public void Draw(Graphics g, bool turn)
        {
            if (canBeDrawn && fruitOn == null && turn)
            {
                g.DrawEllipse(new Pen(Color.Red, 2), this.position.X - Radius, this.position.Y - Radius, 2 * Radius, 2 * Radius);
            }
            if(fruitOn != null)
            {
                fruitOn.Draw(g);
            }
        }


    }
}

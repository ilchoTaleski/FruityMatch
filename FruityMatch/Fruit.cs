using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FruityMatch
{
    public abstract class  Fruit
    {
        public enum TYPE
        {
            ORANGE,
            WATERMELON,
            APPLE,
            PEACH,
            PLUM,
            LEMON
        }
        public TYPE type;
        public int Width { get; set; }
        public int Height { get; set; }
        public Point position { get; set; }
        public Fruit(int width, int height, int x, int y)
        { 
            this.Width = width;
            this.Height = height;
            this.position = new Point(x, y);
        }

        public abstract void Draw(Graphics g);

        public void MoveTo(int x, int y)
        {
            this.position = new Point(x, y);
        }
        public bool isHit(int x, int y)
        {
            double distance = Math.Sqrt((position.X - x) * (position.X - x)
                + (position.Y - y) * (position.Y - y));
            //MessageBox.Show(Width.ToString());
            return distance <= (Width/2);
        }

    }
}

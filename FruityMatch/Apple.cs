using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class Apple : Fruit
    {
        public Image applePicture { get; set; }

        public Apple(int width, int height, int x, int y) :
            base(width, height, x, y)
        {
            type = TYPE.APPLE;
            this.applePicture = Properties.Resources.apple;
        }
        override
        public void Draw(Graphics g)
        {
            g.DrawImage(applePicture, this.position.X - (Width/2), this.position.Y - (Height/2), this.Width, this.Height);
        }
    }
}

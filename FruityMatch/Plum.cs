using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class Plum : Fruit
    {
        public Image plumPicture { get; set; }
       
        public Plum(int width, int height, int x, int y) :
            base(width, height, x, y)
        {
            type = TYPE.PLUM;
            this.plumPicture = Properties.Resources.plum;

        }
        override
        public void Draw(Graphics g)
        {
            g.DrawImage(plumPicture, this.position.X - (Width/2), this.position.Y - (Height/2), this.Width, this.Height);
        }
    }
}

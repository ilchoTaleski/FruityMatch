using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class Watermelon:Fruit
    {
        public Image watermelonPicture { get; set; }
        
        public Watermelon(int width, int height, int x, int y) :
            base(width, height, x, y)
        {
            type = TYPE.WATERMELON;
            watermelonPicture = Properties.Resources.watermelon;
        }
        override
        public void Draw(Graphics g)
        {
            g.DrawImage(watermelonPicture, this.position.X - (Width/2), this.position.Y - (Height/2),
                this.Width, this.Height);
        }
    }
}

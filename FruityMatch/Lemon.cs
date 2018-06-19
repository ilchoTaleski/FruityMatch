using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class Lemon:Fruit
    {
        public Image lemonPicture { get; set; }
        
        public Lemon(int width, int height, int x, int y) :
            base(width, height, x, y)
        {
            lemonPicture = Properties.Resources.lemon;
            type = TYPE.LEMON;
        }
        override
        public void Draw(Graphics g)
        {
            g.DrawImage(lemonPicture, this.position.X - (Width/2), this.position.Y - (Height/2),
                this.Width, this.Height);
            
        }
    }
}

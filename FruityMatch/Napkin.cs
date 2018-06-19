using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class Napkin
    {
        public int Row { get; set; }
        public Image napkin { get; set; }
        public Point position { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public static readonly Dictionary<String, Image> napkinDic = new Dictionary<string, Image> {
            {"00", Properties.Resources.salfetki_00 },
            {"01", Properties.Resources.salfetki_01 },
            {"02", Properties.Resources.salfetki_02 },
            {"03", Properties.Resources.salfetki_03 },
            {"04", Properties.Resources.salfetki_04 },
            {"10", Properties.Resources.salfetki_10 },
            {"11", Properties.Resources.salfetki_11 },
            {"12", Properties.Resources.salfetki_12 },
            {"13", Properties.Resources.salfetki_13 },
            {"20", Properties.Resources.salfetki_20 },
            {"21", Properties.Resources.salfetki_21 },
            {"22", Properties.Resources.salfetki_22 },
            {"30", Properties.Resources.salfetki_30 },
            {"40", Properties.Resources.salfetki_40 },
            {"hover", Properties.Resources.salfetki_match}
        };

        public Napkin (int row, string napkin,
            int x, int y, int width, int height)
        {
            this.Row = row;
            this.napkin = napkinDic[napkin];
            this.position = new Point(x, y);
            this.Width = width;
            this.Height = height;
        }

        public void changeNapkin(string napkin)
        {
            this.napkin = napkinDic[napkin];
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(this.napkin, this.position.X - Width / 2,
                this.position.Y - Height / 2, this.Width, this.Height);
        }

        public bool isCollision(int x, int y)
        {
            double distance = Math.Sqrt((position.X - x) * (position.X - x) + (position.Y - y) * (position.Y - y));
            return (distance <= (this.Width / 2));
        }

    }
}

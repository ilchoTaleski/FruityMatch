using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    public class NapkinCollection
    {
        public List<Napkin> napkins { get; set; }
        public int activeRow { get; set; }
        public int playerID { get; set; }
        public NapkinCollection(int playerID)
        {
            napkins = new List<Napkin>();
            this.activeRow = 0;
            this.playerID = playerID;
            InitializeNapkins();
        }
        public void InitializeNapkins()
        {
            int x = 440;
            int y = 215;
            int difference = 47;
            if (playerID == 0)
            {
                x = 440;

            }
            else
            {
                x = 540;

            }
            for (int i = 0; i<10; i++)
            {
                Napkin napkin = new Napkin(i, "00", x, y + difference * (i % 10), 50, 50);
                napkins.Add(napkin);
            }
        }

        public void Draw(Graphics g)
        {
            foreach (Napkin n in napkins)
            {
                n.Draw(g);
            }
        }
        public Napkin getNapkinCollision(int x, int y, int activeRow)
        {
            foreach(Napkin n in napkins)
            {
                if (activeRow == n.Row) return n;
            }
            return null;
        }
    }
}

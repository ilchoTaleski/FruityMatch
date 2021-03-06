﻿using System;
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
            int x = Form1.getRatioX(440);
            int y = Form1.getRatioY(215);
            int difference = Form1.getRatioY(47);
            if (playerID == 0)
            {
                x = Form1.getRatioX(440);

            }
            else
            {
                x = Form1.getRatioX(540);

            }
            for (int i = 0; i<10; i++)
            {
                Napkin napkin = new Napkin(i, "00", x, y + difference * (i % 10), (int)Math.Round(50 * Form1.ratioX), (int)Math.Round(50 * Form1.ratioY));
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

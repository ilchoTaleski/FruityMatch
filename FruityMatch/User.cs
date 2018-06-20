using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    [Serializable]
    public class User
    {
        public String name { get; set; }
        public Image avatar { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public int points;
        public bool defaultUser { get; set; }
        public int uniqueID { get; set; }
        public User(String name, int ID)
        {
            this.name = name;
            avatar = Properties.Resources.default_avatar;
            wins = 0;
            losses = 0;
            ties = 0;
            points = 0;
            defaultUser = false;
            this.uniqueID = ID;
        }
        public void makeDefaultUser()
        {
            this.defaultUser = true;
        }

        public void increaseWins()
        {
            this.wins++;
        }

        public void increaseLosses()
        {
            this.losses++;
        }

        public void increaseTies()
        {
            this.ties++;
        }

        public Tuple<int,int,int> getStats()
        {
            return Tuple.Create(wins, losses, ties);
        }

        public void changeAvatar(Image img)
        {
            this.avatar = img;
        }

        public void changeName(String name)
        {
            this.name = name;
        }

        public bool isDefault()
        {
            return defaultUser;
        }
        override
        public string ToString()
        {
            return name;
        }
    }
}

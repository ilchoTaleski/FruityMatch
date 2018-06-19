using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityMatch
{
    [Serializable]
    public class UniqueIDGenerator
    {
        public int ID { get; set; }
        public UniqueIDGenerator()
        {
            ID = 0;
        }
        public int generateUniqueId()
        {
            return ++ID;
        }
    }
}

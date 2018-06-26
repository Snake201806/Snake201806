using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake201806.Model
{
    class Foods
    {
        public Foods()
        {
            //null object pattern
            FoodPositions = new List<ArenaPosition>();
        }

        public List<ArenaPosition> FoodPositions { get; set; }

        internal void Add(int row, int column)
        {
            FoodPositions.Add(new ArenaPosition(row, column));
        }
    }
}

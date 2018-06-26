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

        internal void Remove(int rowPosition, int columnPosition)
        {
            //az x a FoodPositions lista egy eleme
            //ez a sor akkor fut le, ha létezik pontosan egy elem, amire a feltétel igaz!
            //ha nincs ilyen, vagy több ilyen van, akkor a program elszáll.
            var foodToDelete = FoodPositions.Single(x => x.RowPosition == rowPosition
                                                    && x.ColumnPosition == columnPosition);


            FoodPositions.Remove(foodToDelete);
        }
    }
}

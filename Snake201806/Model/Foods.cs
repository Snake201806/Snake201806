using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake201806.Model
{
    class Foods
    {
        public Foods()
        {
            //null object pattern
            FoodPositions = new List<CanvasPosition>();
        }

        public List<CanvasPosition> FoodPositions { get; set; }

        internal void Add(int row, int column, UIElement paint)
        {
            FoodPositions.Add(new CanvasPosition(row, column, paint));
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

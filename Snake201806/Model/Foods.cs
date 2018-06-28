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

        /// <summary>
        /// Egy elem törlése az ételek közül
        /// </summary>
        /// <param name="rowPosition"></param>
        /// <param name="columnPosition"></param>
        /// <returns>azzal az étellel tér vissza, amit törölt</returns>
        internal CanvasPosition Remove(int rowPosition, int columnPosition)
        {
            //az x a FoodPositions lista egy eleme
            
            //a Single() akkor fut le, ha létezik pontosan egy elem, amire a feltétel igaz!
            //ha nincs ilyen, vagy több ilyen van, akkor a program elszáll.

            //a SingleOrDefault() akkor fut le, ha legfeljebb egy elem létezik, amire a feltétel igaz
            //ha nincs ilyen, akkor null értékkel tér vissza.
            //ha egy ilyen van, akkor azzal tér vissza
            //ha több ilyen ilyen van, akkor pedig kivétellel elszáll a programunk.
            var foodToDelete = FoodPositions.SingleOrDefault(x => x.RowPosition == rowPosition
                                                                    && x.ColumnPosition == columnPosition);

            FoodPositions.Remove(foodToDelete);
            return foodToDelete;
        }

    }
}

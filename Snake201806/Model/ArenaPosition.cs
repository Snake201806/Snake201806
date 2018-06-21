using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake201806.Model
{
    class ArenaPosition
    {
        public ArenaPosition(int rowPosition, int columnPosition)
        {
            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
        }

        public int RowPosition { get; set; }
        public int ColumnPosition { get; set; }
    }
}

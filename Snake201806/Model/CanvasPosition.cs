using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Snake201806.Model
{
    /// <summary>
    /// Leszármaztatjuk az ArenaPosition osztályból
    /// Ennek megfelelően minden tud, amit az ArenaPosition
    /// mi pedig képesek vagyunk továbbfejleszteni azt
    /// </summary>
    class CanvasPosition : ArenaPosition
    {
        private UIElement paint;

        public CanvasPosition(int rowPosition, int columnPosition, UIElement paint) 
            : base(rowPosition, columnPosition) //ezzel a háttérben lévő ősosztály példányosítása történik meg
        {
            this.paint = paint;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Snake201806.Model
{
    /// <summary>
    /// A játékmenet logikáját tartalmazza
    /// 
    /// Ez egy osztálydefiníció, ami leírja, hogy ha létrehozok egy példányt ebből az osztályból, 
    /// akkor hogyan is kell minden példánynak működnie.
    /// Ez olyan, mint egy tervrajz.
    /// </summary>
    class Arena
    {
        internal void KeyDown(KeyEventArgs e)
        {
            //a játék megkezdéséhez a négy nyílbillentyű valamelyikét kell leütni.
            switch (e.Key)
            {
                case Key.Left:
                case Key.Up:
                case Key.Right:
                case Key.Down:
                    Console.WriteLine(e.Key);
                    break;
            }
        }
    }
}

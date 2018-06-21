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
        private MainWindow View;
        private Snake snake;

        /// <summary>
        /// Konstruktorfüggvény, ő hozza létre az osztály egy-egy példányát.
        /// </summary>
        /// <param name="view">az ablak, ami létrehozta az Arena példányát</param>
        public Arena(MainWindow view)
        {
            //hivatkozva az osztálypéldányra, amiben vagyunk
            //így is el tudjuk érni az osztálypéldány osztályszintű változóját
            this.View = view;

            //A játék kezdetén megjelenítjük a játékszabályokat
            //Az osztályon belül a thid használata nem kötelező
            View.GamePlayBorder.Visibility = System.Windows.Visibility.Visible;

            snake = new Snake(10,10);

            //Kígyófej megjelenítése Circle ikonnal
            //A grid az általa tartalmazott elemeket egy gyűjteményen keresztül teszi elérhetővé
            //ez a gyűjtemény a Children
            //a gyűjtemény egy felsorolás, ahol az első elm a 0. indexő, a második az 1. indexű, és így tovább.
            //a 10. sor 10. elemét tehát így tudjuk elkérni a gyűjteménytől
            var cell = View.ArenaGrid.Children[10 * 20 + 10];
            //viszont ez egy általános IUElement típust ad vissza, bármi, ami belekerül a gridbe
            //ilyen elemként kerül bele
            var image = (FontAwesome.WPF.ImageAwesome)cell;

            //és már el tudom érni az ikon tulajdonságot
            image.Icon = FontAwesome.WPF.FontAwesomeIcon.Circle;

        }

        internal void KeyDown(KeyEventArgs e)
        {
            //a játék megkezdéséhez a négy nyílbillentyű valamelyikét kell leütni.
            switch (e.Key)
            {
                case Key.Left:
                case Key.Up:
                case Key.Right:
                case Key.Down:
                    //elindítjuk a játékot: eltüntetjük a játékszabályokat
                    View.GamePlayBorder.Visibility = System.Windows.Visibility.Hidden;
                    View.NumberOfMealsTextBlock.Visibility = System.Windows.Visibility.Visible;
                    View.ArenaGrid.Visibility = System.Windows.Visibility.Visible;

                    Console.WriteLine(e.Key);
                    break;
            }
        }
    }
}

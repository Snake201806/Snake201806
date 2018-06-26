using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

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
        private DispatcherTimer pendulum;
        private bool isStarted;
        private int RowCount;
        private int ColumnCount;

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

            pendulum = new DispatcherTimer(TimeSpan.FromMilliseconds(500),DispatcherPriority.Normal, 
                                            ItsTimeForDisplay, Application.Current.Dispatcher);

            isStarted = false;

            //Az aréna méreteinek beállítása
            //todo: az aréna méretezését átvenni a Windows Grid-ből.
            RowCount = 20;
            ColumnCount = 20;


        }

        private void ItsTimeForDisplay(object sender, EventArgs e)
        {

            if (!isStarted)
            { // ha nem indult el a játék, akkor ne csináljunk semmit
                return;
            }

            //meg kell jegyezni, hogy a kígyó feje hol van
            //ez egy rossz kód, mivel az eredeti példányra mutató kód referenciáját 
            //veszi át, így az eredeti példányra mutat. Ha azt változtatom, akkor ez is változik
            //var currentPosition = snake.HeadPosition;

            //új példányt hozunk létre, így elváasztjuk a jelenlegi példányra mutató referenciától
            var neck = new ArenaPosition(snake.HeadPosition.RowPosition, snake.HeadPosition.ColumnPosition);

            //ki kell számolni a következő pozíciót a fej iránya alapján
            switch (snake.HeadDirection)
            {
                case SnakeHeadDirectionEnum.Up:
                    snake.HeadPosition.RowPosition = snake.HeadPosition.RowPosition - 1;
                    break;
                case SnakeHeadDirectionEnum.Down:
                    snake.HeadPosition.RowPosition = snake.HeadPosition.RowPosition + 1;
                    break;
                case SnakeHeadDirectionEnum.Left:
                    snake.HeadPosition.ColumnPosition = snake.HeadPosition.ColumnPosition - 1;
                    break;
                case SnakeHeadDirectionEnum.Right:
                    snake.HeadPosition.ColumnPosition = snake.HeadPosition.ColumnPosition + 1;
                    break;
                case SnakeHeadDirectionEnum.InPlace:
                    break;
                default:
                    break;
            }

            //itt kéne tudni, hogy az új pozíció az vajon étel-e? vagy falnak mentünk-e?
            //falnak mentünk?
            if (snake.HeadPosition.RowPosition<0 || snake.HeadPosition.RowPosition>RowCount-1
                || snake.HeadPosition.ColumnPosition<0 || snake.HeadPosition.ColumnPosition>ColumnCount-1)
            { //falnak mentünk.
                EndOfGame();
                //mivel vége a játéknak, már nem csinálunk semmit.
                return;
            }

            ShowSnakeHead(snake.HeadPosition.RowPosition, snake.HeadPosition.ColumnPosition);

            //a kígyó fejébő nyak lesz, ennek megfelelően kell megjeleníteni
            ShowSnakeNeck(neck.RowPosition, neck.ColumnPosition);
            //viszont, a farok adataihoz a nyaknak hozzá kell adódnia.
            snake.Tail.Add(new ArenaPosition(neck.RowPosition, neck.ColumnPosition));

            //amíg a kígyó hossza (Tail.Count) kevesebb, mint a kígyó hossza (Tail.Length) :)
            if (snake.Tail.Count < snake.Length)
            { //addig MEGJELENÍTÉSHEZ nem csinálunk semmit, a kígyó húzza a csóváját
            }
            else
            { //a kígyó "előbújt", nem kell, hogy hosszabb legyen, a kígyó legvégét törölni kell

                //kell az információ, hogy eltüntessük a képernyőről
                //Az ábrán látszik, hogy a kígyó legvége mindig az első listaelem
                var end = snake.Tail[0];
                //meg kell jeleníteni erre az elemre a tábla rajzot (=eltüntetjük a tábláról)
                ShowEmptyArenaPosition(end.RowPosition, end.ColumnPosition);
                //majd az adatok közül is töröljük
                snake.Tail.RemoveAt(0);
            }
        }

        private void EndOfGame()
        {
            Console.WriteLine("Játék vége: ");
            pendulum.Stop();
            //todo: ki kell írni, hogy vége a játéknak
            //todo: és lehetőséget kell adni újrajátszásra

        }

        private void ShowEmptyArenaPosition(int rowPosition, int columnPosition)
        {
            var image = GetImage(rowPosition, columnPosition);
            //és már el tudom érni az ikon tulajdonságot
            image.Icon = FontAwesome.WPF.FontAwesomeIcon.SquareOutline;
            image.Foreground = Brushes.Black;
        }

        private void ShowSnakeNeck(int rowPosition, int columnPosition)
        {
            var image = GetImage(rowPosition, columnPosition);
            //és már el tudom érni az ikon tulajdonságot
            image.Icon = FontAwesome.WPF.FontAwesomeIcon.Circle;
            image.Foreground = Brushes.Gray;
        }

        private void ShowSnakeHead(int rowPosition, int columnPosition)
        {
            //ki kell rajzolni a következő pozícióra a kígyó fejét
            //Kígyófej megjelenítése Circle ikonnal
            var image = GetImage(rowPosition, columnPosition);
            //és már el tudom érni az ikon tulajdonságot
            image.Icon = FontAwesome.WPF.FontAwesomeIcon.Circle;
        }

        private FontAwesome.WPF.ImageAwesome GetImage(int rowPosition, int columnPosition)
        {
            //A grid az általa tartalmazott elemeket egy gyűjteményen keresztül teszi elérhetővé
            //ez a gyűjtemény a Children
            //a gyűjtemény egy felsorolás, ahol az első elm a 0. indexő, a második az 1. indexű, és így tovább.
            //a rowPosition. sor columnPosition. elemét tehát így tudjuk elkérni a gyűjteménytől
            var cell = View.ArenaGrid.Children[rowPosition * 20 + columnPosition];
            //viszont ez egy általános IUElement típust ad vissza, bármi, ami belekerül a gridbe
            //ilyen elemként kerül bele
            var image = (FontAwesome.WPF.ImageAwesome)cell;
            return image;
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
                    if (!isStarted)
                    { //még nem fut, indítjuk
                        StartNewGame();
                    }

                    //Le kell kezelni a billentyűleütést
                    switch (e.Key)
                    {
                        case Key.Left:
                            snake.HeadDirection = SnakeHeadDirectionEnum.Left;
                            break;
                        case Key.Up:
                            snake.HeadDirection = SnakeHeadDirectionEnum.Up;
                            break;
                        case Key.Right:
                            snake.HeadDirection = SnakeHeadDirectionEnum.Right;
                            break;
                        case Key.Down:
                            snake.HeadDirection = SnakeHeadDirectionEnum.Down;
                            break;
                    }
                    Console.WriteLine(e.Key);
                    break;
            }
        }

        private void StartNewGame()
        {
            //elindítjuk a játékot: eltüntetjük a játékszabályokat
            View.GamePlayBorder.Visibility = System.Windows.Visibility.Hidden;
            View.NumberOfMealsTextBlock.Visibility = System.Windows.Visibility.Visible;
            View.ArenaGrid.Visibility = System.Windows.Visibility.Visible;
            isStarted = true;
        }
    }
}

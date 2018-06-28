using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
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
        //a tábla méretei
        private int RowCount;
        private int ColumnCount;
        private Random Random; //használhatom a típus nevét változónévkén is nyugodtan
        //ételek nyilvántartása
        private Foods foods;
        //a megevett ételek száma
        private int foodsHaveEatenCount;

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

            snake = new Snake(10, 10);

            StartPendulum();

            isStarted = false;

            //Az aréna méreteinek beállítása
            //todo: az aréna méretezését átvenni a Windows Grid-ből.
            RowCount = 20;
            ColumnCount = 20;

            //a véletlenszám generátort létrehozzuk, az arénában bárki használhatja
            Random = new Random();

            //az ételeket nyilvántartó osztályt létrehozzuk, az arénában bárki használhatja
            foods = new Foods();

            foodsHaveEatenCount = 0;

        }

        private void StartPendulum()
        {
            //ha fut az ingaórám, akkor megállítjuk
            //a C# nyelvben az ellenőrzés csak addig fut le, ameddig feltétlenül szükséges
            //itt például, ha null a pendelum értéke, nem megy tovább a vizsgálat!!!
            //fordítva, ez:  pendulum.IsEnabled && pendulum!=null
            //null reference errorra futna, ha a pendelum null
            if (pendulum!=null && pendulum.IsEnabled)
            {
                pendulum.Stop();
            }

            //(újra)indítjuk a kígyó hosszának megfelelően
            //minél hosszabb a kígyó, annál rövidebb az intervallum
            var interval = 3000 / snake.Length;
            pendulum = new DispatcherTimer(TimeSpan.FromMilliseconds(interval), DispatcherPriority.Normal,
                                            ItsTimeForDisplay, Application.Current.Dispatcher);
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


            //old school model
            //
            //var isCollosion = false;
            //foreach (var tailItem in snake.Tail)
            //{ // a farokpontokon végigmegyünk
            //    if (tailItem.RowPosition == snake.HeadPosition.RowPosition
            //        && tailItem.ColumnPosition == snake.HeadPosition.ColumnPosition)
            //    {
            //        isCollosion = true;
            //    }
            //}
            //if (isCollosion)
            //{ //ütköztünk
            //    EndOfGame();
            //}

            //beleharaptunk-e saját farkunkba?
            //az Any linq axtension az adott feltételt megvizsgálja a lista minden elemére, és ha 
            //bármelyikre igaz, akkor true-val tére vissza, különben false-zal.
            //az x jelenti a lista egy adott elemét, ebben az esetben egy ArenaPosition-t ami a Tail listán van.
            if (snake.Tail.Any(x=>x.RowPosition==snake.HeadPosition.RowPosition 
                                && x.ColumnPosition==snake.HeadPosition.ColumnPosition))
            { //ütköztünk
                EndOfGame();
                //mivel játék vége van, nem folytatjuk a megjelenítést
                return;
            }

            //ellenőrizni, hogy ettünk-e?
            //az x az egy foodPosition
            //todo: helyezzük át ezt az ellenőrzést a Remove-ba, és az adja vissza, hogy: true=létezett és töröltem, false=nem létezik
            
            if (foods.FoodPositions.Any(x=>x.RowPosition==snake.HeadPosition.RowPosition
                                        &&x.ColumnPosition==snake.HeadPosition.ColumnPosition))
            { //ettünk
                //a kígyó feje el fogja tüntetni az ételt, a gridről
                //így csak adminisztrálnunk kell.

                //töröljük az ételt az ételek közül
                var foodToDelete = foods.Remove(snake.HeadPosition.RowPosition, snake.HeadPosition.ColumnPosition);

                //A Canvasról viszont nekünk kell törölnünk.
                EraseFromCanvas(foodToDelete.Paint);

                //számoljuk, hogy mennyit ettünk
                foodsHaveEatenCount = foodsHaveEatenCount + 1;

                //eggyel nőjön a kígyó hossza
                snake.Length = snake.Length + 1;

                //és gyorsuljon is

                //megjelenítjük, hogy mennyit ettünk
                View.NumberOfMealsTextBlock.Text = foodsHaveEatenCount.ToString();

                //generálunk egy új ételt
                GetNewFood();

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

        /// <summary>
        /// Rajzol egy elemet a Canvas-ra. 
        /// </summary>
        /// <param name="rowPosition">sorpizíció</param>
        /// <param name="columnPosition">oszloppozíció</param>
        /// <returns>A kirajzolt elem, amit aztán majd törölni kell</returns>
        private UIElement PaintOnCanvas(int rowPosition, int columnPosition)
        {
            var paint = new Ellipse();

            //a megjelenítés után az aktiális mérete ezzel kérdezhető le egy-egy 
            //megjelenített elemnek
            paint.Height = View.ArenaCanvas.ActualHeight / RowCount;
            paint.Width = View.ArenaCanvas.ActualWidth / ColumnCount;

            //A kitöltő szín legyen ugyanolyan piros, mint az almáé a Grid-en
            paint.Fill = Brushes.Red;

            //Meg kell határoztatni Canvas koordinátákban a kirajzolandó pozíciót
            Canvas.SetTop(paint, rowPosition * paint.Height);
            Canvas.SetLeft(paint, columnPosition * paint.Width);

            //Végül hozzáadjuk a Canvas-hoz, ezzel megjelenítjük
            View.ArenaCanvas.Children.Add(paint);
            return paint;
        }

        /// <summary>
        /// Ez a rajzolófüggvény párja, a kirajzolt elem törlésére
        /// </summary>
        /// <param name="paint">a rajzoláskor használt elemet kell visszaküldeni a törléshez</param>
        private void EraseFromCanvas(UIElement paint)
        {
            View.ArenaCanvas.Children.Remove(paint);
        }

        private void PaintOnGrid(int rowPosition, int columnPosition, VisibleElementTypesEnum visibleType)
        {
            var image = GetImage(rowPosition, columnPosition);
            //és már el tudom érni az ikon tulajdonságot
            switch (visibleType)
            {
                case VisibleElementTypesEnum.SnakeHead:
                    image.Icon = FontAwesome.WPF.FontAwesomeIcon.Circle;
                    break;
                case VisibleElementTypesEnum.SnakeNeck:
                    image.Icon = FontAwesome.WPF.FontAwesomeIcon.Circle;
                    image.Foreground = Brushes.Gray;
                    break;
                case VisibleElementTypesEnum.Food:
                    image.Icon = FontAwesome.WPF.FontAwesomeIcon.Apple;
                    image.Foreground = Brushes.Red;
                    break;
                case VisibleElementTypesEnum.EmptyArenaPosition:
                    image.Icon = FontAwesome.WPF.FontAwesomeIcon.SquareOutline;
                    image.Foreground = Brushes.Black;
                    break;
                default:
                    break;
            }
        }

        private UIElement ShowNewFood(int rowPosition, int columnPosition)
        {
            //rajz a grid-en
            PaintOnGrid(rowPosition, columnPosition, VisibleElementTypesEnum.Food);

            //rajz a Canvas-on
            var paint = PaintOnCanvas(rowPosition, columnPosition);

            //visszaküldjük ez utóbbit a törléshez
            return paint;
        }


        private void ShowEmptyArenaPosition(int rowPosition, int columnPosition)
        {
            PaintOnGrid(rowPosition, columnPosition, VisibleElementTypesEnum.EmptyArenaPosition);
        }

        private void ShowSnakeNeck(int rowPosition, int columnPosition)
        {
            PaintOnGrid(rowPosition, columnPosition, VisibleElementTypesEnum.SnakeNeck);
        }

        private void ShowSnakeHead(int rowPosition, int columnPosition)
        {
            PaintOnGrid(rowPosition, columnPosition, VisibleElementTypesEnum.SnakeHead);
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

            GetNewFood();

        }

        /// <summary>
        /// Ennek a függvénynek az a feladata, hogy generáljon egy új ételt,
        /// olyat, ami nem a kígyó fejények a helyén és nem a kígyó farkának helyén van
        /// és jelenítse is ezt az új ételt meg
        /// </summary>
        private void GetNewFood()
        {
            //olyan helyre, ahol a kígyó van nem kerülhet étel

            //itt kell az ételeket is kiosztani
            //véletlenszerűnek kell lennie
            var row = Random.Next(0, RowCount - 1);
            var column = Random.Next(0, ColumnCount - 1);

            //figyelem, ez a 2. szabálynak ellentmond:
            //http://spinroot.com/p10/
            //innen: http://netacademia.blog.hu/2016/03/30/igy_fejleszt_a_nasa_c_programozasi_nyelven_marsjarot
            while (snake.HeadPosition.RowPosition == row && snake.HeadPosition.ColumnPosition == column //ez a kígyó feje, ide nem kerülhet étel
                || snake.Tail.Any(x => x.RowPosition == row && x.ColumnPosition == column)) //ez meg a farokrésze, ide sem
            { // új generálást kell készíteni
                row = Random.Next(0, RowCount - 1);
                column = Random.Next(0, ColumnCount - 1);
            }


            //megjelenítjük az új ételt
            var paint = ShowNewFood(row, column);

            //adminisztráljuk az adatokat

            //ez helyett készítünk
            //foods.FoodPositions.Add(new ArenaPosition(row, column));
            //egy ilyet
            foods.Add(row, column, paint);

        }
    }
}

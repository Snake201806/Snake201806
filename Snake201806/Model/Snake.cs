using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake201806.Model
{
    /// <summary>
    /// Az irányított kígyót reprezentáló osztály
    /// </summary>
    class Snake
    {
        public Snake(int rowPosition, int columnPosition)
        {
            //ilyenkor még nincs megjelenítve semmi, így nincs ilyen adatunk, 
            //így nem tudunk neki Paint-ot megadni.
            //vagyis, jelezzük, hogy nincs adat, erre szolgál a null.
            HeadPosition = new CanvasPosition(rowPosition, columnPosition, null);
            HeadDirection = SnakeHeadDirectionEnum.InPlace;
            Length = 6;
            //gondoskodom arról, hogy a lista változóm listát tartalmazzon, 
            //nehogy object reference null hibára fussunk
            //http://netacademia.blog.hu/tags/null_object_pattern
            Tail = new List<CanvasPosition>();
        }

        //tudnia kell, hogy hol van a kígyó feje
        public CanvasPosition HeadPosition { get; set; }

        //tudnia kell, hogy merre megy éppen
        public SnakeHeadDirectionEnum HeadDirection { get; set; }

        //tudnia kell, hogy milyen hosszú

        /// <summary>
        /// Ehhez nyilván kell tartanunk a kígyó farkának pontjait, 
        /// amit egy listában célszerű megtenni
        /// </summary>
        public List<CanvasPosition> Tail { get; set; }

        public int Length { get; set; }


        //két property: a kígyó farok vége, és a nyaka, ami az eleje.



    }
}

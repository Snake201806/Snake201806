using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake201806.Model
{
    /// <summary>
    /// Ez egy osztálydefiníció, ami leírja, hogy ha ebből az osztályból
    /// készítünk egy új példányt (new kulcsszóval) akkor ez az osztálypéldány
    /// (vagy objektum) milyen tulajdonságokkal rendelkezzen és hogy viselkedjen
    /// </summary>
    class ArenaPosition
    {

        /// <summary>
        /// Ez az un. konstruktor, ami létrehozza az osztálypéldányt.
        /// a new kulcsszóval őt hívjuk, és azért nincs típusa, mert egy osztálypéldányt
        /// hoz létre, mást nem is tud.
        /// 
        /// Ha nem adunk meg saját konstruktort, akkor a fordító létrehoz egyet suttyomban,
        /// és az egy üres függvény, ez az alapértelmezett, vagy default, vagy paraméter nélküli konstruktor. így:
        /// 
        /// public ArenaPosition()
        /// {
        ///
        /// }
        /// 
        /// Ha saját konstruktort hozunk létre, akkor a fordító már nem szól bele,
        /// nem gyárt default konstruktort, ha szükségünk van rá, nekünk kell létrehozni.
        /// 
        /// </summary>
        /// <param name="rowPosition"></param>
        /// <param name="columnPosition"></param>
        public ArenaPosition(int rowPosition, int columnPosition)
        {
            RowPosition = rowPosition;
            ColumnPosition = columnPosition;
        }

        /// <summary>
        /// Az sor pozíció: hányadik sorban kell megjeleníteni?
        /// </summary>
        public int RowPosition { get; set; }
        /// <summary>
        /// Oszloppozíció: hányadik oszlopban kell megjeleníten?
        /// </summary>
        public int ColumnPosition { get; set; }

        ///A fenti definíciók un. Property-k, vagy magyarul tulajdonságok.
        ///nagyon hasonlít egy sima változóhoz, van neve és típusa, de annál jóval több:
        ///követi egy un. getter és setter definíció.
        ///ez egyelőre csak annyit jelent, hogy a getter-re lekérdezni tudjuk a tulajdonság értékét
        ///a setterrel pedig megváltoztatni, vagyis az írás és olvasás folyamata szét van választva.
        ///ez az alapértelmezett, un. default definíció, amikor a property PONTOSAN úgy viselkedik, 
        ///mintha változó lenne. 
    }
}

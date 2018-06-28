# A NetAcademia "Bevezetés az objektumorientált világba: a SNAKE projekt" tanfolyamának kiegészítõ kódtára

## Snake játék programozása

### A snake játék szabályai
- egy kígyót irányítunk úgy, hogy a fejének az irányát szabjuk, a kígyó követi a fejét.
- a játékterületen megjelennek ételek, ezeket a kígyónak meg kell ennie.
- a játék célja az, hogy minél több ételt megegyünk.
- a játék vége akkor következik be, ha
  - nekimegyünk a falnak
  - beleütközünk a saját fakunkba
- minél több ételt eszünk meg, a kígyó
  - annál hosszabb
  - annál gyorsabb

### A játék képernyõi
Kezdõkép
```
+-------------------------------------------+
|                                           |
|   A játékszabályokat megjelenítjük az     |
|   indulásig                               |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                    ++                     |
|                    ++                     |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
|                                           |
+-------------------------------------------+
```

Játék közben
```
           +-------------------------------------------+
           |                                           |
           |                                           |
Étel       |             +--------------------+        |  A háttérben a játékinformációk
           |             |                    |        |  áttetszõ betûkkel, nem zavaró
     +------->  ++       |                    |  <--------módon------+
           |    ++       |                    |        |  A megjelenítéskor animálhatjuk is
           |             |                    |        |
           |             +--------------------+        |
           |                                           |
           |                                           |
           |                    ^^                     |
           |                    ||                     |
           |                    ||                     |    Kígyó
           |                    ||                     |
           |                    ||  <---------------------------+
           |                    ||                     |
           |                    ||                     |
           |                    ++                     |
           |                                           |
           |                                           |
           |                                           |
           |                                           |
           |                                           |
           +-------------------------------------------+
```

Záróképernyõ
```
+-----------------------------------+
|                                   |
|                                   |
|                                   |
|                                   |
|                                   |
|     A játékinformációk            |
|     megjelenítése                 |
|     - játék idõtartama            |
|     | kígyó hossza                |
|     - megevett ételek             |
|     . top 5 eredménylista         |
|                                   |
|                                   |
|                                   |
|                                   |
|                                   |
|                                   |
|                                   |
|                                   |
|                                   |
+-----------------------------------+
```

### Vázlat az alkalmazás felépítéséhez
Az alkalmazásunk felépítése a következõ lesz:
```
  Képernyõ (View)                                 Alkalmazás logika (Model)
+---------------------------------------+       +-----------------------------------+
|                                       |       |                                   |
|  A megjelenítést végzi, illetve       |       |   A feladata a játékmenethez      |
|  a felhasználó vezérlését fogadja.    |       |   szükséges tudás birtoklása      |
|                                       | +---> |   Fontos, hogy célunk szerint     |
|                                       |       |   nem tudja, hogy a megjelenítés  |
|                                       | <---+ |   pontosan mi.                    |
|                                       |       |   (Ezt nem tudjuk maradéktalanul  |
|                                       |       |   megoldani a jelenlegi           |
|                                       |       |   tudásunkkal, de egy nagy        |
|                                       |       |   lépést teszünk ebbe az irányba  |
|                                       |       |                                   |
|                                       |       |                                   |
|                                       |       |                                   |
|                                       |       |                                   |
|                                       |       |                                   |
|                                       |       |                                   |
|                                       |       |                                   |
|                                       |       |                                   |
+---------------------------------------+       +-----------------------------------+
```

### 1. feladat
- [X] elkészíteni a képernyõt (View: MainWindows.xaml)
  - [X] tudnia kell megjeleníteni a kígyó fejét
    - [X] ehhez kell a játéktábla
      - [X] meg kell tudni jeleníteni a megevett ételek számát
  - [X] tudnia kell megjeleníteni a játékszabályokat
  - [X] tudnia kell elkapni a felhasználó vezérlõparancsait (billentyûleütések), és továbbítni a Model felé.
- [X] elkészíteni az alkalmazáslogikát (Model)
  - [X] tudnia kell átvenni a billentyûparancsokat
  - [X] tudnia kell elindítani a játékmenetet 
    - [X] el kell tudnia tüntetni a játékszabályokat
- [X] ezt a két réteget összekötni


### 2. Feladat
Játékmenet programozása
- [X] a kígyó megy amerre irányítjuk


### 1. Házi feladat 
- meg kell tudni jeleníteni az eltelt idõt
- meg kell tudni jeleníteni a kígyó hosszát
- elgondolkodni az ütközések programozásáról
- csatlakozás a DotNet cápákhoz a [facebookon](https://www.facebook.com/groups/dotnetcapak/)


### 3. Feladat
- [ ] meg kell tudni jeleníteni a kígyó hosszát
  - [X] a játék kezdetekor megmutatni a kígyót, "ahogy kibújik a kígyóverembõl"
  - [X] a kígyó testét navigálni a kígyófej mögött
  - [X] a kígyó evés után nõ


Áttekintõ ábra
```
                                         A kígyó feje
    A kígyófarok eleje  +------------>   +    (Head)
       (Neck)                        |   |
                                     v   v

                                  ++ ++ ++
                                  ++ ++ ++
                                      ^+
                                  ++   |
                                  ++ <--<----------------+
                                       |                 |
                                  ++   |                 |
A kígyófarok vége   +-----------> ++ <-+                 +
  (End)                                               A kígyó farka
                                  ^                    (Tail)
                                  |
                                  |
                                  |
                                  |
                                  |
                                  +

                       A legmesszebb ez az elem van a kígyó
                       fejétõl, így ez került bele legrégebben
                       a listába (List<ArenaPosition> Tail),
                       ahova az új elemek
                       mindig a legvégére kerülnek, így ez az
                       elem értelemszerûen a legelsõ lesz
                       a listában mindig
```


- [X] elgondolkodni az ütközések programozásáról
  - [X] ha ütközik a fallal vége a játéknak
  - [X] ha ütközik magával vége a játéknak
- [X] étel megjelenítése és evés
  - [X] az étel megjelenítése
    - [X] egyszerre mindig egy étel
  - [X] evés
- [X] a kígyó evés után gyorsul
- [X] a kígyó evés után nõjön


### 2. Házi feladat
- helyezzük át a fodds.Remove hívása elõtti ellenõrzést a Remove-ba, és az adja vissza, hogy: true=létezett és töröltem, false=nem létezik
- meg kell tudni jeleníteni az eltelt idõt
- meg kell tudni jeleníteni a kígyó hosszát
- továbbfejlesztés: egyszerre több étel megjelenítése


### 4. Feladat
- [ ] helyezzük át a fodds.Remove hívása elõtti ellenõrzést a Remove-ba, és az adja vissza, hogy: true=létezett és töröltem, false=nem létezik
- [X] az ismétlõdések kiszervezése
- [X] egy második megjelenítési típus befezetése (Canvas)

Tudnivalók
- A Canvas megjelenítéskor egy Children gyûjteményben rögzíti a megjelenítendõ elemeket
- Amilyen sorrendben megjelennek ezek az elemek, olyan sorrendben kerülnek ebbe a gyûjteménybe
- ha törlök ezekbõl az elemekbõl, az indexelés megváltozik a tömbnek
```
 Canvas

+-----------------------------------------------+
|                                               |
|                 3                             |
|                 +----+                        |
|                 |    |   +------------------------------->        Children
|                 +----+                        |                  +---------------------+
|                                               |          +       |                     |
|                                               |          |       | +-----------------+ |  0
|    1                                          |          |       | +-----------------+ |
|    +-----+                                    |          |       |                     |
|    |     | +-------------------------------------------> |       | +-----------------+ |  1
|    +-----+                                    |          |       | +-----------------+ |
|                              2                |          |       |                     |
|                              +-----+          |          |       | +-----------------+ |  2
|                              |     | +-----------------> |       | +-----------------+ |
|                              +-----+          |          |       |                     |
|                                               |          |       |                     |
+-----------------------------------------------+          |       |                     |
                                                           |       |                     |
                                                           |       |                     |
                                                           |       +---------+-----------+
                                                           |                 ^
                                                           |                 |
                                                           |                 |
                                                           v +-------------->+

```

Megoldási lehetõségek:
- RemoveAt() : ehhez ismerni kell az indexet
    - létrehozunk mi is egy listát, amiben ugyanazokat az elemeket nyilvántartjuk, mint amit a Canvas.Children nyilvántart. Tehát: 
      - ha felviszünk egy új elemet, akkor a mi listánkba is felviszünk egy új elemet, 
      - ha törlünk a Childrenbõl, akkor töröljük a listánkról is a megfelelõ elemet.
    - teszünk egyéb megkötéseket, például
      - az ételeket mindig a 0. elemre tesszük, (az InsertAt függvény segítségével), így 
        - mindig az elején lesznek az ételek, 
        - és mindig a végén a kígyó
- Remove() : ehhez meg kell tartani az eredeti elemet

  - [X] Nyilván kell tudni tartani a kirajzolt elipsziseket a meglévõ adatok mellé

Osztályok leszármaztatása, létrehozás
```
 CanvasPosition                            ArenaPosition

+------------------------+               +-------------------------+
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
|                        | +-----------> |                         |
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
|                        |               |                         |
+------------------------+               +-------------------------+



             A CanvasPosition leszármazottja az ArenaPosition-nek
             vagy
             Az ArenaPosition õsosztálya a CanvasPosition-nek
             ez a kettõ ugyanazt jelenti

             Ebbõl az következik, hogyha mi létrehozunk egy CanvasPosition-t,
             akkor mindig létrejön egy ArenaPosition példány, õ fogja mindazt
             megoldani, amit az ArenaPosition tud.
             Ebbõl az következik, hogy MINDIG tudnuk kell példányosítani egy
             ArenaPosition-t.
```

  - [X] vissza kell tudni kapni a kereséskor azt az elemet, amit éppen törölni szeretnénk
  - [X] így tudjuk majd törölni a kirajzolt elemet a Canvas.Childrenbõl



### 3. Házi feladat
- továbbfejlesztés: egyszerre több étel megjelenítése
- Záróképernyõ
- Játék megállítása és újraindítása gomb
- meg kell tudni jeleníteni az eltelt idõt
- meg kell tudni jeleníteni a kígyó hosszát




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
- [ ] elkészíteni a képernyõt (View: MainWindows.xaml)
  - [ ] tudnia kell megjeleníteni a kígyó fejét
  - [ ] tudnia kell megjeleníteni a játékszabályokat
  - [ ] tudnia kell elkapni a felhasználó vezérlõparancsait (billentyûleütések), és továbbítni a Model felé.
- [ ] elkészíteni az alkalmazáslogikát (Model)
  - [ ] tudnia kell átvenni a billentyûparancsokat
  - [ ] tudnia kell elindítani a játékmenetet 
- [ ] ezt a két réteget összekötni

 
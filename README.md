# A NetAcademia "Bevezet�s az objektumorient�lt vil�gba: a SNAKE projekt" tanfolyam�nak kieg�sz�t� k�dt�ra

## Snake j�t�k programoz�sa

### A snake j�t�k szab�lyai
- egy k�gy�t ir�ny�tunk �gy, hogy a fej�nek az ir�ny�t szabjuk, a k�gy� k�veti a fej�t.
- a j�t�kter�leten megjelennek �telek, ezeket a k�gy�nak meg kell ennie.
- a j�t�k c�lja az, hogy min�l t�bb �telt megegy�nk.
- a j�t�k v�ge akkor k�vetkezik be, ha
  - nekimegy�nk a falnak
  - bele�tk�z�nk a saj�t fakunkba
- min�l t�bb �telt esz�nk meg, a k�gy�
  - ann�l hosszabb
  - ann�l gyorsabb

### A j�t�k k�perny�i
Kezd�k�p
```
+-------------------------------------------+
|                                           |
|   A j�t�kszab�lyokat megjelen�tj�k az     |
|   indul�sig                               |
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

J�t�k k�zben
```
           +-------------------------------------------+
           |                                           |
           |                                           |
�tel       |             +--------------------+        |  A h�tt�rben a j�t�kinform�ci�k
           |             |                    |        |  �ttetsz� bet�kkel, nem zavar�
     +------->  ++       |                    |  <--------m�don------+
           |    ++       |                    |        |  A megjelen�t�skor anim�lhatjuk is
           |             |                    |        |
           |             +--------------------+        |
           |                                           |
           |                                           |
           |                    ^^                     |
           |                    ||                     |
           |                    ||                     |    K�gy�
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

Z�r�k�perny�
```
+-----------------------------------+
|                                   |
|                                   |
|                                   |
|                                   |
|                                   |
|     A j�t�kinform�ci�k            |
|     megjelen�t�se                 |
|     - j�t�k id�tartama            |
|     | k�gy� hossza                |
|     - megevett �telek             |
|     . top 5 eredm�nylista         |
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

### V�zlat az alkalmaz�s fel�p�t�s�hez
Az alkalmaz�sunk fel�p�t�se a k�vetkez� lesz:
```
  K�perny� (View)                                 Alkalmaz�s logika (Model)
+---------------------------------------+       +-----------------------------------+
|                                       |       |                                   |
|  A megjelen�t�st v�gzi, illetve       |       |   A feladata a j�t�kmenethez      |
|  a felhaszn�l� vez�rl�s�t fogadja.    |       |   sz�ks�ges tud�s birtokl�sa      |
|                                       | +---> |   Fontos, hogy c�lunk szerint     |
|                                       |       |   nem tudja, hogy a megjelen�t�s  |
|                                       | <---+ |   pontosan mi.                    |
|                                       |       |   (Ezt nem tudjuk marad�ktalanul  |
|                                       |       |   megoldani a jelenlegi           |
|                                       |       |   tud�sunkkal, de egy nagy        |
|                                       |       |   l�p�st tesz�nk ebbe az ir�nyba  |
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
- [X] elk�sz�teni a k�perny�t (View: MainWindows.xaml)
  - [X] tudnia kell megjelen�teni a k�gy� fej�t
    - [X] ehhez kell a j�t�kt�bla
      - [X] meg kell tudni jelen�teni a megevett �telek sz�m�t
      - [ ] Opcion�lisan
        - [ ] meg kell tudni jelen�teni az eltelt id�t (H�zi feladat)
        - [ ] meg kell tudni jelen�teni a k�gy� hossz�t (H�zi feladat)
  - [X] tudnia kell megjelen�teni a j�t�kszab�lyokat
  - [X] tudnia kell elkapni a felhaszn�l� vez�rl�parancsait (billenty�le�t�sek), �s tov�bb�tni a Model fel�.
- [X] elk�sz�teni az alkalmaz�slogik�t (Model)
  - [X] tudnia kell �tvenni a billenty�parancsokat
  - [X] tudnia kell elind�tani a j�t�kmenetet 
    - [X] el kell tudnia t�ntetni a j�t�kszab�lyokat
- [X] ezt a k�t r�teget �sszek�tni


### 2. Feladat
J�t�kmenet programoz�sa
- [ ] a k�gy� megy amerre ir�ny�tjuk
   - [ ] 
- [ ] ha �tk�zik a fallal v�ge a j�t�knak
- [ ] ha �tk�zik mag�val v�ge a j�t�knak



### 1. H�zi feladat 
- meg kell tudni jelen�teni az eltelt id�t
- meg kell tudni jelen�teni a k�gy� hossz�t

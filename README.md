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
  - [X] tudnia kell megjelen�teni a j�t�kszab�lyokat
  - [X] tudnia kell elkapni a felhaszn�l� vez�rl�parancsait (billenty�le�t�sek), �s tov�bb�tni a Model fel�.
- [X] elk�sz�teni az alkalmaz�slogik�t (Model)
  - [X] tudnia kell �tvenni a billenty�parancsokat
  - [X] tudnia kell elind�tani a j�t�kmenetet 
    - [X] el kell tudnia t�ntetni a j�t�kszab�lyokat
- [X] ezt a k�t r�teget �sszek�tni


### 2. Feladat
J�t�kmenet programoz�sa
- [X] a k�gy� megy amerre ir�ny�tjuk


### 1. H�zi feladat 
- meg kell tudni jelen�teni az eltelt id�t
- meg kell tudni jelen�teni a k�gy� hossz�t
- elgondolkodni az �tk�z�sek programoz�s�r�l
- csatlakoz�s a DotNet c�p�khoz a [facebookon](https://www.facebook.com/groups/dotnetcapak/)


### 3. Feladat
- [ ] meg kell tudni jelen�teni a k�gy� hossz�t
  - [X] a j�t�k kezdetekor megmutatni a k�gy�t, "ahogy kib�jik a k�gy�veremb�l"
  - [X] a k�gy� test�t navig�lni a k�gy�fej m�g�tt
  - [X] a k�gy� ev�s ut�n n�


�ttekint� �bra
```
                                         A k�gy� feje
    A k�gy�farok eleje  +------------>   +    (Head)
       (Neck)                        |   |
                                     v   v

                                  ++ ++ ++
                                  ++ ++ ++
                                      ^+
                                  ++   |
                                  ++ <--<----------------+
                                       |                 |
                                  ++   |                 |
A k�gy�farok v�ge   +-----------> ++ <-+                 +
  (End)                                               A k�gy� farka
                                  ^                    (Tail)
                                  |
                                  |
                                  |
                                  |
                                  |
                                  +

                       A legmesszebb ez az elem van a k�gy�
                       fej�t�l, �gy ez ker�lt bele legr�gebben
                       a list�ba (List<ArenaPosition> Tail),
                       ahova az �j elemek
                       mindig a legv�g�re ker�lnek, �gy ez az
                       elem �rtelemszer�en a legels� lesz
                       a list�ban mindig
```


- [X] elgondolkodni az �tk�z�sek programoz�s�r�l
  - [X] ha �tk�zik a fallal v�ge a j�t�knak
  - [X] ha �tk�zik mag�val v�ge a j�t�knak
- [X] �tel megjelen�t�se �s ev�s
  - [X] az �tel megjelen�t�se
    - [X] egyszerre mindig egy �tel
  - [X] ev�s
- [X] a k�gy� ev�s ut�n gyorsul
- [X] a k�gy� ev�s ut�n n�j�n


### 2. H�zi feladat
- helyezz�k �t a fodds.Remove h�v�sa el�tti ellen�rz�st a Remove-ba, �s az adja vissza, hogy: true=l�tezett �s t�r�ltem, false=nem l�tezik
- meg kell tudni jelen�teni az eltelt id�t
- meg kell tudni jelen�teni a k�gy� hossz�t
- tov�bbfejleszt�s: egyszerre t�bb �tel megjelen�t�se


### 4. Feladat
- [ ] helyezz�k �t a fodds.Remove h�v�sa el�tti ellen�rz�st a Remove-ba, �s az adja vissza, hogy: true=l�tezett �s t�r�ltem, false=nem l�tezik
- [ ] az ism�tl�d�sek kiszervez�se
- [ ] egy m�sodik megjelen�t�si t�pus befezet�se (Canvas)

### 3. H�zi feladat
- tov�bbfejleszt�s: egyszerre t�bb �tel megjelen�t�se
- Z�r�k�perny�
- J�t�k meg�ll�t�sa �s �jraind�t�sa gomb
- meg kell tudni jelen�teni az eltelt id�t
- meg kell tudni jelen�teni a k�gy� hossz�t




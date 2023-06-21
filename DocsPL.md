## Autor
- imię: **Szymon Mazurek**
- tytuł **Dungeons The Text Game - dokumentacja**

## Opis Projektu
Jest to prosta gra tekstowa stworzona z myślą o Kursie Pogramowania Obiektowego
na Uniwersytecie Wrocławskim. Celem gry jest odnalezienie księżniczki
w labiryncie Mrocznych Lochów. Każda komnata skrywa tajemnice, a także niebezpiecznych wrogów. 
Gracz (użytkownik terminala) poprzez odpowiednie wpisywanie danych poleceń steruje przebiegiem akcji gry.

## Szczegóły implementacji
Główna logika gry skupia się na obiekcie klasy `DungeonLabyrinthGame.cs`. Zajmuje się ona
konfiguracją gry, a więc scenami, graczami, potworami, umieszczaniem księżniczki, tworzeniem mapy i wreszcie konfiguracją
obiektu `currentState`, który ma kluczowe znaczenie dla obsługi informacji w grze. Główna pętla gry
znajduje się wewnątrz funkcji `Run` tej klasy. Jest to prosta pętla while z instrukcją switch, która pozwala
poruszać się między scenami w grze, tworząc w ten sposób iluzję ruchu. W każdej scenie radzimy sobie
według danego scenariusza, wywołując określone metody klasowe. W każdym zadanym scenariuszu mamy dostęp do `currentState`, który umożliwia
komunikację niepowiązanym ze sobą klasom.

## Sposób wykoniania
Na początku gry gracz (użytkownik terminala) znajduje się w jednej z sześciu scen,
każda związana jest z określonymi wydarzeniami. Te zdarzenia to metody zadeklarowane w różych obiektach, które są właśnie potrzebne.
Z pewnością warto zauważyć, że do każdej metody przekazujemy obiekty `currentState` i `answerList`.
Te dwie rzeczy są najważniejszymi elementami gry. Obiekt `currentState` pozwala obiektom
niepowiązanych klas na komunikację, a `answerList` zawiera nazwy możliwych działań
dla gracza. Ta lista jest stale aktualizowana zgodnie ze zmianami zachodzącymi w grze. Podczas gry można znaleźć się w niektórych z utworzonych komnat. Każda komnata posiada też listę
połączeń z innymi komnatami, dzięki czemu gracz może podróżować po mapie gry.

## Jak grać?
Podczas gry masz dostęp do wszystkich akcji wymienionych w scenie. Jeśli chcesz wykonać określone
akcje musisz wpisać nazwę akcji (wielkość liter nie ma znaczenia) w polu wejściowym, kiedy ją wpiszesz
naciśnij enter, jeśli wpisane dane były poprawne, wykonasz akcję. Oprócz wymienionych działań
można również wybrać kilka poleceń, które są zawsze dostępne, takie jak:
- `-H` co oznacza POMOC, wypisuje listę możliwych poleceń
- `-E` co oznacza WYPOSAŻENIE, wypisuje listę wyposażenia gracza i może być przydatne przy wyborze najpotężniejszej broni
- `-P`, które oznacza PLAYER, wypisuje wszystkie dane gracza, więc imię, wynik, zdrowie i wyposażenie

# Opis klas i metod

## Chamber

### M:ChooseChamberScene(CurrentState,List{String})
Klasa Chamber reprezentuje komnatę w grze dungeon labyrinth i zawiera zmienne instancji oraz metody aktualizujące stan gry.
zmienne i metody aktualizacji stanu gry.
#### Summary
Funkcja ta pozwala graczowi wybrać komnatę, do której chce się przenieść i odpowiednio aktualizuje stan gry.
odpowiednio.

#### Parameters
- `CurrentState`: CurrentState jest obiektem, który przechowuje aktualny stan
  gry, w tym aktualną komnatę, w której gracz się znajduje, poprzednią komnatę, w której gracz był
  oraz listę wszystkich komnat w grze.
- `answerList`: Lista możliwych odpowiedzi, które użytkownik może wybrać w bieżącej scenie.
  bieżącej scenie.

## CurrentState
Klasa CurrentState przechowuje informacje o aktualnym stanie gry, w tym o
gracza, listę komnat, aktualną scenę gry, poprzednią komnatę i informacje o graczu.
i informacje o graczu, a także udostępnia metody do obsługi wycofywania się gracza i wyświetlania jego statystyk i wyposażenia.
wyposażenie.
### M:HandlePlayerRetreat
#### Summary
Funkcja obsługuje odwrót gracza, zamieniając bieżącą komnatę z poprzednią komnatą
i ustawiając bieżącą scenę gry na "ActionForRoom".

### M:ShowPlayerStatistics
#### Summary
Funkcja ta wyświetla imię gracza, jego wynik i statystyki wyposażenia.

### M:ShowPlayerEquipment
#### Summary
Funkcja wyświetla wyposażenie gracza, iterując po jego przedmiotach i wyświetlając
ich informacje.

## DungeonLabyrinthGame
Klasa `DungeonLabyrinthGame` definiuje sceny gry, ustawia początkowy stan gry,
i uruchamia pętlę gry do momentu odnalezienia księżniczki.
### M:Run
#### Summary
Ta funkcja uruchamia pętlę gry, która przełącza się między różnymi scenami gry, dopóki
księżniczka zostanie znaleziona.

### M:SetupChambers
#### Summary
Funkcja ta tworzy listę komnat z różnymi atrybutami, takimi jak potwory, przedmioty i opisy.
opisy.

#### Returns
Metoda `SetupChambers()` zwraca `Listę` obiektów `Chamber`.

### M:StartScreen
#### Summary
Funkcja StartScreen wyświetla komunikat powitalny i instrukcje dotyczące gry Dungeon
Labiryntu i czeka, aż gracz naciśnie klawisz Enter, aby rozpocząć grę.

## Functions
Klasa Functions zawiera kilka statycznych metod służących do wyszukiwania i filtrowania list obiektów
w tekstowej grze przygodowej.
### M:DungeonLabyrinth.Functions.GetIdxOfChamber(List{Chamber},String)
#### Summary
Funkcja zwraca indeks obiektu Chamber w liście na podstawie jego nazwy.

#### Parameters
- `chams`: Lista obiektów typu Chamber.
- `name`: Nazwa komory, której szukamy na liście komór (chams)
  (chams).

#### Returns
Metoda zwraca wartość całkowitą, która reprezentuje indeks pierwszego wystąpienia obiektu
Chamber o nazwie zgodnej z wejściowym ciągiem "name" na podanej liście obiektów Chamber
obiektów "chams". Jeśli nie zostanie znalezione żadne dopasowanie, metoda zwraca 0.

### M:GetIdxOfHealthPotion(List{Item},String)
#### Summary
Funkcja zwraca indeks eliksiru zdrowia na liście przedmiotów.

#### Parameters
- `items`: Lista obiektów Item.
- `name`: Typ wyszukiwanego elementu, reprezentowany jako ciąg znaków. W tym
  przypadku przyjmuje się, że jest to typ eliksiru zdrowia.

#### Returns
Metoda zwraca wartość całkowitą, która jest indeksem pierwszego elementu na danej liście
elementów, który ma typ pasujący do podanego parametru type. Jeśli taki element nie zostanie znaleziony, metoda
zwraca 0.

### M:FilterOutTypeOfItem(List{Item},String)
#### Summary
Funkcja odfiltrowuje elementy określonego typu z listy elementów i zwraca listę
ich nazw zapisanych wielkimi literami.

#### Parameters
- `items`: Lista obiektów typu Item.
- `filterQuery`: Parametr filterQuery jest ciągiem znaków, który jest używany do odfiltrowania
  elementów na podstawie ich typu. Metoda doda elementy do przefiltrowanej listy tylko wtedy, gdy ich typ
  pasuje do łańcucha filterQuery.

#### Returns
Metoda zwraca listę ciągów znaków zawierającą nazwy elementów pasujących do zapytania filtra
zapytanie filtrujące. Nazwy są konwertowane na wielkie litery przed dodaniem do listy.

## Game
Klasa Game inicjuje obiekt klasy DungeonLabyrinthGame i uruchamia grę.
### M:Main(System.String[])
#### Summary
Funkcja Main inicjuje obiekt klasy DungeonLabyrinthGame i uruchamia grę.
## InputHandler
Klasa InputHandler udostępnia metody pobierania i sprawdzania poprawności danych wejściowych użytkownika w oparciu o listę
prawidłowych akcji i bieżącego stanu programu.
### M:GetUserInput(List{String},CurrentState)
#### Summary
Ta funkcja pobiera dane wejściowe użytkownika i weryfikuje je względem listy prawidłowych akcji i
bieżącym stanem.

#### Parameters
- `validActions`: Lista ciągów znaków reprezentujących możliwe działania, które użytkownik
  może wybrać.
- `CurrentState`: CurrentState jest niestandardowym obiektem reprezentującym aktualny stan gry lub programu.
  gry lub programu. Może zawierać informacje takie jak aktualna lokalizacja gracza,
  inwentarz, zdrowie lub inne istotne dane. Metoda GetUserInput używa obiektu CurrentState
  aby zweryfikować dane wejściowe użytkownika w oparciu o CurrentState

#### Returns
Metoda zwraca ciąg znaków, który jest zweryfikowaną informacją wprowadzoną przez użytkownika.

### M:ValidateInput(String,List{String},CurrentState)
#### Summary
Funkcja sprawdza poprawność danych wprowadzonych przez użytkownika i wykonuje określone działania na podstawie tych danych.

#### Parameters
- `input`: ciąg znaków reprezentujący dane wejściowe użytkownika, które mają zostać zweryfikowane.
- `validActions`: Lista prawidłowych akcji wejściowych, które użytkownik może wprowadzić.
- `CurrentState`: CurrentState to obiekt reprezentujący aktualny stan gry lub gracza.
  gry lub gracza. Może zawierać informacje takie jak statystyki gracza, wyposażenie,
  lokalizacja itp.

#### Returns
Metoda zwraca wartość logiczną wskazującą, czy dane wejściowe znajdują się na liście
ważnych akcji.

## Item
Klasa `Item` definiuje obiekt, który gracz może zebrać i który jest umieszczony w jakiejś komnacie.
### M:ShowItemInfo
#### Summary
Funkcja wyświetla informacje o elemencie w formacie wielkich liter.


## Monster
Klasa `Monster` definiuje właściwości i metody do tworzenia i zarządzania potworami w grze.
### M:FightWithMonster(Player,List{String},CurrentState)
#### Summary
Ta funkcja obsługuje walkę między graczem a potworem, używając wybranej broni
siłę i listę możliwych działań.

#### Parameters
- `Player`: Obiekt reprezentujący gracza w grze, z właściwościami takimi jak
  zdrowie i wynik.
- `answerList`: Lista możliwych działań, które gracz może podjąć podczas walki, np.
  walki, takie jak "ROLL", aby rzucić kośćmi do ataku lub "RETREAT", aby wycofać się z walki.
  walki.
- `chosenWeaponStrength`: Siła broni wybranej przez gracza do walki.
  walki.
- `CurrentState`: Aktualny
- `CurrentState`: CurrentState jest obiektem, który przechowuje aktualny stan gry, w tym
  gry, w tym aktualną scenę, aktualną komnatę i inne istotne informacje. Jest
  służy do śledzenia postępów w grze i podejmowania decyzji na podstawie działań gracza.
  działań gracza.
### M:DisplayFightStats(Player,Int32)
#### Summary
Ta funkcja wyświetla statystyki walki gracza i przeciwnika w sformatowany sposób.
sposób

#### Parameters
- `Player`: Parametr `Player` jest obiektem klasy `Plyaer`, który
  zawiera informacje o graczy, którym walczy z przeciwnikiem, takie jak
  nazwa, jego siła i zdrowie.
- `chosenWeaponStrength`: Siła broni, którą gracz wybrał do
  użyć w walce.

## Player
Klasa Player w języku C# reprezentuje gracza w grze i zawiera metody do obsługi działań gracza, w tym
działania gracza, w tym odkrywanie księżniczki, rozglądanie się po pokoju, atakowanie lub
wycofywanie się przed potworem, zbieranie przedmiotów i wybieranie pokoju, do którego chce się wejść.
### M:DungeonLabyrinth.Player.IsPlayerHolding(String)
#### Summary
Funkcja sprawdza, czy gracz posiada przedmiot określonego typu.

#### Parameters
- `type`: Parametr "type" jest ciągiem znaków reprezentującym typ przedmiotu, który
  metoda sprawdza, czy gracz go trzyma. Jest on używany do porównywania z właściwością "type"
  każdego przedmiotu na liście "wyposażenia", aby sprawdzić, czy gracz trzyma przedmiot
  tego typu.

#### Returns
Metoda `IsPlayerHolding` zwraca wartość logiczną. Zwraca ona `true`, jeśli gracz
trzyma przedmiot określonego typu, a `false` w przeciwnym razie.

### M:PlayerChooseAction(CurrentState,List{String})
#### Summary
Funkcja ta obsługuje działania gracza w grze, w tym odkrywanie księżniczki,
rozglądanie się po pokoju, atakowanie lub wycofywanie się przed potworem, zbieranie przedmiotów i
wybór pokoju, do którego chce się wejść.

#### Parameters
- `CurrentState`: CurrentState jest obiektem, który zawiera aktualny stan gry, w tym
  gry, w tym aktualną komnatę, w której gracz się znajduje, poprzednią komnatę, w której gracz był
  w której gracz się znajdował, wszelkie przedmioty, które gracz trzyma i wszelkie potwory, które mogą być obecne. Służy do
  śledzenia postępów w grze i tworzenia

- `answerList`: Lista możliwych działań, które gracz może wybrać. Ta
  lista jest czyszczona i aktualizowana w oparciu o aktualny stan gry.

### M:HandlePlayerChoice(CurrentState,List{String})
#### Summary
Ta funkcja obsługuje wybory gracza podczas rozgrywki, w tym atakowanie, wycofywanie się,
picie mikstur, wybór pokoju i podnoszenie przedmiotów.

#### Parameters
- `CurrentState`: CurrentState jest obiektem reprezentującym aktualny stan gry.
  gry. Zawiera informacje takie jak aktualny pokój, w którym znajduje się gracz, jego
  zdrowie i wyposażenie gracza oraz aktualna scena gry.
- `answerList`: answerList jest listą ciągów znaków, która zawiera możliwe działania
  które gracz może podjąć w bieżącym stanie gry. Metoda HandlePlayerChoice
  używa tej listy, aby poprosić gracza o wybranie akcji, a następnie obsługuje wybór gracza
  odpowiednio.

### M:PlayerFightMonster(CurrentState,List{String})
#### Summary
Funkcja ta pozwala graczowi wybrać broń i walczyć z potworem w grze.

#### Parameters
- `CurrentState`: CurrentState jest obiektem, który zawiera aktualny stan gry, w tym
  gry, w tym aktualną komnatę, w której znajduje się gracz, aktualny pokój, w którym się znajduje, oraz
  wszelkie przedmioty lub potwory obecne w pomieszczeniu.
- `answerList`: Lista możliwych odpowiedzi, które gracz może wybrać podczas walki z potworem.
  walki z potworem. Ta lista zawiera opcję odwrotu i wszelkie bronie, które gracz ma w swoim ekwipunku.
  gracz posiada w swoim ekwipunku.
## Princess
Klasa `Princess` ma właściwości dla nazwy i opisu oraz konstruktor, który inicjalizuje te właściwości.
te właściwości. Księżniczka jest klasą specjalną, której wykrycie powoduje zakończenie gry.
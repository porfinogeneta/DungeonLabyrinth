## Opis Projektu
Jest to prosta gra tekstowa stworzona z myślą o Kursie pPogramowania Obiektowego
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
Te dwie rzeczy są najważniejszymi elementami gry. Obiekt `currentState` pozwala na obiektom
niepowiązanych klas na komunikację, a `answerList` zawiera nazwy możliwych działań
dla gracza. Ta lista jest stale aktualizowana zgodnie ze zmianami zachodzącymi w grze.

## Jak grać?
Podczas gry masz dostęp do wszystkich akcji wymienionych w scenie. Jeśli chcesz wykonać określone
akcje musisz wpisać nazwę akcji (wielkość liter nie ma znaczenia) w polu wejściowym, kiedy ją wpiszesz
naciśnij enter, jeśli wpisane dane były poprawne, wykonasz akcję. Oprócz wymienionych działań
można również wybrać kilka poleceń, które są zawsze dostępne, takie jak:
- `-H` co oznacza POMOC, wypisuje listę możliwych poleceń
- `-E` co oznacza WYPOSAŻENIE, wypisuje listę wyposażenia gracza i może być przydatne przy wyborze najpotężniejszej broni
- `-P`, które oznacza PLAYER, wypisuje wszystkie dane gracza, więc imię, wynik, zdrowie i wyposażenie

# Opis klas i metod


## Komnata
Klasa Chamber reprezentuje komnatę w grze w labirynt lochów i zawiera instancję
zmienne i metody aktualizacji stanu gry.
### M:ChooseChamberScene(CurrentState,List{String})
#### Streszczenie
Funkcja pozwala graczowi wybrać komnatę, do której chce się przenieść i aktualizuje stan gry
odpowiednio.

#### Parametry
- `CurrentState`: CurrentState to obiekt, który przechowuje aktualny stan
  grę, w tym obecną komnatę, w której znajduje się gracz, poprzednią komnatę, w której przebywał gracz
  w oraz listę wszystkich komnat w grze.
- `answerList`: Lista możliwych odpowiedzi, z których użytkownik może wybrać w
  aktualna scena.

## Stan aktulany
Klasa CurrentState przechowuje informacje o bieżącym stanie gry, w tym m.in
obecna komnata gracza, lista komnat, aktualna scena gry, poprzednia komnata i gracz
informacje i zapewnia metody obsługi odwrotu gracza i wyświetlania statystyk gracza oraz
sprzęt.
### M:HandlePlayerRetreat
#### Streszczenie
Funkcja obsługuje odwrót gracza poprzez zamianę obecnej komnaty na poprzednią
komorę i ustawienie bieżącej sceny gry na „ActionForRoom”.

### M:ShowPlayerStatistics
#### Streszczenie
Funkcja wyświetla imię i nazwisko gracza, jego wynik oraz statystyki wyposażenia.

### M:ShowPlayerEquipment
#### Streszczenie
Funkcja wyświetla wyposażenie gracza, przeglądając jego przedmioty i pokazując
ich informacje.

## DungeonLabyrinthGame
Klasa `DungeonLabyrinthGame` definiuje sceny gry, ustawia stan początkowy gry,
i uruchamia pętlę gry, dopóki księżniczka nie zostanie znaleziona.
### M:Uciekaj
#### Streszczenie
Ta funkcja uruchamia pętlę gry, która przełącza różne sceny gry, aż do
odnaleziona księżniczka.

### M:SetupChambers
#### Streszczenie
Funkcja tworzy listę komnat z różnymi atrybutami, takimi jak potwory, przedmioty i
opisy.

#### Zwroty
Metoda `SetupChambers()` zwraca `List` obiektów `Chamber`.

### M:Ekran startowy
#### Streszczenie
Funkcja StartScreen wyświetla wiadomość powitalną i instrukcje dotyczące Lochu
Gra Labirynt i czeka, aż gracz naciśnie Enter, aby rozpocząć.

## Funkcje
Klasa Functions zawiera kilka statycznych metod wyszukiwania i filtrowania list obiektów
w tekstowej grze przygodowej.
### M:DungeonLabyrinth.Functions.GetIdxOfChamber(List{Chamber},String)
#### Streszczenie
Funkcja zwraca indeks obiektu Chamber na Liście na podstawie jego nazwy.

#### Parametry
- `chams`: Lista obiektów typu Chamber.
- `nazwa`: Nazwa komory, której szukamy w Liul Chambers
  (czamy).

#### Zwroty
Metoda zwraca wartość całkowitą, która reprezentuje indeks pierwszego wystąpienia a
Obiekt komory o nazwie zgodnej z wprowadzonym ciągiem „nazwa” na podanej Liście izb
obiekty „chams”. Jeśli nie zostanie znalezione dopasowanie, metoda zwraca 0.

### M:GetIdxOfHealthPotion(List{Item},String)
#### Streszczenie
Funkcja zwraca indeks pozycji mikstury zdrowia na liście pozycji.

#### Parametry
- `items`: Lista obiektów Item.
- `nazwa`: Typ szukanej pozycji, reprezentowany jako ciąg znaków. W tym
  przypadku przyjmuje się, że jest to rodzaj mikstury zdrowia.

#### Zwroty
Metoda zwraca wartość całkowitą, która jest indeksem pierwszego elementu na podanej liście
elementów, które mają typ pasujący do podanego parametru typu. Jeśli nie zostanie znaleziony żaden taki element,
metoda zwraca 0.

### M:FilterOutTypeOfItem(List{Item},String)
#### Streszczenie
Funkcja odfiltrowuje elementy określonego typu z listy elementów i zwraca listę
ich nazwiska wielkimi literami.

#### Parametry
- `items`: Lista obiektów typu Item.
- `filterQuery`: Parametr filterQuery jest ciągiem znaków używanym do odfiltrowania
  elementy według ich rodzaju. Metoda doda elementy do przefiltrowanej listy tylko wtedy, gdy ich typ
  pasuje do ciągu filterQuery.

#### Zwroty
Metoda zwraca listę ciągów zawierających nazwy elementów, które pasują do
filtruj zapytanie. Nazwy są konwertowane na wielkie litery przed dodaniem do listy.

## Gra
Klasa Game inicjuje obiekt klasy DungeonLabyrinthGame i uruchamia grę.
### M:Main(System.String[])
#### Streszczenie
Funkcja Main inicjuje obiekt klasy DungeonLabyrinthGame i uruchamia grę.

## Program obsługi wejścia
Klasa InputHandler zapewnia metody pobierania i sprawdzania poprawności danych wejściowych użytkownika na podstawie listy
prawidłowe działania i aktualny stan programu.
### M:GetUserInput(List{String},CurrentState)
#### Streszczenie
Ta funkcja pobiera dane wejściowe użytkownika i weryfikuje je na podstawie listy prawidłowych działań oraz
stan aktulany.

#### Parametry
- `validActions`: Lista ciągów znaków reprezentujących możliwe działania użytkownika
  może wybierać.
- `CurrentState`: CurrentState to niestandardowy obiekt reprezentujący bieżący stan
  gry lub programu. Może zawierać informacje, takie jak aktualna lokalizacja gracza,
  inwentarz, stan zdrowia lub inne istotne dane. Metoda GetUserInput używa właściwości CurrentState
  obiekt do sprawdzania poprawności danych wejściowych użytkownika na podstawie bieżącego stanu

#### Zwroty
Metoda zwraca ciąg, który jest zweryfikowanym wejściem użytkownika.

### M:ValidateInput(String,List{String},CurrentState)
#### Streszczenie
Funkcja sprawdza poprawność danych wprowadzonych przez użytkownika i wykonuje określone działania na podstawie danych wejściowych.

#### Parametry
- `input`: ciąg reprezentujący dane wejściowe użytkownika do sprawdzenia
- `validActions`: Lista prawidłowych działań wejściowych, które użytkownik może wprowadzić.
- `CurrentState`: CurrentState to obiekt reprezentujący aktualny stan
  gra lub gracz. Może zawierać informacje, takie jak statystyki gracza, wyposażenie,
  lokalizacja itp.

#### Zwroty
Metoda zwraca wartość logiczną wskazującą, czy dane wejściowe znajdują się na liście
ważne działania.

## Przedmiot
Klasa `Przedmiot` definiuje przedmiot, który gracz może zbierać i który jest umieszczany w niektórych komnatach.
### M:Pokaż informacje o przedmiocie
#### Streszczenie
Funkcja wyświetla informacje o elemencie dużymi literami.

## Potwór
Klasa Monster definiuje właściwości i metody tworzenia potworów i zarządzania nimi w grze.
### M:FightWithMonster(Player,List{String},CurrentState)
#### Streszczenie
Ta funkcja obsługuje walkę gracza z potworem przy użyciu wybranej broni
siłę i listę możliwych działań.

#### Parametry
- `Gracz`: Obiekt reprezentujący gracza w grze, z właściwościami takimi jak
  zdrowie i wynik.
- `answerList`: Lista możliwych działań, które gracz może wykonać podczas
  walki, na przykład „ROLL”, aby rzucić kostką do ataku, lub „RETREAT”, aby wycofać się z miejsca
  walka.
- `chosenWeaponStrength`: Siła broni wybranej przez gracza dla
  walka.
- `CurrentState`: Bieżący
- `CurrentState`: CurrentState to obiekt, który przechowuje aktualny stan
  grę, w tym bieżącą scenę, obecną komnatę i inne istotne informacje. To jest
  służy do śledzenia postępów w grze i podejmowania decyzji na podstawie decyzji gracza
  działania.

### M:DisplayFightStats(Monster,Int32)
#### Streszczenie
Ta funkcja wyświetla statystyki walki gracza i przeciwnika w sformatowanym formacie
sposób.

#### Parametry
- `Monster`: Parametr Monster jest obiektem klasy Monster, który
  zawiera informacje o wrogu, z którym walczy gracz, np
  imię wroga, siłę i zdrowie.
- `chosenWeaponStrength`: Siła broni wybranej przez gracza
  użyć w walce.

## Gracz
Klasa Player w C# reprezentuje gracza w grze i zawiera metody obsługi
działania gracza, w tym odkrywanie princence, rozglądając się po pokoju, atakując lub
wycofywanie się przed potworem, zbieranie przedmiotów i wybieranie pokoju, do którego chcesz wejść.
### M:DungeonLabyrinth.Player.IsPlayerHolding(String)
#### Streszczenie
Funkcja sprawdza, czy gracz trzyma przedmiot określonego rodzaju.

#### Parametry
- `type`: Parametr "type" jest ciągiem reprezentującym typ elementu, który
  metoda polega na sprawdzeniu, czy gracz trzyma. Służy do porównania z „typem”
  właściwości każdego przedmiotu na liście „wyposażenie”, aby zobaczyć, czy gracz trzyma przedmiot
  ten typ.

#### Zwroty
Metoda `IsPlayerHolding` zwraca wartość logiczną. Zwraca wartość `true`, jeśli gracz jest
przechowuje element określonego typu i `false` w przeciwnym razie.

### M:PlayerChooseAction(CurrentState,List{String})
#### Streszczenie
Funkcja obsługuje działania gracza w grze, w tym odkrywanie księżniczki,
rozglądanie się po pokoju, atakowanie lub wycofywanie się przed potworem, podnoszenie przedmiotów i
wybór pokoju do wejścia.

#### Parametry
- `CurrentState`: CurrentState to obiekt, który zawiera aktualny stan
  grę, w tym obecną komnatę, w której znajduje się gracz, poprzednią komnatę, w której przebywał gracz
  w, wszelkie przedmioty trzymane przez gracza i wszelkie potwory, które mogą być obecne. Jest przyzwyczajony
  śledzić postępy w grze i robić

- `answerList`: Lista możliwych działań, z których gracz może wybierać. Ten
  lista jest czyszczona i aktualizowana na podstawie aktualnego stanu gry.

### M:HandlePlayerChoice(CurrentState,List{String})
#### Streszczenie
Ta funkcja obsługuje wybory gracza podczas rozgrywki, w tym atakowanie, wycofywanie się,
picie mikstur, wybieranie pokoju i zbieranie przedmiotów.

#### Parametry
- `CurrentState`: CurrentState to obiekt reprezentujący aktualny stan
  gra. Zawiera informacje, takie jak aktualny pokój, w którym znajduje się gracz, pokój gracza
  zdrowia i wyposażenia oraz aktualnej sceny gry.
- `answerList`: answerList to lista ciągów znaków zawierająca możliwe działania
  które gracz może przyjąć w bieżącym stanie gry. Metoda HandlePlayerChoice
  używa tej listy, aby zachęcić gracza do wybrania akcji, a następnie obsługuje wybór gracza
  odpowiednio.

### M:PlayerFightMonster(CurrentState,List{String})
#### Streszczenie
Funkcja pozwala graczowi wybrać broń i walczyć z potworem w grze.

#### Parametry
- `CurrentState`: CurrentState to obiekt, który zawiera aktualny stan
  grę, w tym obecną komnatę, w której znajduje się gracz, bieżący pokój, w którym znajduje się gracz, oraz
  wszelkie przedmioty lub potwory obecne w pokoju.
- `answerList`: Lista możliwych odpowiedzi, z których gracz może wybierać podczas
  walka z potworem. Ta lista zawiera opcję wycofania się i wszelkie bronie, które są dostępne
  gracz ma w swoim ekwipunku.
## Księżniczka
Klasa „Księżniczka” ma właściwości nazwy i opisu oraz konstruktora, który się inicjuje
te właściwości. Księżniczka jest specjalną klasą, która po odkryciu przedmiotu tej klasy kończy grę.
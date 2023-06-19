# Zmiany w strukturze projektu
- Największa zmiana, jeżeli chodzi o strukturę projektu, jest całkowite zrezygnowanie.
Z dziedziczenia przez klasę `Chamber ` oraz `Player ` danych z obiektu klasy `CurrentStatę `.
Zmiana ta była podyktowana przede wszystkim kwestiami praktycznymi, mianowicie.
Dużo wygodniej było trzymać interesujące nas obiekty bezpośrednio w klasie.
`CurrentStatę `, niż specjalnie te obiekty przerabiać, żeby współpracowały z dziedziczeniem.
- Kolejną dużą zmianą było przerzucenie całej logiki gry do klasy `DungeonLabyrinthGame. `
I to właśnie w niej przygotowywanie całej gry oraz jej uruchamianie.
- Na etapie projektowym nie przewidziałem także powstania dwóch klas statycznych.
Tj. klasy `Functions ` oraz `Input handler `, okazały się one jednak niezbędne, jeżeli chodzi.
O zachowania przejrzystości kodu i niepowtarzania się.
- Na etapie projektowania aplikacji nie określiłem także prawidłowo relacji łączącej.
`CurrentStatę ` z `Item `, `Player `, `Monster ` i `Chamber `, a mianowicie tego, że.
Powinna je wiązać obustronna asocjacja, co wskazywałoby na dwustronny przepływ informacji.
Między tymi obiektami.
- Na etapie projektowym nie doceniłem także roli kompozycji w moim programie tj. że.
Obiekty takich klas, jak `Item ` i `Monster ` powinny być zawarte w klasach `Player ` i `Chamber `.
Umożliwia to bowiem łatwy dostęp do ich właściwości w metodach zawartych w tych klasach.

# Co poszło dobrze?
Myślę, że dobrze poszła ogólna ocena trudności projektu, i to, jakiego zakresu wiedzy.
I umiejętności będzie wymagał. W szczególności dobrze udało się rozplanować, jakie klasy będą potrzebne.
Oraz jakie powinny być w nich zawarte metody, oraz jakich pól będą potrzebowały. Oczywiście nie jest to całkowicie prawda.
(patrz metody w klasie `Princess ` i `CurrentStatę `), jednak w ogólności udało się przerobić projekt na faktyczną aplikację.

# Co jeszcze bym dopracował?
- Na pewno przerobiłbym kod, tak aby był jeszcze bardziej czytelny, tyczy się to np. metod w klasie `Player `.
- Dodałbym nowe funkcjonalności, takie jak:
- podgląd mapy rozgrywki
- 'ruchoma' księżniczka, tj. żeby mogła ona zmieniać swoje położenie w trakcie rozgrywki
- większy wybór dostępnych w trakcie gry sprzętów
- urozmaicenie rozgrywki poprzez dodanie innych interakcjami z grą oprócz ataków,
może jakieś zagadki itp.

# Czego się nauczyłem?
- planowanie projektu, a jego realizacja mogą od siebie znacznie odbiegać
- podstawy programowania w języku C#
- pisanie poprawnego i 'czystego' kodu – dopiero początki
- pisanie dokumentacji i jakich narzędzi warto do niej używać
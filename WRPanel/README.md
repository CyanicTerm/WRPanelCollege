Napisany projekt jest modułem wstępnym systemu CRM zarządzającego ekosystemem firmy oferującej usługi wulkanizacyjne. Aplikacja została napisana w technologii ASP.NET Core w .NET 5. Logika aplikacji jest napisana w języku C#, w celu zachowania zasad pisania czystego kodu, zastosowany został wzorzec Repozytorium (Repository pattern) przy jednoczesnym skorzystaniu z generycznego UnitOfWork, co pozwala na ograniczenie powtarzalności kodu. Dla uproszczenia testowania modułu, wprowadzony został system seedowania danych do bazy w kontenerze docker. Dla bezpieczeństwa, do aplikacji dodany został system logowania zawierający autentykację oraz autoryzację używając biblioteki Identity. Główna logika znajduje się w folderze Areas, gdzie można znaleźć widoki napisane w Razor opisujące poszczególne strony z biblioteki. Do bazy za pomocą seedu, wprowadzane są także 4 konta z rolami administratora, managera, ownera oraz employee (w zależności od roli, wyświetlane są poszczególne zakładki i możliwości)


**_Funkcjonalności_** 

- możliwość prowadzenia dziennika stałych klientów dodawanych za pomocą UI

- możliwość prowadzenia dziennika obecnych przechowalni i przypisanych im klientów

- możliwość zapisywania zadań „do zrobienia”


**_Pierwszy sposób uruchomienia (Docker)_**

1.       Sklonować repozytorium z serwisu GitHub - [https://github.com/CyanicTerm/WRPanelCollege](https://github.com/CyanicTerm/WRPanelCollege)

2.       Uruchomić plik docker-compose przy użyciu terminala lub programu docker. Po uruchomieniu, automatycznie powinny uruchomić się dwa kontenery – jeden z bazą danych MS SQL, a drugi z aplikacją WRPanel.

3.       Wejść w aplikację poprzez przeglądarkę internetową.


**_Drugi sposób uruchomienia (serwer lokalny)_**

1.       Sklonować repozytorium z serwisu GitHub - [https://github.com/CyanicTerm/WRPanelCollege](https://github.com/CyanicTerm/WRPanelCollege)

2.       Zmienić ConnectionString w pliku appsettings.json na serwer, na którym uruchomiona jest baza danych MS SQL Server.

3.       Uruchomić aplikację przy użyciu środowiska .NET 5 poprzez terminal lub odpowiednie IDE.

4.       Wejść w aplikację poprzez przeglądarkę internetową.

Aby zalogować się do aplikacji należy skorzystać z jednego z kont, a następnie wpisać hasło Admin123*
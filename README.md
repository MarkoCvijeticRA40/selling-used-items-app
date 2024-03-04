# selling-used-items-app
Web aplikacija za prodaju polovnih stvari

Uloge u sistemu:
-Neregistrovani korisnik
-Registrovani korisnik
-Administrator

Tehnički zahtevi:
Aplikacija mora da bude uradjena u .NET(C#) i TypeScript(Angular)
Aplikacija mora da se pokrece pomocu dokera.
Arhitektura aplikacije je proizvoljna.
Koristiti MySql bazu podataka.

1.)Neregistrovani korisnik
-Pretraga svih oglasa
-Sortiranje oglasa
-Filtriranje oglasa po odredjenim kriterijumima
-Registracija
-Uvid u sve detalje oglasa koje pretrazuje

2.)Registrovan korisnik
-CRUD oglasi
-CRUD profila
-Kupovina stvari
-Komunikacija sa vlasnikom oglasa oko kupovine
-Ostavljanje komentara na oglasima kod kojeg je kupio
-Ocenjivanje vlasnika oglasa kod kojeg je kupio
-Omoguciti vracanje naloga
-Notifikacija na mejl kada korisnik dobije poruku
-Istorija recenzija na profilu
-Prijaviti drugog korisnika

3.)Administrator
-Brisanje bilo kog oglasa
-Blokiranje bilo kog korisnika koji je potencijalno opasan sa navedenim razlogom ili ga je prijavilo vise od 5 drugih korisnika
-Omoguciti vracanje naloga

Ostalo:
Sistem za onemogucavanje unosa ruznih reci na oglas ili komentar
Security aplikacije(HTTPS komunkacija, sifrovati osetljive podatke pre unosa u bazu, jwt logovanje, jwt autorizacija na frontu, provera jwt prilikom svakog slanja na back, potvrda naloga prilikom registracije...)
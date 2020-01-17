namespace ShopLogin.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigratiion : DbMigration
    {
        public override void Up()
        {
                    Sql("INSERT INTO `addresses` (`Id`, `City`, `Street`, `Building`, `Apartment`, `PostCode`) VALUES"
        + "(3, 'Poznań', 'Limanowskiego', '7', NULL, 60737),"
        + "(4, 'Kielce', 'Radiowa', '12', '56', 25317),"
        + "(5, 'Wieruszów', 'Warszawska', '11', NULL, 98400),"
        + "(6, 'Przemyśl', 'Borelowskiego', '9', '20', 37700),"
        + "(7, 'Wrocław', 'aleja Pracy', '11', '15', 53231),"
        + "(8, 'Houston', 'Heath', '1178', NULL, 497),"
        + "(9, 'Port Erin', 'Twin Pines', '6', NULL, 148),"
        + "(10, 'Ushiku', 'Butterfield', '31', '92368', 176),"
        + "(11, 'Bulu', 'Holy Cross', '33', '85', 38),"
        + "(12, 'Tall Tamr', 'Oriole', '9', '239', 173),"
        + "(13, 'Zhujiang', 'Old Gate', '06', NULL, 368),"
        + "(14, 'Sigay', 'Summerview', '13', '5645', 50),"
        + "(15, 'Church End', 'Bartelt', '66', '7698', 333),"
        + "(16, 'Tor', 'Independence', '5154', NULL, 354),"
        + "(17, 'Murmuiža', 'Fieldstone', '4', NULL, 434),"
        + "(18, 'Tabora', 'Park Meadow', '3943', '503', 58),"
        + "(19, 'Jiquinlaca', 'Mcguire', '8', '4', 123),"
        + "(20, 'Pilchowice', 'Esker', '812', '221', 362);");

            Sql("INSERT INTO `customers` (`Id`, `FirstName`, `LastName`, `Email`, `BirthDate`, `PhoneNumber`, `BasketValue`, `AddressId`, `Password`, `Login`) VALUES"
            + "(3, 'Jakub', 'Czopa', 'typerk@onet.pl', '1999-04-23', 621476253, 2849, 3, 'x6BGYa4tVV', 'GeneratorFrajdy'),"
            + "(4, 'Tomasz', 'Kurczak', 'algs4live@gmail.com', '1976-12-12', 471929950, 0, 4, 'gyUhGjNpe2xecpZSn', 'Torczak'),"
            + "(5, 'Wojciech', 'Bezen', 'gorniszon@gmail.com', '1997-02-14', 242018902, 2695, 5, 'qwerty12345', 'Wojberry'),"
            + "(6, 'Pamelina', 'Slatford', 'pslatford5@behance.net', '1992-08-25', 2147483647, 46319.1, 6, 'rohHVXCpKn', 'pslatford5'),"
            + "(7, 'Wendie', 'Durrell', 'wdurrell6@army.mil', '1985-01-11', 2147483647, 37857.3, 7, 'YT6LUOtYk', 'wdurrell6'),"
            + "(8, 'Em', 'Westpfel', 'ewestpfel7@google.pl', '1980-06-18', 2147483647, 2528.28, 8, 'EIcHnZif9x', 'ewestpfel7'),"
            + "(9, 'Hew', 'McIlhagga', 'hmcilhagga8@example.com', '1985-03-04', 2147483647, 10485.8, 9, 'wOEfqm7w', 'hmcilhagga8'),"
            + "(10, 'Winslow', 'Virr', 'wvirr9@amazon.com', '1985-10-01', 2147483647, 100711, 10, 'iDFGqmGrg1', 'wvirr9'),"
            + "(11, 'Rodolph', 'Parnell', 'rparnella@berkeley.edu', '1999-08-22', 2147483647, 7558.81, 11, 'dBppfbwebeW', 'rparnella'),"
            + "(12, 'Maggee', 'Stonelake', 'mstonelakeb@arstechnica.com', '1993-12-06', 2147483647, 4657.23, 12, '2Z5Ib5j5ii', 'mstonelakeb'),"
            + "(13, 'Joscelin', 'Hazelby', 'jhazelbyc@1688.com', '1994-10-22', 1335052812, 11974.1, 13, 'aw28na', 'jhazelbyc'),"
            + "(14, 'Ad', 'Yukhtin', 'ayukhtind@google.it', '1994-02-06', 2147483647, 36023.1, 14, 'vlokY0', 'ayukhtind'),"
            + "(15, 'Louisette', 'Ingerfield', 'lingerfielde@flavors.me', '1988-04-12', 2147483647, 5764.83, 15, 'LqMJLE', 'lingerfielde'),"
            + "(16, 'Deana', 'Spencook', 'dspencookf@typepad.com', '1996-09-30', 2147483647, 5729.1, 16, 'C66qYLiGZeMr', 'dspencookf'),"
            + "(17, 'Ricky', 'Brammall', 'rbrammallg@1und1.de', '1995-05-15', 2147483647, 21873, 17, 'zkN4zbtYSzQW', 'rbrammallg'),"
            + "(18, 'Ronni', 'Wrout', 'rwrouth@time.com', '1988-06-08', 2147483647, 843.31, 18, 'CBb4QzdjMT', 'rwrouth'),"
            + "(19, 'Arlene', 'Egentan', 'aegentani@java.com', '1979-02-23', 2147483647, 8813.39, 19, 'mvjmxf', 'aegentani'),"
            + "(20, 'Kamilah', 'Flieger', 'kfliegerj@issuu.com', '1985-03-14', 2147483647, 7963.36, 20, 'ZxnJHwrHQ9', 'kfliegerj');");

            Sql("INSERT INTO `categories` (`Id`, `Name`, `FieldName1`, `FieldName2`, `FieldName3`, `FieldName4`, `FieldName5`, `FieldName6`, `FieldName7`, `FieldName8`) VALUES"
    + "(1, 'Laptopy', 'RAM[GB]', 'Przekątna ekranu[cale]', 'Waga[Kg]', 'Pamięć GPU[MB]', 'Rozdzielczość', 'Procesor', 'Karta graficzna', 'System operacyjny'),"
    + "(2, 'Gry', 'Rok wydania', 'PEGI', NULL, NULL, 'Platforma', 'Gatunek', 'Wersja językowa', 'Wydawca'),"
    + "(3, 'Powerbanki', 'Pojemność[mAH]', 'Napięcie nominalne[V]', NULL, NULL, 'Typ złącza', NULL, NULL, NULL),"
    + "(4, 'Pendrivy', 'Pojemność[GB]', NULL, NULL, NULL, 'Interfejs', 'Dodatkowe informacje', 'PRĘDKOŚĆ ODCZYTU', 'PRĘDKOŚĆ ZAPISU'),"
    + "(5, 'Monitory', 'Przekątna ekranu[cale]', 'Wysokość[mm]', 'Szerokość[mm]', 'Waga[kg]', 'Rozdzielczość', 'Matryca', NULL, NULL),"
    + "(6, 'Konsole do gier', 'Pojemność dysku[GB]', 'Ilość gier w zestawie', 'Waga[kg]', NULL, 'Akcesoria w zestawie', 'Gry w zestawie', NULL, NULL),"
    + "(7, 'Myszki komputerowe', 'Długość przewodu[cm]', 'Szerkość[mm]', 'Długość[mm]', 'Ilość przycisków', 'Łączność', 'DPI', NULL, NULL),"
    + "(8, 'Słuchawki', 'Impedancja[Om]', 'Pasmo przenoszenia[Hz]', 'Długość przewodu[cm]', 'Waga[g]', 'Łączność', 'Konstrukcja', 'Złącza', NULL),"
    + "(9, 'Klawiatury', 'Szerkość[mm]', 'Długość[mm]', 'Wysokość[mm]', NULL, 'Obsługiwane systemy', 'Zasilanie', 'Podświetlanie', NULL); ");

            Sql(
    "INSERT INTO `products` (`Id`, `Price`, `Name`, `Description`, `CategoryId`, `FieldValue1`, `FieldValue2`, `FieldValue3`, `FieldValue4`, `FieldValue5`, `FieldValue6`, `FieldValue7`, `FieldValue8`, `AmountInStore`, `ProducerName`) VALUES"
    + "(1, 199, 'Death Stranding', NULL, 2, 2019, 16, NULL, NULL, 'PlayStation4', 'akcji, przygodowe', 'polska i angielska', 'Sony Interactive Entertainment', 28, 'Kojima Productions'),"
    + "(2, 199, 'STAR WARS JEDI: Upadły Zakon', NULL, 2, 2019, 16, NULL, NULL, 'PC', 'akcji, przygodowe', 'polska i angielska', 'Electronic Arts', 24, 'Respawn Entertainment'),"
    + "(3, 179, 'Gran Turismo Sport', NULL, 2, 2018, 3, NULL, NULL, 'PlayStation4', 'wyścigi', 'polska i angielska', 'Sony Computer Entertainment', 39, 'Polyphony Digital'),"
    + "(4, 4299, 'TUF Gaming FX505DU', NULL, 1, 16, 15.6, 2.4, 6144, '1920x1080', 'AMD Ryzen 7 3750H', 'NVIDIA GeForce GTX 1660Ti', 'Brak', 13, 'ASUS'),"
    + "(5, 3799, 'Inspiron G3', NULL, 1, 8, 15.6, 1.8, 4096, '1336x764', 'Intel Core i5-9300H', 'NVIDIA GeForce GTX 1650', 'Microsoft Windows 10 Home PL', 22, 'DELL'),"
    + "(6, 5499, 'MacBook Air', NULL, 1, 8, 13.3, 1.25, NULL, '2650x1600', 'Intel Core i5-8210Y', 'Intel UHD Graphics 617', 'macOS Mojave', 56, 'Apple'),"
    + "(7, 619, 'P2319H', NULL, 5, 23, 481, 520, 3, '1920x1080', 'LED,IPS,Matowa', NULL, NULL, 14, 'DELL'),"
    + "(8, 619, 'VP239H', NULL, 5, 23, 387, 533, 4, '1920x1080', 'LED,IPS,Błyszcząca', NULL, NULL, 4, 'Asus'),"
    + "(9, 1099, 'PlayStation4', NULL, 6, 1000, 3, 2, NULL, 'Pad, przewód zasilający', 'Gran Turismo Sport, Uncharted 4, Red Dead Redemption 2', NULL, NULL, 55, 'Sony'),"
    + "(10, 1099, 'Xbox One X', NULL, 6, 1000, 1, 4, NULL, 'Pad, przewód zasilający, przewód HDMI', 'STAR WARS JEDI: Upadły Zakon', NULL, NULL, 30, 'Microsoft'),"
    + "(11, 449, 'MX Master 3', NULL, 7, 0, 84, 125, 7, 'Bezprzewodowa', '4000 dpi', NULL, NULL, 42, 'Logitech'),"
    + "(12, 379, 'Naga Trinity', NULL, 7, 85, 74, 119, 19, 'Przwód USB', '16000 dpi', NULL, NULL, 30, 'Razer'),"
    + "(13, 316, 'HD 4.40 BT', NULL, 8, 18, 22000, 140, 225, 'Bezprzewodowa,Przewodowa', 'Nauszne zamknięte', 'USB,Jack', NULL, 70, 'Sennheiser'),"
    + "(14, 779, 'Tiamat 7.1 V2', NULL, 8, 18, 20000, 300, 412, 'Przewodowa', 'Nauszne zamknięte', 'USB,Jack', NULL, 74, 'Razer'),"
    + "(15, 549, 'Magic Keyboard', NULL, 9, 118, 422, 10, NULL, 'macOS X', 'Akumulatorowe', 'Brak', NULL, 28, 'Apple'),"
    + "(16, 599, 'K68', NULL, 9, 170, 456, 39, NULL, 'Windows', 'Przewodowe', 'RGB', NULL, 57, 'Corsair');"
    );
        }
        
        public override void Down()
        {

        }
    }
}

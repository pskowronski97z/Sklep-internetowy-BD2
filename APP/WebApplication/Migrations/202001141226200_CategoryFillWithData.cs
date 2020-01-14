namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CategoryFillWithData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO `categories` (`Id`, `Name`, `FieldName1`, `FieldName2`, `FieldName3`, `FieldName4`, `FieldName5`, `FieldName6`, `FieldName7`, `FieldName8`) VALUES"
            +"(1, 'Laptopy', 'RAM[GB]', 'Przekątna ekranu[cale]', 'Waga[Kg]', 'Pamięć GPU[MB]', 'Rozdzielczość', 'Procesor', 'Karta graficzna', 'System operacyjny'),"
            +"(2, 'Gry', 'Rok wydania', 'PEGI', NULL, NULL, 'Platforma', 'Gatunek', 'Wersja językowa', 'Wydawca'),"
            + "(3, 'Powerbanki', 'Pojemność[mAH]', 'Napięcie nominalne[V]', NULL, NULL, 'Typ złącza', NULL, NULL, NULL),"
            + "(4, 'Pendrivy', 'Pojemność[GB]', NULL, NULL, NULL, 'Interfejs', 'Dodatkowe informacje', 'PRĘDKOŚĆ ODCZYTU', 'PRĘDKOŚĆ ZAPISU'),"
            + "(5, 'Monitory', 'Przekątna ekranu[cale]', 'Wysokość[mm]', 'Szerokość[mm]', 'Waga[kg]', 'Rozdzielczość', 'Matryca', NULL, NULL),"
            + "(6, 'Konsole do gier', 'Pojemność dysku[GB]', 'Ilość gier w zestawie', 'Waga[kg]', NULL, 'Akcesoria w zestawie', 'Gry w zestawie', NULL, NULL),"
            + "(7, 'Myszki komputerowe', 'Długość przewodu[cm]', 'Szerkość[mm]', 'Długość[mm]', 'Ilość przycisków', 'Łączność', 'DPI', NULL, NULL),"
            + "(8, 'Słuchawki', 'Impedancja[Om]', 'Pasmo przenoszenia[Hz]', 'Długość przewodu[cm]', 'Waga[g]', 'Łączność', 'Konstrukcja', 'Złącza', NULL),"
            + "(9, 'Klawiatury', 'Szerkość[mm]', 'Długość[mm]', 'Wysokość[mm]', NULL, 'Obsługiwane systemy', 'Zasilanie', 'Podświetlanie', NULL); ");
        }
        
        public override void Down()
        {
        }
    }
}

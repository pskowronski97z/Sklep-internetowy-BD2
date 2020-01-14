namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ProductsFillWithData : DbMigration
    {
        public override void Up()
        {
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

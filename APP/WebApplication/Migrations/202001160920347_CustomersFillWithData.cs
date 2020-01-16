namespace WebApplication.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CustomersFillWithData : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO `addresses` (`Id`, `City`, `Street`, `Building`, `Apartment`, `PostCode`) VALUES"
            +"(3, 'Poznań', 'Limanowskiego', '7', NULL, 60737),"
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
        }
        
        public override void Down()
        {
        }
    }
}

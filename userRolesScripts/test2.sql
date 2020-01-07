cd folder xampp\mysql\bin

mysql -u root

show databases;
use shop;

mysql -u ANDRZEJ_ADM -pCZARNAOWCA shop;
exit
Utworzenie roli typu Admin, Pracownik, Klient, Niezalogowany

grant all privileges on *.* to ANDRZEJ_ADM;

mysql -u ANDRZEJ_ADM -pCZARNAOWCA shop

grant usage on *.* to ANDRZEJ_ADM;

GRANT ALL PRIVILEGES ON *.* TO ROLE_ADMIN WITH GRANT OPTION;

flush privileges; !!!!!!!!!!!!!!!!!!!!!!

1
	
SELECT current_role();



 select host, user, password from mysql.user;
 
 drop role your_role_name;
 drop user 'user'@'localhost';
 
 drop role if exists jakiesorlenmae
 drop user if exists jakiesrolename
 
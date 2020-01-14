--Test systemu ról-----------------
use sklepinternetowy
create role role_looker;
grant show databases on *.* to role_looker;
create user 'looker' identified by 'lookerpass';
grant role_looker to looker;
set default role role_looker for looker;
grant select on sklepinternetowy.* to 'role_looker';
mysql -u looker -plookerpass sklepinternetowy;

INSERT INTO Address (City, Street, BuildingNumber, ApartmentNumber, PostCode) VALUES
    -> ('ImoWrocław', 'aleja Czewona', 11,15, 13231);
--denied - wszystko dziala okey
----------------------KONIEC TESTU

CREATE ROLE ROLE_START, ROLE_CLIENT, ROLE_WORKER, ROLE_ADMIN, ROLE_TEST;
--Rola test została utworzona do testów, aby nie niszczyć gotowych koneceptów-
-- po przejściu tej fazy, akceptujemy role i wdrażamy jako główną

CREATE USER 'ANDRZEJ_ADM' IDENTIFIED BY 'CZARNAOWCA';
CREATE USER 'PATRYK_ADM' IDENTIFIED BY 'CZARNAOWCA';
CREATE USER 'FILIP_ADM' IDENTIFIED BY 'CZARNAOWCA';

CREATE USER 'ANDRZEJ_CLI' IDENTIFIED BY 'CZARNAOWCA';
CREATE USER 'PATRYK_CLI' IDENTIFIED BY 'CZARNAOWCA';
CREATE USER 'FILIP_CLI' IDENTIFIED BY 'CZARNAOWCA';

CREATE USER 'ANDRZEJ_WOR' IDENTIFIED BY 'CZARNAOWCA';
CREATE USER 'PATRYK_WOR' IDENTIFIED BY 'CZARNAOWCA';
CREATE USER 'FILIP_WOR' IDENTIFIED BY 'CZARNAOWCA';

CREATE USER 'ANDRZEJ_STA' IDENTIFIED BY 'CZARNAOWCA';
CREATE USER 'PATRYK_STA' IDENTIFIED BY 'CZARNAOWCA';
CREATE USER 'FILIP_STA' IDENTIFIED BY 'CZARNAOWCA';

GRANT SHOW DATABASES ON *.* TO ROLE_ADMIN;
GRANT ALL ON QCOM.* TO ROLE_ADMIN;
GRANT ROLE_ADMIN TO ANDRZEJ_ADM, PATRYK_ADM, FILIP_ADM;
SET DEFAULT ROLE ROLE_ADMIN FOR ANDRZEJ_ADM, PATRYK_ADM, FILIP_ADM;
--skonfigurowano role administracyjne i przyłączono je do kont

GRANT ROLE_CLIENT TO ANDRZEJ_CLI, PATRYK_CLI, FILIP_CLI;

SET DEFAULT ROLE ROLE_CLIENT TO ANDRZEJ_CLI;


GRANT EXECUTE ON PROCEDURE QCOM.bascet_to_order TO ROLE_CLIENT;
GRANT SELECT ON QCOM.PRODUCT, QCOM.CATEGORY, QCOM.DISCOUNT;
GRANT SELECT ON shop.products TO ROLE_CLIENT;
--wstepny zarys uprawnien klienta

GRANT ROLE_WORKER TO ANDRZEJ_WOR, PATRYK_WOR, FILIP_WOR;
SET DEFAULT ROLE FOR ANDRZEJ_WOR, PATRYK_WOR, FILIP_WOR;
GRANT EXECUTE ON PROCEDURE QCOM.make_discount TO ROLE_WORKER;
GRANT UPDATE ON QCOM.PRODUCT, QCOM.PRODUCTINSTORE, QCOM.DISCOUNT TO ROLE_WORKER;
GRANT SELECT ON QCOM.* TO ROLE_WORKER;
--wstepny zarys uprawnien pracownika- bedzie zdecydowanie inaczej wygladac 
--po kolejnych konsultacjach z analitykiem grupy

--rola typu START jest jeszcze niezdefiniowana nawet wstępnie- potrzeban analiza czego dokładnie potrzebuje
--jak będziemy realizować te mechanizmy (funkcje, procedury, jak wysłać zapytanie o utworzenie użytkownika,
-- co jest potrzebne do logowania, opcja przeglądania, potrzebny dodatkowy research, konsultacja z resztą grupy


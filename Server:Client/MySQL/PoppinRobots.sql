CREATE DATABASE PoppinRobots;
USE PoppinRobots;
CREATE TABLE Cosmetics (
	ID INT(2) PRIMARY KEY NOT NULL AUTO_INCREMENT,
    GoldFit BOOLEAN NOT NULL,
    RedFit BOOLEAN NOT NULL,
    BlueFit BOOLEAN NOT NULL,
    BlackFit BOOLEAN NOT NULL
    );
    INSERT INTO Cosmetics (ID, GoldFit, RedFit,BlueFit,BlackFit)
		values(1,0,1,1,0);
CREATE TABLE Player(
	PlayerID INT(6) PRIMARY KEY NOT NULL,
    NAME VARCHAR(20) NOT NULL,
    HighScore INT(20) NOT NULL,
    NewGamePlus BOOLEAN NOT NULL,
    CosmeticID INT(2) NOT NULL AUTO_INCREMENT,
    WeaponID INT(1) NOT NULL,
    Money INT(10) NOT NULL,
    FOREIGN KEY fk5(CosmeticID) REFERENCES Cosmetics(ID)
    );
    INSERT INTO Player (PlayerID,NAME,HighScore, NewGamePlus, CosmeticID,WeaponID,Money)
		values ( 1, 'Chris', 100000,false, 1,0, 200);

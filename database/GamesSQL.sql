

CREATE database games

CREATE TABLE games (
game_code int IDENTITY(1,1) PRIMARY KEY,
game_name varchar (255) NOT NULL,
min_player int NOT NULL,
max_player int NOT NULL
);

INSERT INTO games VALUES('Candyland', 2, 4)
INSERT INTO games VALUES('Monopoly', 2, 8)
INSERT INTO games VALUES('Gloomhaven', 1, 4)
INSERT INTO games VALUES('Charterstone', 1, 6)
INSERT INTO games VALUES('Spirit Island', 1, 4)
INSERT INTO games VALUES('Terraforming Mars', 1, 5)



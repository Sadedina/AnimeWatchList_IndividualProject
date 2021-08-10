# Initializing SQL Database

```sql
CREATE DATABASE WatchList
USE WatchList

CREATE TABLE Profiles (
    PersonID varchar(255) NOT NULL,
    username varchar(255) NOT NULL,
    firstName varchar(255),
    lastName varchar(255),
    age int,
    country varchar(255),
    PRIMARY KEY (personID)
);

CREATE TABLE Animes (
    AnimeID int IDENTITY(1,1) NOT NULL,
    animeName varchar(255) NOT NULL,
    genre varchar(255),
    [type] varchar(255),
    episode int,
    releaseYear int,
    [status] varchar(255),
    [language] varchar(255),
    restriction int,
    [rank] int,
    summary varchar(MAX),
    PRIMARY KEY (AnimeID)
);

CREATE TABLE Watchlists (
    PersonID varchar(255) FOREIGN KEY REFERENCES Profiles(PersonID),
    AnimeID int FOREIGN KEY REFERENCES Animes(AnimeID),
    rating int,
    watching varchar(255),
    PRIMARY KEY (PersonID, AnimeID) 
);
```


CREATE TABLE Teams (
    Id UNIQUEIDENTIFIER NOT NULL,
    Name VARCHAR(100) NOT NULL,
    DisputedMatches INT NOT NULL,
    Points INT NOT NULL,
    Victories INT NOT NULL,
    Defeats INT NOT NULL,
    Draws INT NOT NULL,
    GoalsOutcome INT NOT NULL,
    Goals INT NOT NULL,
    ConcededGoals INT NOT NULL,
    EfficiencyPercent INT NOT NULL,
    PRIMARY KEY (Id)
);
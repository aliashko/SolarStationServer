CREATE TABLE Reports (
    Id BIGINT AUTO_INCREMENT PRIMARY_KEY,
    Date DATETIME NOT NULL,
    Timestamp BIGINT NOT NULL,
    Temperature FLOAT,
    Humidity FLOAT,
    RaindropLevel INT,
    SoilMoistureLevel INT,
    GsmSignalLevel INT,
    SolarVoltage FLOAT,
    SolarCurrent FLOAT,
    BatteryVoltage FLOAT,
    ArduinoVoltage FLOAT,
    GsmVoltage FLOAT,
    PowerMode INT,
    SimMoneyBalance INT,
    RestartsCount BIGINT,
    GsmErrors INT
);

CREATE TABLE Settings (
    Key VARCHAR(100) PRIMARY_KEY,
    Value VARCHAR(100)
);
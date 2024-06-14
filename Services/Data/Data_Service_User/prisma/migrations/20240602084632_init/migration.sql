-- CreateTable
CREATE TABLE `Users` (
    `IdUsers` INTEGER NOT NULL AUTO_INCREMENT,
    `CodeUsers` VARCHAR(50) NOT NULL,
    `Username` VARCHAR(150) NOT NULL,
    `Password` VARCHAR(150) NOT NULL,
    `Status` BOOLEAN NOT NULL DEFAULT true,
    `DateCreate` DATETIME(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
    `DateUpdate` DATETIME(3) NOT NULL,
    `IdRole` INTEGER NOT NULL,

    PRIMARY KEY (`IdUsers`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- CreateTable
CREATE TABLE `DetailUsers` (
    `IdDetailUsers` INTEGER NOT NULL AUTO_INCREMENT,
    `CodeDetailUsers` VARCHAR(50) NULL,
    `FullName` VARCHAR(150) NOT NULL,
    `Phone` CHAR(10) NULL,
    `Email` VARCHAR(150) NULL,
    `DateOfBirth` DATETIME(3) NULL,
    `Description` VARCHAR(255) NULL,
    `Sex` INTEGER NULL,
    `Address` VARCHAR(255) NULL,
    `IdImage` INTEGER NOT NULL,
    `IdUsers` INTEGER NOT NULL,

    PRIMARY KEY (`IdDetailUsers`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- CreateTable
CREATE TABLE `Role` (
    `IdRole` INTEGER NOT NULL AUTO_INCREMENT,
    `CodeRole` VARCHAR(50) NULL,
    `NameRole` VARCHAR(150) NULL,
    `Status` BOOLEAN NOT NULL DEFAULT true,
    `DateCreate` DATETIME(3) NOT NULL DEFAULT CURRENT_TIMESTAMP(3),
    `DateUpdate` DATETIME(3) NOT NULL,

    PRIMARY KEY (`IdRole`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

-- CreateTable
CREATE TABLE `UserPermissions` (
    `IdUserPermssions` INTEGER NOT NULL AUTO_INCREMENT,
    `CodeUserPermssions` VARCHAR(50) NULL,
    `NameUserPermissions` VARCHAR(150) NULL,
    `IsRead` BOOLEAN NOT NULL DEFAULT true,
    `IsCreate` BOOLEAN NOT NULL DEFAULT true,
    `IsDelete` BOOLEAN NOT NULL DEFAULT true,
    `IsEdit` BOOLEAN NOT NULL DEFAULT true,
    `IdRole` INTEGER NOT NULL,

    PRIMARY KEY (`IdUserPermssions`)
) DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;

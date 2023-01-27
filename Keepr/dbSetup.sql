CREATE TABLE
    IF NOT EXISTS accounts(
        id VARCHAR(255) NOT NULL primary key COMMENT 'primary key',
        createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'Time Created',
        updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'Last Update',
        name varchar(255) COMMENT 'User Name',
        email varchar(255) COMMENT 'User Email',
        picture varchar(255) COMMENT 'User Picture',
        coverImg VARCHAR(255) COMMENT 'User Cover Image'
    ) default charset utf8 COMMENT '';

-- Keeps Section

CREATE TABLE
    keeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'pirmary key',
        creatorID VARCHAR(255) NOT NULL COMMENT 'Keep CreatorId',
        name VARCHAR(255) NOT NULL COMMENT 'Keep Name',
        description VARCHAR(1000) NOT NULL COMMENT 'Keep Description',
        img VARCHAR(255) NOT NULL COMMENT 'Keep Image',
        views INT NOT NULL COMMENT 'Keep views',
        Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) DEFAULT charset utf8 COMMENT '';

DROP TABLE keeps;

-- Vault Section

CREATE TABLE
    vaults(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'pirmary key',
        creatorID VARCHAR(255) NOT NULL COMMENT 'vault CreatorId',
        name VARCHAR(255) NOT NULL COMMENT 'vault Name',
        description VARCHAR(255) NOT NULL COMMENT 'vault Description',
        img VARCHAR(255) NOT NULL COMMENT 'vault Image',
        isPrivate BOOLEAN NOT NULL DEFAULT false COMMENT 'vault privacy',
        Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE
    ) DEFAULT CHARSET utf8 COMMENT '';

DROP TABLE vaults;

--  VaultKeep Section

CREATE TABLE
    vaultkeeps(
        id INT NOT NULL AUTO_INCREMENT PRIMARY KEY COMMENT 'primary key',
        creatorId VARCHAR(255) NOT NULL COMMENT 'VaultKeep CreatroId',
        vaultId INT NOT NULL COMMENT 'VaultKeep VaultId',
        keepId INT NOT NULL COMMENT 'VaultKeep KeepId',
        Foreign Key (creatorId) REFERENCES accounts (id) ON DELETE CASCADE,
        Foreign Key (vaultId) REFERENCES vaults (id) ON DELETE CASCADE,
        Foreign Key (keepId) REFERENCES keeps (id) ON DELETE CASCADE
    ) DEFAULT CHARSET utf8 COMMENT '';

DROP TABLE vaultkeeps;
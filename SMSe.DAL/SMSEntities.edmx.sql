
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/18/2020 23:55:33
-- Generated from EDMX file: D:\Downloads\SMSe\SMSe.DAL\SMSEntities.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SMSe];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_Group_Subject_Teacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Group] DROP CONSTRAINT [FK_Group_Subject_Teacher];
GO
IF OBJECT_ID(N'[dbo].[FK_Subject_Teacher_Subject]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subject_Teacher] DROP CONSTRAINT [FK_Subject_Teacher_Subject];
GO
IF OBJECT_ID(N'[dbo].[FK_Subject_Teacher_Teacher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Subject_Teacher] DROP CONSTRAINT [FK_Subject_Teacher_Teacher];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Group]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Group];
GO
IF OBJECT_ID(N'[dbo].[Subject]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subject];
GO
IF OBJECT_ID(N'[dbo].[Subject_Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Subject_Teacher];
GO
IF OBJECT_ID(N'[dbo].[Teacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Teacher];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Group'
CREATE TABLE [dbo].[Group] (
    [id] int IDENTITY(1,1) NOT NULL,
    [start_date] datetime  NULL,
    [end_date] datetime  NULL,
    [capacity] int  NULL,
    [lab] int  NULL,
    [subject_teacher_id] int  NULL
);
GO

-- Creating table 'Subject'
CREATE TABLE [dbo].[Subject] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(50)  NULL,
    [total_hour] float  NULL
);
GO

-- Creating table 'Subject_Teacher'
CREATE TABLE [dbo].[Subject_Teacher] (
    [subject_teacher_id] int  NOT NULL,
    [teacher_id] int  NULL,
    [subject_id] int  NULL
);
GO

-- Creating table 'Teacher'
CREATE TABLE [dbo].[Teacher] (
    [id] int IDENTITY(1,1) NOT NULL,
    [fname] nvarchar(50)  NULL,
    [lname] nvarchar(50)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'Group'
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT [PK_Group]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Subject'
ALTER TABLE [dbo].[Subject]
ADD CONSTRAINT [PK_Subject]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [subject_teacher_id] in table 'Subject_Teacher'
ALTER TABLE [dbo].[Subject_Teacher]
ADD CONSTRAINT [PK_Subject_Teacher]
    PRIMARY KEY CLUSTERED ([subject_teacher_id] ASC);
GO

-- Creating primary key on [id] in table 'Teacher'
ALTER TABLE [dbo].[Teacher]
ADD CONSTRAINT [PK_Teacher]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [subject_teacher_id] in table 'Group'
ALTER TABLE [dbo].[Group]
ADD CONSTRAINT [FK_Group_Subject_Teacher]
    FOREIGN KEY ([subject_teacher_id])
    REFERENCES [dbo].[Subject_Teacher]
        ([subject_teacher_id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Group_Subject_Teacher'
CREATE INDEX [IX_FK_Group_Subject_Teacher]
ON [dbo].[Group]
    ([subject_teacher_id]);
GO

-- Creating foreign key on [subject_id] in table 'Subject_Teacher'
ALTER TABLE [dbo].[Subject_Teacher]
ADD CONSTRAINT [FK_Subject_Teacher_Subject]
    FOREIGN KEY ([subject_id])
    REFERENCES [dbo].[Subject]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subject_Teacher_Subject'
CREATE INDEX [IX_FK_Subject_Teacher_Subject]
ON [dbo].[Subject_Teacher]
    ([subject_id]);
GO

-- Creating foreign key on [teacher_id] in table 'Subject_Teacher'
ALTER TABLE [dbo].[Subject_Teacher]
ADD CONSTRAINT [FK_Subject_Teacher_Teacher]
    FOREIGN KEY ([teacher_id])
    REFERENCES [dbo].[Teacher]
        ([id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_Subject_Teacher_Teacher'
CREATE INDEX [IX_FK_Subject_Teacher_Teacher]
ON [dbo].[Subject_Teacher]
    ([teacher_id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
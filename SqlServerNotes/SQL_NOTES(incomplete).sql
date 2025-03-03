IF OBJECT_ID(N'dbo.BOOKS', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BOOKS
    (
        ID varchar(64) not null,
        TITLE varchar(64) not null,
        AUTHOR varchar(64) not null,
        DESCRIPTION varchar(64) not null,
        COVER_IMAGE_ID varchar(64) not null,
        PUBLISHER varchar(64) not null,
        PUBLICATION_DT varchar(64) not null,
        CATEGORY_ID varchar(64) not null,
        ISBN varchar(64) not null,
        PAGE_COUNT varchar(64) not null,
        CREATED_DT varchar(64) not null,
        CREATED_USR varchar(64) not null,
        MODIFIED_DT varchar(64) not null,
        MOFIFIED_USR varchar(64) not null
    );
END;

IF OBJECT_ID(N'dbo.USERS', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.USERS
    (
        ID varchar(64) not null,
        USERNAME varchar(64) not null,
        PASSWORD varchar(64) not null,
        
        COVER_IMAGE_ID varchar(64) not null,
        PUBLISHER varchar(64) not null,
        PUBLICATION_DT varchar(64) not null,
        CATEGORY_ID varchar(64) not null,
        ISBN varchar(64) not null,
        PAGE_COUNT varchar(64) not null,
        CREATED_DT varchar(64) not null,
        CREATED_USR varchar(64) not null,
        MODIFIED_DT varchar(64) not null,
        MOFIFIED_USR varchar(64) not null
    );
END;

IF OBJECT_ID(N'dbo.ROLES', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.ROLES
    (
        ID varchar(64) not null,
        TITLE varchar(64) not null,
        AUTHOR varchar(64) not null,
        DESCRIPTION varchar(64) not null,
        COVER_IMAGE_ID varchar(64) not null,
        PUBLISHER varchar(64) not null,
        PUBLICATION_DT varchar(64) not null,
        CATEGORY_ID varchar(64) not null,
        ISBN varchar(64) not null,
        PAGE_COUNT varchar(64) not null,
        CREATED_DT varchar(64) not null,
        CREATED_USR varchar(64) not null,
        MODIFIED_DT varchar(64) not null,
        MOFIFIED_USR varchar(64) not null
    );
END;

IF OBJECT_ID(N'dbo.BOOK_CHECKOUTS', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BOOK_CHECKOUTS
    (
        ID varchar(64) not null,
        TITLE varchar(64) not null,
        AUTHOR varchar(64) not null,
        DESCRIPTION varchar(64) not null,
        COVER_IMAGE_ID varchar(64) not null,
        PUBLISHER varchar(64) not null,
        PUBLICATION_DT varchar(64) not null,
        CATEGORY_ID varchar(64) not null,
        ISBN varchar(64) not null,
        PAGE_COUNT varchar(64) not null,
        CREATED_DT varchar(64) not null,
        CREATED_USR varchar(64) not null,
        MODIFIED_DT varchar(64) not null,
        MOFIFIED_USR varchar(64) not null
    );
END;


IF OBJECT_ID(N'dbo.BOOK_REVIEWS', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.BOOK_REVIEWS
    (
        ID varchar(64) not null,
        TITLE varchar(64) not null,
        AUTHOR varchar(64) not null,
        DESCRIPTION varchar(64) not null,
        COVER_IMAGE_ID varchar(64) not null,
        PUBLISHER varchar(64) not null,
        PUBLICATION_DT varchar(64) not null,
        CATEGORY_ID varchar(64) not null,
        ISBN varchar(64) not null,
        PAGE_COUNT varchar(64) not null,
        CREATED_DT varchar(64) not null,
        CREATED_USR varchar(64) not null,
        MODIFIED_DT varchar(64) not null,
        MOFIFIED_USR varchar(64) not null
    );
END;



--VIEW to select random books
SELECT TOP 5 FROM BOOKS b
--INNER?
JOIN ON BOOK_REVIEWS r WHERE r.BOOK_ID = b.ID
ORDER BY NEWID()
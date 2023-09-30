CREATE TABLE [dbo].[FileMetadata]
(
	 [Id] INT NOT NULL PRIMARY KEY,
    -- Add other columns for file metadata as needed
    [FileName] NVARCHAR(255) NOT NULL,
    [FileSize] BIGINT NOT NULL,
    [FileType] NVARCHAR(50) NOT NULL,
    [UploadedBy] INT,  -- Assuming a foreign key to another table for user information
    [UploadDate] DATETIME NOT NULL
)

USE [PostComment]
GO

/****** Object:  StoredProcedure [dbo].[Insertpost]    Script Date: 5/13/2020 12:48:19 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Insertpost] @Title           NVARCHAR(155), 
                            @CreatedDateTime DATETIME = NULL, 
                            @Post            NVARCHAR(max) = NULL, 
                            @Author          NVARCHAR(50) = NULL, 
                            @new_identity    INT = NULL output 
AS 
  BEGIN 
      INSERT INTO PostTbl 
                  (Title, 
                   CreatedDateTime, 
                   Post, 
                   Author) 
      VALUES      ( @Title, 
                    @CreatedDateTime, 
                    @Post, 
                    @Author ) 

      SET @new_identity=Scope_identity() 

      RETURN @new_identity 
  END 
GO



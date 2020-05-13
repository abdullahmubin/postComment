USE [PostComment]
GO

/****** Object:  StoredProcedure [dbo].[InsertComment]    Script Date: 5/13/2020 12:47:27 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertComment] @PostId       INT, 
                            @CreatedDateTime DATETIME = NULL, 
                            @Author          NVARCHAR(55) = NULL, 
                            @TotalLike       INT = 0, 
							@TotalDislike    INT = 0,
							@Comment         NVARCHAR(max),
                            @new_identity    INT = NULL output 
AS 
  BEGIN 
      INSERT INTO CommentTbl 
                  (PostId, 
                   CreatedDatetime, 
                   Author, 
                   TotalLike,
				   TotalDislike,
				   Comment) 
      VALUES       (@PostId, 
                    @CreatedDateTime, 
                    @Author, 
                    @TotalLike,
					@TotalDislike,
					@Comment) 

      SET @new_identity=Scope_identity() 

      RETURN @new_identity 
  END 
GO



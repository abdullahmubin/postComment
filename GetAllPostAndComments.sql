USE [PostComment]
GO

/****** Object:  StoredProcedure [dbo].[GetAllPostAndComments]    Script Date: 5/13/2020 12:48:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[GetAllPostAndComments]
AS

BEGIN

  SELECT
    pTbl.Title,
	pTbl.PostId,
	pTbl.Post,
	pTbl.CreatedDateTime,
	pTbl.Author,
	cTbl.Comment,
	cTbl.CommentId,
	cTbl.CreatedDatetime as CommentDateTime,
	cTbl.Author as CommentAuthor,
	cTbl.TotalDislike,
	cTbl.TotalLike

  FROM PostTbl pTbl

  INNER JOIN CommentTbl AS cTbl ON pTbl.PostId = cTbl.PostId
 

END
GO



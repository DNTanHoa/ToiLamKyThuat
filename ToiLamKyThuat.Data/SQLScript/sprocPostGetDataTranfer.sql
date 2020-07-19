USE [ToiLamKyThuat]
GO
/****** Object:  StoredProcedure [dbo].[sprocPostGetDataTranfer]    Script Date: 7/19/2020 6:27:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Duoowng Nguyễn Tấn Hòa
-- Create date: 2020-07-16
-- Description:	Get post for home page 
-- =============================================
ALTER PROCEDURE [dbo].[sprocPostGetDataTranfer]
	
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT
		 A.ID
		,A.Note
		,A.CreateDate
		,A.CreateUser
		,A.UpdateDate
		,A.UpdateUser
		,A.IsActive
		,A.Title
		,A.SubTitle
		,A.Summary
		,A.CoverImage
		,A.MetaKeyword
		,A.MetaTitle
		,A.MetaDescription
		,A.CategoryID
		,B.CodeName AS CategoryName
	FROM
		Post A (NOLOCK)
		JOIN MasterData B (NOLOCK) ON A.CategoryID = B.ID
	ORDER BY A.CreateDate DESC
END

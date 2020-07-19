USE [ToiLamKyThuat]
GO
/****** Object:  StoredProcedure [dbo].[sprocMasterDataGetByConfigAndCodeRoot]    Script Date: 7/19/2020 6:24:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Duoowng Nguyễn Tấn Hòa
-- Create date: 2020-07-16
-- Description:	Get post for home page 
-- =============================================
ALTER PROCEDURE [dbo].[sprocMasterDataGetByConfigAndCodeRoot]
	@Config NVARCHAR(4000) = '',
	@Code NVARCHAR(4000) = ''
AS
BEGIN
	SET NOCOUNT ON;
	
	WITH RecursiveMasterData AS
	(
		SELECT
			A.*
		FROM 
			MasterData A (NOLOCK)
		WHERE 
			A.Config = @Config 
			AND A.Code = @Code
	
		UNION ALL

		SELECT
			A.*
		FROM
			MasterData A (NOLOCK)
			INNER JOIN RecursiveMasterData ON A.ParentID = RecursiveMasterData.ID
	)
	SELECT DISTINCT * FROM RecursiveMasterData

END

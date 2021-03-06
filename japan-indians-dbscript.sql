SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[State]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[State](
	[State_id] [int] IDENTITY(1,1) NOT NULL,
	[State_name] [nvarchar](50) NULL,
	[Country_id] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_cust_Events]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		Gayathri 
-- Create date: 
-- Description:	Japan-Indians.com
-- =============================================
CREATE PROCEDURE [dbo].[sp_cust_Events]
	-- Add the parameters for the stored procedure here
	@Event_id   int, 
	@Event_name   nvarchar(50)   ,
	@Event_Time   nvarchar(50)   ,
	@Event_Location   nvarchar(500)   ,
	@eVENT_dATE   datetime ,
	@event_telephone   nvarchar(50)   ,
	@event_address   nvarchar(500)   ,
	@event_state   int ,
	@event_city   int ,
	@event_zip   nvarchar(50)   ,
	@event_website   nvarchar(500)   ,
	@event_map   nvarchar(50)   ,
	@event_comments   nvarchar(1000)   ,
	@event_image   nvarchar(50)   ,
	@Cust_id   int ,
	@Querytype int

AS
BEGIN
	
if @Querytype=1
    	SELECT * from Events 

else if @Querytype=2
	SELECT * from Events  where Event_id=@Event_id

else if @Querytype=3
	delete from Events  where Event_id=@Event_id
	
else if @Querytype=4

		insert into Events(Event_name
      ,Event_Time
      ,Event_Location
      ,eVENT_dATE
      ,event_telephone
      ,event_address
      ,event_state
      ,event_city
      ,event_zip
      ,event_website
      ,event_map
      ,event_comments
      ,event_image
      ,Cust_id)
		values(@Event_name
      ,@Event_Time
      ,@Event_Location
      ,@eVENT_dATE
      ,@event_telephone
      ,@event_address
      ,@event_state
      ,@event_city
      ,@event_zip
      ,@event_website
      ,@event_map
      ,@event_comments
      ,@event_image
      ,@Cust_id)
	

else if @Querytype=5
	select max(Event_id)+1 from Events


END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Events]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Events](
	[Event_id] [int] IDENTITY(1,1) NOT NULL,
	[Event_name] [nvarchar](50) NULL,
	[Event_Time] [nvarchar](50) NULL,
	[Event_Location] [nvarchar](500) NULL,
	[eVENT_dATE] [datetime] NULL,
	[event_telephone] [nvarchar](50) NULL,
	[event_address] [nvarchar](500) NULL,
	[event_state] [int] NULL,
	[event_city] [int] NULL,
	[event_zip] [nvarchar](50) NULL,
	[event_website] [nvarchar](500) NULL,
	[event_map] [nvarchar](500) NULL,
	[event_comments] [nvarchar](1000) NULL,
	[event_image] [nvarchar](50) NULL,
	[Cust_id] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[store]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[store](
	[s_id] [int] IDENTITY(1,1) NOT NULL,
	[s_name] [varchar](500) NULL CONSTRAINT [DF__store__s_name__0BC6C43E]  DEFAULT (NULL),
	[s_address] [varchar](1000) NULL CONSTRAINT [DF__store__s_address__0CBAE877]  DEFAULT (NULL),
	[s_city] [int] NULL CONSTRAINT [DF__store__s_city__0EA330E9]  DEFAULT (NULL),
	[state_id] [int] NULL CONSTRAINT [DF__store__state_id__0F975522]  DEFAULT (NULL),
	[country_id] [int] NULL CONSTRAINT [DF__store__country_i__108B795B]  DEFAULT (NULL),
	[s_zip] [varchar](500) NULL CONSTRAINT [DF__store__s_zip__117F9D94]  DEFAULT (NULL),
	[s_phone] [varchar](500) NULL CONSTRAINT [DF__store__s_phone__1273C1CD]  DEFAULT (NULL),
	[s_email] [varchar](500) NULL CONSTRAINT [DF__store__s_email__1367E606]  DEFAULT (NULL),
	[s_website] [varchar](500) NULL CONSTRAINT [DF__store__s_website__145C0A3F]  DEFAULT (NULL),
	[s_contact] [varchar](1000) NULL CONSTRAINT [DF__store__s_contact__15502E78]  DEFAULT (NULL),
	[map_link] [nvarchar](500) NULL,
	[s_image] [nvarchar](500) NULL,
	[cust_id] [int] NULL,
	[s_desc] [nvarchar](1000) NULL,
 CONSTRAINT [PK__store__0AD2A005] PRIMARY KEY CLUSTERED 
(
	[s_id] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[CP_FORUM_Comments]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[CP_FORUM_Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[ArticleID] [int] NULL,
	[Title] [nvarchar](250) NULL,
	[UserName] [nvarchar](50) NULL,
	[UserEmail] [nvarchar](50) NULL,
	[Description] [nvarchar](2000) NULL,
	[Indent] [int] NULL,
	[DateAdded] [datetime] NULL CONSTRAINT [DF_CP_FORUM_Comments_DateAdded]  DEFAULT (getdate()),
	[UserProfile] [nvarchar](100) NULL,
	[CommentType] [tinyint] NULL CONSTRAINT [DF_CP_FORUM_Comments_CommentType]  DEFAULT ((1)),
 CONSTRAINT [PK_CP_FORUM_Comments] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (IGNORE_DUP_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO
SET ANSI_NULLS OFF
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TempTable]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TempTable](
	[Id] [int] NULL,
	[ParentId] [int] NULL,
	[ArticleId] [int] NULL,
	[Title] [nvarchar](250) NULL,
	[username] [nvarchar](50) NULL,
	[UserEmail] [nvarchar](50) NULL,
	[Description] [nvarchar](2000) NULL,
	[Indent] [int] NULL,
	[DateAdded] [datetime] NULL,
	[UserProfile] [nvarchar](100) NULL,
	[CommentType] [tinyint] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Resale_Products]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Resale_Products](
	[prod_id] [int] IDENTITY(1,1) NOT NULL,
	[prod_name] [nvarchar](50) NULL,
	[prod_desc] [nvarchar](1000) NULL,
	[prod_price] [nvarchar](50) NULL,
	[prod_cat] [int] NULL,
	[prod_largeimage] [nvarchar](50) NULL,
	[cust_id] [int] NULL,
	[last_day_togo] [datetime] NULL,
	[prod_pickup_address] [nvarchar](500) NULL,
	[prod_hide] [bit] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[City]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[City](
	[City_id] [int] IDENTITY(1,1) NOT NULL,
	[Country_id] [int] NULL,
	[City_name] [nvarchar](50) NULL,
	[State_id] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[prod_cat]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[prod_cat](
	[prod_cat_id] [int] IDENTITY(1,1) NOT NULL,
	[cat_name] [nvarchar](50) NULL,
	[cat_desc] [nvarchar](50) NULL,
	[cust_id] [int] NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Customers]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Customers](
	[Cust_id] [int] IDENTITY(1,1) NOT NULL,
	[Cust_name] [nvarchar](50) NULL,
	[Cust_email] [nvarchar](50) NULL,
	[Cust_Password] [nvarchar](50) NULL,
	[Cust_Country] [int] NULL,
	[Cust_State] [int] NULL,
	[Cust_City] [int] NULL,
	[Cust_Address] [nvarchar](1000) NULL,
	[Cust_CellNumber] [nvarchar](50) NULL,
	[Cust_picture] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Country]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Country](
	[Country_Id] [int] IDENTITY(1,1) NOT NULL,
	[Country] [nvarchar](50) NULL
) ON [PRIMARY]
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Country]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Gayathri 
-- Create date: 
-- Description:	Japan-Indians.com
-- =============================================
CREATE PROCEDURE [dbo].[sp_Country]
	-- Add the parameters for the stored procedure here
	@Country_id int,
	@Country nvarchar(50) ,
	@Querytype int

AS
BEGIN
	
if @Querytype=1
    	SELECT * from Country order by country

else if @Querytype=2
	SELECT * from Country  where Country_id=@Country_id

else if @Querytype=3
	delete from Country  where Country_id=@Country_id
	
else if @Querytype=4


		insert into Country(Country)
		values(@Country)
	
else if @Querytype=5
	SELECT * from State  where Country_id=@Country_id order by state_name

END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_State]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'



-- =============================================
-- Author:		Gayathri 
-- Create date: 
-- Description:	Japan-Indians.com
-- =============================================
CREATE PROCEDURE [dbo].[sp_State]
	-- Add the parameters for the stored procedure here
	@State_id int,
	@Country_id int,
	@State_name nvarchar(50) ,
	@Querytype int

AS
BEGIN
	
if @Querytype=1
    	SELECT * from State 

else if @Querytype=2
	SELECT * from City  where State_id=@State_id order by LTRIM(City_name)


else if @Querytype=3
	SELECT * from State  where State_id=@State_id



END







' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Store]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		Gayathri 
-- Create date: 
-- Description:	Japan-Indians.com
-- =============================================
CREATE PROCEDURE [dbo].[sp_Store]
	-- Add the parameters for the stored procedure here
@s_id int,
@s_name varchar(500) ,
@s_address varchar(1000) ,
@s_city int  ,
@state_id int ,
@country_id int,
@s_zip varchar(500), 
@s_phone varchar(500),
@s_email varchar(500),
@s_website varchar(500),
@s_contact varchar(1000),
@map_link nvarchar(500),
@s_image nvarchar(500),
@s_desc nvarchar(1000),
@cust_id int,
@Querytype int

AS
BEGIN
	
if @Querytype=1
    	SELECT * from store order by s_name

else if @Querytype=2
	begin
		if @state_id='''' and @s_city<>'''' 		
			SELECT * from store  where s_city=@s_city

        else if @state_id='''' and @s_city=''''
			select * from store

		else if @state_id<>'''' and @s_city<>'''' 
			select * from store where state_id=@state_id and s_city=@s_city

		else if @state_id<>'''' and @s_city='''' 
			select * from store where state_id=@state_id 

	End

else if @Querytype=3
		insert into store(s_name
      ,s_address
      ,s_city
      ,state_id
      ,country_id
      ,s_zip
      ,s_phone
      ,s_email
      ,s_website
      ,s_contact
      ,map_link
      ,s_image
      ,cust_id
      ,s_desc)
	  values(@s_name
      ,@s_address
      ,@s_city
      ,@state_id
      ,@country_id
      ,@s_zip
      ,@s_phone
      ,@s_email
      ,@s_website
      ,@s_contact
      ,@map_link
      ,@s_image
      ,@cust_id
      ,@s_desc)

else if @Querytype=4
	select max(s_id)+1 from store
END









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[DeleteHierarchyForum]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE                           PROC [dbo].[DeleteHierarchyForum]
(
	@Root int,
	@ArticleId int
)
AS
BEGIN

if not exists (select name from [dbo].[sysobjects] where name like ''TempTable%'')  
create table TempTable (Id int, ParentId int,ArticleId int, Title nVarchar(250),username nvarchar(50),UserEmail nvarchar(50),Description nvarchar(2000),Indent int,DateAdded datetime,UserProfile nvarchar(100))


	SET NOCOUNT ON
	DECLARE @CID int, @PID int, @Title varchar(250)

	--''SET @Title = (SELECT Title FROM CP_FORUM_Comments WHERE CP_FORUM_Comments.ID = @Root and CP_FORUM_Comments.ArticleId = @ArticleId)--, NestLevel int
	--''SET @PId =  (SELECT ParentID FROM CP_FORUM_Comments  WHERE CP_FORUM_Comments.ID = @Root and CP_FORUM_Comments.ArticleId = @ArticleId)-- @@NESTLEVEL * 4 

	insert into TempTable SELECT CP_FORUM_Comments.Id , ParentId ,ArticleId , Title,username ,UserEmail ,Description ,Indent ,DateAdded ,UserProfile  from CP_FORUM_Comments WHERE ID = @Root and ArticleId = @ArticleId 

	SET @CID = (SELECT MAX(ID) FROM CP_FORUM_Comments  WHERE ParentID = @Root)
	
	WHILE @CID IS NOT NULL
	BEGIN
		EXEC dbo.DeleteHierarchyForum @CID, @ArticleId
		SET @CID = (SELECT MAX(ID) FROM CP_FORUM_Comments  WHERE ParentID = @Root AND ID < @CID and ArticleId = @ArticleId)


	END
END

if @@NESTLEVEL =1 
Delete from CP_FORUM_Comments where CP_FORUM_Comments.Id in (select ID from TempTable)





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[ShowHierarchyForum]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'


CREATE                          PROC [dbo].[ShowHierarchyForum]
(
	@Root int,
	@ArticleId int
)
AS
BEGIN

if not exists (select name from [dbo].[sysobjects] where name like ''TempTable%'')  
create table TempTable (Id int, ParentId int,ArticleId int, Title nVarchar(250),username nvarchar(50),UserEmail nvarchar(50),Description nvarchar(2000),Indent int,DateAdded datetime,UserProfile nvarchar(100), CommentType tinyint)


	SET NOCOUNT ON
	DECLARE @CID int, @PID int, @Title varchar(250)

	insert into TempTable SELECT CP_FORUM_Comments.Id , ParentId ,ArticleId , Title,username ,UserEmail ,Description ,Indent ,DateAdded ,UserProfile, CommentType  from CP_FORUM_Comments WHERE ID = @Root and ArticleId = @ArticleId 

	SET @CID = (SELECT MAX(ID) FROM CP_FORUM_Comments  WHERE ParentID = @Root)
	
	WHILE @CID IS NOT NULL
	BEGIN
		EXEC dbo.ShowHierarchyForum @CID, @ArticleId
		SET @CID = (SELECT MAX(ID) FROM CP_FORUM_Comments  WHERE ParentID = @Root AND ID < @CID and ArticleId = @ArticleId)


	END
END

if @@NESTLEVEL =1 
select * from TempTable

' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_prod]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'











-- =============================================
-- Author:		Gayathri 
-- Create date: 
-- Description:	Japan-Indians.com
-- =============================================
CREATE PROCEDURE [dbo].[sp_prod]
	-- Add the parameters for the stored procedure here
	@prod_id   int  ,
	@prod_name   nvarchar (50)  ,
	@prod_desc   nvarchar (1000)  ,
	@prod_price   nvarchar (50)  ,
	@prod_cat   int   ,
	@prod_largeimage   nvarchar (50)  ,
	@cust_id   int   ,
	@last_day_togo   datetime   ,
	@prod_pickup_address   nvarchar (500),
@prod_hide  Bit   ,
@state_id int,
@s_city int,
	@Querytype int

AS
BEGIN
	declare @str nvarchar(500)
if @Querytype=1
    	SELECT * from Resale_products where   prod_hide<>''true''

else if @Querytype=2
	SELECT * from Resale_products  where prod_id =@prod_id 

else if @Querytype=3
	delete from Resale_products  where prod_id =@prod_id 
	
else if @Querytype=4

		insert into Resale_products(prod_name
      , prod_desc
      , prod_price
      , prod_cat
      , prod_largeimage
      , cust_id
      , last_day_togo
      , prod_pickup_address,prod_hide)
		values(@prod_name
      ,@prod_desc
      ,@prod_price
      ,@prod_cat
      ,@prod_largeimage
      ,@cust_id
      ,@last_day_togo
      ,@prod_pickup_address,@prod_hide)
	

else if @Querytype=5
	select max(prod_id )+1 from Resale_products

else if @Querytype=6

begin
		if @state_id=0 and @s_city<>0 		
			
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where Customers.Cust_city=@s_city and prod_hide<>''true''

        else if @state_id=0 and @s_city=0
			
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = -1 where  prod_hide<>''true''


		else if @state_id<>0 and @s_city<>0 
			
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where Customers.Cust_state=@state_id and Customers.Cust_city=@s_city  and prod_hide<>''true''

		else if @state_id<>0 and @s_city=0 
			
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where Customers.Cust_state=@state_id  and prod_hide<>''true''

	End

else if @Querytype=7
	SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where Resale_Products.Cust_id=@cust_id  


else if @Querytype=8

begin
		if @state_id=0 	
			
					
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where prod_hide<>''true''


        else if @state_id=0 and @s_city=0
			
					
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where prod_hide<>''true''

		else if @state_id=0 and @s_city=''''
			
					
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where prod_hide<>''true''

		else if @state_id>0 and @s_city>0 
			
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where Customers.Cust_state=@state_id and Customers.Cust_city=@s_city  and prod_hide<>''true''

		else if @state_id>0 and @s_city=0 
			
					SELECT     Customers.*, Resale_Products.*
					FROM         Customers INNER JOIN
                    Resale_Products ON Customers.Cust_id = Resale_Products.cust_id
					where Customers.Cust_state=@state_id   and prod_hide<>''true''


	End


	
else if @Querytype=9
	begin
			 if @prod_cat<>''''
					update Resale_products set prod_name=@prod_name
				  , prod_desc=@prod_desc
				  , prod_price=@prod_price
				  , prod_cat=@prod_cat
				  , prod_largeimage=@prod_largeimage
				  , cust_id=@cust_id
				  , last_day_togo=@last_day_togo
				  , prod_pickup_address=@prod_pickup_address,prod_hide=@prod_hide where prod_id=@prod_id
				
			else
			update Resale_products set prod_name=@prod_name
				  , prod_desc=@prod_desc
				  , prod_price=@prod_price
						, prod_largeimage=@prod_largeimage
				  , cust_id=@cust_id
				  , last_day_togo=@last_day_togo
				  , prod_pickup_address=@prod_pickup_address,prod_hide=@prod_hide where prod_id=@prod_id
				
	END
else if @Querytype=10
		begin
		set @str=''SELECT     Customers.*, Resale_Products.*	FROM Customers INNER JOIN  Resale_Products ON Customers.Cust_id = Resale_Products.cust_id where Resale_Products.prod_id in ('' + @prod_name + '');''
		--set @str = ''select * from resale_products where prod_id in ('' + @prod_name + '');''
		EXEC SP_EXECutesql @str
		end
else if @Querytype=11
begin
		set @str=''SELECT     Customers.*, Resale_Products.*	FROM Customers INNER JOIN  Resale_Products ON Customers.Cust_id = Resale_Products.cust_id where prod_name like  '' + ''''''%'' + @prod_name + ''%''''''
		--set @str = ''select * from resale_products where prod_id in ('' + @prod_name + '');''
		EXEC SP_EXECutesql @str
		end
End














' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_City]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'

-- =============================================
-- Author:		Gayathri 
-- Create date: 
-- Description:	Japan-Indians.com
-- =============================================
CREATE PROCEDURE [dbo].[sp_City]
	-- Add the parameters for the stored procedure here
	@City_id int,
	@Country_id int,
	@City_name nvarchar(50) ,
	@State_id int,
	@Querytype int

AS
BEGIN
	
if @Querytype=1
    	SELECT * from City order by city_name

else if @Querytype=2
	SELECT * from City  where City_id=@City_id



END





' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_prod_cat]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'






-- =============================================
-- Author:		Gayathri 
-- Create date: 
-- Description:	Japan-Indians.com
-- =============================================
Create PROCEDURE [dbo].[sp_prod_cat]
	-- Add the parameters for the stored procedure here
	@prod_cat_id   int  ,
	@cat_name   nvarchar (50)  ,
	@cat_desc   nvarchar (1000)  ,
	@cust_id   int   ,
	
	@Querytype int

AS
BEGIN
	
if @Querytype=1
    	SELECT * from prod_cat 

else if @Querytype=2
	SELECT * from prod_cat  where prod_cat_id =@prod_cat_id 

else if @Querytype=3
	delete from prod_cat  where prod_cat_id =@prod_cat_id 
	
else if @Querytype=4

		insert into prod_cat(cat_name
      , cat_desc
      , cust_id
      )
		values(@cat_name
      ,@cat_desc      
      ,@cust_id
     )
	

else if @Querytype=5
	select max(prod_cat_id )+1 from prod_cat


END









' 
END
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[sp_Customers]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'




-- =============================================
-- Author:		Gayathri 
-- Create date: 
-- Description:	Japan-Indians.com
-- =============================================
CREATE PROCEDURE [dbo].[sp_Customers]
	-- Add the parameters for the stored procedure here
	@Cust_id int,
	@Cust_name nvarchar(50) ,
	@Cust_email nvarchar(50), 
	@Cust_Country int,
	@Cust_City int ,
	@Cust_State int ,
	@Cust_Address nvarchar(1000),
	@Cust_CellNumber nvarchar(50),
	@Cust_Password nvarchar(50),
	@Cust_picture nvarchar(50),
	@Querytype int

AS
BEGIN
	declare @str nvarchar(500)
if @Querytype=1
    	SELECT * from Customers 

else if @Querytype=2
	SELECT * from Customers  where Cust_id=@Cust_id

else if @Querytype=3
	delete from Customers  where Cust_id=@Cust_id
	
else if @Querytype=4

		insert into Customers(Cust_name
		  ,Cust_email
		  ,Cust_Password
		  ,Cust_Country
		  ,Cust_State
		  ,Cust_City
		  ,Cust_Address
		  ,Cust_CellNumber,Cust_picture)
		values(@Cust_name
	   , @Cust_email
	   , @Cust_Password
	   , @Cust_Country
	   , @Cust_State
	   , @Cust_City
	   , @Cust_Address
	   , @Cust_CellNumber,@Cust_picture)
	

else if @Querytype=5
Begin
	if @Cust_Password <> ''''
		Begin
			If @Cust_picture <> ''''
			  update Customers set Cust_name=@Cust_name
			  ,Cust_email=@Cust_email
			  ,Cust_Password=@Cust_Password
			  ,Cust_Country=@Cust_Country
			  ,Cust_State=@Cust_State
			  ,Cust_City=@Cust_City
			  ,Cust_Address=@Cust_Address
			  ,Cust_CellNumber=@Cust_CellNumber,Cust_picture=@Cust_picture where Cust_id=@Cust_Id
			else
				update Customers set Cust_name=@Cust_name
			  ,Cust_email=@Cust_email
			  ,Cust_Password=@Cust_Password
			  ,Cust_Country=@Cust_Country
			  ,Cust_State=@Cust_State
			  ,Cust_City=@Cust_City
			  ,Cust_Address=@Cust_Address
			  ,Cust_CellNumber=@Cust_CellNumber where Cust_id=@Cust_Id
		End
	else
		Begin
			If @Cust_picture <> ''''
			update Customers set Cust_name=@Cust_name
			  ,Cust_email=@Cust_email      
			  ,Cust_Country=@Cust_Country
			  ,Cust_State=@Cust_State
			  ,Cust_City=@Cust_City
			  ,Cust_Address=@Cust_Address
			  ,Cust_CellNumber=@Cust_CellNumber,Cust_picture=@Cust_picture  where Cust_id=@Cust_Id
			else				
			update Customers set Cust_name=@Cust_name
			  ,Cust_email=@Cust_email      
			  ,Cust_Country=@Cust_Country
			  ,Cust_State=@Cust_State
			  ,Cust_City=@Cust_City
			  ,Cust_Address=@Cust_Address
			  ,Cust_CellNumber=@Cust_CellNumber where Cust_id=@Cust_Id
		End
End

else if @Querytype=6
	select max(Cust_id)+1 from Customers

else if @Querytype=7
	SELECT * from Customers  where Cust_email=@Cust_email and Cust_password=@Cust_password


else if @Querytype=8
	begin
		if @cust_state=0 		
			SELECT * from customers 

        else if @cust_state>0 and @cust_city=0
			select * from customers where cust_state=@cust_state

		else if @cust_state>0 and @cust_city>0 
			select * from customers where cust_state=@cust_state and cust_city=@cust_city

	

	End

else if @Querytype=9
	Select * from customers where cust_email=@cust_email
else if @Querytype=10
begin
		set @str=''SELECT * from Customers where Cust_name like  '' + ''''''%'' + @cust_name + ''%''''  or Cust_email like  '' + ''''''%'' + @cust_name + ''%''''''
		
		EXEC SP_EXECutesql @str
		end
	
END








' 
END

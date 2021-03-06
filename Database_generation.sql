USE [softtehnica]
GO
/****** Object:  Table [dbo].[client]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstname] [nvarchar](50) NULL,
	[lastname] [nvarchar](50) NULL,
	[email] [varchar](50) NOT NULL,
 CONSTRAINT [PK_client] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[location]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[location](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[location_name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_location] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[order]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[order](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [datetime] NOT NULL,
	[comment] [nvarchar](500) NULL,
	[clientid] [int] NOT NULL,
	[operatorid] [int] NOT NULL,
	[locationid] [int] NOT NULL,
 CONSTRAINT [PK_order] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[orderitems]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[orderitems](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[orderid] [int] NOT NULL,
	[productid] [int] NOT NULL,
 CONSTRAINT [PK_orderitems] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[product]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[price] [money] NOT NULL,
 CONSTRAINT [PK_product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[role]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[role_name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_roles] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[user]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [nvarchar](50) NOT NULL,
	[username] [varchar](50) NOT NULL,
	[password] [nvarchar](100) NOT NULL,
	[email] [varchar](50) NULL,
	[roleid] [int] NOT NULL,
 CONSTRAINT [PK_operator] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[v_ClientGlobalActivity]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_ClientGlobalActivity] as 
SELECT
	--TOP(1)
	O.[clientid],
	C.firstname,
	C.lastname,
	COUNT(O.id) as no_visits
FROM [dbo].[order] O
INNER JOIN [dbo].[client] C on O.clientid = C.id
GROUP BY O.[clientid],
	C.firstname,
	C.lastname
	--ORDER BY COUNT(O.id) desc

GO
/****** Object:  View [dbo].[v_ClientLocationActivity]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_ClientLocationActivity] as
SELECT
	O.[clientid],
	O.locationid,
	C.firstname,
	C.lastname,
	C.email,
	COUNT(O.id) as no_visits
FROM [dbo].[order] O
INNER JOIN location L on L.id = O.locationid
INNER JOIN client C on C.id = O.clientid
GROUP BY O.[clientid],
		O.locationid,
		C.firstname,
		C.lastname,
		C.email
--ORDER BY COUNT(O.id) desc
GO
/****** Object:  View [dbo].[v_OrderProducts]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_OrderProducts] AS
SELECT
	O.[id] as orderid,
    O.[date],
    O.[comment],
    O.[clientid],
    O.[operatorid],
    O.[locationid],
	oi.id as orderitemid,
	p.id as productid,
	P.name, 
	P.price
FROM [dbo].[order] O
INNER JOIN [dbo].[orderitems] OI on O.id = OI.orderid
INNER JOIN [dbo].[product] P on P.id = OI.productid
GO
/****** Object:  View [dbo].[v_OrderTotals]    Script Date: 5/3/2016 12:23:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[v_OrderTotals] as
SELECT
	L.id,
	L.[location_name],
	SUM(isnull(P.price, 0)) as Total
FROM [dbo].[location] L
LEFT JOIN [dbo].[order] O on O.locationid = L.id
LEFT JOIN [dbo].[orderitems] OI on OI.orderid = O.id
LEFT JOIN [dbo].[product] P on P.[id] = OI.[productid]
GROUP BY L.id, L.[location_name]


GO
SET IDENTITY_INSERT [dbo].[client] ON 

GO
INSERT [dbo].[client] ([id], [firstname], [lastname], [email]) VALUES (14, N'Ion', N'Marius', N'ion.marius@softtehnica.ro')
GO
INSERT [dbo].[client] ([id], [firstname], [lastname], [email]) VALUES (15, N'Mihai', N'Barbu', N'mihai.barbu@gmail.com')
GO
INSERT [dbo].[client] ([id], [firstname], [lastname], [email]) VALUES (16, N'Claudiu', N'Ionescu', N'ionescu@yahoo.com')
GO
INSERT [dbo].[client] ([id], [firstname], [lastname], [email]) VALUES (17, N'Aurel', N'Popescu', N'aurel.popescu@gmail.com')
GO
INSERT [dbo].[client] ([id], [firstname], [lastname], [email]) VALUES (18, N'Dan', N'Dinu', N'dandinu@yahoo.com')
GO
INSERT [dbo].[client] ([id], [firstname], [lastname], [email]) VALUES (20, N'Nicu', N'Radu', N'nicu.radu@facebook.com')
GO
SET IDENTITY_INSERT [dbo].[client] OFF
GO
SET IDENTITY_INSERT [dbo].[location] ON 

GO
INSERT [dbo].[location] ([id], [location_name]) VALUES (1, N'Tratoria')
GO
INSERT [dbo].[location] ([id], [location_name]) VALUES (2, N'Switch.eat')
GO
INSERT [dbo].[location] ([id], [location_name]) VALUES (3, N'Calif')
GO
INSERT [dbo].[location] ([id], [location_name]) VALUES (4, N'Dristor')
GO
INSERT [dbo].[location] ([id], [location_name]) VALUES (10, N'Pizza Hut')
GO
INSERT [dbo].[location] ([id], [location_name]) VALUES (11, N'Presto')
GO
INSERT [dbo].[location] ([id], [location_name]) VALUES (12, N'KFC')
GO
SET IDENTITY_INSERT [dbo].[location] OFF
GO
SET IDENTITY_INSERT [dbo].[order] ON 

GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (6, CAST(N'2016-04-30 14:39:52.833' AS DateTime), NULL, 14, 2, 2)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (7, CAST(N'2016-04-30 15:03:37.370' AS DateTime), NULL, 14, 2, 3)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (8, CAST(N'2016-04-30 16:34:50.470' AS DateTime), NULL, 14, 2, 3)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (9, CAST(N'2016-04-30 16:40:36.173' AS DateTime), NULL, 14, 2, 3)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (10, CAST(N'2016-05-02 14:54:28.977' AS DateTime), NULL, 14, 2, 1)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (11, CAST(N'2016-05-02 14:54:39.970' AS DateTime), NULL, 14, 2, 1)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (15, CAST(N'2016-05-02 15:44:28.507' AS DateTime), NULL, 18, 2, 3)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (16, CAST(N'2016-05-02 15:44:32.163' AS DateTime), NULL, 16, 2, 3)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (19, CAST(N'2016-05-02 23:12:15.227' AS DateTime), NULL, 17, 2, 4)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (21, CAST(N'2016-05-02 23:21:41.537' AS DateTime), NULL, 16, 2, 3)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (22, CAST(N'2016-05-03 11:01:01.063' AS DateTime), NULL, 16, 2, 4)
GO
INSERT [dbo].[order] ([id], [date], [comment], [clientid], [operatorid], [locationid]) VALUES (23, CAST(N'2016-05-03 12:01:01.867' AS DateTime), NULL, 20, 2, 4)
GO
SET IDENTITY_INSERT [dbo].[order] OFF
GO
SET IDENTITY_INSERT [dbo].[orderitems] ON 

GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (29, 6, 9)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (30, 6, 9)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (31, 7, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (32, 7, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (33, 7, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (34, 8, 2)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (35, 8, 3)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (36, 8, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (37, 8, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (38, 9, 3)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (39, 9, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (40, 9, 3)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (41, 9, 1)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (42, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (43, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (44, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (45, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (46, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (47, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (48, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (49, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (50, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (51, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (52, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (53, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (54, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (55, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (56, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (57, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (58, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (59, 9, 7)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (60, 9, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (61, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (62, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (63, 9, 7)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (64, 9, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (65, 10, 2)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (66, 10, 6)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (67, 11, 5)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (71, 15, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (72, 16, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (77, 19, 3)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (81, 21, 7)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (82, 21, 8)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (83, 21, 9)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (84, 22, 4)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (85, 22, 3)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (86, 23, 6)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (87, 23, 6)
GO
INSERT [dbo].[orderitems] ([id], [orderid], [productid]) VALUES (88, 23, 4)
GO
SET IDENTITY_INSERT [dbo].[orderitems] OFF
GO
SET IDENTITY_INSERT [dbo].[product] ON 

GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (1, N'Ciorba de pui', 12.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (2, N'Ciorba de vita', 12.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (3, N'Piept de pui', 15.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (4, N'Cartofi prajiti', 5.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (5, N'Paine', 2.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (6, N'Salata varza', 6.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (7, N'Mamaliguta cu branza si smantana', 15.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (8, N'Coca-cola', 8.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (9, N'Hamburger', 18.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (10, N'Bere', 7.0000)
GO
INSERT [dbo].[product] ([id], [name], [price]) VALUES (11, N'Apa plata', 4.0000)
GO
SET IDENTITY_INSERT [dbo].[product] OFF
GO
SET IDENTITY_INSERT [dbo].[role] ON 

GO
INSERT [dbo].[role] ([id], [role_name]) VALUES (1, N'Operator')
GO
INSERT [dbo].[role] ([id], [role_name]) VALUES (2, N'Management')
GO
SET IDENTITY_INSERT [dbo].[role] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

GO
INSERT [dbo].[user] ([id], [name], [username], [password], [email], [roleid]) VALUES (2, N'operator@softtehnica.ro', N'operator@softtehnica.ro', N'ACMe9SyfyUQoY5K0JWwav99pROH68rMpWc3RdERyJAZ7WBHTzCYdcW5uPKPl1EpRHQ==', N'operator@softtehnica.ro', 1)
GO
INSERT [dbo].[user] ([id], [name], [username], [password], [email], [roleid]) VALUES (7, N'not implemented yet', N'manager@softtehnica.ro', N'ACMe9SyfyUQoY5K0JWwav99pROH68rMpWc3RdERyJAZ7WBHTzCYdcW5uPKPl1EpRHQ==', N'manager@softtehnica.ro', 2)
GO
SET IDENTITY_INSERT [dbo].[user] OFF
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_client] FOREIGN KEY([clientid])
REFERENCES [dbo].[client] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_client]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_location] FOREIGN KEY([locationid])
REFERENCES [dbo].[location] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_location]
GO
ALTER TABLE [dbo].[order]  WITH CHECK ADD  CONSTRAINT [FK_order_operator] FOREIGN KEY([operatorid])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[order] CHECK CONSTRAINT [FK_order_operator]
GO
ALTER TABLE [dbo].[orderitems]  WITH CHECK ADD  CONSTRAINT [FK_orderitems_order] FOREIGN KEY([orderid])
REFERENCES [dbo].[order] ([id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[orderitems] CHECK CONSTRAINT [FK_orderitems_order]
GO
ALTER TABLE [dbo].[orderitems]  WITH CHECK ADD  CONSTRAINT [FK_orderitems_product] FOREIGN KEY([productid])
REFERENCES [dbo].[product] ([id])
GO
ALTER TABLE [dbo].[orderitems] CHECK CONSTRAINT [FK_orderitems_product]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_role] FOREIGN KEY([roleid])
REFERENCES [dbo].[role] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_role]
GO

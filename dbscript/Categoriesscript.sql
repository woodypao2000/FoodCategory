USE [db01]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[DisplayOrder] [int] NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (1, N'茶凍', 1)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (2, N'水果茶', 2)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (3, N'咖啡', 3)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (4, N'乳清', 4)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (5, N'可樂', 5)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (6, N'啤酒', 6)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (7, N'美味沙茶牛肉', 7)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (9, N'胖老爹炸雞桶', 9)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (10, N'海陸雙響披薩', 11)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (12, N'海鮮義大利麵', 12)
INSERT [dbo].[Categories] ([Id], [Name], [DisplayOrder]) VALUES (13, N'牛肉飯糰加辣', 12)
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO

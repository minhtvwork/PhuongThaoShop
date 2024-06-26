USE [PTS_DEV]
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (1, N'Administrator', N'Admin', N'ADMIN', N'1')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (2, N'Employee', N'Employee', N'EMPLOYEE', N'1')
INSERT [dbo].[Roles] ([Id], [Description], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (3, N'Customer', N'Customer', N'CUSTOMER', N'1')
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FullName], [Address], [BirthDay], [DefaultActionId], [Notes], [AvatarPath], [IsEnabled], [LastTimeChangePass], [LastTimeLogin], [CrDateTime], [Status], [RoleEntitiesId], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (1, N'Administrator', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'admin', N'ADMIN', N'admin@phuongthaoshop.vn', N'ADMIN@PHUONGTHAOSHOP.VN', 0, N'AQAAAAIAAYagAAAAEOMsjFecv9A9qyXLxhMZRqKjQ7z3bDfsqQZ5itJYNDr7qLjTcp+8SCQZXdB4t3wOJA==', N'phuongthaoshop.vn', N'phuongthaoshop.vn', NULL, 0, 0, NULL, 0, 0)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[CardVGA] ON 

INSERT [dbo].[CardVGA] ([Id], [Ma], [Ten], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'AMD Radeon Graphics', N'AMD Radeon Graphics', N'4GB', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[CardVGA] OFF
GO
SET IDENTITY_INSERT [dbo].[Color] ON 

INSERT [dbo].[Color] ([Id], [Ma], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'
black', N'Màu đen', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Color] ([Id], [Ma], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (2, N'
white', N'Màu trắng', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Color] ([Id], [Ma], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (3, N'silver', N'Màu bạc', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Color] ([Id], [Ma], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (5, N'grey', N'Màu xám', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Color] OFF
GO
SET IDENTITY_INSERT [dbo].[CPU] ON 

INSERT [dbo].[CPU] ([Id], [Ma], [Ten], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'Core i5-13500HX', N'Core i5-13500HX', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[CPU] ([Id], [Ma], [Ten], [CrUserId], [CrDateTime], [Status]) VALUES (2, N'Core i5-13420H', N'Core i5-13420H', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[CPU] OFF
GO
SET IDENTITY_INSERT [dbo].[HardDrive] ON 

INSERT [dbo].[HardDrive] ([Id], [Ma], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'SSD256-PT', N'256 GB', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[HardDrive] OFF
GO
SET IDENTITY_INSERT [dbo].[Ram] ON 

INSERT [dbo].[Ram] ([Id], [Ma], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (2, N'DDR4-PM', N'8GB', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Ram] ([Id], [Ma], [ThongSo], [CrUserId], [CrDateTime], [Status]) VALUES (3, N'DDR5-PM16', N'16GB DDR5', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Ram] OFF
GO
SET IDENTITY_INSERT [dbo].[Screen] ON 

INSERT [dbo].[Screen] ([Id], [Ma], [KichCo], [TanSo], [ChatLieu], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'PM-16K', N'15.6"', N'144Hz', N'IPS', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Screen] OFF
GO
SET IDENTITY_INSERT [dbo].[Manufacturer] ON 

INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'Laptop Dell', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (2, N'Laptop Acer', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (3, N'Laptop HP', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (5, N'Laptop Asus', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (6, N'Laptop Gigabyte', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (7, N'Laptop Lenovo', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (8, N'Laptop MSI', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[Manufacturer] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (9, N'LaptopSamsung', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[Manufacturer] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductType] ON 

INSERT [dbo].[ProductType] ([Id], [Name], [CrUserId], [CrDateTime], [Status]) VALUES (1, N'Laptop Gaming', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[ProductType] OFF
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([Id], [Name], [CrUserId], [CrDateTime], [Status], [ManufacturerEntityId], [ProductTypeEntityId]) VALUES (1, N'Dell Alienware', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1, 1, 1)
INSERT [dbo].[Product] ([Id], [Name], [CrUserId], [CrDateTime], [Status], [ManufacturerEntityId], [ProductTypeEntityId]) VALUES (2, N'Dell XPS 15', 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1, 1, 1)
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
SET IDENTITY_INSERT [dbo].[ProductDetail] ON 

INSERT [dbo].[ProductDetail] ([Id], [Code], [Price], [OldPrice], [Image1], [Image2], [Image3], [Image4], [Image5], [Image6], [Upgrade], [Description], [ProductEntityId], [ColorEntityId], [RamEntityId], [CpuEntityId], [HardDriveEntityId], [ScreenEntityId], [CardVGAEntityId], [CrUserId], [CrDateTime], [Status]) VALUES (4, N'5430', CAST(20000000.00 AS Decimal(18, 2)), CAST(25000000.00 AS Decimal(18, 2)), NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'', 1, 1, 2, 1, 1, 1, 1, 1, CAST(N'2024-06-16T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[ProductDetail] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (1, 1)
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240616070106_InitDb', N'8.0.0')
GO

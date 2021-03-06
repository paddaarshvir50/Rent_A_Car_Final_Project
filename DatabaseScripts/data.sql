SET IDENTITY_INSERT [dbo].[Car] ON
INSERT INTO [dbo].[Car] ([Id], [Make], [Model], [RentPricePerDay], [Booked], [Picture], [RegistrationId]) VALUES (1, N'TOYOTA', N'MARK X ', CAST(80.00 AS Decimal(18, 2)), 1, N'TOYOTA_MARK_X.jpg', N'HHT894')
INSERT INTO [dbo].[Car] ([Id], [Make], [Model], [RentPricePerDay], [Booked], [Picture], [RegistrationId]) VALUES (2, N'Audi', N'r8', CAST(90.00 AS Decimal(18, 2)), 1, N'audi_r8.jpg', N'WDC456')
INSERT INTO [dbo].[Car] ([Id], [Make], [Model], [RentPricePerDay], [Booked], [Picture], [RegistrationId]) VALUES (3, N'BMW ', N'Series', CAST(95.00 AS Decimal(18, 2)), 0, N'bmw.jpg', N'GHT234')
INSERT INTO [dbo].[Car] ([Id], [Make], [Model], [RentPricePerDay], [Booked], [Picture], [RegistrationId]) VALUES (4, N'Ford', N'Mustang', CAST(85.00 AS Decimal(18, 2)), 0, N'ford_mustang.jpg', N'RTY894')
SET IDENTITY_INSERT [dbo].[Car] OFF
SET IDENTITY_INSERT [dbo].[Customer] ON
INSERT INTO [dbo].[Customer] ([Id], [Email], [Name], [ContactNumber]) VALUES (1, N'cus1@cars.com', N'James Harris', N'02134567890')
SET IDENTITY_INSERT [dbo].[Customer] OFF
SET IDENTITY_INSERT [dbo].[Booking] ON
INSERT INTO [dbo].[Booking] ([Id], [CustomerId], [CarId]) VALUES (5, 1, 1)
INSERT INTO [dbo].[Booking] ([Id], [CustomerId], [CarId]) VALUES (6, 1, 2)
SET IDENTITY_INSERT [dbo].[Booking] OFF
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'62298019-5031-45ab-97e1-8e0ea8c998a1', N'Customer', N'Customer', N'a2eeab78-de3e-4f5c-9f8a-e9206fa0040f')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e42d3953-3677-4b4c-97ab-b6bf3bad7676', N'Administrator', N'Administrator', N'9dc900d7-090a-4d37-a53c-eede101948f5')
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'25064ab2-6bd4-4784-b7ef-d7c083b65c6f', N'admin@cars.com', N'ADMIN@CARS.COM', N'admin@cars.com', N'ADMIN@CARS.COM', 1, N'AQAAAAEAACcQAAAAEBK7cLhD6Q866IzXuwiC6PBIzMmw/OVeGvsJ67+tATdNIq3o8m5Y+9d4/neK7vAmrg==', N'QOHYJRZJDGDF6AZ67VYBIYHR6RG37ATN', N'91b7c744-8442-4527-8502-d19ee2b633e9', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9c20c246-b957-4c09-a37b-61a58a7d6bb3', N'cus1@cars.com', N'CUS1@CARS.COM', N'cus1@cars.com', N'CUS1@CARS.COM', 1, N'AQAAAAEAACcQAAAAEEnnNyPZAM2yTOyaVg43IoHXa9nXgo3kmGJmEzerD/x62UEALMr2sd0BzrrxKwoK8w==', N'PQH7KOKEW62LJBWFYNQZWXI3DFG3NWPJ', N'91638d09-cf50-45c2-8888-440daa17c5ef', NULL, 0, 0, NULL, 1, 0)
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9c20c246-b957-4c09-a37b-61a58a7d6bb3', N'62298019-5031-45ab-97e1-8e0ea8c998a1')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'25064ab2-6bd4-4784-b7ef-d7c083b65c6f', N'e42d3953-3677-4b4c-97ab-b6bf3bad7676')

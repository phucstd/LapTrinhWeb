USE [web_app]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'65f2f17e-f1c6-4d5a-ac7c-d4d6a11180b8', N'Member', N'MEMBER', NULL)
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'ba9ab140-0475-4538-88b9-20bda6c0fd39', N'Admin', N'ADMIN', NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Address]) VALUES (N'18dce081-40e0-4a51-b586-122e62b58050', N'admin@admin.com', N'ADMIN@ADMIN.COM', N'admin@admin.com', N'ADMIN@ADMIN.COM', 0, N'AQAAAAIAAYagAAAAEJ5Asu8EtctesjRZ8mQDXBRR4KJGuHR5P6B5hhUVWtXilKU8+poGl+ke9//jPgjqZA==', N'DX2QVCNPMQTIJY4JLUYCEFJVXT6MDAAG', N'05f34a88-d52a-4bc7-98cd-49b739a879c2', NULL, 0, 0, NULL, 1, 0, NULL, NULL, NULL)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount], [FirstName], [LastName], [Address]) VALUES (N'9ebbce02-a4a4-4496-9241-363b363d2dc8', N'phuc.nm01953@sinhvien.hoasen.edu.vn', N'PHUC.NM01953@SINHVIEN.HOASEN.EDU.VN', NULL, NULL, 0, N'AQAAAAIAAYagAAAAENafixfz6lqfBcAf5TpfCohYb8goee6mf1765qILsXQgGnxwEB3g71K8lungr+Sl6A==', N'2TMOVT6PF2OUGA7LJVYW5MIIKDZ3EP63', N'9d65166c-3d6d-41ee-8cff-c05236de5211', NULL, 0, 0, NULL, 1, 0, N'Default', N'Version', N'123 HCM')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'18dce081-40e0-4a51-b586-122e62b58050', N'ba9ab140-0475-4538-88b9-20bda6c0fd39')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9ebbce02-a4a4-4496-9241-363b363d2dc8', N'ba9ab140-0475-4538-88b9-20bda6c0fd39')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description], [ImagePath]) VALUES (1, N'Top', N'Discover our collection of stylish tops, perfect for any occasion! From casual tees to elegant blouses, our variety will elevate your wardrobe. Mix and match to create looks that express your unique style.', N'content/images/t-shirts-img.jpg')
INSERT [dbo].[Categories] ([Id], [Name], [Description], [ImagePath]) VALUES (2, N'Bottom', N'Shop our range of bottoms, featuring everything from comfy jeans to chic skirts. Whether you’re dressing up or keeping it casual, our diverse selection ensures you''ll find the perfect fit for any look.', N'content/images/shirt-img.jpg')
INSERT [dbo].[Categories] ([Id], [Name], [Description], [ImagePath]) VALUES (3, N'Accessory', N'Complete your outfit with our stunning accessories! From statement jewelry to trendy bags and scarves, our curated pieces add that extra flair, making every outfit stand out. Elevate your style with the perfect finishing touches!', N'content/images/wallet-img.jpg')
INSERT [dbo].[Categories] ([Id], [Name], [Description], [ImagePath]) VALUES (4, N'Cloth', N'Explore our premium selection of fabrics and textiles, perfect for DIY projects or custom creations. Whether you''re looking for soft cottons, luxurious silks, or vibrant prints, our quality materials inspire your creativity and help you bring your fashion visions to life.', N'content/images/women-bag-img.jpg')
INSERT [dbo].[Categories] ([Id], [Name], [Description], [ImagePath]) VALUES (5, N'Shoes', N'Shop our range of bottoms, featuring everything from comfy jeans to chic skirts. Whether you’re dressing up or keeping it casual, our diverse selection ensures you''ll find the perfect fit for any look.', N'content/images/shoes-img.jpg')
INSERT [dbo].[Categories] ([Id], [Name], [Description], [ImagePath]) VALUES (6, N'Bag', N'Discover our collection of stylish tops, perfect for any occasion! From casual tees to elegant blouses, our variety will elevate your wardrobe. Mix and match to create looks that express your unique style.', N'content/images/women-bag-img.jpg')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (1, N'Classic White Tee', N'A versatile staple for every wardrobe. Soft, breathable cotton makes this tee perfect for layering or wearing on its own.', N'content/images/classic_white_tee.jpg', 1, 19.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (2, N'Boho-Chic Blouse', N'Flowing and stylish, this blouse features delicate embroidery and bell sleeves, perfect for a casual day out.', N'content/images/classic_white_tee.jpg', 1, 34.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (3, N'Graphic Print Tank', N'Make a statement with this bold graphic tank. Ideal for warm days or layering under your favorite jacket.', N'content/images/classic_white_tee.jpg', 1, 24.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (4, N'Cozy Knit Sweater', N'Stay warm and stylish with this soft knit sweater, featuring a relaxed fit and ribbed cuffs.', N'content/images/classic_white_tee.jpg', 1, 49.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (5, N'Elegant Silk Camisole', N'Luxurious silk camisole that drapes beautifully. Perfect for layering or wearing on its own for a night out.', N'content/images/classic_white_tee.jpg', 1, 39.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (6, N'Classic Denim Jeans', N'Timeless denim jeans with a flattering fit, perfect for any casual occasion.', N'content/images/classic_white_tee.jpg', 2, 49.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (7, N'A-Line Skirt', N'Flirty A-line skirt that flows beautifully, ideal for both casual outings and dressed-up events.', N'content/images/classic_white_tee.jpg', 2, 34.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (8, N'Tailored Trousers', N'Chic and professional tailored trousers that elevate your office attire with a modern touch.', N'content/images/classic_white_tee.jpg', 2, 59.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (9, N'Comfy Joggers', N'Perfect for lounging or running errands, these joggers combine style and comfort in soft fabric.', N'content/images/classic_white_tee.jpg', 2, 29.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (10, N'Stylish Culottes', N'Trendy culottes that offer a unique look while providing comfort and versatility for any outfit.', N'content/images/classic_white_tee.jpg', 2, 39.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (11, N'Statement Necklace', N'Bold statement necklace that adds a touch of glamour to any outfit. Perfect for special occasions.', N'content/images/classic_white_tee.jpg', 3, 29.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (12, N'Trendy Crossbody Bag', N'Sleek crossbody bag designed for both style and functionality, perfect for on-the-go days.', N'content/images/classic_white_tee.jpg', 3, 49.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (13, N'Soft Scarf', N'Cozy and chic scarf made from premium materials, ideal for keeping warm and stylish.', N'content/images/classic_white_tee.jpg', 3, 19.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (14, N'Classic Watch', N'Timeless watch that combines elegance with functionality. A must-have accessory for every wardrobe.', N'content/images/classic_white_tee.jpg', 3, 89.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (15, N'Stylish Sunglasses', N'Trendsetting sunglasses that protect your eyes while keeping you stylish on sunny days.', N'content/images/classic_white_tee.jpg', 3, 39.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (16, N'Casual Summer Dress', N'Light and breezy summer dress perfect for warm days. Features a flattering silhouette and vibrant colors.', N'content/images/classic_white_tee.jpg', 4, 49.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (17, N'Elegant Evening Gown', N'Stunning evening gown that makes a statement at any formal event. Exquisite design and luxurious fabric.', N'content/images/classic_white_tee.jpg', 4, 149.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (18, N'Comfy Lounge Set', N'Perfect for relaxing at home, this lounge set is made from soft materials for ultimate comfort.', N'content/images/classic_white_tee.jpg', 4, 39.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (19, N'Tailored Blazer', N'Smart and sophisticated blazer that elevates any outfit, perfect for office wear or evening outings.', N'content/images/classic_white_tee.jpg', 4, 79.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (20, N'Cozy Hoodie', N'Perfect for chilly days, this hoodie offers comfort and style with a relaxed fit and soft fabric.', N'content/images/classic_white_tee.jpg', 4, 34.99)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[Orders] ON 

INSERT [dbo].[Orders] ([Id], [UserId], [Status], [CreatedAt]) VALUES (1, N'phuc.nm01953@sinhvien.hoasen.edu.vn', N'Ordered', CAST(N'2024-12-15T23:54:35.7555937' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Orders] OFF
GO
SET IDENTITY_INSERT [dbo].[OrderProducts] ON 

INSERT [dbo].[OrderProducts] ([Id], [ProductId], [OrderId], [Quantity], [Price]) VALUES (1, 2, 1, 10, 34.99)
SET IDENTITY_INSERT [dbo].[OrderProducts] OFF
GO

USE [web_app]
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (1, N'Top', N'Discover our collection of stylish tops, perfect for any occasion! From casual tees to elegant blouses, our variety will elevate your wardrobe. Mix and match to create looks that express your unique style.')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (2, N'Bottom', N'Shop our range of bottoms, featuring everything from comfy jeans to chic skirts. Whether you’re dressing up or keeping it casual, our diverse selection ensures you''ll find the perfect fit for any look.')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (3, N'Accessory', N'Complete your outfit with our stunning accessories! From statement jewelry to trendy bags and scarves, our curated pieces add that extra flair, making every outfit stand out. Elevate your style with the perfect finishing touches!')
INSERT [dbo].[Categories] ([Id], [Name], [Description]) VALUES (4, N'Cloth', N'Explore our premium selection of fabrics and textiles, perfect for DIY projects or custom creations. Whether you''re looking for soft cottons, luxurious silks, or vibrant prints, our quality materials inspire your creativity and help you bring your fashion visions to life.')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (4, N'Classic White Tee', N'A versatile staple for every wardrobe. Soft, breathable cotton makes this tee perfect for layering or wearing on its own.', N'~/content/images/classic_white_tee.jpg', 1, 19.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (5, N'Boho-Chic Blouse', N'Flowing and stylish, this blouse features delicate embroidery and bell sleeves, perfect for a casual day out.', N'~/content/images/boho_chic_blouse.jpg', 1, 34.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (6, N'Graphic Print Tank', N'Make a statement with this bold graphic tank. Ideal for warm days or layering under your favorite jacket.', N'~/content/images/graphic_print_tank.jpg', 1, 24.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (7, N'Cozy Knit Sweater', N'Stay warm and stylish with this soft knit sweater, featuring a relaxed fit and ribbed cuffs.', N'~/content/images/cozy_knit_sweater.jpg', 1, 49.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (8, N'Elegant Silk Camisole', N'Luxurious silk camisole that drapes beautifully. Perfect for layering or wearing on its own for a night out.', N'~/content/images/elegant_silk_camisole.jpg', 1, 39.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (9, N'Classic Denim Jeans', N'Timeless denim jeans with a flattering fit, perfect for any casual occasion.', N'~/content/images/classic_denim_jeans.jpg', 2, 49.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (10, N'A-Line Skirt', N'Flirty A-line skirt that flows beautifully, ideal for both casual outings and dressed-up events.', N'~/content/images/a_line_skirt.jpg', 2, 34.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (11, N'Tailored Trousers', N'Chic and professional tailored trousers that elevate your office attire with a modern touch.', N'~/content/images/tailored_trousers.jpg', 2, 59.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (12, N'Comfy Joggers', N'Perfect for lounging or running errands, these joggers combine style and comfort in soft fabric.', N'~/content/images/comfy_joggers.jpg', 2, 29.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (13, N'Stylish Culottes', N'Trendy culottes that offer a unique look while providing comfort and versatility for any outfit.', N'~/content/images/stylish_culottes.jpg', 2, 39.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (14, N'Statement Necklace', N'Bold statement necklace that adds a touch of glamour to any outfit. Perfect for special occasions.', N'~/content/images/statement_necklace.jpg', 3, 29.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (15, N'Trendy Crossbody Bag', N'Sleek crossbody bag designed for both style and functionality, perfect for on-the-go days.', N'~/content/images/trendy_crossbody_bag.jpg', 3, 49.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (16, N'Soft Scarf', N'Cozy and chic scarf made from premium materials, ideal for keeping warm and stylish.', N'~/content/images/soft_scarf.jpg', 3, 19.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (17, N'Classic Watch', N'Timeless watch that combines elegance with functionality. A must-have accessory for every wardrobe.', N'~/content/images/classic_watch.jpg', 3, 89.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (18, N'Stylish Sunglasses', N'Trendsetting sunglasses that protect your eyes while keeping you stylish on sunny days.', N'~/content/images/stylish_sunglasses.jpg', 3, 39.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (19, N'Casual Summer Dress', N'Light and breezy summer dress perfect for warm days. Features a flattering silhouette and vibrant colors.', N'~/content/images/casual_summer_dress.jpg', 4, 49.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (20, N'Elegant Evening Gown', N'Stunning evening gown that makes a statement at any formal event. Exquisite design and luxurious fabric.', N'~/content/images/elegant_evening_gown.jpg', 4, 149.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (21, N'Comfy Lounge Set', N'Perfect for relaxing at home, this lounge set is made from soft materials for ultimate comfort.', N'~/content/images/comfy_lounge_set.jpg', 4, 39.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (22, N'Tailored Blazer', N'Smart and sophisticated blazer that elevates any outfit, perfect for office wear or evening outings.', N'~/content/images/tailored_blazer.jpg', 4, 79.99)
INSERT [dbo].[Products] ([Id], [Name], [Description], [ImagePath], [CategoryId], [Price]) VALUES (23, N'Cozy Hoodie', N'Perfect for chilly days, this hoodie offers comfort and style with a relaxed fit and soft fabric.', N'~/content/images/cozy_hoodie.jpg', 4, 34.99)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241011092714_DBFirst', N'8.0.10')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20241018090557_DBFirst_1', N'8.0.10')
GO

USE [DemoProjectDb]
GO
SET IDENTITY_INSERT [dbo].[AbpLanguageTexts] ON 

GO
INSERT [dbo].[AbpLanguageTexts] ([Id], [CreationTime], [CreatorUserId], [Key], [LanguageName], [LastModificationTime], [LastModifierUserId], [Source], [TenantId], [Value]) VALUES (1, CAST(N'2021-03-04 15:38:15.4430000' AS DateTime2), NULL, N'HomePage', N'en', NULL, NULL, N'DemoProject', 2, N'Home page Tenant A')
GO
INSERT [dbo].[AbpLanguageTexts] ([Id], [CreationTime], [CreatorUserId], [Key], [LanguageName], [LastModificationTime], [LastModifierUserId], [Source], [TenantId], [Value]) VALUES (2, CAST(N'2021-03-04 15:38:15.5130000' AS DateTime2), NULL, N'HomePage', N'en', NULL, NULL, N'DemoProject', 3, N'Home page Tenant B')
GO
INSERT [dbo].[AbpLanguageTexts] ([Id], [CreationTime], [CreatorUserId], [Key], [LanguageName], [LastModificationTime], [LastModifierUserId], [Source], [TenantId], [Value]) VALUES (3, CAST(N'2021-03-04 15:38:15.5400000' AS DateTime2), NULL, N'HomePage', N'en', NULL, NULL, N'DemoProject', 4, N'Home page Tenant C')
GO
SET IDENTITY_INSERT [dbo].[AbpLanguageTexts] OFF
GO
SET IDENTITY_INSERT [dbo].[ConfigureRule] ON 

GO
INSERT [dbo].[ConfigureRule] ([Id], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [RuleForProperty], [SyntaxForProperty], [TenantId]) VALUES (4, CAST(N'2021-03-05 21:39:55.3245166' AS DateTime2), 3, CAST(N'2021-03-05 22:44:51.8196321' AS DateTime2), 3, N'Abp.Tenant.User.EmailAddress.RegEx', N'^\w+([-+.'']\w+)*@Tenant_A.com$', 2)
GO
INSERT [dbo].[ConfigureRule] ([Id], [CreationTime], [CreatorUserId], [LastModificationTime], [LastModifierUserId], [RuleForProperty], [SyntaxForProperty], [TenantId]) VALUES (5, CAST(N'2021-03-05 21:43:26.8181586' AS DateTime2), 4, NULL, NULL, N'Abp.Tenant.User.EmailAddress.RegEx', N'^\w+([-+.'']\w+)*@Tenant_B.com$', 3)
GO
SET IDENTITY_INSERT [dbo].[ConfigureRule] OFF
GO

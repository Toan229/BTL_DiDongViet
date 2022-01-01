CREATE DATABASE [DBDiDongViet]
GO
USE [DBDiDongViet]
GO
/****** Object:  Table [dbo].[Admin]    Script Date: 12/19/2021 4:28:46 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Admin](
	[ID] [nchar](10) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](32) NULL,
	[Type] [bit] NOT NULL,
	[Status] [bit] NOT NULL,
 CONSTRAINT [PK_Admin] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Feedback]    Script Date: 12/19/2021 4:28:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Feedback](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductID] [bigint] NULL,
	[UserID] [bigint] NULL,
	[FBContent] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_Feedback] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[News]    Script Date: 12/19/2021 4:28:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[News](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](50) NULL,
	[NewContent] [ntext] NULL,
	[Image] [nchar](10) NULL,
	[Description] [nvarchar](500) NULL,
	[CreatedDate] [datetime] NULL,
 CONSTRAINT [PK_News] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Order]    Script Date: 12/19/2021 4:28:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Order](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[UserID] [bigint] NULL,
	[ShipName] [nvarchar](50) NULL,
	[ShipAddress] [nvarchar](500) NULL,
	[ShipPhone] [nchar](10) NULL,
	[ShipEmail] [nvarchar](50) NULL,
	[Notes] [nvarchar](500) NULL,
 CONSTRAINT [PK_Order] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[OrderDetail]    Script Date: 12/19/2021 4:28:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[OrderDetail](
	[OrderID] [bigint] NOT NULL,
	[ProductID] [bigint] NOT NULL,
	[Quantity] [int] NOT NULL,
 CONSTRAINT [PK_OrderDetail_1] PRIMARY KEY CLUSTERED 
(
	[OrderID] ASC,
	[ProductID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategory]    Script Date: 12/19/2021 4:28:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategory](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NOT NULL,
	[MetaTitle] [varchar](250) NULL,
	[ParentID] [bigint] NULL,
	[CreatedDate] [datetime] NULL,
	[CreateBy] [nvarchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](250) NULL,
 CONSTRAINT [PK_ProductCategory] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 12/19/2021 4:28:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](250) NOT NULL,
	[CategoryID] [bigint] NULL,
	[Storage] [nvarchar](50) NULL,
	[Price] [money] NOT NULL,
	[Color] [nvarchar](50) NOT NULL,
	[Sale] [decimal](18, 0) NULL,
	[Quantity] [bigint] NOT NULL,
	[Image] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[Sets] [nvarchar](250) NULL,
	[Insurance] [nvarchar](250) NULL,
	[NumberOfPurchases] [bigint] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/19/2021 4:28:47 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[ID] [bigint] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NULL,
	[Password] [varchar](32) NULL,
	[Name] [nvarchar](50) NULL,
	[Address] [nvarchar](250) NULL,
	[Email] [nvarchar](50) NULL,
	[Phone] [nchar](10) NULL,
	[Status] [bit] NOT NULL,
	[CreatedDate] [datetime] NULL,
	[CreateBy] [nvarchar](250) NULL,
	[ModifiedDate] [datetime] NULL,
	[ModifiedBy] [nvarchar](250) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Admin] ([ID], [Name], [Username], [Password], [Type], [Status]) VALUES (N'AD01      ', N'Đỗ Ngọc Sơn', N'sondo123', N'abc123', 1, 1)
INSERT [dbo].[Admin] ([ID], [Name], [Username], [Password], [Type], [Status]) VALUES (N'AD02      ', N'Hoàng Ngọc Nhất', N'nhat', N'nhat123', 0, 1)
INSERT [dbo].[Admin] ([ID], [Name], [Username], [Password], [Type], [Status]) VALUES (N'AD03      ', N'Phạm Cảnh Toàn', N'toanmobile', N'toan123', 0, 0)
GO
SET IDENTITY_INSERT [dbo].[Feedback] ON 

INSERT [dbo].[Feedback] ([ID], [ProductID], [UserID], [FBContent], [CreatedDate]) VALUES (1, 2, 1, N'Sản phẩm đẹp và chất lượng, giao hàng nhanh, đóng gói cũng rất cẩn thận', CAST(N'2019-01-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [ProductID], [UserID], [FBContent], [CreatedDate]) VALUES (2, 4, 3, N'Giao nhầm màu khác, nhắn tin thì shop chưa rep lại', CAST(N'2018-10-22T00:00:00.000' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [ProductID], [UserID], [FBContent], [CreatedDate]) VALUES (3, 6, 1, N'Giao hàng nhanh, sản phẩm chất lượng, tiếp tục ủng hộ shop', CAST(N'2020-12-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [ProductID], [UserID], [FBContent], [CreatedDate]) VALUES (4, 7, 2, N'Đóng gói chắc chắn, chưa sử dụng nên sẽ review thêm sau', CAST(N'2020-03-04T00:00:00.000' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [ProductID], [UserID], [FBContent], [CreatedDate]) VALUES (5, 5, 4, N'Shop thân thiện, đóng gói hàng kĩ càng', CAST(N'2019-01-02T00:00:00.000' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [ProductID], [UserID], [FBContent], [CreatedDate]) VALUES (6, 8, 2, N'Sản phẩm không như mô tả, thiếu phụ kiện đi kèm', CAST(N'2019-05-06T00:00:00.000' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [ProductID], [UserID], [FBContent], [CreatedDate]) VALUES (7, 8, 1, N'Yêu cầu trả hàng vì lý do sản phẩm lỗi', CAST(N'2019-03-08T00:00:00.000' AS DateTime))
INSERT [dbo].[Feedback] ([ID], [ProductID], [UserID], [FBContent], [CreatedDate]) VALUES (8, 9, 3, N'Sản phẩm đẹp, dùng mượt, âm thanh to rõ ràng', CAST(N'2019-02-06T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Feedback] OFF
GO
SET IDENTITY_INSERT [dbo].[News] ON 

INSERT [dbo].[News] ([ID], [Title], [NewContent], [Image], [Description], [CreatedDate]) VALUES (7, N'iOS 15.2 có gì mới? iOS 15.2 hỗ trợ iPhone nào?', N'iOS 15.2 có gì mới? Top 10+ tính năng mới trên iOS 15.2 dành cho iPhone
Mới đây, người dùng điện thoại iPhone toàn thế giới đã chính thức có thể trải nghiệm iOS 15.2 chính thức kể từ lúc rạng sáng 14/12 theo giờ VIệt Nam. Ở thời điểm hiện tại, mình đang sử dụng iPhone 8 Plus và máy cũng đã báo có thể cập nhật lên bản phần mềm mới hơn gần đây. Tổng dung lượng của phiên bản này rơi vào tầm gần 800 MB.

Mình đã tiến hình update ngay lên bản mới khi được phép đến từ nhà sản xuất. Hôm nay, mình cũng sẽ giới thiệu cho các iFan biết được xem bản iOS 15.2 này có gì hay ho và có nên lên đời hay không. Ở phía dưới bài viết này chính là top 10+ tính năng mới trên iOS 15.2.

1. Apple Maps tương thích với CarPlay
Trước đây, Apple Maps trên những chiếc điện thoại iPhone đã từng được bổ sung hàng loạt các tính năng hữu ích mới khi cập nhật lên bản iOS 15. Tuy nhiên, chúng vẫn chưa khả dụng với CarPlay khiến cho khá nhiều người dùng bất tiện khi sử dụng.

Táo khuyết đã lắng nghe các iFan và đã tạo nên một sự đổi mới bất ngờ trên hệ điều hành iOS 15.2 mới này. Cụ thể, ứng dụng Maps này sẽ tạo điều kiện cho những người dùng CarPlay có thể xem được bản đồ thành phố dạng nâng cao trong lúc đang điều khiển xe.', N'n1.jpg    ', N'Sau khi trải qua nhiều đợt thử nghiệm Beta, cuối cùng thì phiên bản iOS 15.2 chính thức cũng đã được Apple phát hành cho iPhone. Giống với các bản cập nhật phần mềm khác, hệ điều hành này sẽ đem lại cho chúng ta hàng loạt tính năng hay ho. Cùng khám phá ngay xem iOS 15.2 có gì mới ngay bên dưới.', CAST(N'2021-11-11T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([ID], [Title], [NewContent], [Image], [Description], [CreatedDate]) VALUES (9, N'4 lý do nên mua ngay iPhone 13 ', N'Có nên mua iPhone 13 series ngay hay đợi iPhone 14?
Đây là câu hỏi khiến người dùng đắn đo nhất trong khoảng thời gian mua sắm cuối năm bởi thế hệ iPhone 13 series năm nay cực kỳ có sức hút nhưng các tin đồn về iPhone 14 mới đang nóng dần lên. Nhiều người dùng không biết nên chờ đợi thế hệ mới hay chọn mua iPhone 13 series, bài viết sẽ đánh giá và cho bạn câu trả lời chính xác nhất!

1. Về iPhone 13 series
Ra mắt vào cuối tháng 9/2021, iPhone 13 Pro Max hiện đang là chiếc điện thoại được người dùng yêu thích và săn đón tìm mua, đây là chiếc iPhone tốt nhất ở thời điểm hiện tại và cũng là chiếc iPhone đắt tiền nhất. iPhone 13 Pro sẽ có màn hình nhỏ hơn và mức giá rẻ hơn, ngoài ra phiên bản iPhone 13 tiêu chuẩn và phiên bản iPhone 13 Mini cũng cho người dùng nhiều lựa chọn đa dạng.

', N'n2.jpg    ', N'Thời điểm cuối năm 2021, những tin đồn về thế hệ iPhone 14 tiếp theo xuất hiện ngày càng nhiều. Người dùng cũng đắn đo trong việc quyết định chọn mua điện thoại mới bởi iPhone 13 series là dòng sản phẩm đáng mua mùa mua sắm cuối năm nhưng iPhone mới trong năm sau cũng đáng mong đợi với nhiều cải tiến hấp dẫn.', CAST(N'2021-08-08T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([ID], [Title], [NewContent], [Image], [Description], [CreatedDate]) VALUES (12, N'Hướng dẫn 4 cách quay màn hình iPhone đơn giản ', N'Quay màn hình iPhone là gì? 4 cách quay video màn hình iPhone
Quay màn hình iPhone là tính năng được nhà phát hành Apple bổ sung vào các dòng điện thoại của mình bằng cách tích hợp trên hệ điều hành. Kể từ phiên bản iOS 11 trở đi, hệ điều hành sẽ có tính năng Record màn hình, cho phép người dùng dễ dàng ghi lại quá trình thao tác trên iPhone và chia sẻ đến mọi người.Nếu bạn chưa biết cách sử dụng tính năng này, hoặc muốn khám phá thêm những cách khác để ghi màn hình iPhone, thì với 4 cách quay màn hình iPhone được chia sẻ một cách chi tiết sau đây sẽ là những thông tin hữu ích nhất cho bạn.

1. Cách quay màn hình iPhone trên iOS 11, iOS 12
Xuất hiện lần đầu trên bản iOS 11 và tiếp tục được cải tiến ở iOS 12, tính năng quay màn hình iPhone thực sự đem lại những tiện ích đáng mong đợi cho người dùng. Với những ai đang sử dụng phiên bản hệ điều hành cũ, mà cụ thể ở đây là bản iOS 11, 12 thì bạn có thể làm theo hướng dẫn quay màn hình iPhone sau đây.

Bước 1: Mở phần Cài đặt > Chọn Trung tâm kiểm soát > Chọn tiếp Tùy chỉnh điều khiển

Bước 2: Trong mục Điều khiển khác, bạn hãy tìm dòng Ghi màn hình > Tiếp tục nhấn dấu “+” màu xanh để thêm tính năng này vào Trung tâm điều khiển.', N'n3.jpg    ', N'Mỗi khi bạn muốn chia sẻ một video màn hình hoặc ghi lại những hướng dẫn thực hiện thao tác nào đó và gửi đến bạn bè, đã có tính năng quay màn hình iPhone cực kỳ tiện lợi của iOS. Không chỉ có 1 cách để ghi lại màn hình iPhone mà bạn có thể thực hiện điều này theo nhiều cách khác nhau. Những hướng dẫn cụ thể sau đây sẽ giúp ích cho bạn, cùng khám phá nhé.', CAST(N'2021-10-10T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([ID], [Title], [NewContent], [Image], [Description], [CreatedDate]) VALUES (14, N'Top 12+ cách làm iPhone mượt hơn ', N'Top 12+ cách làm iphone mượt hơn đơn giản nhất dành cho bạn
Như các bạn đã biết, các dòng iPhone cũng như hệ điều hành iOS được Apple sản xuất luôn được nhiều người dùng cũng như chuyên gia công nghệ đánh giá cao về sự ổn định, mượt mà chúng có trong quá trình trải nghiệm. Tuy nhiên, điện thoại chắc chắn sẽ bị xuống cấp và sẽ xử lý chậm hơn sau một khoảng thời gian dài sử dụng.

Bạn hãy đừng nên quá lo lắng. Cùng khám ngay ở dưới 12+ cách làm cho iPhone mượt hơn như lúc mới mua ban đầu để có thể thỏa sức chiến game hay chìm đắm vào những thước phim mà không bị các tình trạng giật, lag làm phiền nữa.

1. Luôn giữ pin ở mức cao
Theo một vài nghiên cứu và các thử nghiệm của các chuyên gia về công nghệ, điện thoại iPhone sẽ đạt được hiệu năng cao nhất cũng như hoạt động được lâu hơn khi dung lượng pin của thiết bị nằm trong khoảng từ 40 – 80%. Do đó, để có thể làm iPhone mượt hơn thì mọi người tốt nhất nên giữ pin của máy ở mức ổn định này.Người dùng cũng nên lưu ý là không nên dùng smartphone đến mức cạn sạch pin và bị tắt nguồn điện thoại trừ các trường hợp cấp bách. Lý do chính là điều này sẽ gây ảnh hưởng không nhỏ cho iPhone cũng như tác động xấu tới tốc độ xử lý mà thiết bị này đang có.

2. Tải phần mềm dọn dẹp rác
Trong quá trình sử dụng iPhone, đôi lúc người dùng có tải một vài thứ không thiết yếu về máy mà không nhớ. Ngoài ra, thiết bị cũng có thể sản sinh ra những file rác không có giá trị trong lúc vận hành. Những tệp này đều không hề có một chút hiệu quả nào cho các bạn mà ngược lại còn khiến cho hiệu năng xử lý của máy bị ảnh hưởng nặng nề.', N'n4.jpg    ', N'Chắc hắn đa phần người sử dụng điện thoại iPhone cũng đã đôi khi bắt gặp tình trạng máy bị chậm hay giật, lag. Điều này sẽ làm cho trải nghiệm của các bạn có thể bị suy giảm và khiến cho chúng ta thấy khó chịu. Cùng nhau bỏ túi ngay hơn 12 cách làm iPhone mượt hơn cực kỳ hiệu quả tại bài viết này.', CAST(N'2021-11-15T00:00:00.000' AS DateTime))
INSERT [dbo].[News] ([ID], [Title], [NewContent], [Image], [Description], [CreatedDate]) VALUES (17, N'Cách cập nhật iOS 15.2 Beta 4 mới nhất', N'Hướng dẫn cách cập nhật iOS 15.2 Beta 4 chi tiết nhanh nhất
Bản cập nhật iOS 15.2 Beta 4 được xem là khá hoàn thiện để Apple tiến đến bản chính thức. Nhiều người dùng đã không đợi được mà nhanh chóng cài đặt cho mình bản cập nhật này để trải nghiệm những tính năng mới nhất.Để có cái nhìn rõ hơn về những điểm mới ở iOS 15.2, cũng như tìm hiểu cách cài đặt bản nâng cấp một cách nhanh chóng và đơn giản nhất, hãy cùng lần lượt điểm qua những thông tin sau đây.

1. iOS 15.2 Beta 4 có gì mới?
Sau 3 phiên bản Beta được ra mắt, có thể nói iOS 15.2 Beta 4 là bản Beta hoàn thiện nhất tính đến thời điểm này, khi mà các cập nhật trước đó đều có mặt ở Beta 4, cộng thêm những tính năng mới khác. Một số thay đổi có thể kể đến như tính năng báo cáo quyền riêng tư của ứng dụng được tích hợp vào Settings, hay việc giúp cho người dùng có thể trải nghiệm các ứng dụng tốt hơn và khắc phục các lỗi cũ.

– Tính năng Báo cáo quyền riêng tư của ứng dụng

Đầu tiên, điểm mới đáng ghi nhận nhất ở bản cập nhật iOS 15.2 Beta 4 là tính năng Báo cáo quyền riêng tư của ứng dụng đã được tích hợp vào mục Quyền riêng tư trong phần Cài đặt/Settings. Giờ đây, người dùng đã có thể check các dữ liệu được phía ứng dụng truy cập, kể cả ứng dụng của bên thứ 3 và ứng dụng từ Apple.', N'n5.jpg    ', N'Theo sau bản cập nhật Beta 3, Apple đã tiếp tục cho ra mắt phiên bản iOS 15.2 Beta 4, càng làm các iFan thích thú hơn với những điểm cải tiến mới. Nếu các phiên bản Beta 1, 2, 3 chưa đủ thỏa mãn bạn thì iOS 15.2 Beta 4 hứa hẹn sẽ là bản nâng cấp tuyệt vời mà bạn cần.', CAST(N'2021-10-09T00:00:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[News] OFF
GO
SET IDENTITY_INSERT [dbo].[Order] ON 

INSERT [dbo].[Order] ([ID], [UserID], [ShipName], [ShipAddress], [ShipPhone], [ShipEmail], [Notes]) VALUES (1, 2, N'Trịnh Minh Dũng', N'Đống Đa, Hà Nội', N'098745632 ', N'abc@gmail.com', N'Giao sau 6h30 tối')
INSERT [dbo].[Order] ([ID], [UserID], [ShipName], [ShipAddress], [ShipPhone], [ShipEmail], [Notes]) VALUES (2, 3, N'Đào Quốc Cường', N'Thanh Xuân, Hà Nội', N'091234787 ', N'abc@gmail.com', NULL)
INSERT [dbo].[Order] ([ID], [UserID], [ShipName], [ShipAddress], [ShipPhone], [ShipEmail], [Notes]) VALUES (3, 1, N'Hoàng Ngọc Nhất', N'Nam Từ Liêm, Hà Nội', N'098123458 ', N'abc@gmail.com', N'Giao vào giờ hành chính')
SET IDENTITY_INSERT [dbo].[Order] OFF
GO
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity]) VALUES (1, 4, 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity]) VALUES (2, 5, 1)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity]) VALUES (2, 7, 2)
INSERT [dbo].[OrderDetail] ([OrderID], [ProductID], [Quantity]) VALUES (3, 15, 2)
GO
SET IDENTITY_INSERT [dbo].[ProductCategory] ON 

INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (1, N'Điện thoại', N'Smart Phone', NULL, CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn', CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (2, N'Apple Iphone', N'Iphone', NULL, CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn', CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (3, N'Tablet', N'Tablet', NULL, CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn', CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (4, N'Đồng hồ', N'Smart Watch', NULL, CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn', CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (5, N'Phụ kiện', N'Sets', NULL, CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Lê Thị Nghiêm', CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Lê Thị Nghiêm')
INSERT [dbo].[ProductCategory] ([ID], [Name], [MetaTitle], [ParentID], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (6, N'Máy cũ giá rẻ', N'Old Phone', NULL, CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Lê Thị Nghiêm', CAST(N'2021-01-12T00:00:00.000' AS DateTime), N'Lê Thị Nghiêm')
SET IDENTITY_INSERT [dbo].[ProductCategory] OFF
GO
SET IDENTITY_INSERT [dbo].[Products] ON 

INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (2, N'Samsung Galaxy A22 (6GB|128GB) Chính Hãng', 1, N'128GB', 4999000.0000, N'Màu tím', CAST(15 AS Decimal(18, 0)), 100, N'h1.jpg', N'Samsung Galaxy A22 (6GB|128GB) sở hữu thiết kế tinh tế với mặt lưng và khung viền được chế tác từ chất liệu nhựa cao cấp. Màn hình infinity-V với kích thước 6.5 inch cùng chipset Snapdragon 450 mạnh mẽ, cụm camera lên đến 16MP chụp hình ấn tượng. ', N'Bộ sản phẩm: Thân máy, Cáp, Sạc, Sách hướng dẫn, Cây chọc sim', N'Bảo hành 12 tháng theo chính sách ủy quyền của Samsung Việt Nam', 1)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (3, N'iPhone 13 512GB Chính Hãng (VN/A)', 2, N'512GB', 28290000.0000, N'Màu đen', CAST(15 AS Decimal(18, 0)), 80, N'h2.jpg', N'iPhone 13 512GB Chính hãng (VN/A) bán tại Di Động Việt - Đại lý uỷ quyền chính thức của Apple tại Việt Nam, iPhone 13 mini là phiên bản quốc tế 2 sim (Nano + Esim) chính hãng VN/A. Máy chưa Active + nguyên seal hộp, mới 100% (Fullbox)', N'Bộ sản phẩm gồm: Thân máy, Cáp USB-C to Lightning, Cây lấy sim, Sách HDSD.', N'Giá đã bao gồm 10% VAT. Bảo hành 12 tháng tại trung tâm bảo hành chính hãng Apple Việt Nam.', 0)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (4, N'iPhone 11 64GB (Likenew)', 2, N'64GB', 12390000.0000, N'Màu tím', CAST(6 AS Decimal(18, 0)), 50, N'h3.jpg', N'iPhone 11 64GB cũ bán tại Di Động Việt đã được kiểm duyệt nghiêm ngặt bởi đội ngũ kĩ thuật viên. Sản phẩm được bảo hành 1 đổi 1, dùng thử miễn phí, nhận ưu đãi hấp dẫn như trả góp 0%, Trade-in thu cũ đổi mới.', N'Bộ sản phẩm gồm: Thân máy, Cáp sạc, Cây lấy sim', N'Dùng thử 7 ngày miễn phí. 1 Đổi 1 trong vòng 33 ngày. Bảo hành pin 06 tháng 1 đổi 1 Miễn Phí. Bảo hành mặc định 06 tháng.', 1)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (5, N'iPhone 13 mini 128GB Chính Hãng (VN/A)', 2, N'128GB', 19190000.0000, N'Màu hồng', CAST(0 AS Decimal(18, 0)), 120, N'h4.jpg', N'iPhone 13 mini 128GB Chính hãng (VN/A) bán tại Di Động Việt - Đại lý uỷ quyền chính thức của Apple tại Việt Nam, iPhone 13 mini là phiên bản quốc tế 2 sim (Nano + Esim) chính hãng VN/A. Máy chưa Active + nguyên seal hộp, mới 100% (Fullbox)', N'Bộ sản phẩm gồm: Thân máy, Cáp USB-C to Lightning, Cây lấy sim, Sách HDSD.', N'Giá đã bao gồm 10% VAT. Bảo hành 12 tháng tại trung tâm bảo hành chính hãng Apple Việt Nam.', 1)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (6, N'iPhone 11 Pro Max 256GB (Likenew)', 2, N'256GB', 18590000.0000, N'Màu đen', CAST(5 AS Decimal(18, 0)), 150, N'h5.jpg', N'iPhone 11 Pro Max 256GB cũ smartphone sở hữu thiết kế thời thường với màn hình lớn đẹp, cấu hình mạnh mẽ cùng con chip A13 Bionic, dung lượng lên đến 256GB lưu trữ thoải mái, máy được trang bị đến 3 camera sau với nhiều công nghệ chụp ảnh mới.', N'Bộ sản phẩm gồm: Thân máy, Cáp sạc, Cây lấy sim', N'Dùng thử 7 ngày miễn phí. 1 Đổi 1 trong vòng 33 ngày. Bảo hành pin 06 tháng 1 đổi 1 Miễn Phí. Bảo hành mặc định 06 tháng.', 2)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (7, N'iPhone Xr 64GB (Likenew)', 2, N'64GB', 8790000.0000, N'Màu đỏ', CAST(13 AS Decimal(18, 0)), 20, N'h6.jpg', N'iPhone Xr 64GB cũ là điện thoại có thiết kế đẹp, hiện đại màn hình 6.1 inch cho khả năng hiển thị sắc nét. Cấu hình máy mạnh mẽ với chip A12 Bionic và camera đơn phía sau máy với nhiều công nghệ chụp ảnh chuyên nghiệp.', N'Bộ sản phẩm: Thân máy, cáp, sạc.', N'Bảo hành pin 06 tháng 1 đổi 1 Miễn Phí.
Giá đã bao gồm 10% VAT. Bảo hành 12 tháng theo chính sách Apple toàn cầu.', 1)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (8, N'Xiaomi Redmi 9C (4GB|128GB) Chính Hãng', 1, N'128GB', 3490000.0000, N'Màu xanh lá', CAST(5 AS Decimal(18, 0)), 10, N'h7.jpg', N'Xiaomi Redmi 9C bán tại Di Động Việt là phiên bản chính hãng Xiaomi, mới 100% với tình trạng nguyên seal máy, nhận bảo hành 18 tháng tại hệ thống ủy quyền, đồng thời nhận nhiều ưu đãi, khuyến mãi hấp dẫn tại Di Động Việt.', N'Bộ sản phẩm: Thân máy, Hộp, Cáp sạc, Ốp lưng, Sách hướng dẫn, Que chọc sim', N'Bảo hành 18 tháng tại hệ thống ủy quyền, 1 đổi 1 trong 30 ngày nếu có lỗi từ nhà sản xuất.', 7)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (9, N'OPPO Reno6 5G (8GB|128GB) Chính Hãng', 1, N'128GB', 1299000.0000, N'Màu bạc', CAST(7 AS Decimal(18, 0)), 35, N'h9.jpg', N'OPPO Reno6 5G (8GB|128GB) sở hữu thiết kế trẻ trung với màn hình AMOLED rộng 6.43 inch, hiệu năng mạnh mẽ với vi xử lý Dimensity 900 5G, camera sau 64MP', N'Bộ sản phẩm gồm: Hộp, Thân máy, Cáp sạc, Sách HDSD, Que chọc sim', N'Bảo hành 12 tháng chính hãng', 5)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (14, N'OPPO Reno 4 (8GB|128GB) Chính hãng (Fullbox, Likenew)', 1, N'128GB', 5790000.0000, N'Màu xanh', CAST(17 AS Decimal(18, 0)), 21, N'h11.jpg', N'Oppo Reno 4 cũ sở hữu thiết kế thời thượng, sang trọng với màn hình rộng 6.4 inch, độ phân giải Full HD+, đi kèm là cấu hình mạnh mẽ với chip Snapdragon 720G, Adreno 618. Máy được trang bị hệ thống 4 camera sau', N'Bộ sản phẩm gồm: Thân máy, Cáp sạc, Sách hướng dẫn, Que chọc sim', N'Bảo hành 06 tháng tại Di Động Việt', 9)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (15, N'Điện Thoại Nokia 110 4G TA - 1376', 1, N'4GB', 790000.0000, N'Màu xám', CAST(0 AS Decimal(18, 0)), 100, N'h12.jpg', N'Nokia 110 4G sở hữu ngoại hình quen thuộc, khi sử dụng chất liệu nhựa Polycarbonate được tinh chỉnh giúp máy trở nên trẻ trung, năng động và vô cùng bắt mắt. máy cũng hỗ trợ 2 sim 2 sóng', N'Bộ sản phẩm gồm: Thân máy, Bộ sạc micro USB, Sách hướng dẫn', N'Bảo hành 12 tháng hành chính hãng. 1 đổi 1 trong 30 ngày nếu có lỗi nhà sản xuất.', 4)
INSERT [dbo].[Products] ([ID], [ProductName], [CategoryID], [Storage], [Price], [Color], [Sale], [Quantity], [Image], [Description], [Sets], [Insurance], [NumberOfPurchases]) VALUES (16, N'Samsung Galaxy Z Fold2 5G (Phiên bản Spring 2021)', 1, N'256GB', 33990000.0000, N'Vàng đồng', CAST(32 AS Decimal(18, 0)), 102, N'h13.jpg', N'Samsung Galaxy Z Fold 2 5G là chiếc điện thoại màn hình cảm ứng gập của Samsung. Máy sở hữu thiết kế sang trọng, cấu hình khủng với Snapdragon 865+ cùng 12GB RAM và 256GB bộ nhớ trong cực kì rộng rãi', N'Bộ sản phẩm: Thân máy, Hộp, Cáp sạc, Củ sạc nhanh, Ốp lưng, Đầu chuyển USB OTG, Sách hướng dẫn.', N'Bảo hành 12 tháng chính hãng theo chính sách của Samsung Việt Nam.', 12)
SET IDENTITY_INSERT [dbo].[Products] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([ID], [Username], [Password], [Name], [Address], [Email], [Phone], [Status], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (1, N'nhat12345', N'123', N'Hoàng Ngọc Nhất', N'Nam Từ Liêm, Hà Nội', N'hoangngocnhat@gmail.com', N'0123456789', 1, CAST(N'2018-07-03T00:00:00.000' AS DateTime), N'Hoàng Ngọc Nhất', CAST(N'2019-12-06T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn')
INSERT [dbo].[User] ([ID], [Username], [Password], [Name], [Address], [Email], [Phone], [Status], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (2, N'toan12345', N'123', N'Phạm Cảnh Toàn', N'Vĩnh Phúc', N'phamcanhtoan@gmail.com', N'0987654321', 1, CAST(N'2019-12-25T00:00:00.000' AS DateTime), N'Phạm Cảnh Toàn', NULL, NULL)
INSERT [dbo].[User] ([ID], [Username], [Password], [Name], [Address], [Email], [Phone], [Status], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (3, N'phuong12345', N'123', N'Đào Trung Phương', N'Hải Phòng', N'daotrungphuong@gmail.com', N'0456789123', 0, CAST(N'2017-12-09T00:00:00.000' AS DateTime), N'Đào Trung Phương', CAST(N'2019-10-24T00:00:00.000' AS DateTime), N'Đỗ Ngọc Sơn')
INSERT [dbo].[User] ([ID], [Username], [Password], [Name], [Address], [Email], [Phone], [Status], [CreatedDate], [CreateBy], [ModifiedDate], [ModifiedBy]) VALUES (4, N'nghiem12345', N'123', N'Lê Văn Nghiêm', N'Hải Phòng', N'levannghiem@gmail.com', N'0582656877', 0, CAST(N'2018-06-12T00:00:00.000' AS DateTime), N'Lê Văn Nghiêm', NULL, NULL)
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Feedback]  WITH NOCHECK ADD  CONSTRAINT [FK_Feedback_Products] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_Products]
GO
ALTER TABLE [dbo].[Feedback]  WITH NOCHECK ADD  CONSTRAINT [FK_Feedback_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Feedback] CHECK CONSTRAINT [FK_Feedback_User]
GO
ALTER TABLE [dbo].[Order]  WITH NOCHECK ADD  CONSTRAINT [FK_Order_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Order] CHECK CONSTRAINT [FK_Order_User]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_OrderDetail_Order] FOREIGN KEY([OrderID])
REFERENCES [dbo].[Order] ([ID])
ON UPDATE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_Order]
GO
ALTER TABLE [dbo].[OrderDetail]  WITH NOCHECK ADD  CONSTRAINT [FK_OrderDetail_OrderDetail] FOREIGN KEY([ProductID])
REFERENCES [dbo].[Products] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[OrderDetail] CHECK CONSTRAINT [FK_OrderDetail_OrderDetail]
GO
ALTER TABLE [dbo].[ProductCategory]  WITH NOCHECK ADD  CONSTRAINT [FK_ProductCategory_ProductCategory] FOREIGN KEY([ParentID])
REFERENCES [dbo].[ProductCategory] ([ID])
GO
ALTER TABLE [dbo].[ProductCategory] CHECK CONSTRAINT [FK_ProductCategory_ProductCategory]
GO
ALTER TABLE [dbo].[Products]  WITH NOCHECK ADD  CONSTRAINT [FK_Products_ProductCategory] FOREIGN KEY([CategoryID])
REFERENCES [dbo].[ProductCategory] ([ID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategory]
GO


create trigger tg_InsertUser on [dbo].[User] for Insert 
as
begin
	declare @UserId int
	select @UserId = ID from inserted
	insert into [dbo].[Order] values(@UserId,'','','','','')
end

/*insert into [dbo].[User] values('abc','123', N'Nguyễn Công Nguyên',N'Hà Nội', 'abc@gmail.com', 12345678,1,1/1/2019, N'Nguyễn Công Nguyên','','')
select * from [dbo].[User]
select* from [dbo].[Order]*/
USE [TestWork]
GO
/****** Object:  Schema [bookstore]    Script Date: 10/16/2022 2:35:19 PM ******/
CREATE SCHEMA [bookstore]
GO
/****** Object:  Table [bookstore].[Author]    Script Date: 10/16/2022 2:35:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bookstore].[Author](
                                     [Id] [int] IDENTITY(1,1) NOT NULL,
                                     [AuthorName] [varchar](50) NOT NULL,
                                     CONSTRAINT [PK_Author] PRIMARY KEY CLUSTERED
                                         (
                                          [Id] ASC
                                             )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [bookstore].[Book]    Script Date: 10/16/2022 2:35:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bookstore].[Book](
                                   [Id] [int] IDENTITY(1,1) NOT NULL,
                                   [AuthorId] [int] NOT NULL,
                                   [BookName] [varchar](50) NOT NULL,
                                   CONSTRAINT [PK_Book] PRIMARY KEY CLUSTERED
                                       (
                                        [Id] ASC
                                           )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [bookstore].[Chapter]    Script Date: 10/16/2022 2:35:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [bookstore].[Chapter](
                                      [Id] [int] IDENTITY(1,1) NOT NULL,
                                      [AuthorId] [int] NOT NULL,
                                      [BookId] [int] NOT NULL,
                                      [ChapterName] [varchar](50) NOT NULL,
                                      CONSTRAINT [PK_Chapter] PRIMARY KEY CLUSTERED
                                          (
                                           [Id] ASC
                                              )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [bookstore].[Book]  WITH CHECK ADD  CONSTRAINT [FK_Book_Author] FOREIGN KEY([AuthorId])
    REFERENCES [bookstore].[Author] ([Id])
GO
ALTER TABLE [bookstore].[Book] CHECK CONSTRAINT [FK_Book_Author]
GO
ALTER TABLE [bookstore].[Chapter]  WITH CHECK ADD  CONSTRAINT [FK_Chapter_Author] FOREIGN KEY([AuthorId])
    REFERENCES [bookstore].[Author] ([Id])
GO
ALTER TABLE [bookstore].[Chapter] CHECK CONSTRAINT [FK_Chapter_Author]
GO
ALTER TABLE [bookstore].[Chapter]  WITH CHECK ADD  CONSTRAINT [FK_Chapter_Book] FOREIGN KEY([BookId])
    REFERENCES [bookstore].[Book] ([Id])
GO
ALTER TABLE [bookstore].[Chapter] CHECK CONSTRAINT [FK_Chapter_Book]
GO

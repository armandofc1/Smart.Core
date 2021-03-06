USE [Smart]
GO
/****** Object:  Table [dbo].[TB_CATEGORIA]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_CATEGORIA](
	[CD_CATEGORIA] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [nvarchar](30) NOT NULL,
	[DESCRICAO] [nvarchar](200) NULL,
 CONSTRAINT [PK_TB_CATEGORIA] PRIMARY KEY CLUSTERED 
(
	[CD_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_COMENTARIO]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_COMENTARIO](
	[CD_COMENTARIO] [int] IDENTITY(1,1) NOT NULL,
	[CD_USUARIO] [int] NOT NULL,
	[CD_POSTAGEM] [int] NOT NULL,
	[DT_CRIACAO] [datetime2](7) NOT NULL,
	[CONTEUDO] [nvarchar](255) NOT NULL,
	[STATUS] [int] NOT NULL,
 CONSTRAINT [PK_TB_COMENTARIO] PRIMARY KEY CLUSTERED 
(
	[CD_COMENTARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PERFIL]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PERFIL](
	[CD_PERFIL] [int] IDENTITY(1,1) NOT NULL,
	[NOME] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TB_PERFIL] PRIMARY KEY CLUSTERED 
(
	[CD_PERFIL] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_PERFIL_USUARIO]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_PERFIL_USUARIO](
	[CD_USUARIO] [int] NOT NULL,
	[CD_PERFIL] [int] NOT NULL,
	[GERENCIAR_USUARIOS] [int] NOT NULL,
	[GERENCIAR_CATEGORIAS] [int] NOT NULL,
	[GERENCIAR_POSTAGENS] [int] NOT NULL,
	[GERENCIAR_COMENTARIOS] [int] NOT NULL,
 CONSTRAINT [PK_TB_PERFIL_USUARIO] PRIMARY KEY CLUSTERED 
(
	[CD_PERFIL] ASC,
	[CD_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_POSTAGEM]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_POSTAGEM](
	[CD_POSTAGEM] [int] IDENTITY(1,1) NOT NULL,
	[CD_USUARIO] [int] NOT NULL,
	[DT_CRIACAO] [datetime2](7) NOT NULL,
	[TITULO] [nvarchar](100) NOT NULL,
	[SUBTITULO] [nvarchar](150) NULL,
	[RESUMO] [nvarchar](255) NULL,
	[CONTEUDO] [nvarchar](4000) NULL,
	[FOTO] [nvarchar](255) NULL,
	[DT_INICIAL] [datetime2](7) NOT NULL,
	[DT_FINAL] [datetime2](7) NOT NULL,
	[STATUS] [int] NOT NULL,
 CONSTRAINT [PK_TB_POSTAGEM] PRIMARY KEY CLUSTERED 
(
	[CD_POSTAGEM] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_POSTAGEM_CATEGORIA]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_POSTAGEM_CATEGORIA](
	[CD_POSTAGEM] [int] NOT NULL,
	[CD_CATEGORIA] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_MOVIMENTACAO]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_MOVIMENTACAO](
	[CD_TIPO_MOVIMENTACAO] [int] IDENTITY(1,1) NOT NULL,
	[TIPO] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TB_TIPO_MOVIMENTACAO] PRIMARY KEY CLUSTERED 
(
	[CD_TIPO_MOVIMENTACAO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_TIPO_USUARIO]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_TIPO_USUARIO](
	[CD_TIPO_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[TIPO] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_TB_TIPO_USUARIO] PRIMARY KEY CLUSTERED 
(
	[CD_TIPO_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_USUARIO]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIO](
	[CD_USUARIO] [int] IDENTITY(1,1) NOT NULL,
	[CD_TIPO_USUARIO] [int] NOT NULL,
	[DT_CADASTRO] [datetime2](7) NOT NULL,
	[NOME] [nvarchar](100) NOT NULL,
	[SOBRENOME] [nvarchar](100) NOT NULL,
	[SEXO] [nvarchar](1) NOT NULL,
	[LOGIN] [nvarchar](20) NOT NULL,
	[SENHA] [nvarchar](20) NOT NULL,
	[EMAIL] [nvarchar](200) NOT NULL,
	[FOTO] [nvarchar](255) NULL,
	[STATUS] [int] NOT NULL,
 CONSTRAINT [PK_TB_USUARIO] PRIMARY KEY CLUSTERED 
(
	[CD_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_USUARIO_INTERESSE_CATEGORIA]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIO_INTERESSE_CATEGORIA](
	[CD_USUARIO] [int] NOT NULL,
	[CD_CATEGORIA] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_USUARIO_MOVIMENTACAO]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIO_MOVIMENTACAO](
	[CD_MOVIMENTACAO] [int] IDENTITY(1,1) NOT NULL,
	[CD_TIPO_MOVIMENTACAO] [int] NOT NULL,
	[DT_CADASTRO] [datetime2](7) NOT NULL,
	[CD_USUARIO_ORIGEM] [int] NOT NULL,
	[CD_USUARIO_DESTINO] [int] NOT NULL,
	[CD_POSTAGEM] [int] NOT NULL,
	[PONTOS] [int] NOT NULL,
 CONSTRAINT [PK_TB_USUARIO_MOVIMENTACAO] PRIMARY KEY CLUSTERED 
(
	[CD_MOVIMENTACAO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TB_USUARIO_PONTUACAO]    Script Date: 21/05/2019 01:36:35 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TB_USUARIO_PONTUACAO](
	[CD_USUARIO] [int] NOT NULL,
	[PONTOS_SALDO] [int] NOT NULL,
 CONSTRAINT [PK_TB_USUARIO_PONTUACAO] PRIMARY KEY CLUSTERED 
(
	[CD_USUARIO] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[TB_CATEGORIA] ON 

INSERT [dbo].[TB_CATEGORIA] ([CD_CATEGORIA], [NOME], [DESCRICAO]) VALUES (1, N'Artesenato', N'Para se fazer em casa')
INSERT [dbo].[TB_CATEGORIA] ([CD_CATEGORIA], [NOME], [DESCRICAO]) VALUES (2, N'Tutorials', N'Guia passo a passo')
INSERT [dbo].[TB_CATEGORIA] ([CD_CATEGORIA], [NOME], [DESCRICAO]) VALUES (3, N'JavaScript', N'JavaScript')
INSERT [dbo].[TB_CATEGORIA] ([CD_CATEGORIA], [NOME], [DESCRICAO]) VALUES (4, N'HTML', N'HTML')
INSERT [dbo].[TB_CATEGORIA] ([CD_CATEGORIA], [NOME], [DESCRICAO]) VALUES (5, N'CSS', N'CSS')
INSERT [dbo].[TB_CATEGORIA] ([CD_CATEGORIA], [NOME], [DESCRICAO]) VALUES (6, N'Web Design', N'Web Design')
INSERT [dbo].[TB_CATEGORIA] ([CD_CATEGORIA], [NOME], [DESCRICAO]) VALUES (7, N'Freebies', N'Freebies')
SET IDENTITY_INSERT [dbo].[TB_CATEGORIA] OFF
SET IDENTITY_INSERT [dbo].[TB_COMENTARIO] ON 

INSERT [dbo].[TB_COMENTARIO] ([CD_COMENTARIO], [CD_USUARIO], [CD_POSTAGEM], [DT_CRIACAO], [CONTEUDO], [STATUS]) VALUES (1, 5, 1, CAST(N'2019-05-13T01:29:49.4694283' AS DateTime2), N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor sit amet, <a href="#">#consecteturadipiscing</a>', 1)
INSERT [dbo].[TB_COMENTARIO] ([CD_COMENTARIO], [CD_USUARIO], [CD_POSTAGEM], [DT_CRIACAO], [CONTEUDO], [STATUS]) VALUES (2, 6, 1, CAST(N'2019-05-13T01:29:49.4698618' AS DateTime2), N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Lorem ipsum dolor <a href="#">#ipsumdolor</a> adipiscing elit.', 1)
INSERT [dbo].[TB_COMENTARIO] ([CD_COMENTARIO], [CD_USUARIO], [CD_POSTAGEM], [DT_CRIACAO], [CONTEUDO], [STATUS]) VALUES (3, 7, 1, CAST(N'2019-05-13T01:29:49.4698641' AS DateTime2), N'Lorem ipsum dolor <a href="#">#ipsumdolor</a> sit amet, consectetur adipiscing elit.', 1)
INSERT [dbo].[TB_COMENTARIO] ([CD_COMENTARIO], [CD_USUARIO], [CD_POSTAGEM], [DT_CRIACAO], [CONTEUDO], [STATUS]) VALUES (4, 6, 2, CAST(N'2019-05-13T01:29:49.4698657' AS DateTime2), N'Lorem ipsum dolor <a href="#">#ipsumdolor</a> sit amet, consectetur adipiscing elit.', 1)
SET IDENTITY_INSERT [dbo].[TB_COMENTARIO] OFF
SET IDENTITY_INSERT [dbo].[TB_PERFIL] ON 

INSERT [dbo].[TB_PERFIL] ([CD_PERFIL], [NOME]) VALUES (1, N'Administrador')
INSERT [dbo].[TB_PERFIL] ([CD_PERFIL], [NOME]) VALUES (2, N'Moderador')
INSERT [dbo].[TB_PERFIL] ([CD_PERFIL], [NOME]) VALUES (3, N'Usuário')
SET IDENTITY_INSERT [dbo].[TB_PERFIL] OFF
INSERT [dbo].[TB_PERFIL_USUARIO] ([CD_USUARIO], [CD_PERFIL], [GERENCIAR_USUARIOS], [GERENCIAR_CATEGORIAS], [GERENCIAR_POSTAGENS], [GERENCIAR_COMENTARIOS]) VALUES (1, 1, 0, 0, 0, 0)
INSERT [dbo].[TB_PERFIL_USUARIO] ([CD_USUARIO], [CD_PERFIL], [GERENCIAR_USUARIOS], [GERENCIAR_CATEGORIAS], [GERENCIAR_POSTAGENS], [GERENCIAR_COMENTARIOS]) VALUES (2, 2, 0, 0, 0, 0)
INSERT [dbo].[TB_PERFIL_USUARIO] ([CD_USUARIO], [CD_PERFIL], [GERENCIAR_USUARIOS], [GERENCIAR_CATEGORIAS], [GERENCIAR_POSTAGENS], [GERENCIAR_COMENTARIOS]) VALUES (3, 3, 0, 0, 0, 0)
INSERT [dbo].[TB_PERFIL_USUARIO] ([CD_USUARIO], [CD_PERFIL], [GERENCIAR_USUARIOS], [GERENCIAR_CATEGORIAS], [GERENCIAR_POSTAGENS], [GERENCIAR_COMENTARIOS]) VALUES (4, 3, 0, 0, 0, 0)
SET IDENTITY_INSERT [dbo].[TB_POSTAGEM] ON 

INSERT [dbo].[TB_POSTAGEM] ([CD_POSTAGEM], [CD_USUARIO], [DT_CRIACAO], [TITULO], [SUBTITULO], [RESUMO], [CONTEUDO], [FOTO], [DT_INICIAL], [DT_FINAL], [STATUS]) VALUES (1, 2, CAST(N'2019-05-13T01:29:49.4632148' AS DateTime2), N'Qual a melhor divisão de treino?', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>', N'images/postagens/blog-5.jpg', CAST(N'2019-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-31T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[TB_POSTAGEM] ([CD_POSTAGEM], [CD_USUARIO], [DT_CRIACAO], [TITULO], [SUBTITULO], [RESUMO], [CONTEUDO], [FOTO], [DT_INICIAL], [DT_FINAL], [STATUS]) VALUES (2, 3, CAST(N'2019-05-13T01:29:49.4648527' AS DateTime2), N'Como obter fotos profissionais usando o celular', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', N'<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>', N'images/postagens/fotos_com_celular.jpg', CAST(N'2019-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-31T00:00:00.0000000' AS DateTime2), 1)
INSERT [dbo].[TB_POSTAGEM] ([CD_POSTAGEM], [CD_USUARIO], [DT_CRIACAO], [TITULO], [SUBTITULO], [RESUMO], [CONTEUDO], [FOTO], [DT_INICIAL], [DT_FINAL], [STATUS]) VALUES (3, 4, CAST(N'2019-05-13T01:29:49.4648570' AS DateTime2), N'Aprenda a tingir o cabelo sozinho', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit.', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
Lorem ipsum dolor sit amet, consectetur adipiscing', N'<p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>
                            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Reiciendis aliquid atque, nulla? Quos cum ex quis soluta, a laboriosam. Dicta expedita corporis animi vero voluptate voluptatibus possimus, veniam magni quis!</p>', N'images/postagens/cortar_cabelo.jpg', CAST(N'2019-05-01T00:00:00.0000000' AS DateTime2), CAST(N'2019-12-31T00:00:00.0000000' AS DateTime2), 1)
SET IDENTITY_INSERT [dbo].[TB_POSTAGEM] OFF
INSERT [dbo].[TB_POSTAGEM_CATEGORIA] ([CD_POSTAGEM], [CD_CATEGORIA]) VALUES (1, 1)
INSERT [dbo].[TB_POSTAGEM_CATEGORIA] ([CD_POSTAGEM], [CD_CATEGORIA]) VALUES (1, 2)
INSERT [dbo].[TB_POSTAGEM_CATEGORIA] ([CD_POSTAGEM], [CD_CATEGORIA]) VALUES (1, 3)
INSERT [dbo].[TB_POSTAGEM_CATEGORIA] ([CD_POSTAGEM], [CD_CATEGORIA]) VALUES (2, 3)
INSERT [dbo].[TB_POSTAGEM_CATEGORIA] ([CD_POSTAGEM], [CD_CATEGORIA]) VALUES (2, 4)
INSERT [dbo].[TB_POSTAGEM_CATEGORIA] ([CD_POSTAGEM], [CD_CATEGORIA]) VALUES (3, 2)
SET IDENTITY_INSERT [dbo].[TB_TIPO_MOVIMENTACAO] ON 

INSERT [dbo].[TB_TIPO_MOVIMENTACAO] ([CD_TIPO_MOVIMENTACAO], [TIPO]) VALUES (1, N'Crédito')
INSERT [dbo].[TB_TIPO_MOVIMENTACAO] ([CD_TIPO_MOVIMENTACAO], [TIPO]) VALUES (2, N'Débito')
SET IDENTITY_INSERT [dbo].[TB_TIPO_MOVIMENTACAO] OFF
SET IDENTITY_INSERT [dbo].[TB_TIPO_USUARIO] ON 

INSERT [dbo].[TB_TIPO_USUARIO] ([CD_TIPO_USUARIO], [TIPO]) VALUES (1, N'Administrador')
INSERT [dbo].[TB_TIPO_USUARIO] ([CD_TIPO_USUARIO], [TIPO]) VALUES (2, N'Moderador')
INSERT [dbo].[TB_TIPO_USUARIO] ([CD_TIPO_USUARIO], [TIPO]) VALUES (3, N'Usuário')
SET IDENTITY_INSERT [dbo].[TB_TIPO_USUARIO] OFF
SET IDENTITY_INSERT [dbo].[TB_USUARIO] ON 

INSERT [dbo].[TB_USUARIO] ([CD_USUARIO], [CD_TIPO_USUARIO], [DT_CADASTRO], [NOME], [SOBRENOME], [SEXO], [LOGIN], [SENHA], [EMAIL], [FOTO], [STATUS]) VALUES (1, 1, CAST(N'2019-05-13T01:29:49.4599940' AS DateTime2), N'Armando', N'Costa', N'M', N'admin', N'admin', N'armandofc1@gmail.com', N'', 1)
INSERT [dbo].[TB_USUARIO] ([CD_USUARIO], [CD_TIPO_USUARIO], [DT_CADASTRO], [NOME], [SOBRENOME], [SEXO], [LOGIN], [SENHA], [EMAIL], [FOTO], [STATUS]) VALUES (2, 3, CAST(N'2019-05-13T01:29:49.4618860' AS DateTime2), N'João', N'da Silva', N'M', N'jpsilva', N'123', N'joao@site.com.br', N'images/usuarios/rotating_card_profile3.png', 1)
INSERT [dbo].[TB_USUARIO] ([CD_USUARIO], [CD_TIPO_USUARIO], [DT_CADASTRO], [NOME], [SOBRENOME], [SEXO], [LOGIN], [SENHA], [EMAIL], [FOTO], [STATUS]) VALUES (3, 3, CAST(N'2019-05-13T01:29:49.4618927' AS DateTime2), N'André', N'Oswaldo', N'M', N'andreow', N'123', N'andreow@site.com.br', N'images/usuarios/rotating_card_profile2.png', 1)
INSERT [dbo].[TB_USUARIO] ([CD_USUARIO], [CD_TIPO_USUARIO], [DT_CADASTRO], [NOME], [SOBRENOME], [SEXO], [LOGIN], [SENHA], [EMAIL], [FOTO], [STATUS]) VALUES (4, 3, CAST(N'2019-05-13T01:29:49.4618939' AS DateTime2), N'Maria', N'das Dores', N'F', N'mdores', N'123', N'mdores@site.com.br', N'images/usuarios/rotating_card_profile.png', 1)
INSERT [dbo].[TB_USUARIO] ([CD_USUARIO], [CD_TIPO_USUARIO], [DT_CADASTRO], [NOME], [SOBRENOME], [SEXO], [LOGIN], [SENHA], [EMAIL], [FOTO], [STATUS]) VALUES (5, 3, CAST(N'2019-05-13T01:29:49.4618959' AS DateTime2), N'Martino', N'Mont', N'M', N'MartinoMont', N'123', N'martinomont@site.com.br', N'images/usuarios/user_1.jpg', 1)
INSERT [dbo].[TB_USUARIO] ([CD_USUARIO], [CD_TIPO_USUARIO], [DT_CADASTRO], [NOME], [SOBRENOME], [SEXO], [LOGIN], [SENHA], [EMAIL], [FOTO], [STATUS]) VALUES (6, 3, CAST(N'2019-05-13T01:29:49.4618979' AS DateTime2), N'Laurence', N'Correil', N'F', N'LaurenceCorreil', N'123', N'laurencecorreil@site.com.br', N'images/usuarios/user_2.jpg', 1)
INSERT [dbo].[TB_USUARIO] ([CD_USUARIO], [CD_TIPO_USUARIO], [DT_CADASTRO], [NOME], [SOBRENOME], [SEXO], [LOGIN], [SENHA], [EMAIL], [FOTO], [STATUS]) VALUES (7, 3, CAST(N'2019-05-13T01:29:49.4619006' AS DateTime2), N'John', N'Nida', N'M', N'JohnNida', N'123', N'johnnida@site.com.br', N'images/usuarios/user_3.jpg', 1)
SET IDENTITY_INSERT [dbo].[TB_USUARIO] OFF
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (1, 1)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (1, 2)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (1, 3)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (1, 4)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (2, 1)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (3, 2)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (4, 3)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (5, 4)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (6, 5)
INSERT [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ([CD_USUARIO], [CD_CATEGORIA]) VALUES (7, 6)
SET IDENTITY_INSERT [dbo].[TB_USUARIO_MOVIMENTACAO] ON 

INSERT [dbo].[TB_USUARIO_MOVIMENTACAO] ([CD_MOVIMENTACAO], [CD_TIPO_MOVIMENTACAO], [DT_CADASTRO], [CD_USUARIO_ORIGEM], [CD_USUARIO_DESTINO], [CD_POSTAGEM], [PONTOS]) VALUES (1, 1, CAST(N'2019-05-13T01:29:49.4703303' AS DateTime2), 3, 2, 1, 10)
INSERT [dbo].[TB_USUARIO_MOVIMENTACAO] ([CD_MOVIMENTACAO], [CD_TIPO_MOVIMENTACAO], [DT_CADASTRO], [CD_USUARIO_ORIGEM], [CD_USUARIO_DESTINO], [CD_POSTAGEM], [PONTOS]) VALUES (2, 1, CAST(N'2019-05-13T01:29:49.4708470' AS DateTime2), 4, 2, 1, 20)
INSERT [dbo].[TB_USUARIO_MOVIMENTACAO] ([CD_MOVIMENTACAO], [CD_TIPO_MOVIMENTACAO], [DT_CADASTRO], [CD_USUARIO_ORIGEM], [CD_USUARIO_DESTINO], [CD_POSTAGEM], [PONTOS]) VALUES (3, 2, CAST(N'2019-05-13T01:29:49.4708490' AS DateTime2), 2, 3, 2, 15)
INSERT [dbo].[TB_USUARIO_MOVIMENTACAO] ([CD_MOVIMENTACAO], [CD_TIPO_MOVIMENTACAO], [DT_CADASTRO], [CD_USUARIO_ORIGEM], [CD_USUARIO_DESTINO], [CD_POSTAGEM], [PONTOS]) VALUES (4, 1, CAST(N'2019-05-13T01:29:49.4708498' AS DateTime2), 2, 4, 1, 40)
SET IDENTITY_INSERT [dbo].[TB_USUARIO_MOVIMENTACAO] OFF
INSERT [dbo].[TB_USUARIO_PONTUACAO] ([CD_USUARIO], [PONTOS_SALDO]) VALUES (1, 1500)
INSERT [dbo].[TB_USUARIO_PONTUACAO] ([CD_USUARIO], [PONTOS_SALDO]) VALUES (2, 500)
INSERT [dbo].[TB_USUARIO_PONTUACAO] ([CD_USUARIO], [PONTOS_SALDO]) VALUES (3, 400)
INSERT [dbo].[TB_USUARIO_PONTUACAO] ([CD_USUARIO], [PONTOS_SALDO]) VALUES (4, 300)
/****** Object:  Index [PK_TB_POSTAGEM_CATEGORIA]    Script Date: 21/05/2019 01:36:35 ******/
ALTER TABLE [dbo].[TB_POSTAGEM_CATEGORIA] ADD  CONSTRAINT [PK_TB_POSTAGEM_CATEGORIA] PRIMARY KEY NONCLUSTERED 
(
	[CD_POSTAGEM] ASC,
	[CD_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [PK_TB_USUARIO_INTERESSE_CATEGORIA]    Script Date: 21/05/2019 01:36:35 ******/
ALTER TABLE [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] ADD  CONSTRAINT [PK_TB_USUARIO_INTERESSE_CATEGORIA] PRIMARY KEY NONCLUSTERED 
(
	[CD_USUARIO] ASC,
	[CD_CATEGORIA] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TB_COMENTARIO] ADD  DEFAULT ('2019-05-13T01:29:49.3294823-03:00') FOR [DT_CRIACAO]
GO
ALTER TABLE [dbo].[TB_COMENTARIO] ADD  DEFAULT ((1)) FOR [STATUS]
GO
ALTER TABLE [dbo].[TB_POSTAGEM] ADD  DEFAULT ('2019-05-13T01:29:49.3784817-03:00') FOR [DT_CRIACAO]
GO
ALTER TABLE [dbo].[TB_POSTAGEM] ADD  DEFAULT ((1)) FOR [STATUS]
GO
ALTER TABLE [dbo].[TB_USUARIO] ADD  DEFAULT ('2019-05-13T01:29:49.4134907-03:00') FOR [DT_CADASTRO]
GO
ALTER TABLE [dbo].[TB_USUARIO] ADD  DEFAULT ((1)) FOR [STATUS]
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO] ADD  DEFAULT ('2019-05-13T01:29:49.4279108-03:00') FOR [DT_CADASTRO]
GO
ALTER TABLE [dbo].[TB_COMENTARIO]  WITH CHECK ADD  CONSTRAINT [FK_COMENTARIO_POST] FOREIGN KEY([CD_POSTAGEM])
REFERENCES [dbo].[TB_POSTAGEM] ([CD_POSTAGEM])
GO
ALTER TABLE [dbo].[TB_COMENTARIO] CHECK CONSTRAINT [FK_COMENTARIO_POST]
GO
ALTER TABLE [dbo].[TB_COMENTARIO]  WITH CHECK ADD  CONSTRAINT [FK_COMENTARIO_USUA] FOREIGN KEY([CD_USUARIO])
REFERENCES [dbo].[TB_USUARIO] ([CD_USUARIO])
GO
ALTER TABLE [dbo].[TB_COMENTARIO] CHECK CONSTRAINT [FK_COMENTARIO_USUA]
GO
ALTER TABLE [dbo].[TB_PERFIL_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_PERFUSUARIO_PERF] FOREIGN KEY([CD_PERFIL])
REFERENCES [dbo].[TB_PERFIL] ([CD_PERFIL])
GO
ALTER TABLE [dbo].[TB_PERFIL_USUARIO] CHECK CONSTRAINT [FK_PERFUSUARIO_PERF]
GO
ALTER TABLE [dbo].[TB_PERFIL_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_PERFUSUARIO_USUA] FOREIGN KEY([CD_USUARIO])
REFERENCES [dbo].[TB_USUARIO] ([CD_USUARIO])
GO
ALTER TABLE [dbo].[TB_PERFIL_USUARIO] CHECK CONSTRAINT [FK_PERFUSUARIO_USUA]
GO
ALTER TABLE [dbo].[TB_POSTAGEM]  WITH CHECK ADD  CONSTRAINT [FK_POST_USUARIO] FOREIGN KEY([CD_USUARIO])
REFERENCES [dbo].[TB_USUARIO] ([CD_USUARIO])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TB_POSTAGEM] CHECK CONSTRAINT [FK_POST_USUARIO]
GO
ALTER TABLE [dbo].[TB_POSTAGEM_CATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK_POSTCATEGORIA_CAT] FOREIGN KEY([CD_CATEGORIA])
REFERENCES [dbo].[TB_CATEGORIA] ([CD_CATEGORIA])
GO
ALTER TABLE [dbo].[TB_POSTAGEM_CATEGORIA] CHECK CONSTRAINT [FK_POSTCATEGORIA_CAT]
GO
ALTER TABLE [dbo].[TB_POSTAGEM_CATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK_POSTCATEGORIA_POST] FOREIGN KEY([CD_POSTAGEM])
REFERENCES [dbo].[TB_POSTAGEM] ([CD_POSTAGEM])
GO
ALTER TABLE [dbo].[TB_POSTAGEM_CATEGORIA] CHECK CONSTRAINT [FK_POSTCATEGORIA_POST]
GO
ALTER TABLE [dbo].[TB_USUARIO]  WITH CHECK ADD  CONSTRAINT [FK_USUARIO_TIPO] FOREIGN KEY([CD_TIPO_USUARIO])
REFERENCES [dbo].[TB_TIPO_USUARIO] ([CD_TIPO_USUARIO])
GO
ALTER TABLE [dbo].[TB_USUARIO] CHECK CONSTRAINT [FK_USUARIO_TIPO]
GO
ALTER TABLE [dbo].[TB_USUARIO_INTERESSE_CATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK_INTERESSE_CATEGORIA] FOREIGN KEY([CD_CATEGORIA])
REFERENCES [dbo].[TB_CATEGORIA] ([CD_CATEGORIA])
GO
ALTER TABLE [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] CHECK CONSTRAINT [FK_INTERESSE_CATEGORIA]
GO
ALTER TABLE [dbo].[TB_USUARIO_INTERESSE_CATEGORIA]  WITH CHECK ADD  CONSTRAINT [FK_INTERESSE_USUARIO] FOREIGN KEY([CD_USUARIO])
REFERENCES [dbo].[TB_USUARIO] ([CD_USUARIO])
GO
ALTER TABLE [dbo].[TB_USUARIO_INTERESSE_CATEGORIA] CHECK CONSTRAINT [FK_INTERESSE_USUARIO]
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO]  WITH CHECK ADD  CONSTRAINT [FK_MOV_POSTAGEM] FOREIGN KEY([CD_POSTAGEM])
REFERENCES [dbo].[TB_POSTAGEM] ([CD_POSTAGEM])
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO] CHECK CONSTRAINT [FK_MOV_POSTAGEM]
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO]  WITH CHECK ADD  CONSTRAINT [FK_MOV_TIPO] FOREIGN KEY([CD_TIPO_MOVIMENTACAO])
REFERENCES [dbo].[TB_TIPO_MOVIMENTACAO] ([CD_TIPO_MOVIMENTACAO])
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO] CHECK CONSTRAINT [FK_MOV_TIPO]
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO]  WITH CHECK ADD  CONSTRAINT [FK_MOV_USU_DETINO] FOREIGN KEY([CD_USUARIO_DESTINO])
REFERENCES [dbo].[TB_USUARIO] ([CD_USUARIO])
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO] CHECK CONSTRAINT [FK_MOV_USU_DETINO]
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO]  WITH CHECK ADD  CONSTRAINT [FK_MOV_USU_ORIGEM] FOREIGN KEY([CD_USUARIO_ORIGEM])
REFERENCES [dbo].[TB_USUARIO] ([CD_USUARIO])
GO
ALTER TABLE [dbo].[TB_USUARIO_MOVIMENTACAO] CHECK CONSTRAINT [FK_MOV_USU_ORIGEM]
GO
ALTER TABLE [dbo].[TB_USUARIO_PONTUACAO]  WITH CHECK ADD  CONSTRAINT [FK_PONTUACAO_USUARIO] FOREIGN KEY([CD_USUARIO])
REFERENCES [dbo].[TB_USUARIO] ([CD_USUARIO])
GO
ALTER TABLE [dbo].[TB_USUARIO_PONTUACAO] CHECK CONSTRAINT [FK_PONTUACAO_USUARIO]
GO

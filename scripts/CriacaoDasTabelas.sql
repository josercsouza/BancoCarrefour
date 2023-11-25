USE Carrefour
GO

/****** Tabela [dbo].[ContaCorrente] ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ContaCorrente](
	[AnoMes] [varchar](7) NOT NULL,
	[SaldoDaConta] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_ContaCorrente] PRIMARY KEY CLUSTERED 
(
	[AnoMes] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

/****** Tabela [dbo].[Lancamento] ******/

CREATE TABLE [dbo].[Lancamento](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[AnoMes] [varchar](7) NOT NULL,
	[DataEfetiva] [datetime] NOT NULL,
	[Valor] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_Lancamento] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Lancamento]  WITH CHECK ADD  CONSTRAINT [FK_Lancamento_ContaCorrente_AnoMes] FOREIGN KEY([AnoMes])
REFERENCES [dbo].[ContaCorrente] ([AnoMes])
GO

ALTER TABLE [dbo].[Lancamento] CHECK CONSTRAINT [FK_Lancamento_ContaCorrente_AnoMes]
GO

CREATE NONCLUSTERED INDEX [IX_Lancamento_DataEfetiva] ON [dbo].[Lancamento] ([DataEfetiva] ASC)
GO


USE [SUCOS_VENDAS]
GO

INSERT INTO [dbo].[TABELA DE CLIENTES]
           ([CPF]
           ,[NOME]
           ,[ENDERECO 1]
           ,[ENDERECO 2]
           ,[BAIRRO]
           ,[CIDADE]
           ,[ESTADO]
           ,[CEP]
           ,[DATA DE NASCIMENTO]
           ,[IDADE]
           ,[SEXO]
           ,[LIMITE DE CREDITO]
           ,[VOLUME DE COMPRA]
           ,[PRIMEIRA COMPRA])
     VALUES
           (<CPF, varchar(11),>
           ,<NOME, varchar(100),>
           ,<ENDERECO 1, varchar(150),>
           ,<ENDERECO 2, varchar(150),>
           ,<BAIRRO, varchar(50),>
           ,<CIDADE, varchar(50),>
           ,<ESTADO, varchar(2),>
           ,<CEP, varchar(8),>
           ,<DATA DE NASCIMENTO, date,>
           ,<IDADE, smallint,>
           ,<SEXO, varchar(1),>
           ,<LIMITE DE CREDITO, money,>
           ,<VOLUME DE COMPRA, float,>
           ,<PRIMEIRA COMPRA, bit,>)
GO



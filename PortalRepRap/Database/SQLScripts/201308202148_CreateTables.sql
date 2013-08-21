USE PortalRepRap ;
GO
IF  NOT EXISTS (SELECT * FROM sys.tables WHERE name = N'Clientes' AND type = 'U')
BEGIN
	CREATE TABLE dbo.Clientes
	(
		ID int IDENTITY (1,1) PRIMARY KEY NOT NULL,
		Nome nvarchar(255) NOT NULL,
		Sobrenome nvarchar(255) NULL,
		Email nvarchar(255) NOT NULL,
		Senha nvarchar(20) NULL,
		CPF nvarchar(11) NULL,
		RG nvarchar(10) NULL,
		CNPJ nvarchar(14) NULL,
		TelefoneFixo nvarchar(15) NULL,
		Celular nvarchar(15) NULL,
		CEP nvarchar(8) NULL,
		Endereco nvarchar(255) NULL,
		Numero nvarchar(10) NULL,
		Complemento nvarchar(50) NULL,
		Referencia nvarchar(255) NULL,
		Bairro nvarchar(50) NULL,
		Cidade nvarchar(50) NULL,
		Estado nvarchar(10) NULL,
		Pais nvarchar(50) NULL,
		Newsletter bit NULL DEFAULT 0,
		Inativo bit NOT NULL DEFAULT 0,
		DataInativacao datetime NULL,
		DataModificacao datetime NULL,
		DataCadastro datetime DEFAULT GETDATE() NOT NULL


		--PurchaseOrderID int NOT NULL
		--	REFERENCES Purchasing.PurchaseOrderHeader(PurchaseOrderID),
		--LineNumber smallint NOT NULL,
		--ProductID int NULL 
		--	REFERENCES Production.Product(ProductID),
		--UnitPrice money NULL,
		--OrderQty smallint NULL,
		--ReceivedQty float NULL,
		--RejectedQty float NULL,
		--DueDate datetime NULL,
		--rowguid uniqueidentifier ROWGUIDCOL  NOT NULL
		--	CONSTRAINT DF_PurchaseOrderDetail_rowguid DEFAULT (newid()),
		--ModifiedDate datetime NOT NULL 
		--	CONSTRAINT DF_PurchaseOrderDetail_ModifiedDate DEFAULT (getdate()),
		--LineTotal  AS ((UnitPrice*OrderQty)),
		--StockedQty  AS ((ReceivedQty-RejectedQty)),
		--CONSTRAINT PK_PurchaseOrderDetail_PurchaseOrderID_LineNumber
		--		   PRIMARY KEY CLUSTERED (PurchaseOrderID, LineNumber)
		--		   WITH (IGNORE_DUP_KEY = OFF)
	) 
END

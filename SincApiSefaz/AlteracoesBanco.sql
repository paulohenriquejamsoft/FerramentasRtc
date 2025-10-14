CREATE TABLE CbsIbsSituacaoTributaria
(
	Id int Primary key,
	Codigo varchar(3) not null,
	Descricao varchar(max)
)


Create table CbsIbsClassificacaoTributaria(
	Id int identity(1,1) primary key,
	IdSituacaoTributaria int not null,
	Codigo varchar(10),
	Descricao varchar(max),
	TipoAliquota varchar(50),
	Nomenclatura varchar(max),
	DescricaoTratamentoTributario varchar(max),
	IncompativelComSuspensao bit,
	ExigeGrupoDesoneracao bit,
	PossuiPercentualReducao bit,
	CONSTRAINT FK_CbsIbsClassTrib_IdSitTributaria Foreign key (IdSituacaoTributaria)
	REFERENCES CbsIbsSituacaoTributaria(Id) ON DELETE CASCADE
)
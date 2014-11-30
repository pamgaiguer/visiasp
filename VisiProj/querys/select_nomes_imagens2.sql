--SELECT * FROM INFORMATION_SCHEMA.TABLES;
select * from CategoriaModels;
select * from ImagemProjetoModels;
select * from ProjetoModels;
select ProjetoModels.Id, ProjetoModels.Nome, ProjetoModels.Local, ProjetoModels.Area, 
ImagemProjetoModels.UrlNormal, ImagemProjetoModels.UrlMiniatura, ProjetoModels.Deleted
FROM ProjetoModels 
INNER JOIN ImagemProjetoModels ON ProjetoModels.Id = ImagemProjetoModels.Projeto_Id
WHERE ProjetoModels.deleted = 0
order by ProjetoModels.Nome;

select * from ImagemProjetoModels where TipoImagem = 1;
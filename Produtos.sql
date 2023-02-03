create table Produtos
(
  id int identity,
  [name] varchar(60),
  price decimal(18,2),
  brand varchar(60),
  createdAt datetime,
  updatedAt datetime,
  
  CONSTRAINT PK_Produtos_id PRIMARY KEY (id)
)


create procedure pr_s_produtos
as
begin
	select 
	id
	,[name]
	,price
	,brand
	,createdAt
	,updatedAt
	from Produtos
end

create procedure pr_s_produtos_id
(
	@id int
)
as
begin
	select 
	id
	,[name]
	,price
	,brand
	,createdAt
	,updatedAt
	from Produtos
	where id = @id
end

create procedure pr_i_produtos
  @name varchar(60),
  @price decimal(18,2),
  @brand varchar(60),
  @createdAt datetime
as
begin
	insert into Produtos ([name], price, brand, createdAt)
	values (@name, @price, @brand, @createdAt)

	select SCOPE_IDENTITY() 
end


create procedure pr_u_produtos
  @id int,
  @name varchar(60),
  @price decimal(18,2),
  @brand varchar(60),
  @updatedAt datetime
as
begin
	update Produtos 
	set 
		[name] = @name, 
		price = @price, 
		brand = @brand, 
		updatedAt = @updatedAt
	where id = @id
end
create procedure pr_d_produtos
(
	@id int
)
as
begin
	delete
	from Produtos
	where id = @id
end
exec pr_i_produtos @name='Carro', @price=20000.00, @brand='chevrolet', @createdAt='2023-02-02 11:38:04.703'
exec pr_s_produtos
exec pr_u_produtos @id=1, @name='Carro', @price=30000.00, @brand='ford', @updatedAt='2023-02-02 11:44:04.703'
exec pr_s_produtos_id @id=1
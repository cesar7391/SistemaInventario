
--CREATE TABLE dtpaises(idpais int identity(1,1) primary key, pais nchar(50))

--CREATE PROCEDURE usp_listarPaises
--AS
--BEGIN
--SELECT idpais, pais FROM dtpaises
--END

--INSERT INTO dtpaises values('Perú')
--INSERT INTO dtpaises values('México')
--INSERT INTO dtpaises values('España')
--INSERT INTO dtpaises values('Colombia')
--INSERT INTO dtpaises values('Bolivia')
--INSERT INTO dtpaises values('Ecuador')
--INSERT INTO dtpaises values('Argentina')
--INSERT INTO dtpaises values('Chile')

--***********************************************

--CREATE TABLE dtmoneda(idmoneda int identity(1,1) primary key, moneda nchar(10)) 

--INSERT INTO dtmoneda values('MXN$');
--INSERT INTO dtmoneda values('$');

--CREATE PROCEDURE usp_listarMoneda
--AS
--BEGIN
--SELECT idmoneda, moneda FROM dtmoneda
--END

--***********************************************

--CREATE TABLE dttimpuesto(idtimpuesto int identity(1,1) primary key, timpuesto nchar(10)) 

--INSERT INTO dttimpuesto values('IVA');
--INSERT INTO dttimpuesto values('IGV');

--CREATE PROCEDURE usp_listarTImpuesto
--AS
--BEGIN
--SELECT idtimpuesto, timpuesto FROM dttimpuesto
--END

--***********************************************

--CREATE TABLE dtpimpuesto(idpimpuesto int identity(1,1) primary key, pimpuesto int) 

--INSERT INTO dtpimpuesto values(18);
--INSERT INTO dtpimpuesto values(5);
--INSERT INTO dtpimpuesto values(23);

--CREATE PROCEDURE usp_listarPImpuesto
--AS
--BEGIN
--SELECT idpimpuesto, pimpuesto FROM dtpimpuesto
--END

--***********************************************

--CREATE TABLE dtempresa(idempresa int identity(1,1) primary key, razonsocial nchar(100),
--ruc nchar(20), email nchar(100), idpais int, idmoneda int, vendeconimpuestos int,
--tipoimpuesto int, idporcimpuestos int, direccion varchar(max), imagen varchar(max), proyecto nchar(30),
--status int, fregistro datetime)

--RECIBE 3 PARÁMETROS SIRVE PARA VALIDAR QUE NO ESTÉN AGREGADOS YA A LA BASE DE DATOS
--CREATE PROCEDURE usp_validarRegistroEmpresa(@razonsocial nchar(100),@ruc nchar(20),@email nchar(100))
--AS
--BEGIN
--IF NOT EXISTS(SELECT * FROM dtempresa WHERE razonsocial = @razonsocial)
--BEGIN
--	IF NOT EXISTS(SELECT * FROM dtempresa WHERE ruc = @ruc)
--	BEGIN		
--		IF NOT EXISTS(SELECT * FROM dtempresa WHERE email = @email)
--		BEGIN
--		SELECT 'OK' response
--		END
--		ELSE
--		BEGIN
--		SELECT 'El email ya se encuentra registrado' response
--		END
--	END
--	ELSE
--	BEGIN
--	SELECT 'El RFC ya se encuentra registrado' response
--	END
--END
--ELSE
--BEGIN
--SELECT 'La razón social ya se encuentra registrada' response
--END
--END

--*********************************************** SP PARA INSERTAR EMPRESA

--CREATE PROCEDURE usp_insertarEmpresa(
--@razonsocial nchar(100),
--@ruc nchar(20),
--@email nchar(100),
--@idpais int,
--@idmoneda int,
--@direccion varchar(max),
--@idimpuesto int,
--@idporcentaje int,
--@vendeimpuesto int,
--@filename varchar(max),
--@proyecto nchar(30))
--AS
--BEGIN
--IF NOT EXISTS(SELECT * FROM dtempresa WHERE ruc = @ruc)
--BEGIN
--	INSERT INTO dtempresa VALUES(
--	@razonsocial,
--	@ruc,
--	@email,
--	@idpais,
--	@idmoneda,
--	@vendeimpuesto,
--	@idimpuesto,
--	@idporcentaje,
--	@direccion,	
--	@filename,
--	@proyecto,
--	1,
--	GETDATE())
	
--	SELECT 'ok' response

--END
--ELSE
--BEGIN
--SELECT 'La empresa ya se encuentra registrada'
--END
--END

--***********************************************

--TRUNCATE TABLE dtempresa

--*********************************************** CREAR TABLA dtproveedores

--create table dtproveedores(idproveedor int identity(1,1) primary key,
--ruc nchar(20),  razonsocial nchar(200), telefono nchar(50), email nchar(200),
--direccion varchar(max), rucempresa nchar(20), status int)

--*********************************************** CREAR SP Registrar proveedores
/*
ALTER PROCEDURE usp_registrarProveedor(
@ruc nchar(20),
@razonsocial nchar(200),
@telefono nchar(50),
@email nchar(200),
@direccion varchar(max),
@rucempresa nchar(20))
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM dtproveedores WHERE ruc = @ruc AND rucempresa = @rucempresa)
	BEGIN
		IF NOT EXISTS(SELECT * FROM dtproveedores WHERE razonsocial = @razonsocial AND rucempresa = @rucempresa)
		BEGIN
			IF NOT EXISTS(SELECT * FROM dtproveedores WHERE email = @email AND rucempresa = @rucempresa)
			BEGIN
				INSERT INTO dtproveedores
				VALUES(@ruc, @razonsocial, @telefono, @email, @direccion, @rucempresa, 1)
				SELECT 'ok' response
			END
			ELSE
			BEGIN
				select 'El email del proveedor ya se encuentra registrado' response
			END
		END
		ELSE
		BEGIN
			SELECT 'La Razón Social del proveedor ya se encuentra registrada' response
		END
	END
	ELSE
	BEGIN
		SELECT 'El RFC del proveedor ya se encuentra registrado' response
	END
END
*/
--*********************************************** CREAR SP Listar proveedores
/*
ALTER PROCEDURE usp_listarProveedores(@rucempresa nchar(20))
AS
BEGIN
	SELECT idproveedor, LTRIM(RTRIM(ruc)) ruc, LTRIM(RTRIM(razonsocial))razonsocial, LTRIM(RTRIM(telefono))telefono, LTRIM(RTRIM(email))email, LTRIM(RTRIM(direccion))direccion, status from dtproveedores
END
*/
--*********************************************** CREAR SP Desactivar proveedor
/*
CREATE PROCEDURE usp_desactivarProveedor(@idprov int, @rucempresa nchar(20))
AS
BEGIN
	IF EXISTS(SELECT * FROM dtproveedores  where rucempresa = @rucempresa and idproveedor = @idprov)
	BEGIN
	update dtproveedores SET STATUS = 0 WHERE rucempresa = @rucempresa and idproveedor = @idprov
	SELECT 'ok' response
	END
	ELSE
	BEGIN
		SELECT 'No se pudo desactivar al proveedor' response
	END
END
*/
--*********************************************** CREAR SP Activar proveedor
/*
CREATE PROCEDURE usp_activarProveedor(@idprov int, @rucempresa nchar(20))
AS
BEGIN
	IF EXISTS(SELECT * FROM dtproveedores  where rucempresa = @rucempresa and idproveedor = @idprov)
	BEGIN
	update dtproveedores SET STATUS = 1 WHERE rucempresa = @rucempresa and idproveedor = @idprov
	SELECT 'ok' response
	END
	ELSE
	BEGIN
		SELECT 'No se pudo activar al proveedor' response
	END
END
*/
--*********************************************** CREAR SP Eliminar proveedor
/*
create procedure usp_eliminarProveedor(@idprov int, @rucempresa nchar(20))
as
begin
	if exists(Select * from dtproveedores  where rucempresa = @rucempresa and idproveedor = @idprov)
	begin
		delete dtproveedores where rucempresa = @rucempresa and idproveedor = @idprov
		select 'ok' response
	end
	else
	begin
		select 'No se pudo eliminar al proveedor' response
	end
end
*/
--*********************************************** CREAR SP Obtener proveedor
/*
create procedure usp_obteditarProveedor(@idprov int)
as
begin
	if exists(select * from dtproveedores where idproveedor = @idprov)
	begin
		select idproveedor,RTRIM(LTRIM(ruc))ruc, RTRIM(LTRIM(razonsocial))razonsocial,
		RTRIM(LTRIM(telefono))telefono, RTRIM(LTRIM(email))email, RTRIM(LTRIM(direccion))direccion,
		'ok'response
		from dtproveedores where idproveedor = @idprov
	end
	else
	begin
		select 'El proveedor no existe' response 
	end
end
*/
--*********************************************** CREAR SP Editar proveedor
/*
CREATE procedure usp_editarProveedor
(
@idprov int,
@ruc nchar(20),
@razonsocial nchar(200),
@telefono nchar(50),
@email nchar(200),
@direccion varchar(max),
@rucempresa nchar(20)
)
as
begin
	if not exists(select * from dtproveedores where ruc = @ruc and rucempresa = @rucempresa and idproveedor != @idprov)
	begin
		if not exists(select * from dtproveedores where razonsocial = @razonsocial and rucempresa = @rucempresa and idproveedor != @idprov)
		begin
			if not exists(select * from dtproveedores where email = @email and rucempresa = @rucempresa and idproveedor != @idprov)
			begin
				update dtproveedores set ruc= @ruc, razonsocial = @razonsocial, telefono= @telefono,
				email =@email,  direccion = @direccion where idproveedor = @idprov
				select 'ok' response
			end
			else
			begin
				select 'El email del proveedor ya se encuentra registrado' response
			end
		end
		else
		begin
			select 'La Razón Social del proveedor ya se encuentra registrada' response
		end
	end
	else
	begin
		select 'El RFC del proveedor ya se encuentra registrado' response
	end
end
*/
--*********************************************** CALCULAR VENTAS CON GANANCIA
--EXEC usp_calcularPventaSinImpuestos 250,10

--CREATE PROCEDURE usp_calcularPventaSinImpuestos
--(
--@pcosto decimal(18,2),
--@ganancia decimal(18,2)
--)
--AS
--BEGIN
--	declare @totala decimal(18,2)
--	declare @totalb decimal(18,2)

--	select @totala = (@ganancia/100);
--	select @totalb = @pcosto + (@pcosto*@totala)
--	--Se devuelve pventa
--	select @totalb AS pventa
--END
--*********************************************** TABLA DEPARTAMENT
/*
create table dtdepartamentos(iddepartamento int identity(1,1) primary key,
departamento nchar(250),   
status int)

insert into dtdepartamentos values('Laptops', 1)
insert into dtdepartamentos values('Impresoras', 1)
insert into dtdepartamentos values('Refrescos', 1)
insert into dtdepartamentos values('Lácteos', 1)
insert into dtdepartamentos values('Informática', 1)
*/
--*********************************************** LISTAR DEPARTAMENTO
/*
CREATE PROCEDURE usp_ListarDepartamentos
AS
BEGIN
	SELECT iddepartamento, LTRIM(RTRIM(departamento)) departamento from dtdepartamentos where status = 1
END
*/
--*********************************************** TABLA PRODUCTOS
/*
create table dtproductos(
idproducto int identity(1,1) primary key,
tipo int, 
codbarra nchar(50), 
descripcion varchar(max), 
tproduct int, pcosto decimal(18,2), 
ganancia int,
pventa decimal(18,2), 
pmayoreo decimal(18,2), 
apartir int, 
iddepart int, 
existencia int,
minexisten int, 
fvenci date, 
faplica int,  
status int , 
rucempresa nchar(20))
*/
--*********************************************** SP GUARDAR PRODUCTOS
/*
CREATE PROCEDURE usp_guardarProducto(
@rucempresa nchar(20),
@tipo int,
@codbarra nchar(50),
@desc varchar(max),
@tproduct int,
@pcosto decimal(18,2),
@ganancia decimal(18,2),
@pventa decimal(18,2),
@pmayoreo decimal(18,2),
@apartir int,
@sldepart int,
@existen int,
@minexisten int,
@fvenci nchar(50),
@faplica int
)     
AS
BEGIN
	DECLARE @fvencimiento DATETIME
	--SI EL TIPO ES 1 ENTONCES ES UN PRODUCTO
	if @tipo = 1
	begin
		if not exists(select * from dtproductos where  codbarra = @codbarra and rucempresa = @rucempresa)
		begin
			if not exists(select * from dtproductos where  descripcion = @desc and rucempresa = @rucempresa)
			begin

				if @fvenci = ''
				begin
					select @fvencimiento =  GETDATE();
				end
				else
				begin
					select @fvencimiento =  CAST(@fvenci as datetime);
				end

				insert into dtproductos values(@tipo,@codbarra,@desc,@tproduct,@pcosto,@ganancia,@pventa,
				@pmayoreo,@apartir,@sldepart,@existen,@minexisten, @fvencimiento, @faplica, 1, @rucempresa)

				select 'ok'response
			end
			else
			begin
				select 'La descripción ya se encuentra registrada' response
			end
		end
		else
		begin
			select 'El código de barras ya se encuentra registrado' response
		end
	end
	--SI EL TIPO ES 2 ENTONCES ES UN SERVICIO
	if	@tipo = 2
	begin
		if not exists(select * from dtproductos where  descripcion = @desc and rucempresa = @rucempresa)
		begin
			if @fvenci = ''
			begin
				select @fvencimiento =  GETDATE();
			end
			else
			begin
				select @fvencimiento =  cast(@fvenci as datetime);
			end

			insert into dtproductos values(@tipo,@codbarra,@desc,@tproduct,0,
			100,@pventa,0,0,@sldepart,0,0, @fvencimiento, 1, 1, @rucempresa)

			select 'ok'response
		end
		else
		begin
			select 'La descripción ya se encuentra registrado' response
		end
	end
end 
*/
--*********************************************** SP LISTAR PRODUCTOS
/*
EXECUTE usp_listarProductos '00000000'
CREATE PROCEDURE usp_listarProductos(@rucempresa nchar(20))
AS
BEGIN
	SELECT TOP 1000 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row,  a.idproducto,
	CASE WHEN a.tipo = 1 then 'Bien' else 'Servicio' END tipo,
	CASE WHEN a.tproduct = 1 THEN 'Unidad/Caja' ELSE 'Kilos/Gramos' END tproduct,
	a.codbarra, a.descripcion, b.departamento, a.pcosto,
	a.pventa, a.pmayoreo, a.existencia, a.minexisten,
	CASE WHEN a.faplica = 1 THEN 'No Aplica' ELSE CAST(a.fvenci AS nchar) END fvenci,
	a.status
	FROM dtproductos a
	inner join dtdepartamentos b on a.iddepart = b.iddepartamento
	WHERE a.rucempresa = @rucempresa
END
*/
--*********************************************** SP BUSCAR PRODUCTOS
--
/*
ALTER PROCEDURE usp_buscarProducto(@letra varchar(200),@rucempresa nchar(20))
AS
BEGIN
	SELECT TOP 30 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row, a.idproducto,
	CASE WHEN a.tipo = 1 then 'Bien' else 'Servicio' end tipo,
	CASE WHEN a.tproduct = 1 then 'Unidad/Caja' else 'Kilos/Gramos' end tproduct,
	a.codbarra, a.descripcion, b.departamento, a.pcosto,
	a.pventa, a.pmayoreo, a.existencia, a.minexisten,
	CASE WHEN a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci,
	a.status
	FROM dtproductos a
	inner join dtdepartamentos b on a.iddepart = b.iddepartamento
	WHERE a.descripcion LIKE '%' + @letra + '%' AND a.rucempresa = @rucempresa
	UNION
	select top 30 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row, a.idproducto,
	CASE WHEN a.tipo = 1 then 'Bien' else 'Servicio' end tipo,
	CASE WHEN a.tproduct = 1 then 'Unidad/Caja' else 'Kilos/Gramos' end tproduct,
	a.codbarra ,a.descripcion ,b.departamento ,a.pcosto,
	a.pventa , a.pmayoreo, a.existencia ,a.minexisten,
	CASE WHEN a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci,
	a.status
	FROM dtproductos a
	inner join dtdepartamentos b on a.iddepart = b.iddepartamento
	WHERE a.codbarra LIKE '%' + @letra + '%' AND a.rucempresa = @rucempresa
end
*/
--*********************************************** SP PARA BUSCAR PRODUCTO POR DEPARTAMENTOS
/*
ALTER procedure usp_buscarProductoDepartamento(@iddepartamento int, @rucempresa nchar(20))
AS
BEGIN
	if @iddepartamento <> 0
	begin
		select top 30 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row, a.idproducto,
		case when a.tipo = 1 then 'Bien' else 'Servicio' end tipo,
		case when a.tproduct = 1 then 'Unid/Caja' else 'Kilos/Gramos' end tproduct,
		a.codbarra ,a.descripcion ,b.departamento ,a.pcosto,
		a.pventa , a.pmayoreo, a.existencia ,a.minexisten,
		case when a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci,
		a.status
		from dtproductos a
		inner join dtdepartamentos b on a.iddepart = b.iddepartamento
		where a.iddepart = @iddepartamento AND a.rucempresa = @rucempresa
	end

	if @iddepartamento = 0
		begin
		select top 30 ROW_NUMBER() OVER(ORDER BY a.idproducto ASC) AS Row, a.idproducto,
		case when a.tipo = 1 then 'Bien' else 'Servicio' end tipo,
		case when a.tproduct = 1 then 'Unid/Caja' else 'Kilos/Gramos' end tproduct,
		a.codbarra ,a.descripcion ,b.departamento ,a.pcosto,
		a.pventa , a.pmayoreo, a.existencia ,a.minexisten,
		case when a.faplica = 1 then 'No Aplica' else cast(a.fvenci as nchar) end fvenci,
		a.status
		from dtproductos a
		inner join dtdepartamentos b on a.iddepart = b.iddepartamento
		where a.rucempresa = @rucempresa 
	end
end
*/
--*********************************************** SP PARA ELIMINAR PRODUCTOS
/*
CREATE PROCEDURE usp_eliminarProducto(@idproducto int)
as
begin
	delete dtproductos where idproducto = @idproducto
select 'ok' response 
end
*/
--*********************************************** SP PARA OBTENER EL TIPO DE MONEDA
/*
ALTER procedure usp_obtTipoMoneda(@rucempresa nchar(30))
AS
BEGIN
	select RTRIM(LTRIM(b.Moneda)) Moneda from dtempresa a
    INNER JOIN dtmoneda b on a.idmoneda = b.idmoneda
	where a.ruc = @rucempresa
END
*/
--***********************************************
CREATE procedure usp_obtEditarProducto(@idproducto int)
AS
BEGIN
	select a.idproducto, a.tipo, RTRIM(LTRIM(a.codbarra)) codbarra, RTRIM(LTRIM(a.descripcion)) descripcion
	,a.tproduct sevende, a.pcosto,a.ganancia,a.pventa, a.pmayoreo, a.apartir, b.iddepartamento, RTRIM(LTRIM(b.departamento))departamento,
	a.existencia, a.minexisten, RTRIM(LTRIM(cast(a.fvenci as nchar))) fvenci, a.faplica
	from dtproductos a
	inner join dtdepartamentos b on a.iddepart = b.iddepartamento   
	where idproducto = @idproducto
end



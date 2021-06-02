--******************************************************************* TABLA DE USUARIOS
/*
CREATE TABLE dtusuarios_factur(
idusuario int identity(1,1) primary key, 
username nchar(200), 
dni nchar(10), 
email nchar(100), 
usuario nchar(50), 
contrasena varchar(max), 
cargo nchar(50), 
cantaccesos int, 
ruc nchar(20), 
proyecto nchar(30),
status int, 
fregistro datetime)
*/
--******************************************************************* TABLA LICENCIAS
/*
CREATE TABLE dtlicencias(
idlicencia int identity(1,1) primary key, 
ruc nchar(20), 
email nchar(100),
finicio datetime,
ffin datetime,
proyecto nchar(30),
cantuser int,
validateemail int,
status int, 
fregistro datetime)
*/
--******************************************************************* SP PARA INSERTAR USER
/*
CREATE PROCEDURE usp_insertarUserAdminEmpresa
@ruc nchar(20),
@email nchar(100),
@username nchar(200),
@usuario nchar(50),
@contrasena varchar(max),
@cargo nchar(20),
@cantuser int,
@proyecto nchar(30)
AS
BEGIN
IF NOT EXISTS(SELECT * FROM dtusuarios_factur WHERE usuario = @usuario AND ruc = @ruc)
BEGIN
	INSERT INTO dtusuarios_factur VALUES(@username,'00000000',@email,@usuario,@contrasena,@cargo,0,@ruc,@proyecto,0,GETDATE())
	DECLARE @ffin DATETIME
	SELECT @ffin = DATEADD(DAY,16,GETDATE());	
	INSERT INTO dtlicencias VALUES(@ruc,@email,GETDATE(),@ffin,@proyecto,0,0,0,GETDATE())
	SELECT 'ok' response
END
ELSE
BEGIN	
	SELECT 'El usuario ya se encuentra registrado' response
END
END

TRUNCATE TABLE dtusuarios_factur
TRUNCATE TABLE dtlicencias
*/
--******************************************************************* SP PARA ACTIVAR CUENTA
/*
ALTER PROCEDURE usp_activarCuenta(@ruc nchar(20))
AS
BEGIN
IF EXISTS(SELECT * FROM dtlicencias WHERE ruc = @ruc AND validateemail = 0)
BEGIN
	DECLARE @ffin DATETIME
	SELECT @ffin = DATEADD(DAY,16,GETDATE());
	UPDATE dtlicencias SET validateemail = 1, status = 1, finicio = GETDATE(), ffin = @ffin WHERE ruc = @ruc
	UPDATE dtusuarios_factur SET status =1 WHERE ruc = @ruc
	SELECT 'CUENTA ACTIVADA CORRECTAMENTE' response
END
ELSE
BEGIN
	SELECT 'LA CUENTA ESTÁ ACTIVA' response
END
END
*/
--******************************************************************* CREAR TABLA usertoken

--CREATE TABLE dtusertoken(idusertoken INT IDENTITY(1,1) PRIMARY KEY, usertoken nchar(50), passwordtoken nchar(100), proyecto nchar(50), status int)

--******************************************************************* SP PARA VALIDAR TOKEN
/*
CREATE PROCEDURE usp_validarUserToken(
@usertoken nchar(50),
@passwordtoken nchar(100),
@proyecto nchar(50)
)
AS
BEGIN
	IF EXISTS(SELECT * FROM dtusertoken WHERE usertoken = @usertoken AND passwordtoken = @passwordtoken AND proyecto = @proyecto AND status = 1)
	BEGIN
		SELECT 'ok' response
	END
	ELSE
	BEGIN
		SELECT 'El usuario o contraseña del token no existen' response
	END
END
*/
--******************************************************************* SP PARA VALIDAR EL ACCESO
--usp_validarAccesos '00000000','admin','a70af698efecdc3de29bda8a3085774d6e73efaacf624ceba3a1f6c6effc6ae1','FACTUR'
/*
ALTER PROCEDURE usp_validarAccesos(
@ruc nchar(20),
@user nchar(50),
@password varchar(max),
@proyecto nchar(500)
)
AS
BEGIN
	IF EXISTS(SELECT * FROM dtlicencias WHERE validateemail = 1 AND ruc = @ruc)
	BEGIN
		UPDATE dtlicencias SET status = 0 WHERE ruc = @ruc AND ffin < GETDATE()
		IF EXISTS(SELECT * FROM dtlicencias WHERE status = 1)
		BEGIN
			IF EXISTS(SELECT * FROM dtusuarios_factur WHERE status = 1 AND ruc = @ruc AND usuario = @user AND contrasena = @password)
			BEGIN
				SELECT 'ok' response, LTRIM(RTRIM(username))username, LTRIM(RTRIM(cargo))cargo, cantaccesos, LTRIM(RTRIM(ruc))ruc,
				m.ventas, m.caja, m.clientes, m.compras, m.productos, m.inventario, m.proveedor, m.dashboard, m.usuarios, m.empresa, m.configuraciones
				FROM dtusuarios_factur u
				INNER JOIN dtmoduloapp_factur m ON m.idusuario = u.idusuario
				WHERE status = 1 AND ruc = @ruc AND usuario = @user AND contrasena = @password AND cargo <> 'superadmin'
				UNION
				SELECT 'ok' response, LTRIM(RTRIM(username))username, LTRIM(RTRIM(cargo))cargo, cantaccesos, LTRIM(RTRIM(ruc))ruc,
				0 ventas, 0 caja, 0 clientes, 0 compras, 0 productos, 0 inventario, 0 proveedor, 0 dashboard, 0 usuarios, 0 empresa, 0 configuraciones
				FROM dtusuarios_factur u
				--INNER JOIN dtmoduloapp_factur m ON m.idusuario = u.idusuario
				WHERE status = 1 AND ruc = @ruc AND usuario = @user AND contrasena = @password AND cargo = 'superadmin'
			END
			ELSE
			BEGIN
				SELECT 'Usuario o contraseña incorrectos' response, '' username, '' cargo, 0 cantaccesos, '' ruc,
				0 ventas, 0 caja, 0 clientes, 0 compras, 0 productos, 0 inventario, 0 proveedor, 0 dashboard, 0 usuarios, 0 empresa, 0 configuraciones
			END
		END
		ELSE
		BEGIN
			UPDATE dtusuarios_factur SET status = 0 WHERE ruc = @ruc
			SELECT 'Licencia vencida o la empresa no está registrada' response, '' username, '' cargo, 0 cantaccesos, '' ruc,
			0 ventas, 0 caja, 0 clientes, 0 compras, 0 productos, 0 inventario, 0 proveedor, 0 dashboard, 0 usuarios, 0 empresa, 0 configuraciones
		END
	END
	ELSE
	BEGIN
		SELECT 'No ha validado el correo o la empresa no está registrada' response, '' username, '' cargo, 0 cantaccesos, '' ruc,
		0 ventas, 0 caja, 0 clientes, 0 compras, 0 productos, 0 inventario, 0 proveedor, 0 dashboard, 0 usuarios, 0 empresa, 0 configuraciones
	END
END

--******************************************************************* SP VALIDAR CANTIDAD DE USUARIOS

ALTER PROCEDURE usp_validarCantUsers(@ruc nchar(20))
AS
BEGIN
	IF EXISTS(SELECT * FROM dtlicencias WHERE ruc = @ruc AND status = 1)
	BEGIN
		DECLARE @cantidad int
		DECLARE @cantidadlogin int

		SELECT @cantidad = cantuser FROM dtlicencias WHERE ruc = @ruc
		SELECT @cantidadlogin = COUNT(*) FROM dtusuarios_factur WHERE ruc = @ruc AND status = 1 AND cargo <> 'superadmin'

		IF @cantidad > @cantidadlogin
		BEGIN
			SELECT 'ok' response
		END
		ELSE
		BEGIN
			SELECT 'error' response
		END
	END
	ELSE
	BEGIN
		SELECT 'El RFC no existe' response
 	END
END

--SE NECESITA CREAR LA TABLA DE MODULO DE ACCESO
CREATE TABLE dtmoduloapp_factur(
idmodulo INT IDENTITY(1,1) PRIMARY KEY, 
idusuario int, 
ventas int, 
caja int, 
clientes int,
compras int,
productos int,
inventario int,
proveedor int,
dashboard int,
usuarios int,
empresa int,
configuraciones int
)
*/
--************************ SP PARA REGISTRAR USUARIOS
/*
ALTER PROCEDURE usp_registrarUsuario(
@ruc nchar(20),
@nombre nchar(200),
@dni nchar(10),
@email varchar(max),
@user nchar(50),
@password varchar(max),
@slcargo nchar(50),
/*ACCESOS*/
@ventas int,
@caja int,
@clientes int,
@compras int,
@productos int,
@inventario int,
@proveedor int,
@dashboard int,
@usuarios int,
@empresa int,
@configuraciones int
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM dtusuarios_factur WHERE dni = @dni AND ruc = @ruc AND proyecto = 'FACTUR')
	BEGIN
		IF NOT EXISTS(SELECT * FROM dtusuarios_factur WHERE email = @email AND ruc = @ruc AND proyecto = 'FACTUR')
		BEGIN
			IF NOT EXISTS(SELECT * FROM dtusuarios_factur WHERE usuario = @user AND ruc = @ruc AND proyecto = 'FACTUR')
			BEGIN
				DECLARE @countaccesos int
				SELECT @countaccesos = SUM(
				@ventas +
				@caja +
				@clientes +
				@compras +
				@productos +
				@inventario +
				@proveedor +
				@dashboard +
				@usuarios +
				@empresa +
				@configuraciones)

				INSERT INTO dtusuarios_factur VALUES(@nombre,
				@dni,
				@email,
				@user,
				@password,
				@slcargo,
				@countaccesos, 
				@ruc, 
				'FACTUR', 
				1, 
				GETDATE())
				
				DECLARE @idusuario int
				SELECT @idusuario = idusuario FROM dtusuarios_factur WHERE dni = @dni AND ruc = @ruc AND proyecto = 'FACTUR'

				INSERT INTO dtmoduloapp_factur VALUES(
				@idusuario,
				@ventas,
				@caja,
				@clientes,
				@compras,
				@productos,
				@inventario,
				@proveedor,
				@dashboard,
				@usuarios,
				@empresa,
				@configuraciones)

				SELECT 'ok' response
			END
			ELSE
			BEGIN
				SELECT 'El usuario ya está registrado' response
			END
		END
		ELSE
		BEGIN
			SELECT 'El email del usuario ya existe' response
		END
	END
	ELSE
	BEGIN
		SELECT 'El DNI del usuario ya existe' response
	END
END
*/

--******************************************************************* SP PARA LISTAR EMPLEADOS

--EXEC usp_listarEmpleados '00000000', 'superadmin'

/*
CREATE PROCEDURE usp_listarEmpleados(@ruc nchar(20), @cargo nchar(50))
AS
BEGIN
	IF @cargo = 'superadmin'
	BEGIN
		SELECT idusuario, username, dni, usuario, email, cargo, status 
		FROM dtusuarios_factur WHERE ruc = @ruc
	END
	ELSE
	BEGIN
		SELECT idusuario, username, dni, usuario, email, cargo, status 
		FROM dtusuarios_factur WHERE ruc = @ruc AND cargo <> 'superadmin'
	END
END

UPDATE dtusuarios_factur SET status = 0 WHERE idusuario = 4
*/

--******************************************************************* SP PARA ACTIVAR EMPLEADOS
/*
CREATE PROCEDURE usp_activarEmpleado(@iduser int, @ruc nchar(20))
AS
BEGIN
	DECLARE @countuser int
	DECLARE @count int
	SELECT @countuser = COUNT(*) FROM dtusuarios_factur WHERE ruc = @ruc AND status = 1 AND cargo <> 'superadmin'
	SELECT @count = cantuser FROM dtlicencias WHERE ruc = @ruc
	IF @countuser < @count
	BEGIN
		UPDATE dtusuarios_factur SET status = 1 WHERE idusuario = @iduser
		SELECT 'ok' response
	END
	ELSE
	BEGIN
		SELECT 'Ya superó la cantidad de usuarios permitidos' response
	END
END
*/

--******************************************************************* SP PARA DESACTIVAR EMPLEADOS
/*
ALTER PROCEDURE usp_desactivarEmpleado(@iduser int, @ruc nchar(20))
AS
BEGIN
	IF EXISTS(SELECT * FROM dtusuarios_factur WHERE idusuario = @iduser AND ruc = @ruc AND cargo != 'superadmin')
	BEGIN
		UPDATE dtusuarios_factur SET status = 0 WHERE idusuario = @iduser AND ruc = @ruc
		SELECT 'ok' response
	END
	ELSE
	BEGIN
		SELECT 'No se pudo desactivar al empleado' response
	END
END
*/
--******************************************************************* SP PARA ELIMINAR EMPLEADOS
/*
ALTER PROCEDURE usp_eliminarEmpleado(@iduser int, @ruc nchar(20))
AS
BEGIN
	IF EXISTS(SELECT * FROM dtusuarios_factur WHERE idusuario = @iduser AND ruc = @ruc AND cargo != 'superadmin')
	BEGIN
		DELETE dtusuarios_factur WHERE idusuario = @iduser AND ruc = @ruc
		SELECT 'ok' response
	END
	ELSE
	BEGIN
		SELECT 'No se pudo eliminar al empleado' response
	END
END
*/
--******************************************************************* TABLA PARA AGREGAR CARGOS
--CREATE TABLE dtcargo(idcargo INT IDENTITY(1,1) PRIMARY KEY, cargo nchar(100), status int)
--INSERT INTO dtcargo VALUES('Vendedor/Caja',1)
--INSERT INTO dtcargo VALUES('Almacenista',1)
--INSERT INTO dtcargo VALUES('Comunicaciones',1)
--INSERT INTO dtcargo VALUES('Administrador',1)
--******************************************************************* SP PARA LISTAR CARGOS
/*
CREATE PROCEDURE usp_listarCargos
AS
BEGIN
	SELECT idcargo, cargo FROM dtcargo WHERE status = 1
END
*/
--******************************************************************* SP PARA OBTENER DATOS DEL EMPLEADO
/*
EXEC usp_obteditarEmpleado '7', '00000000', 'Vendedor/Caja'
ALTER PROCEDURE usp_obteditarEmpleado(@iduser int, @ruc nchar(20), @cargosession nchar(50))
AS
BEGIN
	IF EXISTS(SELECT * FROM dtusuarios_factur WHERE idusuario = @iduser AND ruc = @ruc AND cargo <> 'superadmin')
	BEGIN
		SELECT 
		a.idusuario, RTRIM(LTRIM(a.username)) username, RTRIM(LTRIM(a.dni)) dni, RTRIM(LTRIM(a.email)) email, RTRIM(LTRIM(a.usuario)) usuario, 
		b.idcargo, RTRIM(LTRIM(b.cargo)) cargo,
		c.ventas, c.caja, c.clientes, c.compras, c.productos, c.inventario, 
		c.proveedor, c.dashboard, c.usuarios, c.empresa, c.configuraciones, 'ok' response
		FROM dtusuarios_factur a 
		INNER JOIN dtcargo b ON b.cargo = a.cargo
		INNER JOIN dtmoduloapp_factur c ON c.idusuario = a.idusuario
		WHERE a.idusuario = @iduser AND ruc = @ruc
	END
	ELSE
	BEGIN
		SELECT 'No puede editar estos datos' response
	END
END
*/
--******************************************************************* SP PARA ACTUALIZAR/EDITAR EMPLEADOS
/*
ALTER PROCEDURE usp_editarUsuario(
@iduser int,
@ruc nchar(20),
@nombre nchar(200),
@dni nchar(10),
@email varchar(max),
@user nchar(50),
@password varchar(max),
@slcargo nchar(50),
/*ACCESOS*/
@ventas int,
@caja int,
@clientes int,
@compras int,
@productos int,
@inventario int,
@proveedor int,
@dashboard int,
@usuarios int,
@empresa int,
@configuraciones int
)
AS
BEGIN
	IF NOT EXISTS(SELECT * FROM dtusuarios_factur WHERE dni = @dni AND ruc = @ruc AND proyecto = 'FACTUR' AND idusuario <> @iduser)
	BEGIN
		IF NOT EXISTS(SELECT * FROM dtusuarios_factur WHERE email = @email AND ruc = @ruc AND proyecto = 'FACTUR' AND idusuario <> @iduser)
		BEGIN
			IF NOT EXISTS(SELECT * FROM dtusuarios_factur WHERE usuario = @user AND ruc = @ruc AND proyecto = 'FACTUR' AND idusuario <> @iduser)
			BEGIN
				DECLARE @countaccesos int
				SELECT @countaccesos = SUM(
				@ventas +
				@caja +
				@clientes +
				@compras +
				@productos +
				@inventario +
				@proveedor +
				@dashboard +
				@usuarios +
				@empresa +
				@configuraciones)

				IF @password != '0'
				BEGIN
					UPDATE dtusuarios_factur SET
					ruc= @ruc,
					username = @nombre,
					dni = @dni,
					email = @email,
					usuario = @user,
					contrasena = @password,
					cargo = @slcargo,
					cantaccesos = @countaccesos
					WHERE idusuario = @iduser
				END
				ELSE
				BEGIN
					UPDATE dtusuarios_factur SET
					ruc= @ruc,
					username = @nombre,
					dni = @dni,
					email = @email,
					usuario = @user,
					cargo = @slcargo,
					cantaccesos = @countaccesos
					WHERE idusuario = @iduser
				END
				UPDATE dtmoduloapp_factur SET
				ventas = @ventas,
				caja = @caja,
				clientes = @clientes,
				compras = @compras,
				productos = @productos,
				inventario = @inventario,
				proveedor = @proveedor,
				dashboard = @dashboard,
				usuarios = @usuarios,
				empresa = @empresa,
				configuraciones = @configuraciones
				WHERE idusuario = @iduser
				SELECT 'ok' response
			END
			ELSE
			BEGIN
				SELECT 'El usuario ya está registrado' response
			END
		END
		ELSE
		BEGIN
			SELECT 'El email del usuario ya existe' response
		END
	END
	ELSE
	BEGIN
		SELECT 'El DNI del usuario ya existe' response
	END
END
*/


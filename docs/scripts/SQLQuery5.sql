CREATE PROCEDURE sp_ObtenerPermisosUsuario
    @id_usuario UNIQUEIDENTIFIER
AS
BEGIN
    WITH recursivo AS (
        SELECT pp.permiso_padre_id, pp.permiso_hijo_id
        FROM permiso_permisos pp
        WHERE pp.permiso_padre_id IN (
            SELECT up.permiso_id
            FROM usuario_permisos up
            WHERE up.usuario_id = @id_usuario
        )
        UNION ALL
        SELECT pp.permiso_padre_id, pp.permiso_hijo_id
        FROM permiso_permisos pp
        INNER JOIN recursivo r ON r.permiso_hijo_id = pp.permiso_padre_id
    )
    SELECT DISTINCT 
        p.permiso_id AS id,
        p.nombre,
        p.descripcion
    FROM recursivo r
    INNER JOIN permisos p ON r.permiso_hijo_id = p.permiso_id
    WHERE p.nombre IS NOT NULL;
END;

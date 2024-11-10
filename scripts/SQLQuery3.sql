-- Listar tablas, columnas, tipos de dato zy relaciones en la base de datos CRM excluyendo tablas propias del sistema
USE CRM;
WITH Columnas AS (
    SELECT
        t.TABLE_NAME,
        c.COLUMN_NAME,
        c.DATA_TYPE,
        c.CHARACTER_MAXIMUM_LENGTH,
        c.NUMERIC_PRECISION,
        c.NUMERIC_SCALE
    FROM
        INFORMATION_SCHEMA.TABLES t
        INNER JOIN INFORMATION_SCHEMA.COLUMNS c ON t.TABLE_NAME = c.TABLE_NAME
    WHERE
        t.TABLE_TYPE = 'BASE TABLE'
        AND t.TABLE_SCHEMA = 'dbo'
        AND t.TABLE_NAME NOT LIKE 'sys%' 
        AND t.TABLE_NAME NOT LIKE 'INFORMATION_SCHEMA%'
),
Relaciones AS (
    SELECT
        fk.name AS Relacion,
        tp.name AS Tabla_Origen,
        cp.name AS Columna_Origen,
        tr.name AS Tabla_Destino,
        cr.name AS Columna_Destino
    FROM
        sys.foreign_keys fk
        INNER JOIN sys.foreign_key_columns fkc ON fk.object_id = fkc.constraint_object_id
        INNER JOIN sys.tables tp ON fkc.parent_object_id = tp.object_id
        INNER JOIN sys.columns cp ON fkc.parent_object_id = cp.object_id AND fkc.parent_column_id = cp.column_id
        INNER JOIN sys.tables tr ON fkc.referenced_object_id = tr.object_id
        INNER JOIN sys.columns cr ON fkc.referenced_object_id = cr.object_id AND fkc.referenced_column_id = cr.column_id
)
SELECT
    col.TABLE_NAME,
    col.COLUMN_NAME,
    col.DATA_TYPE
    --col.CHARACTER_MAXIMUM_LENGTH,
    --col.NUMERIC_PRECISION,
    --col.NUMERIC_SCALE,
    --rel.Relacion,
    --rel.Tabla_Origen,
    --rel.Columna_Origen,
    --rel.Tabla_Destino,
    --rel.Columna_Destino
FROM
    Columnas col
    LEFT JOIN Relaciones rel ON col.TABLE_NAME = rel.Tabla_Origen AND col.COLUMN_NAME = rel.Columna_Origen
	--where col.TABLE_NAME in ('idiomas','sesion')
ORDER BY
    col.TABLE_NAME, col.COLUMN_NAME;

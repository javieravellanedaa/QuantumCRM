USE [CRM]
GO
/****** Object:  StoredProcedure [dbo].[sp_ListarGruposTecnicos]    Script Date: 22/10/2024 08:20:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[sp_ListarGruposTecnicos]
AS
BEGIN
    SET NOCOUNT ON; -- Evita que se devuelvan contadores de filas afectadas

    SELECT 
        grupo_id,           -- ID del grupo técnico
        Nombre,            -- Nombre del grupo técnico
        Descripcion,       -- Descripción del grupo técnico
        id_tecnico_lider    -- ID del técnico líder
    FROM 
        grupos
    ORDER BY 
        Nombre;           -- Opcional: ordena por nombre
END

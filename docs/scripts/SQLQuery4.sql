CREATE TABLE sesion (
    session_id UNIQUEIDENTIFIER DEFAULT NEWID() PRIMARY KEY,
    usuario_id UNIQUEIDENTIFIER NOT NULL,
    fecha_inicio DATETIME NOT NULL DEFAULT GETDATE(),
    fecha_fin DATETIME NULL,
    estado BIT NOT NULL DEFAULT 1,
    ultimo_idioma UNIQUEIDENTIFIER NULL,
    ultimo_rol_id UNIQUEIDENTIFIER NULL,
    FOREIGN KEY (usuario_id) REFERENCES usuarios(usuario_id),
    FOREIGN KEY (ultimo_idioma) REFERENCES idiomas(idioma_id),
    FOREIGN KEY (ultimo_rol_id) REFERENCES roles(rol_id)
);

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE.Composite
{
    enum  EnumPermisos
    {

        Administrador =1,
        // el administrador tiene permisos para todo

        // el aadministrador puede ver cualquier bo

        Tecnico = 2,

        /// <summary>
        ///  tecnico aprobador
        ///  tecnico con permisos para crear departamentos
        ///  tecnico con permisos para crear categorias
        ///  
        /// </summary>

        Cliente = 3
        // cliente con permisos de lectura sobre tickets
        // cliente con permisos de escritura sobre tickets
        // cliente con permisos de lectura sobre categorias
        // cliente con permisos de lectura sobre departamentos
        // cliente con permisos de lectura sobre prioridades
        // cliente con permisos de lectura sobre estados



    }
}

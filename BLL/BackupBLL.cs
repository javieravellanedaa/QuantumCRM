using System;
using System.Collections.Generic;
using BE;
using DAL;

namespace BLL
{
    public class BackupBLL
    {
        private readonly BackupDAL _dal = new BackupDAL();

        public IList<Backup> Listar()
            => _dal.Listar();

        public IList<BackupHistoryEntry> ListarHistorial()
            => _dal.ListarHistorial();

        public bool Crear(string descripcion)
        {
            try
            {
                return _dal.Crear(descripcion) != Guid.Empty;
            }
            catch
            {
                return false;
            }
        }

        public bool Restaurar(Guid id)
        {
            try
            {
                _dal.Restaurar(id);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public void SincronizarMetadataDesdeDisco()
        {
            _dal.SincronizarMetadataDesdeDisco();
        }
    }
}

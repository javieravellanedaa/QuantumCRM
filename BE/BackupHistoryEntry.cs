using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE
{
    public class BackupHistoryEntry
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FileName { get; set; }
        public string User { get; set; }
        public string MachineName { get; set; }
    }

}
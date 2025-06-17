using System.Collections.Generic;

namespace INTERFACES
{
    public class IntegrityError
    {
        public string Message { get; set; }
        public IntegrityError() { }
        public IntegrityError(string message) => Message = message;
    }

    public class IntegrityResult
    {
        public bool Result { get; set; } = true;
        public List<IntegrityError> DHErrors { get; set; } = new List<IntegrityError>();
        public List<IntegrityError> DVErrors { get; set; } = new List<IntegrityError>();
    }

    public class IntegrityResume
    {
        public bool Result { get; set; } = true;
        public List<IntegrityError> DVHErrors { get; set; } = new List<IntegrityError>();
        public List<IntegrityError> DVVErrors { get; set; } = new List<IntegrityError>();
        public List<string> DVTables { get; set; } = new List<string>();
    }
}

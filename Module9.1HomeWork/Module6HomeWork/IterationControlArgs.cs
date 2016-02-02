using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Module6HomeWork
{
    public class IterationControlArgs
    {
        public FileSystemInfo CurrentFile { get; set; }
        public bool TerminateSearch { get; set; }
        public bool Exclude { get; set; }
    }
}


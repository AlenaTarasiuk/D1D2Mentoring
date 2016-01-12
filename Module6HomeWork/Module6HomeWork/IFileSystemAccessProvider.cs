using System;
using System.Collections.Generic;

namespace Module6HomeWork
{
    public interface IFileSystemAccessProvider
    {
        IEnumerable<string> GetFiles(string rootPath);
        IEnumerable<string> GetDirectories(string rootPath);
    }
}

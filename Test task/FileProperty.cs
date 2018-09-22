using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;

namespace Test_task
{
    class FileProperty
    {
        public string FullPath { get; set; }
        public string Name { get; set; }
        public long Size { get; set; }

        public FileProperty(string path)
        {
            FileInfo fileInfo = new FileInfo(path);
            FullPath = fileInfo.DirectoryName;            
            Name = fileInfo.Name;
            Size = fileInfo.Length;
        }
    }
}

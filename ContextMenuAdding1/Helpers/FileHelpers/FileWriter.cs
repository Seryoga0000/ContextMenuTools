using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenuAdding1.Helpers.FileHelpers
{
    public class FileWriter : IFileWriter
    {
        private readonly string _path;

        public FileWriter(string path)
        {
            _path = path;
        }
        public void WriteText(string text)
        {
            File.WriteAllText(_path, text);
        }
    }
}

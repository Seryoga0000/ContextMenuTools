using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenuAdding1.Helpers.FileHelpers
{
    public class FileReader : IFileReader
    {
        private readonly string _path;

        public FileReader(string path)
        {
            _path = path;
        }
        public string ReadText()
        {
            return File.ReadAllText(_path);
        }
    }
}

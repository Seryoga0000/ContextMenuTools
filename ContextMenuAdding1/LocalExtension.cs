using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace ContextMenuAdding1
{
    public static class LocalExtension
    {
        public static RegistryKey OpenOrCreate(this RegistryKey rkKey, string name, bool writable)
        {
            var key = rkKey.OpenSubKey(name, writable) ?? rkKey.CreateSubKey(name);
            return key;
        }
    }
}

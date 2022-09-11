using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextMenuAdding1.ContextMenuClasses;
using Microsoft.Win32;

namespace ContextMenuAdding1.Helpers.GuardHelpers
{
    public class GuardHelper
    {
        public static void ContextMenuChecking(ContextMenu cm)
        {
            if (cm is null) throw new ArgumentNullException($"Context menu can't be null");
            if (cm.Count < 1) throw new ArgumentException("Context menu can't has no item");
            foreach (var item in cm)
            {
                ContextMenuItemChecking(item);
            }
        }

        public static void ContextMenuItemChecking(ContextMenuItem item)
        {
            if (item is null) throw new ArgumentNullException($"Context Menu Item can't be null");
            if (string.IsNullOrEmpty(item.Name)) throw new ArgumentException($"Context Menu Item should has name");
            if (string.IsNullOrEmpty(item.Command) && (item.SubItems.Count < 1))
                throw new ArgumentException($"Context Menu Item {item.Name} should has Command or SubItems");

            foreach (var subItem in item.SubItems)
            {
                ContextMenuSubItemChecking(subItem);
            }

        }

        public static void ContextMenuSubItemChecking(ContextMenuSubItem item)
        {
            if (item is null) throw new ArgumentNullException($"Context Menu Sub Item can't be null");
            if (string.IsNullOrEmpty(item.Name)) throw new ArgumentException($"Context Menu Sub Item should has name");
        }

        public static void RegistryKeyNullChecking(RegistryKey key)
        {
            if (key is null) throw new ArgumentNullException($"RegistryKey cannot be null");
        }
        public static void RegistryKeyNullChecking(RegistryKey key,string keyName)
        {
            if (key is null) throw new ArgumentNullException($"RegistryKey {keyName} cannot be null");
        }
        public static void StringNullChecking(string str)
        {
            if (str is null) throw new ArgumentNullException($"String cannot be null");
        }
        public static void StringNullChecking(string str,string strNamme)
        {
            if (str is null) throw new ArgumentNullException($"String {strNamme} cannot be null");
        }
    }
}

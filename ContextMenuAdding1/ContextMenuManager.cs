using ContextMenuAdding1.ContextMenuClasses;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ContextMenuAdding1.Helpers.GuardHelpers;

namespace ContextMenuAdding1
{
    public class ContextMenuManager
    {
        const string softwareClassesShell = $"SOFTWARE\\Classes\\*\\Shell";
        //const string softwareMicrosoftWindowsCurrentversionExplorerCommandstoreShell = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell";
        const string softwareMicrosoftWindowsCurrentversionExplorerCommandstoreShell = "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell";
        public static void AddContextMenuSubItem(string nameItem, string pathExe, bool bottom = true)
        {
            //RegistryKey key = Registry.ClassesRoot.OpenSubKey("Directory\\Background\\Shell", true);
            //RegistryKey newKey = key.CreateSubKey(nameList);
            //RegistryKey subNewKey = newKey.CreateSubKey("Command");
            //subNewKey.SetValue("", pathExe);
            //subNewKey.Close();
            //newKey.Close();
            //key.Close();

            //TODO:Добавить MUIverb
            var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\*\\Shell", true);
            var newKey = key?.CreateSubKey(nameItem);

            if (bottom)
            {
                var bkey = newKey?.CreateSubKey("Position");
                bkey?.SetValue("", "Bottom");
            }
            var subNewKey = newKey?.CreateSubKey("Command");
            subNewKey?.SetValue("", pathExe);
            subNewKey?.Close();
            newKey?.Close();
            key?.Close();
        }
        public static void AddContextMenuSubItem(RegistryKey newKey, string pathExe)
        {
            var subNewKey = newKey?.CreateSubKey("Command");
            subNewKey?.SetValue("", pathExe);
            subNewKey?.Close();
            newKey?.Close();
        }
        public static void AddContextMenuSubItem(RegistryKey subItemKey, ContextMenuSubItem subItem)
        {
            GuardHelper.RegistryKeyNullChecking(subItemKey!, nameof(subItemKey));
            SetContextItemBaseProperties(subItem, subItemKey);

            CreateCommandSubKey(subItemKey, subItem);
        }

        private static void CreateCommandSubKey(RegistryKey ItemKey, ContextMenuItemBase item)
        {
            GuardHelper.RegistryKeyNullChecking(ItemKey!, nameof(ItemKey));

            var subItemCommandKey = ItemKey.CreateSubKey("Command");
            GuardHelper.RegistryKeyNullChecking(subItemCommandKey!, nameof(subItemCommandKey));
            subItemCommandKey.SetValue("", item.Command!);
            subItemCommandKey.Close();
        }

        public static void AddContextMenu(ContextMenu contextMenu)
        {
            GuardHelper.ContextMenuChecking(contextMenu);
            
            ////TODO:Добавить MUIverb
            var shellKey = Registry.CurrentUser.OpenOrCreate(softwareClassesShell, true);
            //var shellKey = Registry.CurrentUser.
            GuardHelper.RegistryKeyNullChecking(shellKey!,nameof(shellKey));

            foreach (var cmItem in contextMenu)
            {
                AddContextMenuItem(shellKey, cmItem);
            }

            shellKey.Close();
        }

        private static void AddContextMenuItem(RegistryKey? shellKey, ContextMenuItem cmItem)
        {
            GuardHelper.RegistryKeyNullChecking(shellKey!, nameof(shellKey));
            
            var contextMenuItemKey = shellKey!.CreateSubKey(cmItem.Name!);
            GuardHelper.RegistryKeyNullChecking(contextMenuItemKey!, nameof(contextMenuItemKey));
            
            SetContextItemBaseProperties(cmItem, contextMenuItemKey);
            //List<RegistryKey> itemKeyList = new List<RegistryKey>();
            if(cmItem.SubItems.Count>0) AddContextMenuSubItems(cmItem.SubItems, contextMenuItemKey);
            else
            {
                if (string.IsNullOrEmpty(cmItem.Command)) CreateCommandSubKey(contextMenuItemKey, cmItem);
            }
            
        }

        private static void AddContextMenuSubItems(List<ContextMenuSubItem> subItems, RegistryKey contextMenuItemKey)
        {
            GuardHelper.RegistryKeyNullChecking(contextMenuItemKey!, nameof(contextMenuItemKey));
            var commandStoreShellKey =
                Registry.CurrentUser.OpenSubKey(softwareMicrosoftWindowsCurrentversionExplorerCommandstoreShell, true);
            GuardHelper.RegistryKeyNullChecking(commandStoreShellKey!, nameof(commandStoreShellKey));

            contextMenuItemKey.SetValue("SubCommands", string.Join(";", subItems.Select(item => item.Name)));
            foreach (var item in subItems)
            {
                var k = commandStoreShellKey!.CreateSubKey(item.Name!);
                GuardHelper.RegistryKeyNullChecking(k!, item.Name!);
                AddContextMenuSubItem(k, item);
                k.Close();
            }

            contextMenuItemKey.Close();
        }

        private static void SetContextItemBaseProperties(ContextMenuItemBase cmItem, RegistryKey contextMenuItemKey)
        {
            if (!string.IsNullOrEmpty(cmItem.Name)) contextMenuItemKey.SetValue("MUIVerb ", cmItem.Name!);
            if (cmItem.Position == PositionEnum.Below) contextMenuItemKey.SetValue("Position", "Bottom");
            if (cmItem.Position == PositionEnum.Above) contextMenuItemKey.SetValue("Position", "Top");
            if (!string.IsNullOrEmpty(cmItem.Icon)) contextMenuItemKey.SetValue("icon", cmItem.Icon);
        }

        public static RegistryKey? ContextMenuItemKey(RegistryKey shellKey, string keyName)
        {
            GuardHelper.RegistryKeyNullChecking(shellKey,nameof(shellKey));

            var contextMenuItemKey = shellKey.CreateSubKey(keyName);

            return contextMenuItemKey;
        }

        public static RegistryKey? OpenCurrentUserRegistryKey()
        {
            var shellKey = Registry.CurrentUser.OpenSubKey(softwareClassesShell, true);
            return shellKey;
        }

        public static void RemoveOption_ContextMenu(string nameItem)
        {
            RemoveKeyTree(nameItem);
        }

        private static void RemoveKeyTree(string nameItem)
        {
            var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\*\\Shell", true);
            //key?.DeleteSubKey(nameList);
            key?.DeleteSubKeyTree(nameItem);

            key?.Close();
        }

        public static void RemoveContextMenu(ContextMenu contextMenu)
        {

            RemoveKeyTree("76");
        }

    }
}

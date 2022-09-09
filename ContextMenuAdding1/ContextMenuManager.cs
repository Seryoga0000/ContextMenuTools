using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContextMenuAdding1
{
    public class ContextMenuManager
    {
        public static void AddOption_ContextMenu(string nameItem, string pathExe, bool bottom = true)
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
        public static void AddOption_ContextMenu(RegistryKey newKey,  string pathExe)
        {
            var subNewKey = newKey?.CreateSubKey("Command");
            subNewKey?.SetValue("", pathExe);
            subNewKey?.Close();
            newKey?.Close();
        }

        public static void AddList_ContextMenu(string nameList, MenuItemList menuItemList, bool bottom = true)
        {
            if (menuItemList == null) return;
            if (nameList == null) return;


            //TODO:Добавить MUIverb
            var key = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Classes\\*\\Shell", true);
            if (key == null) return;

            var commandStoreKey = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Explorer\\CommandStore\\shell", true);
            if (commandStoreKey == null) return;


            var newKey = key.CreateSubKey(nameList);
            if (newKey == null) return;

            if (bottom) newKey.SetValue("Position", "Bottom");

            newKey.SetValue("SubCommands", menuItemList.GetItemsString());

            newKey.Close();
            key.Close();

            
            //if (commandStoreKey) RemoveList_ContextMenu(nameList);

            List<RegistryKey> itemKeyList=new List<RegistryKey>();

            foreach (var item in menuItemList)
            {
                if (item == null) continue;
                if (item.ItemName == null) continue;
                if (item.Command == null) continue;
                var k = commandStoreKey.CreateSubKey(item.ItemName);
                if (k == null) continue;
                AddOption_ContextMenu(k, item.Command);
                itemKeyList.Add(k);
            }

            //itemList.ForEach(item => itemKeyList.Add(commandStoreKey?.CreateSubKey(item)));


            commandStoreKey.Close();
            itemKeyList.ForEach(item => item?.Close());
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

        public static void RemoveList_ContextMenu(string nameList)
        {
            RemoveKeyTree(nameList);
        }
        public class ItemCommandPair
        {
            string _itemName;
            string _command;


            public ItemCommandPair(string item, string command)
            {
                _itemName = item;
                _command = command;
            }

            public string Command { get => _command;  }
            public string ItemName { get => _itemName; }
        }
    }
}

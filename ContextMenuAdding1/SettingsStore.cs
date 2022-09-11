using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using ContextMenuAdding1.ContextMenuClasses;
using ContextMenuAdding1.Helpers.FileHelpers;
using static ContextMenuAdding1.ContextMenuManager;

namespace ContextMenuAdding1
{
    public interface ISettingsStore
    {
        ContextMenu LoadItemList();
        void SaveItemList(ContextMenu contextMenu);
    }

    public abstract class SettingsStore : ISettingsStore
    {
        protected ContextMenu _itemList;
        public ContextMenu ItemList => _itemList;
        public abstract ContextMenu LoadItemList();

        public abstract void SaveItemList(ContextMenu list);
    }

    public class SettingsStoreJson : SettingsStore
    {
        private readonly IFileReader _fileReader;

        private readonly IFileWriter _fileWriter;

        //private string _filePath = String.Empty;
        public 
            SettingsStoreJson(IFileReader fileReader,IFileWriter fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }
        //public interface IMenuItemListForSerialize
        //{
        //    List<ContextMenuItem> Items { get; set; }
        //    string Name { get; set; }
        //    string Command { get; set; }
        //}

        //private class MenuItemListForSerialize : IMenuItemListForSerialize
        //{
        //    public List<ContextMenuItem> Items { get; set; }
        //    public string Name { get; set; }
        //    public string Command { get; set; }
        //}

        public override ContextMenu LoadItemList()
        {
            //using FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate);
            var jsonString = _fileReader.ReadText();
            var contextMenu = JsonSerializer.Deserialize<ContextMenu>(jsonString)!;
            return contextMenu;
           
           
            //var t= new JsonDocument

            //Type type = typeof(ContextMenu);
            //PropertyInfo[] props = type.GetProperties();
            //foreach (PropertyInfo propertyInfo in props)
            //{
            //    //propertyInfo.
            //}

            //var jsonString = File.ReadAllText(_filePath);
            //JsonNode itemListNode = JsonNode.Parse(jsonString)!;
            //string listName = (string)itemListNode["Name"]!;
            //string listCommand = (string)itemListNode["Command"]!;
            //var res = new ContextMenu(listName, listCommand);
            //var itemsArray = (IEnumerable<JsonNode>)itemListNode["Items"]!;
            //foreach (var item in itemsArray)
            //{
            //    res.Add(new ContextMenuItem((string)item["Name"]!, (string)item["Command"]!));
            //}
            //return default;
        }

        public override void SaveItemList(ContextMenu contextMenu)
        {
            //var folderPath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            //if (folderPath == null) throw new Exception("Can't get directory path of application");
            //_filePath = Path.Combine(folderPath, "MenuDescription.json");
            //using FileStream fs = new FileStream(_filePath, FileMode.OpenOrCreate);
            var jsonString = JsonSerializer.Serialize(contextMenu, new JsonSerializerOptions() { WriteIndented = true });
            _fileWriter.WriteText(jsonString);
        }
    }

  

    class SettingsStoreTest : SettingsStore
    {
        ContextMenu cm = new ContextMenu();

        public SettingsStoreTest()
        {
            var subContextMenuItems = new List<ContextMenuSubItem>();

            subContextMenuItems.Add(new ContextMenuSubItem()
            {
                Name = "To basket",
                Command =
                    @"C:\Users\Сергей\source\repos\ContextMenuTools\ContextMenuAdding2\bin\Debug\net6.0\ContextMenuAdding2.exe",
            });
            subContextMenuItems.Add(new ContextMenuSubItem()
            {
                Name = "Copy to basket",
                Command =
                    @"C:\Users\Сергей\source\repos\ContextMenuTools\CopyToBasketWinApp\bin\Debug\net6.0\CopyToBasketWinApp.exe",
                Position = PositionEnum.None,
                Icon = "",
            });

            var contextMenuItem = new ContextMenuItem()
            {
                Name = "Tools",
                SubItems = subContextMenuItems,
                Position = PositionEnum.Below,
            };
            cm.Add(contextMenuItem);

            ContextMenuItem contextMenuItem2 = new ContextMenuItem()
            {
                Name = "TTTTT",
                Position = PositionEnum.Below,
                Command =
                    @"C:\Users\Сергей\source\repos\ContextMenuTools\CopyToBasketWinApp\bin\Debug\net6.0\CopyToBasketWinApp.exe",
            }; 
            cm.Add(contextMenuItem2);
        }

        public override ContextMenu LoadItemList()
        {
            return cm;
        }

        public override void SaveItemList(ContextMenu list)
        {

        }
    }
}

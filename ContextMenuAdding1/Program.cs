// See https://aka.ms/new-console-template for more information
using ContextMenuAdding1;
using System.Reflection;
using static ContextMenuAdding1.ContextMenuManager;
using Microsoft.Win32;

//var comandAddres = "C:\\Users\\Сергей\\source\\repos\\ContextMenuAdding2\\bin\\Debug\\net6.0\\ContextMenuAdding2.exe %1";
//ContextMenuManager.AddOption_ContextMenu("В корзину", comandAddres);
//ContextMenuManager.RemoveOption_ContextMenu("В корзину");
//var t = new KeyValuePair<string, string>();
var settingsStore = new SettingsStore();

MenuItemList meniItemList = settingsStore.ItemList;

//meniItemList.Add(new ItemCommandPair("В корзину", ""));


ContextMenuManager.AddList_ContextMenu("Instruments", meniItemList);
Console.WriteLine("End");


//ContextMenuManager.RemoveOption_ContextMenu("TestMenu");
//var t = Assembly.GetEntryAssembly().Location;
//var t = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
//var t = AppDomain.CurrentDomain.BaseDirectory;
//var m = 0;

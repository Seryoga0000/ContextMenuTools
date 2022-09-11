// See https://aka.ms/new-console-template for more information
using ContextMenuAdding1;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using static ContextMenuAdding1.ContextMenuManager;
using Microsoft.Win32;
using System.Xml.Serialization;
using ContextMenuAdding1.Helpers;
using ContextMenuAdding1.ContextMenuClasses;
using ContextMenuAdding1.Helpers.FileHelpers;

SettingsStoreTest t=new SettingsStoreTest();


var path = @"C:\Users\Сергей\source\repos\ContextMenuTools\ContextMenuAdding1\bin\Debug\net6.0\MenuDescription.json";
IFileReader fileReader = new FileReader(path);
IFileWriter fileWriter = new FileWriter(path);
ISettingsStore settingsStore = new SettingsStoreJson(fileReader, fileWriter);

//settingsStore.SaveItemList(t.LoadItemList());

ContextMenu cm = settingsStore.LoadItemList()!;
//ContextMenuManager.RemoveList_ContextMenu(cm[1]);
ContextMenuManager.AddContextMenu(cm);
Console.WriteLine("End");

//ContextMenuManager.AddContextMenu(cm);
//ContextMenuManager.RemoveOption_ContextMenu("TestMenu");
//var t = Assembly.GetEntryAssembly().Location;
//var t = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
//var t = AppDomain.CurrentDomain.BaseDirectory;
//var m = 0;

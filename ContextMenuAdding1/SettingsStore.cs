using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContextMenuAdding1.ContextMenuManager;

namespace ContextMenuAdding1
{
    internal class SettingsStore
    {
        private readonly MenuItemList _itemList;


        public SettingsStore()
        {
            _itemList = new MenuItemList();
            _itemList.Add(new ItemCommandPair("В корзину", "C:\\Users\\Сергей\\source\\repos\\ContextMenuAdding2\\bin\\Debug\\net6.0\\ContextMenuAdding2.exe %1"));
            _itemList.Add(new ItemCommandPair("Копию в корз.", @"C:\Users\Сергей\source\repos\ContextMenuProject\CopyToBasketWinApp\bin\Debug\net6.0\CopyToBasketWinApp.exe %1"));

        }

        public MenuItemList ItemList => _itemList;
    }
}

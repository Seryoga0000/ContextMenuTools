using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ContextMenuAdding1.ContextMenuManager;

namespace ContextMenuAdding1
{
    public class MenuItemList : List<ItemCommandPair>
    {
        public string GetItemsString()
        {
            var nameList=this.Select(pair => pair.ItemName).ToList();
            return string.Join(";", nameList);
        }
    }
}

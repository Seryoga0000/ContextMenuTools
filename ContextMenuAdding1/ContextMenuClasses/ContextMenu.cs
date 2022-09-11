
namespace ContextMenuAdding1.ContextMenuClasses
{

    public enum PositionEnum
    {
        None,
        Above,
        Below,
    }

    public class ContextMenu : List<ContextMenuItem>
    {

    }

    public abstract class ContextMenuItemBase
    {
        public string? Name { get; set; }
        public string? Command { get; set; }
        public string? Icon { get; set; }
        public PositionEnum Position { get; set; }
    }

    public class ContextMenuItem : ContextMenuItemBase
    {
        public List<ContextMenuSubItem> SubItems { get; set; } = new();

    }
    public class ContextMenuSubItem : ContextMenuItemBase
    {

    }

}

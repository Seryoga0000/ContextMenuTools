using System;
using System.Diagnostics;
using System.IO;
namespace ContextMenuAdding2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AddBasketMenuItem(args);
        }

        private static void AddBasketMenuItem(string[] args)
        {
            var fileFullPath = string.Join(" ", args);
            var fileExtension = Path.GetExtension(fileFullPath);
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileFullPath);
            var fileName = Path.GetFileName(fileFullPath);
            var folderPath = Path.GetDirectoryName(fileFullPath);
            var basketFolderPath = Path.Combine(folderPath, "Корзина");
            var newFileNameWithoutExt = string.Concat(fileNameWithoutExt, DateTime.Now.ToString("_yyyyMMddHHmmss"));
            var newFileName = Path.ChangeExtension(newFileNameWithoutExt, fileExtension);
            var newFileFullPath = Path.Combine(basketFolderPath, newFileName);
            Directory.CreateDirectory(basketFolderPath);
            File.Move(fileFullPath, newFileFullPath);
        }
    }
}

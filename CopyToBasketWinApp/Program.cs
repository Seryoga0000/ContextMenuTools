namespace CopyToBasketWinApp
{
    internal class Program
    {
        private const string folderName = "Корзина";
        private const string newFileNameFormat = "Корзина";
        static void Main(string[] args)
        {
            AddBasketMenuItem(args);
            //foreach (var item in args)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.ReadLine();
        }

        private static void AddBasketMenuItem(string[] args)
        {
            string fileFullPath, newFileFullPath;
            CreateFilesPaths(args, out fileFullPath, out newFileFullPath);
            File.Copy(fileFullPath, newFileFullPath);
        }

        private static void CreateFilesPaths(string[] args, out string fileFullPath, out string newFileFullPath)
        {
            fileFullPath = string.Join(" ", args);
            var fileExtension = Path.GetExtension(fileFullPath);
            var fileNameWithoutExt = Path.GetFileNameWithoutExtension(fileFullPath);
            var fileName = Path.GetFileName(fileFullPath);
            var folderPath = Path.GetDirectoryName(fileFullPath);
            var basketFolderPath = Path.Combine(folderPath, folderName);
            var newFileNameWithoutExt = string.Concat(fileNameWithoutExt, DateTime.Now.ToString("_yyyyMMddHHmmss"));
            var newFileName = Path.ChangeExtension(newFileNameWithoutExt, fileExtension);
            newFileFullPath = Path.Combine(basketFolderPath, newFileName);
            Directory.CreateDirectory(basketFolderPath);
        }
    }
}
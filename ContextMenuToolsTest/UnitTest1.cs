using  ContextMenuAdding1;
using ContextMenuAdding1.Helpers.FileHelpers;
using System.Text.Json;

namespace ContextMenuToolsTest
{
    [TestClass]
    public class SettingsStoreJsonTest
    {
        
        [TestMethod]
        public void LoadItemList_Test1()
        {
            var path = @"C:\Users\Сергей\source\repos\ContextMenuTools\ContextMenuAdding1\bin\Debug\net6.0\MenuDescription.json";
            IFileReader fileReader = new FileReaderTest(path);
            //IFileWriter fileWriter = new FileWriter(path);
            ISettingsStore settingsStore = new SettingsStoreJson(fileReader, null!);

            Assert.ThrowsException<JsonException>(() => settingsStore.LoadItemList());
        }
        
    }
    public class FileReaderTest : IFileReader
    {
        public FileReaderTest(string path)
        {
            
        }

        public string ReadText()
        {
            return "sfhtrhyedfsgsergwres";
        }
    }
}
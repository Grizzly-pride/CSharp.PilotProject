namespace PilotProject.Services
{
    enum Folder
    {
        DataBase,
        DataJson,
        Orders,
        SaveOrderList,
        TemplateMessages
    }

    internal static class FilePathService
    {
        private static readonly string _basePath = Environment.CurrentDirectory;
        public static string BasePath => _basePath.Remove(_basePath.IndexOf("bin"));

        private static Dictionary<Folder, string> _listFolders = new()
        {
            [Folder.DataBase] = Path.Combine(BasePath, "DataBase"),
            [Folder.DataJson] = Path.Combine(BasePath, "DataJson"),
            [Folder.Orders] = Path.Combine(BasePath, "DataJson", "Orders"),
            [Folder.SaveOrderList] = Path.Combine(BasePath, "SaveOrderList"),
            [Folder.TemplateMessages] = Path.Combine(BasePath, "DataJson", "TemplateMessages")
        };

        public static string GetPathFile(Folder folder, string fileName) => Path.Combine(_listFolders[folder], fileName);
    }
}
using PilotProject.Pages;


namespace PilotProject
{
    internal static class Main
    {
        public static void Run()
        {
            PageController MenuController = new();
            MenuController.InitializationPages();
            MenuController.SetPageByDefault(Page.Main);
        }
    }
}
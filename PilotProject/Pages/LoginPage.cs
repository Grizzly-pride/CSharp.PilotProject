using PilotProject.Services;
using PilotProject.Entities;
using static System.Console;


namespace PilotProject.Pages
{
    internal class LoginPage : BasePage
    {
        private string _name;
        private string _password;
        public override string TitlePage => "LOGIN";
        public LoginPage(PageController controller) : base(controller)
        {
            CreateWindow();
        }
        public override void Enter()
        {
            base.Enter();
            CursorVisible = true;
            UpdateForm();
        }
        public override async void UpdateForm()
        {
            base.UpdateForm();

            for (int i = 0; i < itemsForm.Length; i++)
            {
                PageItems.WriteText($"{itemsForm[i]}: ", menuPosX - 5, menuPosY + i, ConsoleColor.Green);

                switch (i)
                {
                    case 0: _name = ReadLine(); break;
                    case 1: _password = ReadLine(); break;
                }
            }

            if (await Authentication())
            {
                PageItems.WriteText("Successful login", menuPosX - 5, menuPosY + 4, ConsoleColor.Blue);
                ReadKey();
                controller.TransitionToPage(Page.Main);
            }
            else
            {
                PageItems.WriteText("Invalid password or username!", menuPosX - 5, menuPosY + 4, ConsoleColor.Red);
                PageItems.WriteText("Do you want to try again?", menuPosX - 5, menuPosY + 6, ConsoleColor.White);

                switch (PageItems.YesOrNo(menuPosX + 22, menuPosY + 6))
                {
                    case true: Enter(); break;
                    case false: controller.TransitionToPage(Page.Authorization); break;
                }
            }
        }

        public override void Exit() { }

        public override void CreateWindow()
        {
            itemsForm = new string[]
            {
                "Name",
                "Password"
            };
        }

        private async Task<bool> Authentication()
        {
            dataBase = new();
            List<User> users = dataBase.Users.ToList();           
            dataBase.Dispose();

            foreach (var user in users)
            {
                if (user.Name.Equals(_name) && user.Password.Equals(_password))
                {
                    Session.Instance.SessionId = Guid.NewGuid();
                    Session.Instance.Status = SessionStatus.LogIn;
                    Session.Instance.Time = DateTime.UtcNow;
                    Session.Instance.CurrentUser = user;
                    await FileService.ObjectToJsonAsync
                        (FilePathService.GetPathFile
                        (Folder.DataJson, "SessionsData.json"),
                        Session.Instance);
                    return true;
                }
            }
            return false;
        }
    }
}
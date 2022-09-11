using PilotProject.Services;


namespace PilotProject.Entities
{
    enum Template
    {
        Registration,
        OrderDelivered,
        OrderCompletion
    }

    internal sealed class Letter
    {
        public string Theme { get; set; }
        public string Message { get; set; }

        public static Dictionary<Template, string> TemplateLetters = new()
        {
            [Template.Registration] = FilePathService.GetPathFile(Folder.TemplateMessages, "Registering.json"),
            [Template.OrderDelivered] = FilePathService.GetPathFile(Folder.TemplateMessages, "OrderDelivered.json"),
            [Template.OrderCompletion] = FilePathService.GetPathFile(Folder.TemplateMessages, "OrderCompletion.json")
        };

        public Letter(string theme, string message)
        {
            Theme = theme;
            Message = message;
        }

        public static Letter? GetTemplateLatter(Template templateLetter)
        {
            return NewtonFileService.DeserializeFromFile<Letter>(TemplateLetters[templateLetter]);
        }
    }
}
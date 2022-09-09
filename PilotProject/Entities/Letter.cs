using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PilotProject.Services;
using static PilotProject.Services.FilePathService;


namespace PilotProject.Entities
{
    enum Template
    {
        Registration,
        OrderPaid,
        OrderDelivered,
        OrderCompletion
    }

    internal sealed class Letter
    {
        public string Theme { get; set; }
        public string Message { get; set; }

        public static Dictionary<Template, string> TemplateLetters = new()
        {
            [Template.Registration] = GetPathFile(Folder.TemplateMessages, "Registering.json"),
            [Template.OrderPaid] = GetPathFile(Folder.TemplateMessages, "OrderPaid.json"),
            [Template.OrderDelivered] = GetPathFile(Folder.TemplateMessages, "OrderDelivered.json"),
            [Template.OrderCompletion] = GetPathFile(Folder.TemplateMessages, "OrderCompletion.json")
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

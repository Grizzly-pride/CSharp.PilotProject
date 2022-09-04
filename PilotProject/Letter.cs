using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PilotProject.Services;

namespace PilotProject
{
    enum Template
    {
        Registration,
        PlacedOrder
    }

    internal sealed class Letter
    {
        public string Theme { get; set; }
        public string Message { get; set; }

        public static Dictionary<Template, string> TemplateLetters = new()
        {
            [Template.Registration] = @"D:\IT Academy Project\PilotProject\DataJson\TemplateMessages\Registering.json",
            [Template.PlacedOrder] = @"blablabla"
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

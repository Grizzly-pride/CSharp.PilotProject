using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject
{
    internal class TestTable
    {
        public int TableWidth { get; set; } 
        public void PrintLine()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine(new string('┅', TableWidth));
        }

        public void PrintRow(params string[] columns)
        {
            int width = (TableWidth - columns.Length) / columns.Length;
            string row = "┇";

            foreach (string column in columns)
            {
                row += AlignCentre(column, width) + "┇";
            }

            Console.WriteLine(row);
        }

        public string AlignCentre(string text, int width)
        {
            text = text.Length > width ? string.Concat(text.AsSpan(0, width - 3), "┅") : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}

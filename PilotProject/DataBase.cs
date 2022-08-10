using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilotProject
{
    enum DataFile
    {
        Account,
        Pizza
    }
    static class DataBase
    {
        public static Dictionary<DataFile, String> Files = new()
        {
            [DataFile.Account] = @"D:\IT Academy Project\PilotProject\Data\AccountData.json",
            [DataFile.Pizza] = @"D:\IT Academy Project\PilotProject\Data\PizzaData.json"
        };
    }
}

using PilotProject;
using PilotProject.DBContext;
using PilotProject.FoodMenu;
using System.Text;


/*
using System;
using System.Data;
using Microsoft.Data.Sqlite;
*/

/*
Drink soda1 = new("Sprite", "Soda", 0.5, 3.10);
Drink soda2 = new("Sprite", "Soda", 1, 3.80);
Drink soda3 = new("Coca-Cola", "Soda", 0.5, 3.10);
Drink soda4 = new("Coca-Cola", "Soda", 1, 3.80);
Drink soda5 = new("Coca-Cola Vanila", "Soda", 0.5, 3.10);
Drink soda6 = new("Coca-Cola Vanila", "Soda", 1, 3.80);
Drink soda7 = new("Coca-Cola Zero", "Soda", 0.5, 3.10);
Drink soda8 = new("Coca-Cola Zero", "Soda", 1, 3.80);
Drink soda9 = new("Fanta", "Soda", 0.5, 3.10);
Drink soda10 = new("Fanta", "Soda", 1, 3.80);
Drink soda12 = new("Rich - multifruit", "Juice", 1, 4.90);
Drink soda13 = new("Rich - cherry", "Juice", 1, 4.90);
Drink soda14 = new("Rich - tomato", "Juice", 1, 4.90);
Drink soda15 = new("Rich - mango", "Juice", 1, 4.90);
Drink soda16 = new("Rich - orange", "Juice", 1, 4.90);
Drink soda17 = new("Rich - apple", "Juice", 1, 4.90);
Drink soda18 = new("BonAqua", "Water", 0.5, 1.90);
Drink soda19 = new("Frost", "Water", 0.5, 1.90);
Drink soda20 = new("Frost", "Water", 0.5, 1.90);
Drink soda21 = new("Red-Bull", "Energy", 0.25, 4.70);
Drink soda22 = new("Burn", "Energy", 0.25, 4.20);
ApplicationContext db = new();
db.Add(soda1);
db.Add(soda2);
db.Add(soda3);
db.Add(soda4);
db.Add(soda5);
db.Add(soda6);
db.Add(soda7);
db.Add(soda8);
db.Add(soda9);
db.Add(soda10);
db.Add(soda12);
db.Add(soda13);
db.Add(soda14);
db.Add(soda15);
db.Add(soda16);
db.Add(soda17);
db.Add(soda18);
db.Add(soda19);
db.Add(soda20);
db.Add(soda21);
db.Add(soda22);   
db.SaveChanges();
*/

/*
ApplicationContext db = new();
List<Drink> list = db.Drinks.ToList();
Console.OutputEncoding = Encoding.Unicode;

for (int i = 0; i < list.Count; i++)
{
    Console.Write(list[i].Name);
    Console.WriteLine(list[i].Id);
} 
*/

/*
const int A = -17;
const int B = -7;
const int C = -10;
const int D = -12;

const string NameColA = "Name";
const string NameColB = "Volume";
const string NameColC = "Price";
const string NameColD = "Subcategory";

int ColA = $"│{list[0].Name,A}".Length;
int ColB = $"│{list[0].Volume,B}".Length;
int ColC = $"│{list[0].Price,C}".Length;
int ColD = $"│{list[0].Subcategory,D}│".Length;
int lengthStr = ColA + ColB + ColC + ColD;

Console.Write(new string('┌', 1));
Console.Write(new string('─', ColA - 1));
Console.Write(new string('┬', 1));
Console.Write(new string('─', ColB - 1));
Console.Write(new string('┬', 1));
Console.Write(new string('─', ColC - 1));
Console.Write(new string('┬', 1));
Console.Write(new string('─', ColD - 2));
Console.WriteLine(new string('┐', 1));


Console.Write($"│{NameColA,A}");
Console.Write($"│{NameColB,B}");
Console.Write($"│{NameColC,C}");
Console.WriteLine($"│{NameColD,D}│");


Console.Write(new string('├', 1));
Console.Write(new string('─', ColA - 1));
Console.Write(new string('┼', 1));
Console.Write(new string('─', ColB - 1));
Console.Write(new string('┼', 1));
Console.Write(new string('─', ColC - 1));
Console.Write(new string('┼', 1));
Console.Write(new string('─', ColD - 2));
Console.WriteLine(new string('┤', 1));


for (int i = 0; i < list.Count; i++)
{   
    Console.Write($"│{list[i].Name,A}");
    Console.Write($"│{list[i].Volume,B}");
    Console.Write($"│{list[i].Price,C}");
    Console.WriteLine($"│{list[i].Subcategory,D}│");
}

Console.Write(new string('└', 1));
Console.Write(new string('─', ColA - 1));
Console.Write(new string('┴', 1));
Console.Write(new string('─', ColB - 1));
Console.Write(new string('┴', 1));
Console.Write(new string('─', ColC - 1));
Console.Write(new string('┴', 1));
Console.Write(new string('─', ColD - 2));
Console.WriteLine(new string('┘', 1));

Console.WriteLine(lengthStr);
*/

//Main.Run();


/*
TestTable table = new();
table.TableWidth = 65;
Console.Clear();
table.PrintLine();
table.PrintRow("Column 1", "Column 2", "Column 3", "Column 4", "Column5");
table.PrintLine();
table.PrintRow("qeweqweqwe", "qweew", "we", "qweqwe");
table.PrintRow("wew", "qweqweqwe", "ee", "e");
table.PrintRow("qeweqweqwe", "qweew", "we", "qweqwe");
table.PrintRow("qeweqweqwe", "qweew", "we", "qweqwe");
table.PrintRow("qeweqweqwe", "qweew", "we", "qweqwe");
table.PrintLine();
Console.ReadLine();
*/


/*

using (var connection = new SqliteConnection(@"Data Source=C:\Users\alexandr.medved\Desktop\C#\Pilot_project\PilotProject\DataBase\dotnetpizza.db"))
{
    connection.Open();
    SqliteCommand command = connection.CreateCommand();
}
*/

MenuBuilder menu = new(2, 1, 3, 2, 1);
menu.ItemsMenu = new();
ApplicationContext db = new();
List<Drink> drink = db.Drinks.ToList();

TableBuilder table = new(5);
string[] headers = { "Id", "Name", "Value", "Price", "Category" };
table.Headers = headers;
int[] size = { -3, -18, -5, -5, -8};
table.ColumnSizes = size;


/*
Console.WriteLine(table.AddTopLine());
Console.WriteLine(table.AddHeader());
Console.WriteLine(table.AddMiddleLine());
*/

menu.ItemsMenu.Add(table.AddTopLine());
menu.ItemsMenu.Add(table.AddHeader());
menu.ItemsMenu.Add(table.AddMiddleLine());

for (int i = 0; i < drink.Count; i++)
{
    menu.ItemsMenu.Add(table.AddRow(drink[i].Id, drink[i].Name, drink[i].Volume, drink[i].Price, drink[i].Category));
    //Console.WriteLine(table.AddRow(drink[i].Id, drink[i].Name, drink[i].Volume, drink[i].Price, drink[i].Category));        
}
//Console.WriteLine(table.AddEndLine()); 

//Console.WriteLine(table.PrintRow(drink[0].Id, drink[0].Name, drink[0].Volume, drink[0].Price, drink[0].Category));

menu.ItemsMenu.Add(table.AddEndLine());
menu.RunMenu();



/*
var column1 = new List<string>();
column1.Add("Name");
column1.Add("Value");
column1.Add("Price");
column1.Add("Category");
var maxWidth = column1.Max(s => s.Length);
int a = 20;
var formatString = string.Format($"{{0, -{a}}}|", maxWidth);
foreach (var s in column1)
{
    Console.Write(formatString, s);

}


int n
Console.WriteLine("{0,"+n + "}|{1,"+ n + "}", Variable1, Variable2);
*/





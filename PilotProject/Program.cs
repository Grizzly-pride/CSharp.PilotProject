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
MenuBuilder menu = new(1, 1, 3, 1);
menu.ItemsMenu = new();
ApplicationContext db = new();
List<Drink> drink = db.Drinks.ToList();

TableBuilder table = new(5);
string[] headers = { "Id", "Name", "Value", "Price", "Category" };
table.Headers = headers;
int[] size = { -3, -18, -5, -5, -8};
table.ColumnSizes = size;

menu.ItemsMenu.Add(table.AddTopLine());
menu.ItemsMenu.Add(table.AddHeader());
menu.ItemsMenu.Add(table.AddMiddleLine());

for (int i = 0; i < drink.Count; i++)
{
    menu.ItemsMenu.Add(table.AddRow(drink[i].Id, drink[i].Name, drink[i].Volume, drink[i].Price, drink[i].Category));
 
}

menu.ItemsMenu.Add(table.AddEndLine());
int index = menu.RunMenu();
Console.WriteLine(index);

*/






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


Main.Run();





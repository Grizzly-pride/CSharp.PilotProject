using PilotProject;
using PilotProject.DBContext;
using PilotProject.FoodMenu;
using System.Text;



using System;
using System.Data;
using Microsoft.Data.Sqlite;

#region Drink
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
#endregion

#region Pizzas
/*
Pizza pizza1 = new Pizza("Greek", "Spice", "Traditional", 30, 23.60);
Pizza pizza2 = new Pizza("Greek", "Spice", "Traditional", 40, 36.30);
Pizza pizza111 = new Pizza("Greek", "Spice", "Thin", 30, 23.60);
Pizza pizza222 = new Pizza("Greek", "Spice", "Thin", 40, 36.30);

Pizza pizza3 = new Pizza("Big Bonanza", "Spice", "Traditional", 30, 37.30);
Pizza pizza4 = new Pizza("Big Bonanza", "Spice", "Traditional", 40, 53.80);
Pizza pizza333 = new Pizza("Big Bonanza", "Spice", "Thin", 30, 37.30);
Pizza pizza444 = new Pizza("Big Bonanza", "Spice", "Thin", 40, 53.80);

Pizza pizza5 = new Pizza("Mexican", "Spice", "Traditional", 30, 29.20);
Pizza pizza6 = new Pizza("Mexican", "Spice", "Traditional", 40, 39.90);
Pizza pizza555 = new Pizza("Mexican", "Spice", "Thin", 30, 29.20);
Pizza pizza666 = new Pizza("Mexican", "Spice", "Thin", 40, 39.90);

Pizza pizza7 = new Pizza("Margherita", "Veggie", "Traditional", 30, 23.60);
Pizza pizza8 = new Pizza("Margherita", "Veggie", "Traditional", 40, 36.30);
Pizza pizza777 = new Pizza("Margherita", "Veggie", "Thin", 30, 23.60);
Pizza pizza888 = new Pizza("Margherita", "Veggie", "Thin", 40, 36.30);

Pizza pizza9 = new Pizza("Vegetarian", "Veggie", "Traditional", 30, 23.60);
Pizza pizza10 = new Pizza("Vegetarian", "Veggie", "Traditional", 40, 36.30);
Pizza pizza999 = new Pizza("Vegetarian", "Veggie", "Thin", 30, 23.60);
Pizza pizza1000 = new Pizza("Vegetarian", "Veggie", "Thin", 40, 36.30);

Pizza pizza11 = new Pizza("Cheese", "Veggie", "Traditional", 30, 15.90);
Pizza pizza12 = new Pizza("Cheese", "Veggie", "Traditional", 40, 24.60);
Pizza pizza1111 = new Pizza("Cheese", "Veggie", "Thin", 30, 15.90);
Pizza pizza1222 = new Pizza("Cheese", "Veggie", "Thin", 40, 24.60);

Pizza pizza13 = new Pizza("Alfredo", "Mushrooms", "Traditional", 30, 31.70);
Pizza pizza14 = new Pizza("Alfredo", "Mushrooms", "Traditional", 40, 44.90);
Pizza pizza1333 = new Pizza("Alfredo", "Mushrooms", "Thin", 30, 31.70);
Pizza pizza1444 = new Pizza("Alfredo", "Mushrooms", "Thin", 40, 44.90);

Pizza pizza15 = new Pizza("Ham and Mushrooms", "Mushrooms", "Traditional", 30, 23.60);
Pizza pizza16 = new Pizza("Ham and Mushrooms", "Mushrooms", "Traditional", 40, 36.30);
Pizza pizza1555 = new Pizza("Ham and Mushrooms", "Mushrooms", "Thin", 30, 23.60);
Pizza pizza1666 = new Pizza("Ham and Mushrooms", "Mushrooms", "Thin", 40, 36.30);

Pizza pizza17 = new Pizza("Meat Delight", "Meat", "Traditional", 30, 34.90);
Pizza pizza18 = new Pizza("Meat Delight", "Meat", "Traditional", 40, 47.70);
Pizza pizza1777 = new Pizza("Meat Delight", "Meat", "Thin", 30, 34.90);
Pizza pizza1888 = new Pizza("Meat Delight", "Meat", "Thin", 40, 47.70);

Pizza pizza19 = new Pizza("Double Pepperoni", "Meat", "Traditional", 30, 34.90);
Pizza pizza20 = new Pizza("Double Pepperoni", "Meat", "Traditional", 40, 47.70);
Pizza pizza1999 = new Pizza("Double Pepperoni", "Meat", "Thin", 30, 34.90);
Pizza pizza2000 = new Pizza("Double Pepperoni", "Meat", "Thin", 40, 47.70);

Pizza pizza21 = new Pizza("Chicken ranch", "Meat", "Traditional", 30, 31.70);
Pizza pizza22 = new Pizza("Chicken ranch", "Meat", "Traditional", 40, 44.90);
Pizza pizza2111 = new Pizza("Chicken ranch", "Meat", "Thin", 30, 31.70);
Pizza pizza2222 = new Pizza("Chicken ranch", "Meat", "Thin", 40, 44.90);


ApplicationContext db = new();
db.Add(pizza1);
db.Add(pizza2);
db.Add(pizza111);
db.Add(pizza222);
db.Add(pizza3);
db.Add(pizza4);
db.Add(pizza333);
db.Add(pizza444);
db.Add(pizza5);
db.Add(pizza6);
db.Add(pizza555);
db.Add(pizza666);
db.Add(pizza7);
db.Add(pizza8);
db.Add(pizza777);
db.Add(pizza888);
db.Add(pizza9);
db.Add(pizza10);
db.Add(pizza999);
db.Add(pizza1000);
db.Add(pizza11);
db.Add(pizza12);
db.Add(pizza1111);
db.Add(pizza1222);
db.Add(pizza13);
db.Add(pizza14);
db.Add(pizza1333);
db.Add(pizza1444);
db.Add(pizza15);
db.Add(pizza16);
db.Add(pizza1555);
db.Add(pizza1666);
db.Add(pizza17);
db.Add(pizza18);
db.Add(pizza1777);
db.Add(pizza1888);
db.Add(pizza19);
db.Add(pizza20);
db.Add(pizza1999);
db.Add(pizza2000);
db.Add(pizza21);
db.Add(pizza22);
db.Add(pizza2111);
db.Add(pizza2222);
db.SaveChanges();
*/
#endregion





/*
MenuBuilder menu = new(1, 1,4,1);
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





using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.DBContext;
using PilotProject.FoodMenu;
using PilotProject.Services;
using PilotProject.Builders;
using PilotProject.Interfaces;
using static System.Console;
using static PilotProject.Pages.PageItems;



namespace PilotProject.Pages
{
    enum CategoryDrink
    {
        Soda,
        Juice,
        Water,
        Energy,
        All
    }

    internal sealed class DrinksPage : BasePage, IFilterProduct<Drink, CategoryDrink>
    {
        private bool _isShowTable = false;
        private readonly List<Drink> _drinks;
        private IEnumerable<Drink> _filterDrinks;
        private CategoryDrink _filter;
        public override string TitlePage => "DRINKS";

        public DrinksPage(PageController controller) : base(controller)
        {
            dataBase = new();
            _drinks = dataBase.Drinks.ToList();
            dataBase.Dispose();
        }

        public override void Enter()
        {
            base.Enter();
            CreateWindow();
            UpdateMenu();
        }

        public override void UpdateMenu()
        {
            base.UpdateMenu();

            if (_isShowTable)
            {
                if(selectedItem == -1)
                {
                    _isShowTable = false;
                    Enter();
                }
                else
                {
                    Product addProduct = _filterDrinks.ElementAt(selectedItem);

                    Clear();
                    WriteText($"Add {addProduct.Name} to cart?", 7, ConsoleColor.White);

                    if (YesOrNo(2, 12))
                    {
                        if (Account.IsAuthorization())
                        {
                            Clear();
                            AddingToCart(addProduct);
                        }
                        else
                        {
                            Clear();
                            WriteText("You must be logged in to add to cart.", 7, ConsoleColor.Red);
                            WriteText("Press enter to continue.", 12, ConsoleColor.White);
                            ReadKey();
                        }
                    }
                    Enter();
                }
            }
            else
            {
                switch (selectedItem)
                {
                    case 0: _isShowTable = true; _filter = CategoryDrink.Soda; Enter(); break;
                    case 1: _isShowTable = true; _filter = CategoryDrink.Juice; Enter(); break;
                    case 2: _isShowTable = true; _filter = CategoryDrink.Water; Enter(); break;
                    case 3: _isShowTable = true; _filter = CategoryDrink.Energy; Enter(); break;
                    case 4: _isShowTable = true; _filter = CategoryDrink.All; Enter(); break;
                    case 5: controller.TransitionToPage(Page.Main); break;
                }
            }
        }

        public override void Exit()
        {
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            if (_isShowTable)
            {
                CreateTable();
            }
            else
            {
                moveTitle = 12;
                menu = new(2, 11, false);
                menu.ItemsMenu = new()
                {
                    "Soda",
                    "Juice",
                    "Water",
                    "Energy",
                    "All drinks",
                    "Back"
                };
            }
        }

        private void CreateTable()
        {
            table = new(4);
            table.Headers = new string[] { "Name", "Value", "Price", "Category" };
            table.ColumnSizes = new int[] { -17, -5, -5, -8 };

            moveTitle = 18;
            menu = new(2, 1, 3, 1, true);
            menu.ItemsMenu = new()
            {
                table.AddTopLine(),
                table.AddHeader(),
                table.AddMiddleLine()
            };

            _filterDrinks = _filter switch
            {
                CategoryDrink.All => _drinks,
                CategoryDrink.Soda => CategorySearch(CategoryDrink.Soda),
                CategoryDrink.Juice => CategorySearch(CategoryDrink.Juice),
                CategoryDrink.Water => CategorySearch(CategoryDrink.Water),
                CategoryDrink.Energy => CategorySearch(CategoryDrink.Energy),
                _ => throw new NotImplementedException()
            };

            foreach (var drink in _filterDrinks)
            {
                menu.ItemsMenu.Add(table.AddRow(drink.Name, drink.Volume, drink.Price, drink.Subcategory));
            }

            menu.ItemsMenu.Add(table.AddEndLine());
        }

        public IEnumerable<Drink> CategorySearch(CategoryDrink category) => _drinks.Where(drink => drink.Subcategory.Equals(category.ToString(), StringComparison.OrdinalIgnoreCase));
    }
}

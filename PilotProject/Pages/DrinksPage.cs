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
                    WriteText($"Add {addProduct.Name} to cart?", 11, 0, ConsoleColor.White);

                    if (YesOrNo(14, 2))
                    {
                        if (Account.IsAuthorization())
                        {
                            Clear();
                            AddingToCart(addProduct);
                        }
                        else
                        {
                            Clear();
                            WriteText("You must be logged in to add to cart.", 11, 0, ConsoleColor.Red);
                            WriteText("Press enter to continue.", 15, 2, ConsoleColor.White);
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
                    case 0: _filter = CategoryDrink.Soda; break;
                    case 1: _filter = CategoryDrink.Juice; break;
                    case 2: _filter = CategoryDrink.Water; break;
                    case 3: _filter = CategoryDrink.Energy; break;
                    case 4: _filter = CategoryDrink.All; break;
                    case 5: controller.TransitionToPage(Page.Main); break;
                }
                _isShowTable = true;
                Enter();
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
                moveTitle = 11;
                menu = new(10, 2, false);
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

            moveTitle = 25;
            menu = new(1, 2, 3, 1, true);
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

using PilotProject.FoodMenu;
using PilotProject.Interfaces;
using PilotProject.Entities;
using static System.Console;


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

    internal sealed class DrinksPage : BasePage, IFilterOrderItem<Drink, CategoryDrink>
    {
        private bool _isUpdateTable = false;
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

            if (_isUpdateTable)
            {
                if(selectedItem == -1)
                {
                    _isUpdateTable = false;
                    Enter();
                }
                else
                {
                    Product addProduct = _filterDrinks.ElementAt(selectedItem);

                    if (Session.Instance.IsAuthorization())
                    {
                        PageItems.AddingToCart(addProduct, tablePosX + 61, selectedItem + tablePosY + 3);
                    }
                    else
                    {
                        PageItems.WriteText("You must be logged in to add to cart!",
                            tablePosX + 2,
                            tablePosY -1,
                            ConsoleColor.Red);

                        ReadKey(true);
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
                _isUpdateTable = true;
                Enter();
            }
        }

        public override void Exit()
        {
            menu.ResetSelectIndex();
        }

        public override void CreateWindow()
        {
            if (_isUpdateTable)
            {
                CreateTable();
            }
            else
            {
                menu = new(menuPosX, menuPosY, false);
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
            table.ColumnSizes = new int[] { -28, -7, -7, -11 };

            menu = new(tablePosX, tablePosY, 3, 1, true);
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

        public IEnumerable<Drink> CategorySearch(CategoryDrink category) =>
            _drinks.Where(drink => drink.Subcategory
            .Equals(category.ToString(), StringComparison.OrdinalIgnoreCase));
    }
}
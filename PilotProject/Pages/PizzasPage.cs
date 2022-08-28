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
    enum CategoryPizzas
    {
        Spice,
        Veggie,
        Mushrooms,
        Meat,
        All
    }

    internal sealed class PizzasPage : BasePage, IFilterProduct<Pizza, CategoryPizzas>
    {
        private bool _isShowTable = false;
        private readonly List<Pizza> _pizzas;
        private IEnumerable<Pizza> _filterPizzas;
        private CategoryPizzas _filter;
        public override string TitlePage => "PIZZAS";

        public PizzasPage(PageController controller) : base(controller)
        {
            dataBase = new();
            _pizzas = dataBase.Pizzas.ToList();
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
                if (selectedItem == -1)
                {
                    _isShowTable = false;
                    Enter();
                }
                else
                {
                    Product addProduct = _filterPizzas.ElementAt(selectedItem);

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
                    case 0: _isShowTable = true; _filter = CategoryPizzas.Spice; Enter(); break;
                    case 1: _isShowTable = true; _filter = CategoryPizzas.Veggie; Enter(); break;
                    case 2: _isShowTable = true; _filter = CategoryPizzas.Mushrooms; Enter(); break;
                    case 3: _isShowTable = true; _filter = CategoryPizzas.Meat; Enter(); break;
                    case 4: _isShowTable = true; _filter = CategoryPizzas.All; Enter(); break;
                    case 5: controller.TransitionToPage(Page.Main); break;
                }
            }
        }

        public override void Exit()
        {
            base.Exit();
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
                    "Spice",
                    "Veggie",
                    "Mushrooms",
                    "Meat",
                    "All pizzas",
                    "Back"
                };
            }
        }

        private void CreateTable()
        {
            table = new(5);
            table.Headers = new string[] { "Name", "Size/cm", "Crust", "Price", "Category" };
            table.ColumnSizes = new int[] { -18, -7, -11, -5, -10 };

            moveTitle = 23;
            menu = new(2, 1, 3, 1, true);
            menu.ItemsMenu = new()
            {
                table.AddTopLine(),
                table.AddHeader(),
                table.AddMiddleLine()
            };

            _filterPizzas = _filter switch
            {
                CategoryPizzas.All => _pizzas,
                CategoryPizzas.Spice => CategorySearch(CategoryPizzas.Spice),
                CategoryPizzas.Veggie => CategorySearch(CategoryPizzas.Veggie),
                CategoryPizzas.Mushrooms => CategorySearch(CategoryPizzas.Mushrooms),
                CategoryPizzas.Meat => CategorySearch(CategoryPizzas.Meat),
                _ => throw new NotImplementedException()
            };

            foreach (var pizza in _filterPizzas)
            {
                menu.ItemsMenu.Add(table.AddRow(pizza.Name, pizza.Size, pizza.Crust, pizza.Price, pizza.Subcategory));
            }

            menu.ItemsMenu.Add(table.AddEndLine());
        }

        public IEnumerable<Pizza> CategorySearch(CategoryPizzas category) => _pizzas.Where(pizza => pizza.Subcategory.Equals(category.ToString(), StringComparison.OrdinalIgnoreCase));
    }
}

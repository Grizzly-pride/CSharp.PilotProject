using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PilotProject.DBContext;
using PilotProject.FoodMenu;
using PilotProject.Services;
using PilotProject.Builders;
using PilotProject.Entities;
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

    internal sealed class PizzasPage : BasePage, IFilterOrderItem<Pizza, CategoryPizzas>
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
                    WriteText($"Add {addProduct.Name} to cart?", 11, 0, ConsoleColor.White);

                    if (YesOrNo(14, 2))
                    {
                        if (Session.GetStatic().IsAuthorization())
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
                    case 0: _filter = CategoryPizzas.Spice; break;
                    case 1: _filter = CategoryPizzas.Veggie; break;
                    case 2: _filter = CategoryPizzas.Mushrooms; break;
                    case 3: _filter = CategoryPizzas.Meat; break;
                    case 4: _filter = CategoryPizzas.All; break;
                    case 5: controller.TransitionToPage(Page.Main); break;
                }
                _isShowTable = true;
                Enter();
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
                moveTitle = 11;
                menu = new(10, 2, false);
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

            moveTitle = 25;
            menu = new(1, 2, 3, 1, true);
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

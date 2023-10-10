using Restaurant.Generators;
using Restaurant.Handlers;
using Restaurant.Menus;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //メニューの入力
            MenuInputHandler menuInputHandler = new MenuInputHandler();
            List<Menu> menuList = menuInputHandler.CollectMenuItemsFromConsole();

            //注文の受付
            OrderInputHandler orderHandler = new OrderInputHandler();
            orderHandler.CollectOrdersFromConsole(menuList);
        }
    }
}
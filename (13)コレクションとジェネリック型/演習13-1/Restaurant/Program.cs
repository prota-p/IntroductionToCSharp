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
            //★(a1) リスト型の変数を宣言
            List<Menu> menuList = menuInputHandler.CollectMenuItemsFromConsole();

            //メニュー表を生成
            //★(b) リスト型を配列型に変換
            MenuTableGenerator tableGenerator = new MenuTableGenerator(menuList.ToArray());
            string tableHtml = tableGenerator.GenerateTable();

            //メニュー表をHTMLページとして出力
            MenuPageGenerator htmlGenerator = new MenuPageGenerator(tableHtml);
            string html = htmlGenerator.GenerateHtml();
            Console.WriteLine(html);
        }
    }
}
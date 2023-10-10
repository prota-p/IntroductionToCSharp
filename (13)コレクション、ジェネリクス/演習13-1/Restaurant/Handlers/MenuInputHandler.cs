using Restaurant.Helpers;
using Restaurant.Menus;

namespace Restaurant.Handlers
{
    internal class MenuInputHandler
    {
        //コンソールからメニューを入力
        public List<Menu> CollectMenuItemsFromConsole()
        {
            // ★(a2) リスト型の変数を宣言し、空のリストを生成して代入
            List<Menu> menus = new List<Menu>();

            while (true)
            {
                Console.WriteLine("新しいメニューを追加しますか？");
                //メニューを追加するかどうかを入力
                bool isAddingMenu = InputHelper.GetValidBoolean();
                if (isAddingMenu)
                {
                    //メニューを追加
                    AddNewMenuItem(menus);
                    //現在のメニュー一覧を表示
                    DisplayCurrentMenus(menus);
                }
                else
                {
                    //メニュー追加を終了
                    break;
                }
            }

            return menus;
        }

        //現在のメニュー一覧を表示
        private void DisplayCurrentMenus(List<Menu> menus)
        {
            //★(c) リスト型の変数をforeachで処理
            Console.WriteLine("現在追加されているメニュー名一覧:");
            foreach (Menu menu in menus)
            {
                Console.WriteLine(menu.Name);
            }
        }

        //新しいメニューを追加
        private void AddNewMenuItem(List<Menu> menus)
        {
            //メニュータイプを入力
            MenuType menuType = GetMenuType();

            if (menuType == MenuType.Unknown)
            {
                Console.WriteLine("無効なメニュータイプです。");
                return;
            }

            //メニュー名、説明、価格を入力
            Console.WriteLine("メニュー名を入力してください:");
            string name = InputHelper.GetValidString();

            Console.WriteLine("説明を入力してください:");
            string description = InputHelper.GetValidString();

            Console.WriteLine("価格を入力してください:");
            int price = InputHelper.GetValidInteger();

            switch (menuType)
            {
                case MenuType.Main:
                    Console.WriteLine("ベジタリアン向けですか？");
                    //ベジタリアン向けかどうかを入力
                    bool isVegetarian = InputHelper.GetValidBoolean();
                    //主菜メニューを追加
                    // ★(d1) リスト型の変数に要素を追加
                    menus.Add(new MainMenu(name, description, price, isVegetarian));
                    break;

                case MenuType.Drink:
                    Console.WriteLine("冷たい飲み物ですか？");
                    //冷たい飲み物かどうかを入力
                    bool isCold = InputHelper.GetValidBoolean();
                    //飲み物メニューを追加
                    // ★(d2) リスト型の変数に要素を追加
                    menus.Add(new DrinkMenu(name, description, price, isCold));
                    break;
            }
        }

        //メニュータイプを入力
        private MenuType GetMenuType()
        {
            Console.WriteLine("メニュータイプを選択してください:");
            string? menuTypeInput = Console.ReadLine();

            switch (menuTypeInput)
            {
                case "main":
                    return MenuType.Main;
                case "drink":
                    return MenuType.Drink;
                default:
                    return MenuType.Unknown;
            }
        }
    }
}

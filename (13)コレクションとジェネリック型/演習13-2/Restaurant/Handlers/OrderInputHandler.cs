using Restaurant.Helpers;
using Restaurant.Menus;

namespace Restaurant.Handlers
{
    internal class OrderInputHandler
    {
        //注文を受け付ける
        public Dictionary<string, int> CollectOrdersFromConsole(List<Menu> menus)
        {
            //各メニューを登録し、注文数を0に初期化
            //★(e) 辞書型の変数の宣言とインスタンス生成
            Dictionary<string, int> orderCounts = new Dictionary<string, int>();
            foreach (var menu in menus)
            {
                //★(f) キーと値のペアを追加
                orderCounts[menu.Name] = 0;
            }

            Console.WriteLine("注文を開始します。終了するには 'exit' と入力してください。");
            while (true)
            {
                Console.WriteLine("注文するメニュー名を入力してください:");
                string menuName = InputHelper.GetValidString();
                if (menuName == "exit")
                {
                    break;
                }
                //★ (g)キーが存在するかを確認
                else if (orderCounts.ContainsKey(menuName))
                {//メニュー名が存在する場合、注文数を1増やす
                    //★(h) キーに対応する値を1増やす
                    orderCounts[menuName]++;
                    //現在の注文状況を表示
                    DisplayOrderCounts(orderCounts);
                }
                else
                {
                    Console.WriteLine($"{menuName}は存在しません。もう一度入力してください。");
                }
            }

            return orderCounts;
        }

        //注文状況を表示
        private void DisplayOrderCounts(Dictionary<string, int> orderCounts)
        {
            Console.WriteLine("注文の集計:");
            //それぞれのメニューの注文数を表示
            //★(i) foreachでキーと値のペアを取り出す
            foreach (KeyValuePair<string,int> orderCount in orderCounts)
            {
                Console.WriteLine($"{orderCount.Key}: {orderCount.Value}注文");
            }
        }
    }
}

using Restaurant.Generators;
using Restaurant.Menus;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //メニューデータを定義し、Menu配列に格納
            Menu[] menus = new Menu[] {
                new MainMenu("黒毛和牛ステーキ", "ジューシーで柔らかなステーキです。", 3000, false),
                new MainMenu("ベジタブルカレー", "野菜をたっぷりと使った、スパイシーなカレーです。", 2400, true),
                new DrinkMenu("メロンソーダ", "爽やかな甘さが楽しめるメロンソーダです。", 400, true),
                new DrinkMenu("ホットコーヒー", "丁寧に焙煎されたコーヒー豆を使用しています。", 500, false),
            };

            // メニュー一覧をHTMLコードとして生成する
            MenuTableGenerator generator = new MenuTableGenerator(menus.ToArray());
            string tableHtml = generator.GenerateTable();

            // メニュー表をHTMLページとして生成する
            MenuPageGenerator htmlGenerator = new MenuPageGenerator(tableHtml);
            string html = htmlGenerator.GenerateHtml();

            // 生成されたHTMLをコンソールに出力する
            Console.WriteLine(html);
        }
    }
}

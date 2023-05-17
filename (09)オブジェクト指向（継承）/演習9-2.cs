//■===以下は処理===■
//メニューデータを定義し、Menu配列に格納
Menu[] menus = new Menu[] {
    new MainMenu("黒毛和牛ステーキ", "ジューシーで柔らかなステーキです。", 3000, false),
    new MainMenu("ベジタブルカレー", "野菜をたっぷりと使った、スパイシーなカレーです。", 2400, true),
    new DrinkMenu("メロンソーダ", "爽やかな甘さが楽しめるメロンソーダです。", 400, true),
    new DrinkMenu("ホットコーヒー", "丁寧に焙煎されたコーヒー豆を使用しています。", 500, false),
};

//メニュー一覧をHTMLコードとして出力
MenuTableGenerator generator = new MenuTableGenerator(menus);
string tableHtml = generator.GenerateTable();
Console.WriteLine("<html>");
Console.WriteLine("<head><title>メニュー</title></head>");
Console.WriteLine("<body>");
Console.WriteLine("<h1>メニュー一覧</h1>");
Console.WriteLine(tableHtml);
Console.WriteLine("</body>");
Console.WriteLine("</html>");

//■===以下はクラス定義===■
//メニューの情報を格納するクラス(DrinkMenu、MainMenuの親クラス)
abstract class Menu
{
    private string name;
    private string description;
    private int price;

    public Menu(string name, string description, int price)
    {
        this.name = name;
        this.description = description;
        this.price = price;

    }

    public string Name
    {
        get { return name; }
    }

    public string Description
    {
        get { return description; }
    }

    public int Price
    {
        get { return price; }
    }

    public int GetPriceWithTax()
    {
        const double taxRate = 0.1; // 消費税率10%
        return (int)Math.Round(Price * (1 + taxRate));
    }
}

//飲み物メニューの情報を格納するクラス(Menuから派生した子クラス)
class DrinkMenu : Menu
{
    private bool isCold;

    public DrinkMenu(string name, string description, int price, bool isCold)
        : base(name, description, price)
    {
        this.isCold = isCold;
    }

    public bool IsCold
    {
        get { return isCold; }
    }
}

//主菜メニューの情報を格納するクラス(Menuから派生した子クラス)
class MainMenu : Menu
{
    private bool isVegetarian;

    public MainMenu(string name, string description, int price, bool isVegetarian)
        : base(name, description, price)
    {
        this.isVegetarian = isVegetarian;
    }

    public bool IsVegetarian
    {
        get { return isVegetarian; }
    }
}

//メニューデータ配列からHTMLテーブルを生成するクラス
class MenuTableGenerator
{
    private Menu[] menus;

    public MenuTableGenerator(Menu[] menus)
    {
        this.menus = menus;
    }

    public string GenerateTable()
    {
        string table = "<table border='1'>";
        table += "<tr><th>メニュー名</th><th>価格(税込み)</th><th>説明</th><th>補足</th></tr>\n";
        foreach (Menu menu in menus)
        {
            table += "<tr>";
            table += $"<td>{menu.Name}</td>";
            table += $"<td>{menu.GetPriceWithTax()}円</td>";
            table += $"<td>{menu.Description}</td>";
            string note;
            if (menu is DrinkMenu) //★(a1) is演算子による型判別
            {
                DrinkMenu drinkMenu = (DrinkMenu)menu; //★(b1) 型キャスト
                note = drinkMenu.IsCold ? "（冷）" : "";
            }
            else if (menu is MainMenu) //★(a2) is演算子による型判別
            {
                MainMenu mainMenu = (MainMenu)menu; //★(b2) 型キャスト
                note = mainMenu.IsVegetarian ? "（菜食）" : "";
            }
            else
            {
                note = "";
            }
            table += $"<td>{note}</td>";
            table += "</tr>\n";
            //※ +演算子で多数の文字列を連結させていくのは効率が悪いため、
            //    本当はStringBuilderクラスを使った方が良いです。
        }
        table += "</table>";
        return table;
    }
}
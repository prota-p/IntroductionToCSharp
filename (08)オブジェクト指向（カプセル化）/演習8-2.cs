// ■処理のコード■
Person user = new Person();
user.ReadFromConsole("あなた"); //★(a1)オブジェクトを操作
Person partner = new Person();
partner.ReadFromConsole("あなたの配偶者"); //★(a2)オブジェクトを操作

Console.WriteLine("<html>");
Console.WriteLine("<body>");
Console.WriteLine($"<p>以下が登録情報です</p>");
Console.WriteLine("<table border=\"1\">");
Person.WriteTableHeader(); //クラスメソッド呼び出し
user.WriteAsTableRow(); //インスタンスメソッド呼び出し
partner.WriteAsTableRow(); //インスタンスメソッド呼び出し
Console.WriteLine("</table>");
Console.WriteLine("</body>");
Console.WriteLine("</html>");

// ■ここからは、クラスの定義■
class Person
{
    private string? name; //★(c1)外部へは非公開
    private int age;//★(c2)外部へは非公開

    //★(d1)外部公開する操作(メソッド)を定義
    public void ReadFromConsole(string target)
    {
        Console.WriteLine($"{target}についての情報を入力");
        Console.Write("名前を入力：");
        name = Console.ReadLine();
        Console.Write("年齢を入力：");
        age = Convert.ToInt32(Console.ReadLine());
    }

    //★(d2)外部公開する操作(メソッド)を定義
    public void WriteAsTableRow()
    {
        Console.WriteLine($"<tr><td>{name}</td><td>{age}</td></tr>");
    }

    // クラスメソッドの定義
    public static void WriteTableHeader()
    {
        Console.WriteLine("<tr><th>名前</th><th>年齢</th></tr>");
    }
}
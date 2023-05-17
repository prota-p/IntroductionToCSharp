Person user = new Person(); //★(a1) Personクラスのインスタンスを生成
Console.WriteLine("あなたについての情報を入力");
Console.Write("名前を入力：");
user.name = Console.ReadLine(); //★(b)  //Personインスタンスのフィールドへ代入
Console.Write("年齢を入力：");
user.age = Convert.ToInt32(Console.ReadLine());

Person partner = new Person();//★(a2) Personクラスのインスタンスを生成
Console.WriteLine("あなたの配偶者の情報を入力");
Console.Write("名前を入力：");
partner.name = Console.ReadLine();
Console.Write("年齢を入力：");
partner.age = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("<html>");
Console.WriteLine("<body>");
Console.WriteLine($"<p>以下が登録情報です</p>");
Console.WriteLine("<table border=\"1\">");
Console.WriteLine($"<tr><th>名前</th><th>年齢</th></tr>");
//★(c) Personインスタンスのフィールドを参照
Console.WriteLine($"<tr><td>{user.name}</td><td>{user.age}</td></tr>");
Console.WriteLine($"<tr><td>{partner.name}</td><td>{partner.age}</td></tr>");
Console.WriteLine("</table>");
Console.WriteLine("</body>");
Console.WriteLine("</html>");

//★(d)  Personクラスの定義
class Person
{
    public string? name;
    public int age;
}
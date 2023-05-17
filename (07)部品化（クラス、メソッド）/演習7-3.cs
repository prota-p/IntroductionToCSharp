Person user = ReadPerson("あなた"); //★(a1) メソッド呼び出し
Person partner = ReadPerson("あなたの配偶者"); //★(a2) メソッド呼び出し

Console.WriteLine("<html>");
Console.WriteLine("<body>");
Console.WriteLine($"<p>以下が登録情報です</p>");
Console.WriteLine("<table border=\"1\">");
Console.WriteLine($"<tr><th>名前</th><th>年齢</th></tr>");
WritePerson(user); //★(b1) メソッド呼び出し
WritePerson(partner); //★(b2) メソッド呼び出し
Console.WriteLine("</table>");
Console.WriteLine("</body>");
Console.WriteLine("</html>");

//★(c) 人の情報をコンソールから入力するメソッドを定義
Person ReadPerson(string target)
{
    Person user = new Person();
    Console.WriteLine($"{target}についての情報を入力");
    Console.Write("名前を入力：");
    user.name = Console.ReadLine();
    Console.Write("年齢を入力：");
    user.age = Convert.ToInt32(Console.ReadLine());
    return user;
}

//★(d) 人の情報をテーブルの行として出力するメソッドを定義
void WritePerson(Person user)
{
    Console.WriteLine($"<tr><td>{user.name}</td><td>{user.age}</td></tr>");
}

class Person
{
    public string? name;
    public int age;
}
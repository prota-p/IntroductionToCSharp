Console.Write("名前を入力してください：");
string? name = Console.ReadLine();
Console.Write("年齢を入力してください：");
//↓★(c) 文字列型から整数型へ変換
int age = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("<html>");
Console.WriteLine("<body>");
Console.WriteLine("<p>" + name + "さん、こんにちは！</p>");
//↓★(d) 整数型から文字列型へ変換
Console.WriteLine("<p>" + name + "さんは" + Convert.ToString(age) + "歳です</p>");
Console.WriteLine("</body>");
Console.WriteLine("</html>");
Console.Write("名前を入力してください：");
string? name = Console.ReadLine(); //★(a) ユーザ入力をnameという変数へ格納
Console.WriteLine("<html>");
Console.WriteLine("<body>");
Console.WriteLine("<p>" + name + "さん、こんにちは！</p>"); //★(b) name変数の中身を参照
Console.WriteLine("</body>");
Console.WriteLine("</html>");
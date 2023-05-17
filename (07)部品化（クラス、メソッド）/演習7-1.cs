Console.WriteLine("あなたの情報を入力");
Console.Write("名前を入力：");
string? userName = Console.ReadLine();
Console.Write("年齢を入力：");
int userAge = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("あなたの配偶者の情報を入力");
Console.Write("名前を入力：");
string? partnerName = Console.ReadLine();
Console.Write("年齢を入力：");
int partnerAge = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("<html>");
Console.WriteLine("<body>");
Console.WriteLine($"<p>以下が登録情報です</p>");
Console.WriteLine("<table border=\"1\">");
Console.WriteLine($"<tr><th>名前</th><th>年齢</th></tr>");
Console.WriteLine($"<tr><td>{userName}</td><td>{userAge}</td></tr>");
Console.WriteLine($"<tr><td>{partnerName}</td><td>{partnerAge}</td></tr>");
Console.WriteLine("</table>");
Console.WriteLine("</body>");
Console.WriteLine("</html>");
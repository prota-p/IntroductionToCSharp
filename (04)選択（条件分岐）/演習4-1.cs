Console.Write("身長を入力してください：");
double height = Convert.ToDouble(Console.ReadLine());
Console.Write("体重を入力してください：");
double weight = Convert.ToDouble(Console.ReadLine());
double bmi = weight / (height * height);

Console.WriteLine("<html><body>");
Console.WriteLine($"<p>あなたのBMIは{bmi:F2}</p>");//★(b)
//★(a) ↓ここからが選択（if文）↓
if (bmi < 18.5)
{
    Console.WriteLine("<p><strong>低体重</strong>です<p>");
}
else if (bmi < 25)
{
    Console.WriteLine("<p>標準体重です</p>");
}
else
{
    Console.WriteLine("<p><strong>肥満</strong>です</p>");
}
Console.WriteLine("</body></html>");
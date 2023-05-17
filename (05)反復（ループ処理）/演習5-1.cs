int[] numbers = new int[] { 10, 5, -8, 0, 1 };//★(a)整数配列を作成

Console.WriteLine("<html><body>");
Console.WriteLine("<table border=\"1\">");
int sum = 0;
//★(b)反復を行うfor文
for (int i = 0; i < numbers.Length; i++)
{
    Console.WriteLine($"<tr><td>配列の{i}番目</td><td>{numbers[i]}</td></tr>");
    sum += numbers[i];
}
Console.WriteLine("</table>");
double average = (double)sum / numbers.Length;//★(c)型キャスト
Console.WriteLine($"<p>平均値は{average:F2}</p>");
Console.WriteLine("</body></html>");
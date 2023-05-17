int[] numbers = new int[] { 1, 2, 3, 4, 5 };

Console.WriteLine("<html><body>");
Console.WriteLine("<table border=\"1\">");
int sum = 0;
for (int i = 0; i <= numbers.Length; i++)
{
    Console.WriteLine($"<tr><td>配列の{i}番目</td><td>{numbers[i]}</td></tr>");
    sum = +numbers[i];
}
Console.WriteLine("</table>");
double average = sum / numbers.Length;
Console.WriteLine($"<p>平均値は{average:F2}</p>");
Console.WriteLine("</body></html>");
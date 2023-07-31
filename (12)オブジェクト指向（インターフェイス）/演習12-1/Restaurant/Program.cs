using Restaurant.Generators;
using Restaurant.Menus;

namespace Restaurant
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DrinkMenu melonSoda = new DrinkMenu("メロンソーダ", "爽やかな甘さが楽しめるメロンソーダです。", 400, true);
            DrinkMenu hotCoffee = new DrinkMenu("ホットコーヒー", "丁寧に焙煎されたコーヒー豆を使用しています。", 500, false);

            IJsonWritable[] drinks = new IJsonWritable[] { melonSoda, hotCoffee };

            JsonGenerator generator = new JsonGenerator();

            string json = generator.GenerateJson(drinks);

            Console.WriteLine(json);
        }
    }
}
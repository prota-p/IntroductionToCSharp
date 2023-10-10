using Restaurant.Menus;

namespace Restaurant.Helpers
{
    internal class InputHelper
    {
        public static int GetValidInteger()
        {
            while (true)
            {
                Console.WriteLine("(数値を入力してください)");
                string? input = Console.ReadLine();
                if (input != null)
                {
                    int value;
                    if (int.TryParse(input, out value))
                    {
                        return value;
                    }
                }
                Console.WriteLine("無効な数値です。もう一度入力してください");
            }
        }

        public static string GetValidString()
        {
            while (true)
            {
                string? input = Console.ReadLine();
                if (input != null && input != string.Empty)
                {
                    return input;
                }
                else
                {
                    Console.WriteLine("null、空文字は無効です。もう一度入力してください");
                }
            }
        }

        public static bool GetValidBoolean()
        {
            while (true)
            {
                Console.WriteLine("(yes/no)");
                string? input = Console.ReadLine();
                if (input == "yes")
                {
                    return true;
                }
                else if (input == "no")
                {
                    return false;
                }
                else
                {
                    Console.WriteLine("無効な入力です。yes/noで入力してください");
                }
            }
        }
    }
}

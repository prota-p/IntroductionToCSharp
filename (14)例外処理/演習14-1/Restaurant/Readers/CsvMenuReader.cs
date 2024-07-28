using Restaurant.Menus;

namespace Restaurant.Readers
{
    internal class CsvMenuReader
    {
        private readonly string _filePath;

        // CSV列の定数定義
        private const int ColumnType = 0;
        private const int ColumnName = 1;
        private const int ColumnDescription = 2;
        private const int ColumnPrice = 3;
        private const int ColumnIsVegetarian = 4;
        private const int ColumnIsCold = 5;
        private const int ExpectedColumnCount = 6;

        public CsvMenuReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<Menu> ReadMenus()
        {
            // CSVファイルの全行を読み込む
            string[] lines = File.ReadAllLines(_filePath);
            var menus = new List<Menu>();

            // ヘッダー行をスキップしてデータ行を処理する
            for (int lineIndex = 1; lineIndex < lines.Length; lineIndex++)
            {
                int lineNumber = lineIndex + 1; // 行番号は1から始まる
                string[] parts = lines[lineIndex].Split(',');

                if (parts.Length != ExpectedColumnCount)
                {
                    throw new MenuLoadException("列数が正しくありません。", lineNumber);
                }

                string type = parts[ColumnType].Trim();
                string name = parts[ColumnName].Trim();
                string description = parts[ColumnDescription].Trim();

                int price = int.Parse(parts[ColumnPrice].Trim());

                Menu menu;
                switch (type.ToLower())
                {
                    case "main":
                        if (!bool.TryParse(parts[ColumnIsVegetarian].Trim(), out bool isVegetarian))
                        {
                            throw new MenuLoadException("IsVegetarianの値が無効です。", lineNumber);
                        }
                        menu = new MainMenu(name, description, price, isVegetarian);
                        break;
                    case "drink":
                        if (!bool.TryParse(parts[ColumnIsCold].Trim(), out bool isCold))
                        {
                            throw new MenuLoadException("IsColdの値が無効です。", lineNumber);
                        }
                        menu = new DrinkMenu(name, description, price, isCold);
                        break;
                    default:
                        throw new MenuLoadException($"{type}というMenuの値は無効です。", lineNumber);
                }

                menus.Add(menu);
            }
            return menus;
        }
    }
}

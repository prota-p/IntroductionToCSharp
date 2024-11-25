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
                string[] parts = lines[lineIndex].Split(',');

                string type = parts[ColumnType].Trim();
                string name = parts[ColumnName].Trim();
                string description = parts[ColumnDescription].Trim();
                int price = int.Parse(parts[ColumnPrice].Trim());

                Menu menu;
                switch (type.ToLower())
                {
                    case "main":
                        bool isVegetarian = bool.Parse(parts[ColumnIsVegetarian].Trim());
                        menu = new MainMenu(name, description, price, isVegetarian);
                        break;
                    case "drink":
                        bool isCold = bool.Parse(parts[ColumnIsCold].Trim());
                        menu = new DrinkMenu(name, description, price, isCold);
                        break;
                    default:
                        throw new FormatException($"不明なメニュータイプです: {type} (行: {lineIndex})");
                }

                if (menu != null)
                {
                    menus.Add(menu);
                }
            }
            return menus;
        }
    }
}
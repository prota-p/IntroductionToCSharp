using CsvHelper;
using CsvHelper.Configuration.Attributes;
using System.Globalization;
using Restaurant.Menus;

namespace Restaurant.Readers
{
    // メニューデータのマッピング用クラス
    public class MenuRecord
    {
        [Name("Type")]     // CSVのヘッダー名を指定
        required public string Type { get; set; }
        
        [Name("Name")]
        required public string Name { get; set; }
        
        [Name("Description")]
        required public string Description { get; set; }
        
        [Name("Price")]
        required public int Price { get; set; }
        
        [Name("IsVegetarian")]
        required public bool IsVegetarian { get; set; }
        
        [Name("IsCold")]
        required public bool IsCold { get; set; }
    }

    internal class CsvMenuReader
    {
        private readonly string _filePath;

        public CsvMenuReader(string filePath)
        {
            _filePath = filePath;
        }

        public List<Menu> ReadMenus()
        {
            var menus = new List<Menu>();

            using (var reader = new StreamReader(_filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<MenuRecord>().ToList();

                foreach (var record in records)
                {
                    Menu menu = record.Type.ToLower() switch
                    {
                        "main" => new MainMenu(
                            record.Name, 
                            record.Description, 
                            record.Price, 
                            record.IsVegetarian
                        ),
                        "drink" => new DrinkMenu(
                            record.Name, 
                            record.Description, 
                            record.Price, 
                            record.IsCold
                        ),
                        _ => throw new FormatException(
                            $"{record.Type}というメニュータイプは無効です。"
                        )
                    };
                    menus.Add(menu);
                }
            }

            return menus;
        }
    }
}
using Restaurant.Menus;
using System.Text;

namespace Restaurant.Generators
{
    internal class JsonGenerator
    {
        public string GenerateJson(IJsonWritable[] items)
        {
            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.AppendLine("[");

            for (int i = 0; i < items.Length; i++)
            {
                // items[i]がIJsonWritableインターフェイスを実装しているため、ToJsonメソッドを呼び出すことができます。
                // ToJsonメソッドは、そのオブジェクトのJSON表現を文字列として返します。
                jsonBuilder.AppendLine(items[i].ToJson());

                // 最後の要素以外の後にはカンマを追加します。
                if (i < items.Length - 1)
                {
                    jsonBuilder.AppendLine(",");
                }
            }

            jsonBuilder.Append("]");

            return jsonBuilder.ToString();
        }
    }
}

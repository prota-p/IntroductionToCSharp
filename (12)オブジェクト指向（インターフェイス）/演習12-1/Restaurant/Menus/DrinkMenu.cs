using System.Text;

namespace Restaurant.Menus
{
    //飲み物メニューの情報を格納するクラス(Menuから派生した子クラス)
    internal class DrinkMenu : Menu, IJsonWritable
    {
        private bool isCold;

        public DrinkMenu(string name, string description, int price, bool isCold)
            : base(name, description, price)
        {
            this.isCold = isCold;
        }

        public bool IsCold
        {
            get { return isCold; }
        }

        public override string GetNote()
        {
            return IsCold ? "（冷）" : "";
        }

        public string ToJson()
        {
            StringBuilder jsonBuilder = new StringBuilder();

            jsonBuilder.AppendLine("{")
                       .AppendLine($"  \"Type\": \"Drink\",")
                       .AppendLine($"  \"Name\": \"{Name}\",")
                       .AppendLine($"  \"Description\": \"{Description}\",")
                       .AppendLine($"  \"Price\": {Price},")
                       .AppendLine($"  \"IsCold\": {IsCold.ToString().ToLower()}")
                       .Append("}");

            return jsonBuilder.ToString();
        }
    }
}

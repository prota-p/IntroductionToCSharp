namespace Restaurant.Menus
{
    //メニューの情報を格納するクラス(DrinkMenu、MainMenuの親クラス)
    internal abstract class Menu
    {
        private string name;
        private string description;
        private int price;

        public Menu(string name, string description, int price)
        {
            this.name = name;
            this.description = description;
            this.price = price;
        }

        public string Name
        {
            get { return name; }
        }

        public string Description
        {
            get { return description; }
        }

        public int Price
        {
            get { return price; }
        }

        public int GetPriceWithTax()
        {
            const double taxRate = 0.1; // 消費税率10%
            return (int)Math.Round(Price * (1 + taxRate));
        }

        public abstract string GetNote();
    }
}

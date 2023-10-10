namespace Restaurant.Menus
{
    //主菜メニューの情報を格納するクラス(Menuから派生した子クラス)
    internal class MainMenu : Menu
    {
        private bool isVegetarian;

        public MainMenu(string name, string description, int price, bool isVegetarian)
            : base(name, description, price)
        {
            this.isVegetarian = isVegetarian;
        }

        public bool IsVegetarian
        {
            get { return isVegetarian; }
        }

        public override string GetNote()
        {
            return IsVegetarian ? "（菜食）" : "";
        }
    }
}

namespace Restaurant.Menus
{
    //メニューの情報を格納するクラス(DrinkMenu、MainMenuの親クラス)
    //飲み物メニューの情報を格納するクラス(Menuから派生した子クラス)
    internal class DrinkMenu : Menu
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
    }
}

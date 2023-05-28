namespace Restaurant.Menus
{
    //デザートメニューの情報を格納するクラス(Menuから派生した子クラス)
    internal class DessertMenu : Menu
    {
        private int sweetnessLevel;

        public DessertMenu(string name, string description, int price, int sweetnessLevel)
            : base(name, description, price)
        {
            this.sweetnessLevel = sweetnessLevel;
        }

        public int SweetnessLevel
        {
            get { return sweetnessLevel; }
        }

        public override string GetNote()
        {
            return $"（甘さレベル{sweetnessLevel}）";
        }
    }
}

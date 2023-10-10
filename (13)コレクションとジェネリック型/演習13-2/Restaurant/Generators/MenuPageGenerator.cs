namespace Restaurant.Generators
{
    internal class MenuPageGenerator
    {
        private string tableHtml;

        public MenuPageGenerator(string tableHtml)
        {
            this.tableHtml = tableHtml;
        }

        public string GenerateHtml()
        {
            return $@"
<html>
<head><title>メニュー</title></head>
<body>
<h1>メニュー一覧</h1>
{tableHtml}
</body>
</html>";
        }
    }
}

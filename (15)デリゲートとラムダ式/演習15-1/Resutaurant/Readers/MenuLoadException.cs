namespace Restaurant.Readers
{
    internal class MenuLoadException : Exception
    {
        public MenuLoadException(string message, int? lineNumber = null)
            : base(lineNumber.HasValue ? $"{message} (行: {lineNumber})" : message)
        {
        }
    }
}

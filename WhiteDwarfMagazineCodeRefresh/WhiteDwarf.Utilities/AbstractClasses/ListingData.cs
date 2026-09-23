namespace WhiteDwarf.Utilities.AbstractClasses
{
    public sealed class ListingData
    {
        public string Issue { get; init; } = "WD00";
        public string Date { get; init; } = "Month - YYYY";
        public string Pages { get; init; } = "xx-yy";
        public string Article { get; init; } = "Article Name";
        public string Programme { get; init; } = "Listing Name";
        public string Author { get; init; } = "Bob Smith";
        public string Machine { get; init; } = "ZX81";
        public string Language { get; init; } = "BASIC";
        public string Purpose { get; init; } = "What is it's goal";
        public string Notes { get; init; } = "My notes...";
    }
}

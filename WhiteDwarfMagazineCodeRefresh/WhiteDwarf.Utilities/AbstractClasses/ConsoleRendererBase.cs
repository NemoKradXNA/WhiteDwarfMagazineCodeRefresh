using Microsoft.Extensions.Logging;
using WhiteDwarf.Utilities.Interfaces;

namespace WhiteDwarf.Utilities.AbstractClasses
{
    public abstract class ConsoleRendererBase<T>
    {
        protected ListingData _listingData { get; set; }
        protected readonly IRetroDisplay _display;
        protected readonly ILogger<T> _logger;

        public ConsoleRendererBase(ILogger<T> logger, IRetroDisplay display)
        {
            _listingData = new ListingData();

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _display = display ?? throw new ArgumentNullException(nameof(display));
        }

        public virtual async Task RenderListingData()
        {
            // render listing data to  the screen prior to writing
            _display.Clear();

            _display.WriteAt(0, 0, $"{_listingData.Issue} - {_listingData.Programme}");
            _display.WriteAt(0, 2, $"Date:      {_listingData.Date}");
            _display.WriteAt(0, 3, $"Article:   {_listingData.Article}");
            _display.WriteAt(0, 4, $"Author:    {_listingData.Author}");
            _display.WriteAt(0, 5, $"Machine:   {_listingData.Machine}");
            _display.WriteAt(0, 6, $"Language:  {_listingData.Language}");
            _display.WriteAt(0, 8, _listingData.Purpose);
            _display.WriteAt(0, 10, _listingData.Notes);

            _display.WriteAt(0, 15, "Press any key to continue...");
            Console.ReadKey();
        }

        public virtual async Task Run()
        {
            await RenderListingData();
            await RunListingCode();
        }

        public abstract Task RunListingCode();
    }
}

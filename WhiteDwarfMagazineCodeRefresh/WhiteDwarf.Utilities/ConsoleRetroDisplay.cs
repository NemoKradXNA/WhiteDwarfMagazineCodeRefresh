using WhiteDwarf.Utilities.Interfaces;

namespace WhiteDwarf.Utilities
{
    public sealed class ConsoleRetroDisplay : IRetroDisplay
    {
        private readonly char[,] _screen;

        public int Width { get; }
        public int Height { get; }

        public ConsoleRetroDisplay(IScreen display)
        {
            Width = display.Width;
            Height = display.Height;

            _screen = new char[Height, Width];

            Clear();
        }

        public void Clear()
        {
            Console.Clear();

            for (var row = 0; row < Height; row++)
            {
                for (var column = 0; column < Width; column++)
                {
                    _screen[row, column] = ' ';
                }
            }

            SetCursor(0, 0);
        }

        public void SetCursor(int column, int row)
        {
            if (column < 0 || column >= Width)
                throw new ArgumentOutOfRangeException(nameof(column));

            if (row < 0 || row >= Height)
                throw new ArgumentOutOfRangeException(nameof(row));

            Console.SetCursorPosition(column, row);
        }

        public void Write(string text)
        {
            foreach (var character in text)
                Write(character);
        }

        public void Write(char character)
        {
            var column = Console.CursorLeft;
            var row = Console.CursorTop;

            if (column >= Width || row >= Height)
                return;

            _screen[row, column] = character;

            Console.Write(character);
        }

        public void WriteAt(int column, int row, string text)
        {
            SetCursor(column, row);
            Write(text);
        }

        public void WriteAt(int column, int row, char character)
        {
            SetCursor(column, row);
            Write(character);
        }

        public void NewLine()
        {
            Console.WriteLine();
        }

        public void Pause(int milliseconds)
        {
            Thread.Sleep(milliseconds);
        }

        public void Refresh()
        {
            Console.SetCursorPosition(0, 0);

            for (var row = 0; row < Height; row++)
            {
                for (var column = 0; column < Width; column++)
                {
                    Console.Write(_screen[row, column]);
                }

                if (row < Height - 1)
                    Console.WriteLine();
            }
        }
    }
}

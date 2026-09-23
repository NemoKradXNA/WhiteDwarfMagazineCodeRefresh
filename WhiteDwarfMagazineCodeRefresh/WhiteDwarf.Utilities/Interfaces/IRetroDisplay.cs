namespace WhiteDwarf.Utilities.Interfaces
{
    public interface IRetroDisplay
    {
        int Width { get; }
        int Height { get; }

        void Clear();

        void SetCursor(int column, int row);

        void Write(string text);

        void Write(char character);

        void WriteAt(int column, int row, string text);

        void WriteAt(int column, int row, char character);

        void NewLine();

        void Pause(int milliseconds);

        void Refresh();
    }
}

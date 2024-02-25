namespace Cinema.Models
{
    internal sealed class PlacePair : BasePlace
    {
        internal PlacePair(int row, (int, int) numbers, int rowOffset)
            : base(row, rowOffset)
        {
            Numbers = numbers;
        }

        internal (int, int) Numbers { get; private set; }
    }
}


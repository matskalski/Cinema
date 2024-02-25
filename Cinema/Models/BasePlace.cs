namespace Cinema.Models
{
    internal abstract class BasePlace
    {
        internal BasePlace(int row, int rowOffset)
        {
            Row = row;
            RowOffset = rowOffset;
            ColumnOffset = Math.Abs(6 - row);
        }

        internal int Row { get; private set; }
        internal int RowOffset { get; private set; }

        internal int ColumnOffset { get; private set; }
        internal bool Free { get; private set; } = true;

        internal void MarkAsOccupated()
        {
            Free = false;
        }
    }
}

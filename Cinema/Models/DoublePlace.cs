namespace Cinema.Models
{
    internal sealed class DoublePlace : BasePlace
    {
        internal DoublePlace(int row, int number, int rowOffset)
            : base(row, rowOffset)
        {
            Number = number;
        }

        internal int Number { get; private set; }
    }
}

public class ShiftedGrid<T>
{
    private readonly T[,] _grid;
    private readonly int _xOffset;
    private readonly int _yOffset;

    public ShiftedGrid(int width, int height, int xOffset, int yOffset)
    {
        _grid = new T[width, height];
        _xOffset = xOffset;
        _yOffset = yOffset;
    }

    public T this[int x, int y]
    {
        get { return _grid[x - _xOffset, y - _yOffset]; }
        set { _grid[x - _xOffset, y - _yOffset] = value; }
    }

    public int GetRealX(int x)
    {
        return x + _xOffset;
    }

    public int GetRealY(int y)
    {
        return y + _yOffset;
    }
}

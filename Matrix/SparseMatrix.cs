using System.Collections.Generic;

public class SparseMatrix<T>
{
    private Dictionary<(int, int), T> matrix;

    public Dictionary<(int, int), T> Dictionary
    {
        get { return matrix; }
    }

    public T this[int row, int col]
    {
        get
        {
            if (matrix.TryGetValue((row, col), out T value))
            {
                return value;
            }
            else
            {
                return default(T);
            }
        }

        set
        {
            matrix[(row, col)] = value;
        }
    }

    public SparseMatrix()
    {
        matrix = new Dictionary<(int, int), T>();
    }
}

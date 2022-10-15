Matrix matrix = new(3, 4, 1, 9);
matrix.Show();

matrix.Fill();
Console.WriteLine("\nmatrix.Fill():");
matrix.Show();

matrix.ChangeSize(5, 5);
Console.WriteLine("\nmatrix.ChangeSize(5, 5):");
matrix.Show();



internal class Matrix
{
    private int _m;
    private int _n;
    private int _d1;
    private int _d2;
    private double[,] _matrix;
    private Random _random = new();

    public Matrix(int m, int n, int d1, int d2)
    {
        _m = m;
        _n = n;
        _d1 = d1;
        _d2 = d2;
        _matrix = new double[m, n];
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                _matrix[i,j] = _random.Next(d1, d2);
            }
        }        
    }
    
    public double this[int i, int j]
    {
        get => _matrix[i, j];

        set => _matrix[i, j] = value;
    }

    public void Fill()
    {
        for (var i = 0; i < _m; i++)
        {
            for (var j = 0; j < _n; j++)
            {
                _matrix[i,j] = _random.Next(_d1, _d2);
            }
        }
    }

    public void ChangeSize(int m, int n)
    {
        var newMatrix = new double[m,n];
        for (var i = 0; i < m; i++)
        {
            for (var j = 0; j < n; j++)
            {
                if (i >= _m || j >= _n)
                {
                    newMatrix[i, j] = _random.Next(_d1, _d2);
                }
                else
                {
                    newMatrix[i, j] = _matrix[i, j];
                }
            }
        }

        _matrix = newMatrix;
        _m = m;
        _n = n;
    }

    public void ShowPartialy()
    {
        
    }

    public void Show()
    {
        for (var i = 0; i < _m; i++)
        {
            for (var j = 0; j < _n; j++)
            {
                Console.Write($"{_matrix[i,j]}\t");
            }
            Console.Write('\n');
        }
    }
}


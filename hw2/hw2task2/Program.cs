namespace hw2task2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var A = new Matrix(4);
            A.SpiralSnake();
            A.PrintMatrix();
        }
    }

    public class Matrix
    {
        private int[,] _matrix;
        private int _rows, _cols;
        public Matrix(int rows, int cols)
        {
            _matrix = new int[rows, cols];
            _rows = rows;
            _cols = cols;

        }
        public Matrix(int size) : this(size, size)
        {

        }

        public void VerticalSnake()
        {
            int num = 0;
  
            for (int j = 0; j < _cols; j++)
            {
                for (int i = 0; i < _rows; i++)
                {
                    _matrix[i, j] = ++num;
                }
            }
        }

        public void DiagonalSnake()
        {
            if (_rows != _cols)
            {
                Console.WriteLine("[E] Matrix is not square!");
                return;
            }
            
            int num = 1;
            for (int stage = 0; stage < _cols; stage++)
            {
                if (stage % 2 == 0)
                {
                    for (int y = 0; y <= stage; y++)
                        _matrix[y, stage - y] = num++;
                }
                else
                {
                    for (int x = stage; x >= 0; x--)
                        _matrix[x, stage - x] = num++;
                }
            }
            
            for (int stage = _cols; stage <= (_cols - 1) * 2; stage++)
            {
                if (stage % 2 == 0)
                {
                    for (int y = stage - _rows + 1; y <= _cols - 1; y++)
                        _matrix[y, stage - y] = num++;
                }
                else
                {
                    for (int y = _cols - 1; y >= stage - _rows + 1; y--)
                        _matrix[y, stage - y] = num++;
                }
            }
        }

        public void SpiralSnake()
        {

        }

        public void PrintMatrix()
        {
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    Console.Write(_matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

namespace hw5
{
    public partial class Vector
    {
        private int[] _array;

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < _array.Length)
                {
                    return _array[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                _array[index] = value;
            }
        }

        public Vector(params int[] nums)
        {
            _array = nums == null ? new int[1] : nums;
        }

        public Vector(IEnumerable<int> enumerable)
        {
            _array = enumerable.ToArray();
        }

        public Vector(string vectorString)
        {
            string[] vectorStringArray = vectorString.Split(" ");
            _array = new int[vectorStringArray.Length];
            int count = 0;
            foreach(var item in vectorStringArray)
            {
                try
                {
                    _array[count++] = Int32.Parse(item);
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid string format!");
                    _array = new int[1];
                    break;
                }
            }
        }

        public Vector(int n)
        {
            _array = new int[n];
        }

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < _array.Length; i++)
            {
                str += _array[i] + " ";
            }

            return str;
        }

    }
}
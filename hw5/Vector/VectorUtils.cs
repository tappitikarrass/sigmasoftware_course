namespace hw5
{
    public partial class Vector
    {
        #region Initialization
        // fill array with random numbers in range (a, b)
        public void RandomInitialization(int a, int b)
        {
            Random random = new Random();

            for (int i = 0; i < _array.Length; i++)
            {
                _array[i] = random.Next(a, b);
            }
        }

        // fill array with random non-repeating numbers in range of array size
        public void RandomInitialization()
        {
            Random random = new Random();
            int num;
            bool isExist;

            for (int i = 0; i < _array.Length; i++)
            {
                while (_array[i] == 0)
                {
                    num = random.Next(1, _array.Length + 1);
                    isExist = false;

                    for (int j = 0; j < i; j++)
                    {
                        if (num == _array[j])
                        {
                            isExist = true;
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        _array[i] = num;
                        break;
                    }
                }
            }
        }
        #endregion

        #region Palindrome, Reverse, Subsequence, Frequency, Length
        public List<int> FindLongestSubsequence()
        {
            var answer = new List<int>();

            int buffer = _array[0];
            int end = 0;
            int maxCount = 1;
            int count = 1;

            for (int i = 1; i < _array.Length; i++)
            {
                if (buffer == _array[i])
                {
                    count++;

                    if (count > maxCount)
                    {
                        end = i;
                        maxCount = count;
                    }
                }
                else
                {
                    buffer = _array[i];
                    count = 1;
                }
            }

            for (int i = end; i > end - maxCount; i--)
            {
                answer.Add(_array[i]);
            }

            return answer;
        }

        public void Reverse()
        {
            for (int i = 0; i < _array.Length / 2; i++)
            {
                (_array[i], _array[_array.Length - i - 1]) = (_array[_array.Length - i - 1], _array[i]);
            }
        }

        public bool CheckPalindrome()
        {
            bool isPalindrome = true;
            for (int i = 0; i < _array.Length; i++)
            {
                if (_array[i] != _array[_array.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }

        public int GetLength()
        {
            return _array.Length;
        }

        public Pair[] CalculateFreq()
        {

            Pair[] pairs = new Pair[_array.Length];

            for (int i = 0; i < _array.Length; i++)
            {
                pairs[i] = new Pair(0, 0);

            }

            int countDifference = 0;

            for (int i = 0; i < _array.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (_array[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = _array[i];
                    countDifference++;
                }
            }

            Pair[] result = new Pair[countDifference];
            for (int i = 0; i < countDifference; i++)
            {
                result[i] = pairs[i];
            }

            return result;
        }
        #endregion
    }
}

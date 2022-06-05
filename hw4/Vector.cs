namespace hw4
{
    public enum pivotType { right, left, middle };

    class Vector
    {
        private int[] arr;

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index < arr.Length)
                {
                    return arr[index];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                arr[index] = value;
            }
        }

        public Vector(params int[] nums)
        {
            arr = nums == null ? new int[1] : nums;
        }

        public Vector(int n)
        {
            arr = new int[n];
        }

        public List<int> FindLongestSubsequence()
        {
            var ans = new List<int>();

            int buf = arr[0];
            int end = 0;
            int max_cnt = 1;
            int cnt = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if (buf == arr[i])
                {
                    cnt++;

                    if (cnt > max_cnt)
                    {
                        end = i;
                        max_cnt = cnt;
                    }
                }
                else
                {
                    buf = arr[i];
                    cnt = 1;
                }
            }

            for (int i = end; i > end - max_cnt; i--)
            {
                ans.Add(arr[i]);
            }

            return ans;
        }

        public void BuiltInReverse()
        {
            Array.Reverse(this.arr);
        }

        public void Reverse()
        {
            for (int i = 0; i < arr.Length / 2; i++)
            {
                (arr[i], arr[arr.Length - i - 1]) = (arr[arr.Length - i - 1], arr[i]);
            }
        }

        public bool CheckPalindrome()
        {
            bool isPalindrome = true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] != arr[arr.Length - i - 1])
                {
                    isPalindrome = false;
                    break;
                }
            }
            return isPalindrome;
        }

        public void RandomInitialization(int a, int b)  // fill array with random numbers in range (a, b)
        {
            Random random = new Random();

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(a, b);
            }
        }

        public void RandomInitialization()  // fill array with random non-repeating numbers in range of array size
        {
            Random random = new Random();
            int num;
            bool isExist;

            for (int i = 0; i < arr.Length; i++)
            {
                while (arr[i] == 0)
                {
                    num = random.Next(1, arr.Length + 1);
                    isExist = false;

                    for (int j = 0; j < i; j++)
                    {
                        if (num == arr[j])
                        {
                            isExist = true;
                            break;
                        }
                    }

                    if (!isExist)
                    {
                        arr[i] = num;
                        break;
                    }
                }
            }
        }

        public Pair[] CalculateFreq()
        {

            Pair[] pairs = new Pair[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                pairs[i] = new Pair(0, 0);

            }

            int countDifference = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                bool isElement = false;
                for (int j = 0; j < countDifference; j++)
                {
                    if (arr[i] == pairs[j].Number)
                    {
                        pairs[j].Freq++;
                        isElement = true;
                        break;
                    }
                }
                if (!isElement)
                {
                    pairs[countDifference].Freq++;
                    pairs[countDifference].Number = arr[i];
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

        public override string ToString()
        {
            string str = "";

            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }

            return str;
        }

        protected int partitionRight(int left, int right)
        {
            int pivot = arr[right];
            int i = left;

            for (int j = left; j < right; j++)
            {
                if (arr[j] < pivot)
                {
                    if (j != i )
                    {
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }
                    i++;
                }
            }
            (arr[i], arr[right]) = (arr[right], arr[i]);

            return i;
        }

        protected int partitionLeft(int left, int right)
        {
            int pivot = arr[left];
            int i = left + 1;

            for (int j = left + 1; j <= right; j++)
            {
                if (arr[j] < pivot)
                {
                    if (j != i)
                    {
                        (arr[i], arr[j]) = (arr[j], arr[i]);
                    }
                    i++;
                }
            }

            arr[left] = arr[i - 1];
            arr[i - 1] = pivot;

            return i - 1;
        }

        protected int partitionMiddle(int left, int right)
        {
            (left, right) = (left - 1, right + 1);
            int pivot = arr[left + (right - left) / 2];

            while (true)
            {
                while (arr[++left] < pivot);
                while (arr[--right] > pivot);
                if (left >= right)
                {
                    break;
                }
                (arr[left], arr[right]) = (arr[right], arr[left]);
            }

            return right;
        }

        public void QuickSort(int left, int right, pivotType pivot)
        {
            var partition = partitionRight;
            switch(pivot)
            {
                case pivotType.right:
                    partition = partitionRight;
                    break;
                case pivotType.middle:
                    partition = partitionMiddle;
                    break;
                case pivotType.left:
                    partition = partitionLeft;
                    break;
            }

            if (left < right)
            {
                int pivotIndex = partition(left, right);

                QuickSort(left, pivotIndex - 1, pivot);
                QuickSort(pivotIndex + 1, right, pivot);
            }
        }
    }
}

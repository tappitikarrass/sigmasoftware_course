namespace hw3
{
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
            // array
            string str = String.Format("array[{0}]:\n", arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                str += arr[i] + " ";
            }

            // frequency
            str += "\n\nnum frequency:\n";
            foreach (var item in CalculateFreq())
            {
                str += item.ToString() + "\n";
            }

            // palindrome
            str += String.Format("\nisPalindrom: {0}\n", CheckPalindrome());

            // longest subsequence
            str += "\nlongest subsequence:\n";
            foreach (int item in FindLongestSubsequence())
            {
                str += String.Format("{0} ", item);
            }

            return str;
        }
    }
}

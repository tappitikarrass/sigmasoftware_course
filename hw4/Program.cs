namespace hw4
{
    class Program
    {
        static void Main(string[] args)
        {
            QuickSort();
            //NumberFrequency();
            //Palindrome();
            //LongestSubsequence();
        }
       
        private static void LongestSubsequence()
        {
            var vector1 = new Vector(2, 2, 3, 3, 3, 1, 1, 1, 1, 5, 4);
            Console.WriteLine("Array:\t{0}", vector1);
            string sequence = "";
            foreach (int item in vector1.FindLongestSubsequence())
            {
                sequence += String.Format("{0} ", item);
            }
            Console.Write("Longest subsequence: {0}", sequence);
        }

        private static void Palindrome()
        {
            var vector1 = new Vector(1, 2, 2, 1);
            Console.WriteLine("Array:\t{0}", vector1);
            Console.WriteLine("isPalindrome: {0}", vector1.CheckPalindrome());
        }
        
        private static void NumberFrequency()
        {
            var vector1 = new Vector(2, 2, 3, 3, 3, 1, 1, 1, 1, 5, 4);
            Console.WriteLine("Array:\t{0}", vector1);
            Console.WriteLine("Number frequency:");
            foreach (var item in vector1.CalculateFreq())
            {
                Console.WriteLine(item);
            }
        }

        private static void QuickSort()
        {
            var vector1 = new Vector(2, 3, 1, 5, 4);
            Console.WriteLine("Initial array:\t{0}\n", vector1);

            vector1.QuickSort(0, 4, pivotType.right);
            Console.WriteLine("Right pivot:\t{0}", vector1);

            vector1 = new Vector(2, 3, 1, 5, 4);
            vector1.QuickSort(0, 4, pivotType.left);
            Console.WriteLine("Left pivot:\t{0}", vector1);

            vector1 = new Vector(2, 3, 1, 5, 4);
            vector1.QuickSort(0, 4, pivotType.middle);
            Console.WriteLine("Middle pivot:\t{0}", vector1);
        }
    }
}

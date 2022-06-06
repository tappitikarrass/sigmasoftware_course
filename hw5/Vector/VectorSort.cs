namespace hw5
{
    public enum pivotType { right, left, middle };

	public partial class Vector
	{
		#region QuickSort
		private int partitionRight(int left, int right)
		{
			int pivot = _array[right];
			int i = left;

			for (int j = left; j < right; j++)
			{
				if (_array[j] < pivot)
				{
					if (j != i)
					{
						(_array[i], _array[j]) = (_array[j], _array[i]);
					}
					i++;
				}
			}
			(_array[i], _array[right]) = (_array[right], _array[i]);

			return i;
		}

		protected int partitionLeft(int left, int right)
		{
			int pivot = _array[left];
			int i = left + 1;

			for (int j = left + 1; j <= right; j++)
			{
				if (_array[j] < pivot)
				{
					if (j != i)
					{
						(_array[i], _array[j]) = (_array[j], _array[i]);
					}
					i++;
				}
			}

			_array[left] = _array[i - 1];
			_array[i - 1] = pivot;

			return i - 1;
		}

		protected int partitionMiddle(int left, int right)
		{
			(left, right) = (left - 1, right + 1);
			int pivot = _array[left + (right - left) / 2];

			while (true)
			{
				while (_array[++left] < pivot) ;
				while (_array[--right] > pivot) ;
				if (left >= right)
				{
					break;
				}
				(_array[left], _array[right]) = (_array[right], _array[left]);
			}

			return right;
		}

		public void QuickSort(int left, int right, pivotType pivot)
		{
			var partition = partitionRight;
			switch (pivot)
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
		#endregion

		#region PyramidSort
		private void heapify(int n, int i)
		{
			int largest = i;
			int left = 2 * i + 1;
			int right = 2 * i + 2;

			if (left < n && _array[left] > _array[largest])
				largest = left;

			if (right < n && _array[right] > _array[largest])
				largest = right;

			if (largest != i)
			{
				(_array[i], _array[largest]) = (_array[largest], _array[i]);
				heapify(n, largest);
			}
		}

		public void PyramidSort()
		{
			int n = _array.Length;

			for (int i = n / 2 - 1; i >= 0; i--)
				heapify(n, i);

			for (int i = n - 1; i >= 0; i--)
			{
				(_array[0], _array[i]) = (_array[i], _array[0]);
				heapify(i, 0);
			}
		}
        #endregion

        #region FileSplitMergeSort
		private void FileMerge(string filePath, Vector firstVector, Vector secondVector)
        {
            int i = 0;
            int j = 0;
            using (StreamWriter writer = new StreamWriter(filePath))
            {

				while (i < firstVector.GetLength() && j < secondVector.GetLength())
				{
					if (firstVector[i] < secondVector[j])
					{
						writer.Write(firstVector[i++] + " ");
					}
					else
					{
						writer.Write(secondVector[j++] + " ");
					}
				}
                if (i == firstVector.GetLength())
                {
                    while (j < secondVector.GetLength())
                    {
                        writer.Write(secondVector[j++] + " ");
                    }
                }
                else
                {
                    while (i < firstVector.GetLength())
                    {
                        writer.Write(firstVector[i++] + " ");
                    }
                }
            }
        }

		public void FileSplitMergeSort(string outputFilePath)
        {
            if(File.Exists(outputFilePath))
            {
                File.Delete(outputFilePath);
            }

            List<int> list1 = new List<int>();
            List<int> list2 = new List<int>();

            for (int i = 0; i < _array.Length; i++)
            {
				if (i < _array.Length / 2)
                {
                    list1.Add(_array[i]);
                } else
                {
                    list2.Add(_array[i]);
                }
            }

            Vector vector1 = new Vector(list1);
            Vector vector2 = new Vector(list2);

            vector1.SplitMergeSort(0, vector1.GetLength());
            vector2.SplitMergeSort(0, vector2.GetLength());
			FileMerge(outputFilePath, vector1, vector2);
        }
        #endregion

        #region SplitMergeSort
        private void Merge(int firstIndex, int middle, int lastIndex)
		{
			int i = firstIndex;
			int j = middle;
			int k = 0;
			int[] temp = new int[lastIndex - firstIndex + 1];
			while (i < middle && j < lastIndex)
			{
				if (_array[i] < _array[j])
				{
					temp[k] = _array[i++];
				}
				else
				{
					temp[k] = _array[j++];
				}
				k++;
			}
			if (i == middle)
			{
				for (int t = j; t < lastIndex; t++)
				{
					temp[k++] = _array[t];
				}
			}
			else
			{
				while (i < middle)
				{
					temp[k++] = _array[i++];
				}
			}
			for (int n = 0; n < temp.Length - 1; n++)
			{
				_array[n + firstIndex] = temp[n];
			}
		}
		public void SplitMergeSort(int firstIndex, int lastIndex)
		{
			if (lastIndex - firstIndex <= 1) return;

			int middle = (firstIndex + lastIndex) / 2;
			SplitMergeSort(firstIndex, middle);
			SplitMergeSort(middle, lastIndex);
			Merge(firstIndex, middle, lastIndex);
		}
		#endregion
	}
}

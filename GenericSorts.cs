namespace Generics.Sorts;

public static class PrimSort
{
    #region BubbleSort
    //Generic BubbleSort Method

    /*
        Summary:
            This method is used to sort an array.
            Time Complexity: O(n^2) --> n as the amount of elements in the array.
            Space Complexity: O(1)
    
        Parameters:
            array: The array that will be sorted.
    
        Returns:
            nothing
    
        Exception:
            ArgumentNullException: If the array is null.
    */
    static public void BubbleSort<TBubArr>(TBubArr[] array) where TBubArr : IComparable<TBubArr>, IEquatable<TBubArr>
    {
        //loop through every element of the array
        for (int i = 0; i < array.Length; i++)
        {
            //loop through every element of the array for every element of the array
            for (int j = 0; j < array.Length - 1; j++)
            {
                //if the element is bigger than the next element, swap them
                if (array[j].CompareTo(array[j + 1]) > 0)
                {
                    //swap the current element with the next element
                    TBubArr temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                }
            }
        }
    }
    #endregion

    #region SelectionSort
    //Generic SelectionSort Method

    /*
        Summary:
            This method is used to sort an array.
            Time Complexity: O(n^2) --> n as the amount of elements in the array.
            Space Complexity: O(1)
    
        Parameters:
            array: The array that will be sorted.
    
        Returns:
            nothing
    
        Exception:
            ArgumentNullException: If the array is null.
    */
    static public void SelectionSort<TSeleArr>(TSeleArr[] array) where TSeleArr : IComparable<TSeleArr>, IEquatable<TSeleArr>
    {
        //loop through every element of the array
        for (int i = 0; i < array.Length; i++)
        {
            //define the current element as the smallest element
            int min = i;
            for (int j = i + 1; j < array.Length; j++)
            {
                //if the current element is smaller then the smallest element, set the current element as the smallest element
                if (array[j].CompareTo(array[min]) < 0)
                {
                    min = j;
                }
            }
            //swap the smallest element with the current element
            TSeleArr temp = array[i];
            array[i] = array[min];
            array[min] = temp;
        }
    }
    #endregion

    #region InsertionSort
    //Generic InsertionSort Method

    /*
        Summary:
            This method is used to sort an array.
            Time Complexity: O(n^2) --> n as the amount of elements in the array.
            Space Complexity: O(1)
    
        Parameters:
            array: The array that will be sorted.
    
        Returns:
            nothing
    
        Exception:
            ArgumentNullException: If the array is null.
    */
    static public void InsertionSort<TInseArr>(TInseArr[] array) where TInseArr : IComparable<TInseArr>, IEquatable<TInseArr>
    {
        //loop through every element of the array
        for (int i = 1; i < array.Length; i++)
        {
            //store the current element
            TInseArr temp = array[i];
            int j = i;
            //loop through every element of the array until the current element is smaller then the element before it
            while (j > 0 && array[j - 1].CompareTo(temp) > 0)
            {
                //swap the current element with the element before it
                array[j] = array[j - 1];
                j--;
            }
            array[j] = temp;
        }
    }
    #endregion

    #region MergeSort
    //Generic MergeSort Method

    /*
        Summary:
            This method is used to sort an array.
            Time Complexity: O(n*log(n)) --> n as the amount of elements in the array.
            Space Complexity: O(n)
    
        Parameters:
            array: The array that will be sorted.
    
        Returns:
            nothing
    
        Exception:
            ArgumentNullException: If the array is null.
    */
    static public void MergeSort<TMerArr>(TMerArr[] array) where TMerArr : IComparable<TMerArr>, IEquatable<TMerArr>
    {
        if (array.Length > 1)
        {
            //split the array in half
            int middle = array.Length / 2;
            TMerArr[] left = new TMerArr[middle];
            TMerArr[] right = new TMerArr[array.Length - middle];
            //copy the left half of the array into the left array
            for (int i = 0; i < middle; i++)
            {
                left[i] = array[i];
            }
            //copy the right half of the array into the right array
            for (int i = middle; i < array.Length; i++)
            {
                right[i - middle] = array[i];
            }
            //divide left array into left and right array recursively
            MergeSort<TMerArr>(left);
            //divide right array into left and right array recursively
            MergeSort<TMerArr>(right);
            //merge the sorted left and right array into the original array recursively
            Merge<TMerArr>(left, right, array);
        }
    }

    static private void Merge<TMerArr>(TMerArr[] left, TMerArr[] right, TMerArr[] array) where TMerArr : IComparable<TMerArr>, IEquatable<TMerArr>
    {
        int leftIndex = 0;
        int rightIndex = 0;
        int arrayIndex = 0;

        //loop until the left array and right array reach the end
        //copies the smaller value into the array
        while (leftIndex < left.Length && rightIndex < right.Length)
        {
            if (left[leftIndex].CompareTo(right[rightIndex]) < 0)
            {
                array[arrayIndex] = left[leftIndex];
                leftIndex++;
            }
            else
            {
                array[arrayIndex] = right[rightIndex];
                rightIndex++;
            }
            arrayIndex++;
        }
        //copy remaining elements of the left array into the array (if any)
        while (leftIndex < left.Length)
        {
            array[arrayIndex] = left[leftIndex];
            leftIndex++;
            arrayIndex++;
        }
        //copy remaining elements of the right array into the array (if any)
        while (rightIndex < right.Length)
        {
            array[arrayIndex] = right[rightIndex];
            rightIndex++;
            arrayIndex++;
        }
    }
    #endregion

    #region QuickSort
    //Generic QuickSort Method

    /*
        Summary:
            This method is used to sort an array.
            Time Complexity: O(n*log(n)) --> n as the amount of elements in the array.
            Space Complexity: O(n)
    
        Parameters:
            array: The array that will be sorted.
    
        Returns:
            nothing
    
        Exception:
            ArgumentNullException: If the array is null.
    */
    static public void QuickSort<TQuiArr>(TQuiArr[] array) where TQuiArr : IComparable<TQuiArr>, IEquatable<TQuiArr>
    {
        QuickSort<TQuiArr>(array, 0, array.Length - 1);
    }

    static private void QuickSort<TQuiArr>(TQuiArr[] array, int left, int right) where TQuiArr : IComparable<TQuiArr>, IEquatable<TQuiArr>
    {
        if (left < right)
        {
            int pivot = Partition<TQuiArr>(array, left, right);
            if (pivot > 1)
            {
                QuickSort<TQuiArr>(array, left, pivot - 1);
            }
            if (pivot + 1 < right)
            {
                QuickSort<TQuiArr>(array, pivot + 1, right);
            }
        }
    }

    static private int Partition<TQuiArr>(TQuiArr[] array, int left, int right) where TQuiArr : IComparable<TQuiArr>, IEquatable<TQuiArr>
    {
        TQuiArr pivot = array[left];
        while (true)
        {
            while (array[left].CompareTo(pivot) < 0)
            {
                left++;
            }
            while (array[right].CompareTo(pivot) > 0)
            {
                right--;
            }
            if (left < right)
            {
                TQuiArr temp = array[right];
                array[right] = array[left];
                array[left] = temp;
            }
            else
            {
                return right;
            }
        }
    }
    #endregion
}

public static class MutSort
{
    #region 3-Way QuickSort
    //Generic 3-Way QuickSort Method

    /*
        Summary:
            This method is used to sort an array.
            Time Complexity: O(n*log(n)) --> n as the amount of elements in the array.
            Space Complexity: O(log(n))  --> n as the amount of elements in the array.
    
        Parameters:
            array: The array that will be sorted.
    
        Returns:
            nothing
    
        Exception:
            ArgumentNullException: If the array is null.
    */

    
    #endregion
}
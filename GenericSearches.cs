namespace Generics.Searches;

public static class PrimSearch
{
    #region BinarySearch

    //Generic BinarySearch Method
    /*
        Summary:
            This method is used to search for a specific value in an array.
            The Array needs to be sorted
            Time Complexity: O(log(n)) --> n as in the amount of elements in the array.
            Space Complexity: O(1)

        Parameters:
            TSearchArr: The array that will be searched.
            TSearchVal: The value that will be searched for.

        Returns:
            int: The index of the value that was searched for.
            -1: If the value was not found.

        Exception:
            ArgumentNullException: If the array is null.
    */
    static public int BinarySearch<TBinArr>(TBinArr[] array, TBinArr value) where TBinArr : IComparable<TBinArr>, IEquatable<TBinArr>
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int left = 0; //sets the left boundary as the first index of the array
        int right = array.Length - 1; //sets the right boundary as the last index of the array
        int middle = 0;
        while (left <= right)
        {
            //sets the middle index as the index of the array (left + right) / 2
            middle = (left + right) / 2;

            //if the value is found, return the index
            if (array[middle].Equals(value)) 
            {
                sw.Stop();
                Console.WriteLine("Binary Search: " + sw.ElapsedMilliseconds + "ms");
                return middle;
            }
            //if the value is bigger than the middle value, set the left boundary as the middle index + 1 --> value cannot be in the left side of the arry
            //effectively cuts the left side of the array out of the search
            else if (array[middle].CompareTo(value) < 0)
            {
                left = middle + 1;
            }
            //if the value is smaller than the middle value, set the right boundary as the middle index - 1 --> value cannot in the right side of the array
            //effectively cuts the right side of the array out of the search
            else
            {
                right = middle - 1;
            }
        }
        //if nothing is found, return -1 --> value is not in the array
        return -1;
    }
    #endregion

    #region LinearSearch

    //Generic LinearSearch Method

    /*
        Summary:
            This method is used to search for a specific value in an array.
            Speed: O(n) --> n as the amount of elements in the array.
            Space: O(1)

        Parameters:
            TSearchArr: The array that will be searched.
            TSearchVal: The value that will be searched for.

        Returns:
            int: The index of the value that was searched for.
            -1: If the value was not found.

        Exception:
            ArgumentNullException: If the array is null.
    */
    static public int LinearSearch<TLinArr>(TLinArr[] array, TLinArr value) where TLinArr : IEquatable<TLinArr>
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        //loops through the array
        for (int i = 0; i < array.Length; i++)
        {
            //if the value is equal to the searched value, return the index
            if (array[i].Equals(value))
            {
                sw.Stop();
                Console.WriteLine("Linear Search: " + sw.ElapsedMilliseconds + "ms");
                return i;
            }
        }
        //if nothing is found, return -1 --> value is not in the array
        return -1;
    }
    #endregion
}

public static class SecSearch
{
    #region JumpSearch
    //Generic JumpSearch Method

    /*
        Summary:
            This method is used to search for a specific value in an array.
            The Array needs to be sorted
            Speed: O(sqrt(n)) --> n as the amount of elements in the array.
            Space: O(1)

        Parameters:
            array: The array that will be searched.
            value: The value that will be searched for.

        Returns:
            int: The index of the value that was searched for.
            -1: If the value was not found.

        Exception:
            ArgumentNullException: If the array is null.
    */
    public static int JumpSearch<TJmpArr>(TJmpArr[] array, TJmpArr value) where TJmpArr : IComparable<TJmpArr>, IEquatable<TJmpArr>
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        //sets the jump size as the square root of the array length (optimal jump size)
        int step = (int)Math.Sqrt(array.Length);
        int prev = 0;
        //loop through the array until the value in the array is bigger than the searched value
        while (array[Math.Min(step, array.Length) - 1].CompareTo(value) < 0)
        {
            //set the previous index to the current index
            prev = step;
            //increase the step size by the square root of the array length (if prev step was 4, its now 8)
            step += (int)Math.Sqrt(array.Length);
            //if the step size is greater than the array length, the value was not found --> return -1
            if (prev >= array.Length)
            {
                return -1;
            }
        }
        //linear search through the part of the array on which the value is until the searched value is found
        //loops until a value is found or the end of the array is reached
        while (array[prev].CompareTo(value) < 0)
        {
            prev++;
            //if the end of the array is found whitout finding a value returns -1
            if (prev == Math.Min(step, array.Length))
            {
                return -1;
            }
        }
        //if the value is found, return the index
        if (array[prev].Equals(value))
        {
            sw.Stop();
            Console.WriteLine("Jump Search: " + sw.ElapsedMilliseconds + "ms");
            return prev;
        }
        return -1;
    }
    #endregion

    #region InterpolationSearch

    //Generic InterpolationSearch Method

    /*
        Summary:
            This method is used to search for a specific value in an array.
            The Array needs to be sorted
            Speed: O(log(log(n))) --> n as the amount of elements in the array.
            Space: O(1)

        Parameters:
            array: The array that will be searched.
            value: The value that will be searched for.

        Returns:
            int: The index of the value that was searched for.
            -1: If the value was not found.

        Exception:
            ArgumentNullException: If the array is null.
    */

    public static int InterpolationSearch<TIntArr>(TIntArr[] array, TIntArr value) where TIntArr : IComparable<TIntArr>, IEquatable<TIntArr>
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int left = 0; //sets the left boundary as the first index of the array
        int right = array.Length - 1; //sets the right boundary as the last index of the array
        int middle = 0;
        //if the value is smaller than the first value in the array, return -1 --> value is not in the array
        if(array.Length == 0)
        {
            return -1;
        }
        if (array[left].CompareTo(value) > 0)
        {
            return -1;
        }
        //if the value is bigger than the last value in the array, return -1 --> value is not in the array
        if (array[right].CompareTo(value) < 0)
        {
            return -1;
        }
        //while the left boundary is smaller than the right boundary
        while (left <= right)
        {
            //The idea of formula is to return higher value of pos 
            middle = (int)(left + (right - left) * (value.CompareTo(array[left]) - array[left].CompareTo(value)) / (array[right].CompareTo(array[left]) - array[left].CompareTo(value)));
            //if the value is found, return the index
            if (array[middle].Equals(value))
            {
                sw.Stop();
                Console.WriteLine("Interpolation search: " + sw.ElapsedMilliseconds + "ms");
                return middle;
            }
            //if the value is bigger than the middle value, set the left boundary as the middle index + 1 --> value cannot be in the left side of the arry
            //effectively cuts the left side of the array out of the search
            else if (array[middle].CompareTo(value) < 0)
            {
                left = middle + 1;
            }
            //if the value is smaller than the middle value, set the right boundary as the middle index - 1 --> value cannot in the right side of the array
            //effectively cuts the right side of the array out of the search
            else
            {
                right = middle - 1;
            }
        }
        return -1;
    }
    #endregion
}
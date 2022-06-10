using Generics.Searches;
using Generics.Sorts;

namespace Generics;
public class Program
{
    public static void Main(string[] args)
    {
        int[] intArray = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        int[] intArrayNull = {};
        string[] stringArray = new string[] { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten" };
        Person[] PersonArray = new Person[] { new Person("Ane", "Ball", 20), new Person("BAne", "all", 40), new Person("John", "Doe", 30), new Person("Jane", "Doe", 32) };
        Student[] StudentArray = new Student[] { new Student("Neymar", "Junior", 24), new Student("Ronaldo", "Christiano", 38), new Student("Messi", "Lionel", 32) };
        Teacher[] TeacherArray = new Teacher[] { new Teacher("Morten", "Hansen", 40), new Teacher("Morten", "Hansen", 40), new Teacher("Morten", "Hansen", 40) };

        Array myRandIntArrayBig = ArrayCreation.CreateIntArray(100000000);
        Array myRandIntArray = ArrayCreation.CreateIntArray(100000);
        Array myRandIntArraySmall = ArrayCreation.CreateIntArray(10000);
        Array myRandIntArrayVerySmall = ArrayCreation.CreateIntArray(100);

        int index = PrimSearch.BinarySearch<int>(intArray, 2);
        int index2 = PrimSearch.BinarySearch<string>(stringArray, "six");
        int index3 = PrimSearch.LinearSearch<Person>(PersonArray, new Person("Ane", "Ball", 20));
        int index4 = PrimSearch.BinarySearch<Student>(StudentArray, new Student("Neymar", "Junior", 24));
        int index5 = SecSearch.InterpolationSearch((int[])myRandIntArrayBig, 9004563);
        int index6 = PrimSearch.BinarySearch((int[])myRandIntArrayBig, 9004563);
        int index7 = SecSearch.JumpSearch((int[])myRandIntArrayBig, 9004563);
        int index8 = PrimSearch.LinearSearch((int[])myRandIntArrayBig, 9004563);


        Convenience.Stopwatch(() => PrimSort.BubbleSort<int>((int[])myRandIntArraySmall));
        Thread.Sleep(2000);
        Convenience.PrintArray(myRandIntArraySmall);

        Convenience.Stopwatch(() => PrimSort.SelectionSort<int>((int[])myRandIntArraySmall));
        Thread.Sleep(2000);
        Convenience.PrintArray(myRandIntArraySmall);

        Convenience.Stopwatch(() => PrimSort.InsertionSort<int>((int[])myRandIntArraySmall));
        Thread.Sleep(2000);
        Convenience.PrintArray(myRandIntArraySmall);

        Convenience.Stopwatch(() => PrimSort.MergeSort<int>((int[])myRandIntArraySmall));
        Thread.Sleep(2000);
        Convenience.PrintArray(myRandIntArraySmall);

        Console.WriteLine(index);
        Console.WriteLine(index2);
        Console.WriteLine(index3);
        Console.WriteLine(index4);
        Console.WriteLine(index5);
        Console.WriteLine(index6);
        Console.WriteLine(index7);
        Console.WriteLine(index8);
    }
}
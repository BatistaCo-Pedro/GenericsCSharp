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
        Student[] StudentArray = new Student[] { new Student("Ronaldo", "Christiano", 38), new Student("Messi", "Lionel", 32), new Student("Neymar", "Junior", 24) };
        Teacher[] TeacherArray = new Teacher[] { new Teacher("Morten", "Hansen", 40), new Teacher("Morten", "Hansen", 40), new Teacher("Morten", "Hansen", 40) };

        Array myIntArray = Array.CreateInstance(typeof(Int64), 100000000);
        for(Int64 i = 0; i < 100000000; i++)
        {
            myIntArray.SetValue(i, i);
        }

        PrimSort.QuickSort<string>(stringArray);
        foreach (string s in stringArray)
        {
            Console.WriteLine(s);
        }

        int index = PrimSearch.BinarySearch<int>(intArray, 2);
        int index2 = PrimSearch.BinarySearch<string>(stringArray, "one");
        int index3 = PrimSearch.LinearSearch<Person>(PersonArray, new Person("Ane", "Ball", 20));
        int index4 = PrimSearch.BinarySearch<Student>(StudentArray, new Student("Ronaldo", "Christiano", 38));
        int index5 = SecSearch.InterpolationSearch((Int64[])myIntArray, 9004563);
        int index6 = PrimSearch.BinarySearch((Int64[])myIntArray, 9004563);
        int index7 = SecSearch.JumpSearch((Int64[])myIntArray, 9004563);
        int index8 = PrimSearch.LinearSearch((Int64[])myIntArray, 9004563);

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
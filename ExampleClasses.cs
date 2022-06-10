#nullable disable warnings
namespace Generics;

#region TestClasses
public class Person : IComparable<Person>, IEquatable<Person>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public int Age { get; private set; }

    public Person(string FirstName, string LastName, int Age) => 
    (this.FirstName, this.LastName, this.Age) = (FirstName, LastName, Age);

    public Person(string FirstName, int Age) => 
    (this.FirstName, this.Age) = (FirstName, Age);

    public Person(string FirstName, string LastName) => 
    (this.FirstName, this.LastName) = (FirstName, LastName);

    public int CompareTo(Person other)
    {
        int EndResult = 0;

        if (this.Age.CompareTo(other.Age) == 0) { EndResult = 0; }
        else if (this.Age.CompareTo(other.Age) > 0) { return 1; }
        else {return -1; }

        if (this.FirstName.CompareTo(other.FirstName) == 0) { EndResult = 0; }
        else if (this.FirstName.CompareTo(other.FirstName) > 0) { return 1; }
        else { return -1; }

        if (this.LastName.CompareTo(other.LastName) == 0) { EndResult = 0; }
        else if (this.LastName.CompareTo(other.LastName) > 0) { return 1; }
        else { return -1; }

        return EndResult;
    }

    public bool Equals(Person other)
    {
        if (this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName) && this.Age.Equals(other.Age))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Student : Person, IEquatable<Student>, IComparable<Student>
{
    public Student(string FirstName, string LastName, int Age) : base(FirstName, LastName, Age) { }
    public Student(string FirstName, int Age) : base(FirstName, Age) { }
    public int CompareTo(Student other)
    {
        int EndResult = 0;

        if (this.Age.CompareTo(other.Age) == 0) { EndResult = 0; }
        else if (this.Age.CompareTo(other.Age) > 0) { return 1; }
        else { return -1; }

        if (this.FirstName.CompareTo(other.FirstName) == 0) { EndResult = 0; }
        else if (this.FirstName.CompareTo(other.FirstName) > 0) { return 1; }
        else { return -1; }

        if (this.LastName.CompareTo(other.LastName) == 0) { EndResult = 0; }
        else if (this.LastName.CompareTo(other.LastName) > 0) { return 1; }
        else { return -1; }

        return EndResult;
    }

    public bool Equals(Student other)
    {
        if (this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName) && this.Age.Equals(other.Age))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}

public class Teacher : Person, IComparable<Teacher>, IEquatable<Teacher>
{
    public Teacher(string FirstName, string LastName, int Age) : base(FirstName, LastName, Age) { }
    public Teacher(string FirstName, int Age) : base(FirstName, Age) { }

    public int CompareTo(Teacher other)
    {
        int EndResult = 0;

        if (this.Age.CompareTo(other.Age) == 0) { EndResult = 0; }
        else if (this.Age.CompareTo(other.Age) > 0) { return 1; }
        else { return -1; }

        if (this.FirstName.CompareTo(other.FirstName) == 0) { EndResult = 0; }
        else if (this.FirstName.CompareTo(other.FirstName) > 0) { return 1; }
        else { return -1; }

        if (this.LastName.CompareTo(other.LastName) == 0) { EndResult = 0; }
        else if (this.LastName.CompareTo(other.LastName) > 0) { return 1; }
        else { return -1; }

        return EndResult;
    }

    public bool Equals(Teacher other)
    {
        if (this.FirstName.Equals(other.FirstName) && this.LastName.Equals(other.LastName) && this.Age.Equals(other.Age))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
#endregion

#region Arrays
public class ArrayCreation
{
    public static Array CreateIntArray(int Size)
    {
        Random rnd = new Random();
        Array Array = Array.CreateInstance(typeof(int), Size);
        for(int i = 0; i < Size; i++)
        {
            Array.SetValue(rnd.Next(0, Size * 10), i);
        }
        return Array;
    }
}

public class Convenience
{
    public static void PrintArray(Array Array)
    {
        for(int i = 0; i < Array.Length; i++)
        {
            Console.WriteLine(Array.GetValue(i));
        }
    }

    public static void Stopwatch(Action Action)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Action();
        sw.Stop();
        Console.WriteLine(sw.ElapsedMilliseconds + "ms");
    }
}

#endregion

namespace Module_9;

class Program
{
    //Кавариантность и контравариантьность делегатов
    delegate void ChildInfo(Child child);

    static void GetInfo(Child child)
    {
        Console.WriteLine($"Info: {child.GetType()}");
    }

    static void Main(string[] args)
    {
        ChildInfo childInfo = GetInfo;
        childInfo.Invoke(new Child());
        Console.ReadKey();
    }
}

class Parent
{
}

class Child : Parent
{
}
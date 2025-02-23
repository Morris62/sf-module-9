namespace Module_9;

class Program
{
    delegate int DiffDelegate(int a, int b);
    static int CalculateDiff(int a, int b) => a - b;

    static void Main(string[] args)
    {
        DiffDelegate diffDelegate = CalculateDiff;
        Console.WriteLine(diffDelegate.Invoke(10, 5));
    }
}
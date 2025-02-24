namespace Module_9;

class Program
{
    delegate void ShowMessageDelegate();
    delegate int SumDelegate(int a, int b, int c);
    delegate bool CheckLengthDelegate(string _row);
    
    static void Main(string[] args)
    {
        Action showMessageDelegate = ShowMessage;
        showMessageDelegate();
        
        Func<int,int,int,int> sumDelegate = Sum;
        var result = sumDelegate(10, 20, 30);
        Console.WriteLine(result);
        
        Predicate<string> checkLengthDelegate = CheckLength;
        var status = checkLengthDelegate.Invoke("skill_factory");
        Console.WriteLine(status);
    }
    static void ShowMessage()
    {
        Console.WriteLine("Hello World!");
    }
    static int Sum(int a, int b, int c)
    {
        return a + b + c;
    }
    static bool CheckLength(string _row)
    {
        if (_row.Length > 3)
            return true;
        return false;
    }
}
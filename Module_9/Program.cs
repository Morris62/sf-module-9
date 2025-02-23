using System.Data.SqlTypes;

namespace Module_9;

class Program
{
    delegate int DiffAndSummDelegate(int a, int b);
    delegate void ShowDelegate();
    static int CalculateDiff(int a, int b) => a - b;
    static int CalculateSumm(int a, int b) => a + b;
    static void Show1() => Console.WriteLine("Show1");
    static void Show2() => Console.WriteLine("Show2");
    static void Show3() => Console.WriteLine("Show3");
    static void Show4() => Console.WriteLine("Show4");
    static void Show5() => Console.WriteLine("Show5");
    
    static void Main(string[] args)
    {
        DiffAndSummDelegate diffAndSummDelegate = CalculateDiff;
        diffAndSummDelegate += CalculateSumm;
        diffAndSummDelegate -= CalculateSumm;
        Console.WriteLine(diffAndSummDelegate.Invoke(10, 5));
        Console.WriteLine(diffAndSummDelegate(10, 5));
        
        // multicast delegate (мультикаст делегат или многоадресный)
        ShowDelegate showDelegate1 = Show1;
        showDelegate1 += Show2;
        showDelegate1 += Show3;
        
        ShowDelegate showDelegate2 = Show4;
        showDelegate2 += Show5;
        
        ShowDelegate showDelegate = showDelegate1 + showDelegate2;
        showDelegate();
    }
}
namespace Module_9;

class Program
{
    // Анонимные методы
    // профит - экономия времени
    // нюансы - доступ к переменным во внешней среде

    public delegate void ShowMessageDelegate(string message);

    static void Main(string[] args)
    {
        ShowMessageDelegate showMessageDelegate = delegate(string message)
        {
            Console.WriteLine(message);
        };
        showMessageDelegate.Invoke("Hello World!");
    }
}
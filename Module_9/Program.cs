namespace Module_9;

class Program
{
    // Анонимные методы
    // профит - экономия времени
    // нюансы - доступ к переменным во внешней среде
    delegate int RandomNumberDelegate();
    static void Main(string[] args)
    {
        RandomNumberDelegate randomNumberDelegate = () =>  new Random().Next(0, 100);
        Console.WriteLine(randomNumberDelegate.Invoke().ToString("000"));
    }
}
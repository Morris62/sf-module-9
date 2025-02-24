namespace Module_9;

class Program
{
    // Анонимные методы
    // профит - экономия времени
    // нюансы - доступ к переменным во внешней среде

    public delegate string GreetingDelegate(string name);

    public static string Greeting(string name)
    {
        return $"Привет @{name}! Добро пожаловать на SkillFactory!";
    }

    static void Main(string[] args)
    {
        string exMessage = "Внешний мир!";
        //GreetingDelegate greetingDelegate = Greeting;
        GreetingDelegate greetingDelegate = delegate(string name)
        {
            return $"{exMessage}Привет @{name}! Добро пожаловать на SkillFactory!";
        };
        string greetingMessage = greetingDelegate.Invoke("Будущий гуру");
        Console.WriteLine(greetingMessage);
    }
}
namespace Module_9;

class Program
{
    //Кавариантность и контравариантьность делегатов
    public delegate Car HandlerMethod();

    public static Car CarHadler()
    {
        return null;
    }

    public static Lexus LexusHadler()
    {
        return null;
    }

    static void Main(string[] args)
    {
        HandlerMethod handlerLexus = LexusHadler;
        Console.ReadKey();
    }
}

class Car
{
    
}

class Lexus : Car
{
    
}
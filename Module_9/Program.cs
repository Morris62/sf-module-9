namespace Module_9;

class Program
{
    static void Main(string[] args)
    {
      var exception = new Exception("Тест исключения");
      exception.Data.Add("Время возникновения исключения", DateTime.Now);
      exception.HelpLink = "www.ya.ru";
    }
}
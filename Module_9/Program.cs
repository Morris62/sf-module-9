using System.ComponentModel;

namespace Module_9;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Блок try");
            //1// throw new Exception("Ошибка связи с БД");
            //2// string str = null;
            //2// var x = str.Length;
            //3// throw new ArgumentOutOfRangeException();
            //4// throw new RankException();

            try
            {
                Method2();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }
        }
        catch (Exception ex) when (ex.Message == "Ошибка связи с БД")
        {
            Console.WriteLine("Блок catch - Пользовательский");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex) when (ex is NullReferenceException)
        {
            Console.WriteLine("Блок catch - NullReferenceException");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex) when (ex is ArgumentOutOfRangeException)
        {
            Console.WriteLine("Блок catch - ArgumentOutOfRangeException");
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex) when (ex is RankException)
        {
            Console.WriteLine("Блок catch - RankException");
            Console.WriteLine(ex.Message);
        }
        finally
        {
            Console.WriteLine("Блок finally");
        }

        static void Method1()
        {
            try
            {
                throw new WarningException();
            }
            catch (Exception e)
            {
                throw;
            }
        }

        static void Method2()
        {
            try
            {
                Method1();
            }
            catch (Exception)
            {
                throw;
            }
        }

        Console.ReadKey();
    }
}
namespace Module_9;

class Program
{
    public sealed class UserException : Exception
    {
        public UserException(string message = "Пользовательское исключение!") : base(message)
        {
            Data.Add("Время возникновения исключения", DateTime.Now);
            HelpLink = "www.google.ru";
        }
    }

    static void Main(string[] args)
    {
        #region Задание 1

        Console.WriteLine(new string('-', 50));
        Console.WriteLine(" Задание №1");
        Console.WriteLine(new string('-', 50));

        var exceptions = new Exception[]
        {
            new FormatException("Ошибка! Неверный формат!"),
            new DivideByZeroException("Ошибка! Деление на 0!"),
            new IndexOutOfRangeException("Ошибка! Индекс вне диапазона!"),
            new NullReferenceException("Ошибка! Обращение к null"),
            new UserException()
        };

        Console.WriteLine("Начало генерации исключений");
        foreach (var exception in exceptions)
        {
            try
            {
                throw exception;
            }
            catch (Exception e) when (e is UserException)
            {
                Console.WriteLine(
                    $"{e.GetType().Name}: {e.Message} Время возникновения исключения {e.Data["Время возникновения исключения"]}. Обратитесь {e.HelpLink}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Исключение {e.GetType().Name}: {e.Message}");
            }
            finally
            {
                Console.WriteLine("Генерация исключений завершена");
            }
        }

        #endregion

        #region Задание 2

        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        Console.WriteLine(" Задание №2");
        Console.WriteLine(new string('-', 50));

        var families = new string[]
        {
            "Иванов",
            "Петров",
            "Якин",
            "Сидоров",
            "Лебедев"
        };
        Console.WriteLine("Несортированный список фамилий:");
        foreach (var family in families)
        {
            Console.WriteLine(family);
        }

        var arraySorter = new ArraySorter();
        arraySorter.SortEventAsc += SortAsc;
        arraySorter.SortEventDesc += SortDesc;
        while (true)
        {
            try
            {
                arraySorter.Start();
            }
            catch (Exception ex) when (ex is UserException)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Непредвиденная ошибка! Повторите попытку");
            }
        }

        void SortAsc()
        {
            Console.WriteLine("Выбрана сортировка от А до Я");
            families = families.OrderBy(x => x).ToArray();
            foreach (var family in families)
            {
                Console.WriteLine(family);
            }
        }

        void SortDesc()
        {
            Console.WriteLine("Выбрана сортировка от Я до А");
            families = families.OrderByDescending(x => x).ToArray();
            foreach (var family in families)
            {
                Console.WriteLine(family);
            }
        }
        
        #endregion
    }

    enum SortOrder
    {
        Asc = 1,
        Desc
    }

    class ArraySorter
    {
        public delegate void SortDelegate();

        public event SortDelegate SortEventAsc;
        public event SortDelegate SortEventDesc;

        public void Start()
        {
            Console.WriteLine();
            Console.WriteLine("Введите направление сортировки 1(А->Я) или 2(Я->А)");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2)
            {
                throw new UserException("Ошибка формата данных!");
            }

            switch ((SortOrder)number)
            {
                case SortOrder.Asc:
                    SortEventAsc?.Invoke();
                    break;
                case SortOrder.Desc:
                    SortEventDesc?.Invoke();
                    break;
            }
        }
    }
}
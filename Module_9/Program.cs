namespace Module_9;

class Program
{
    private sealed class UserException : Exception
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
                Console.WriteLine($"{e.GetType().Name}: {e.Message} Время возникновения исключения {e.Data["Время возникновения исключения"]}. Обратитесь {e.HelpLink}");
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

        var numberReader = new NumberReader();
        numberReader.NumberEnteredEvent += SortArray;
        while (true)
        {
            try
            {
                numberReader.Read();
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

        void SortArray(int number)
        {
            SortOrder sortOrder;
            switch (number)
            {
                case 1:
                    Console.WriteLine("Выбрана сортировка от А до Я");
                    sortOrder = SortOrder.Asc;
                    break;
                case 2:
                    Console.WriteLine("Выбрана сортировка от Я до А");
                    sortOrder = SortOrder.Desc;
                    break;
                default:
                    sortOrder = SortOrder.Asc;
                    break;
            }

            if (sortOrder == SortOrder.Asc)
            {
                families = families.OrderBy(x => x).ToArray();
            }
            else
            {
                families = families.OrderByDescending(x => x).ToArray();
            }

            foreach (var family in families)
            {
                Console.WriteLine(family);
            }
        }

        #endregion
    }

    private enum SortOrder
    {
        Asc,
        Desc
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);

        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Введите направление сортировки 1(А->Я) или 2(Я->А)");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2)
            {
                throw new UserException("Ошибка формата данных!");
            }

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
}
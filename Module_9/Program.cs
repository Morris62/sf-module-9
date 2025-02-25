namespace Module_9;

class Program
{
    static void Main(string[] args)
    {
        var numberReader = new NumberReader();
        numberReader.NumberEnteredEvent += ShowNumber;
        while (true)
        {
            try
            {
                numberReader.Read();
            }
            catch (FormatException)
            {
                Console.WriteLine("Введено некорректное значение!");
            }
        }

        static void ShowNumber(int number)
        {
            switch (number)
            {
                case 1:
                    Console.WriteLine("Введено значение 1");
                    break;
                case 2:
                    Console.WriteLine("Введено значение 2");
                    break;
            }
        }
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);

        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Введите значение 1 или 2");

            int number = Convert.ToInt32(Console.ReadLine());

            if (number != 1 && number != 2)
            {
                throw new FormatException();
            }

            NumberEntered(number);
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }
}
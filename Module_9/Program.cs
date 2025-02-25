namespace Module_9;

public delegate void Notify();

/// <summary>
/// Издатель
/// </summary>
public class ProcessBuisnessLogic
{
    public event Notify ProcessCompleted;

    public void StartProcee()
    {
        Console.WriteLine("Процесс начат");
        OnProcessingComleted();
    }

    public virtual void OnProcessingComleted()
    {
        ProcessCompleted?.Invoke();
    }
}

/// <summary>
/// Подписчик
/// </summary>
class Program
{
    static void Main(string[] args)
    {
        var bl = new ProcessBuisnessLogic();
        bl.ProcessCompleted += bl_ProcessComplete;
        bl.StartProcee();
    }

    public static void bl_ProcessComplete()
    {
        Console.WriteLine("Процесс завершен");
    }
}
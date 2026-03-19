public interface ILog
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message);
}

public class ConsoleLogger : ILog
{
    public void LogInfo(string message)
    {
        Console.WriteLine($"[INFO] {message}");
    }

    public void LogWarning(string message)
    {
        Console.WriteLine($"[WARNING] {message}");
    }

    public void LogError(string message)
    {
        Console.WriteLine($"[ERROR] {message}");
    }
}

public class FileLogger : ILog
{
    private string pfad;

    public FileLogger(string pfad)
    {
        this.pfad = pfad;
    }

    public void LogInfo(string message)
    {
        File.AppendAllText(pfad, $"[INFO] {message}\n");
    }

    public void LogWarning(string message)
    {
        File.AppendAllText(pfad, $"[WARNING] {message}\n");
    }

    public void LogError(string message)
    {
        File.AppendAllText(pfad, $"[ERROR] {message}\n");
    }
}

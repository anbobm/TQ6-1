interface ILog
{
    void LogInfo(string message);
    void LogWarning(string message);
    void LogError(string message);
}

class FakeLogger : ILog
{
    public List<string> Messages { get; set; } = new List<string>();
    public void LogError(string message)
    {
        Messages.Add(message);
    }

    public void LogInfo(string message)
    {
        Messages.Add(message);
    }

    public void LogWarning(string message)
    {
        Messages.Add(message);
    }
}

class ConsoleLogger : ILog
{
    public void LogError(string message)
    {
        Console.WriteLine($"Error: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}");
    }

    public void LogInfo(string message)
    {
        Console.WriteLine($"Info: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}");
    }

    public void LogWarning(string message)
    {
        Console.WriteLine($"Warning: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}");
    }
}

class FileLogger : ILog
{
    private string path;

    public FileLogger(string path)
    {
        this.path = path;
    }
    public void LogError(string message)
    {
        File.AppendAllText(path, $"Error: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}\n");
    }

    public void LogInfo(string message)
    {
        File.AppendAllText(path, $"Info: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}\n");
    }

    public void LogWarning(string message)
    {
        File.AppendAllText(path, $"Warning: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")} {message}\n");
    }
}
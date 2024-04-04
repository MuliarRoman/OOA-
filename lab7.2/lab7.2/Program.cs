using System;

// Клас, що представляє задачу
public class Task
{
    public string Description { get; }

    public Task(string description)
    {
        Description = description;
    }
}

// Абстрактний обробник
public abstract class Handler
{
    protected Handler _nextHandler;

    public void SetNextHandler(Handler handler)
    {
        _nextHandler = handler;
    }

    public abstract void HandleTask(Task task);
}

// Конкретний обробник для редактора
public class Editor : Handler
{
    public override void HandleTask(Task task)
    {
        if (task.Description.Contains("внесення правок"))
        {
            Console.WriteLine($"Редактор вносить правки в задачу: {task.Description}");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleTask(task);
        }
    }
}

// Конкретний обробник для макетувальника
public class LayoutDesigner : Handler
{
    public override void HandleTask(Task task)
    {
        if (task.Description.Contains("оформлення макету"))
        {
            Console.WriteLine($"Макетувальник оформляє макет задачі: {task.Description}");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleTask(task);
        }
    }
}

// Конкретний обробник для дизайнера
public class Designer : Handler
{
    public override void HandleTask(Task task)
    {
        if (task.Description.Contains("створення дизайну"))
        {
            Console.WriteLine($"Дизайнер створює дизайн для задачі: {task.Description}");
        }
        else if (_nextHandler != null)
        {
            _nextHandler.HandleTask(task);
        }
    }
}

// Клас-клієнт
public class Client
{
    private Handler _handlerChain;

    public Client()
    {
        // Формуємо ланцюжок обробників
        _handlerChain = new Editor();
        Handler layoutDesigner = new LayoutDesigner();
        Handler designer = new Designer();

        _handlerChain.SetNextHandler(layoutDesigner);
        layoutDesigner.SetNextHandler(designer);
    }

    public void SendTaskToHandler(Task task)
    {
        _handlerChain.HandleTask(task);
    }
}


class Program
{
    static void Main(string[] args)
    {
        Client client = new Client();

        Task task1 = new Task("внесення правок до статті");
        Task task2 = new Task("оформлення макету журналу");
        Task task3 = new Task("створення дизайну обкладинки");

        client.SendTaskToHandler(task1);
        client.SendTaskToHandler(task2);
        client.SendTaskToHandler(task3);
    }
}

using System;
using System.Collections.Generic;

// Інтерфейс команди
public interface ICommand
{
    void Execute();
    void Undo();
}

// Команда додавання
public class AddCommand : ICommand
{
    private readonly Calculator calculator;
    private readonly int valueToAdd;

    public AddCommand(Calculator calculator, int valueToAdd)
    {
        this.calculator = calculator;
        this.valueToAdd = valueToAdd;
    }

    public void Execute()
    {
        calculator.Add(valueToAdd);
    }

    public void Undo()
    {
        calculator.Subtract(valueToAdd);
    }
}

// Команда віднімання
public class SubtractCommand : ICommand
{
    private readonly Calculator _calculator;
    private readonly int _valueToSubtract;

    public SubtractCommand(Calculator calculator, int valueToSubtract)
    {
        _calculator = calculator;
        _valueToSubtract = valueToSubtract;
    }

    public void Execute()
    {
        _calculator.Subtract(_valueToSubtract);
    }

    public void Undo()
    {
        _calculator.Add(_valueToSubtract);
    }
}

// Калькулятор
public class Calculator
{
    private int _currentValue;
    private readonly Stack<ICommand> _commands = new Stack<ICommand>();
    private readonly Stack<ICommand> _undoCommands = new Stack<ICommand>();

    public void ExecuteCommand(ICommand command)
    {
        command.Execute();
        _commands.Push(command);
        _undoCommands.Clear(); // При кожній новій команді очищаємо стек команд для відміни
    }

    public void Undo()
    {
        if (_commands.Count > 0)
        {
            ICommand command = _commands.Pop();
            command.Undo();
            _undoCommands.Push(command);
        }
    }

    public void Redo()
    {
        if (_undoCommands.Count > 0)
        {
            ICommand command = _undoCommands.Pop();
            command.Execute();
            _commands.Push(command);
        }
    }

    public void Add(int value)
    {
        _currentValue += value;
        Console.WriteLine($"Added {value}. Current value: {_currentValue}");
    }

    public void Subtract(int value)
    {
        _currentValue -= value;
        Console.WriteLine($"Subtracted {value}. Current value: {_currentValue}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Calculator calculator = new Calculator();

        // Виконуємо декілька команд
        calculator.ExecuteCommand(new AddCommand(calculator, 10));
        calculator.ExecuteCommand(new SubtractCommand(calculator, 5));
        calculator.ExecuteCommand(new AddCommand(calculator, 7));

        // Відміняємо одну команду
        calculator.Undo();

        // Повторюємо скасовану команду
        calculator.Redo();
    }
}

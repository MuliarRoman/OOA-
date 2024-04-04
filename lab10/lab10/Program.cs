using System;

// Базовий клас для представлення різних рас
public abstract class Race
{
    // Метод, який виконує загальні кроки алгоритму
    public void ExecuteStrategy()
    {
        BuildUnits();
        Attack();
        Defend();
    }

    // Абстрактні методи, які повинні бути реалізовані в підкласах
    protected abstract void BuildUnits();
    protected abstract void Attack();
    protected abstract void Defend();
}

// Конкретна реалізація для раси орків
public class OrcRace : Race
{
    protected override void BuildUnits()
    {
        Console.WriteLine("Орки будують агресивнi загони.");
    }

    protected override void Attack()
    {
        Console.WriteLine("Орки агресивно атакують.");
    }

    protected override void Defend()
    {
        Console.WriteLine("Орки пасивно захищаються.");
    }
}

// Конкретна реалізація для раси людей
public class HumanRace : Race
{
    protected override void BuildUnits()
    {
        Console.WriteLine("Люди будують збалансованi одиницi.");
    }

    protected override void Attack()
    {
        Console.WriteLine("Люди стратегiчно атакують.");
    }

    protected override void Defend()
    {
        Console.WriteLine("Люди активно захищаються.");
    }
}


class Program
{
    static void Main(string[] args)
    {
        Race orcRace = new OrcRace();
        Console.WriteLine("Стратегiя оркiв:");
        orcRace.ExecuteStrategy();

        Console.WriteLine();

        Race humanRace = new HumanRace();
        Console.WriteLine("Стратегiя людей:");
        humanRace.ExecuteStrategy();
    }
}

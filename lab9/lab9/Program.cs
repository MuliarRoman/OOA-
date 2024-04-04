using System;
using System.Collections.Generic;

// Клас, що представляє гравця
public class Player
{
    public string Name { get; private set; }

    public Player(string name)
    {
        Name = name;
    }

    public void Play()
    {
        Console.WriteLine($"{Name} у грі.");
    }

    public void Rest()
    {
        Console.WriteLine($"{Name} відпочиває.");
    }
}

// Спостерігач (менеджер)
public class Manager
{
    public void Substitute(Player tiredPlayer, Player substitutePlayer)
    {
        tiredPlayer.Rest();
        substitutePlayer.Play();
        Console.WriteLine($"Менеджер заміняє {tiredPlayer.Name} на {substitutePlayer.Name}");
    }
}

// Суб'єкт (гра баскетбольних команд)
public class BasketballGame
{
    private List<Player> _players = new List<Player>();
    private Manager _manager = new Manager();

    public void AddPlayer(Player player)
    {
        _players.Add(player);
    }

    public void PlayGame()
    {
        foreach (var player in _players)
        {
            player.Play();
        }

        // Припустимо, що гравець №2 втомився
        Player tiredPlayer = _players[1];
        // Створюємо запасного гравця
        Player substitutePlayer = new Player("Player999");

        _manager.Substitute(tiredPlayer, substitutePlayer);
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        Player player1 = new Player("Player1");
        Player player2 = new Player("Player2");
        Player player3 = new Player("Player3");

        BasketballGame game = new BasketballGame();
        game.AddPlayer(player1);
        game.AddPlayer(player2);
        game.AddPlayer(player3);

        game.PlayGame();
    }
}

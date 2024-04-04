using System;
using System.Collections.Generic;

// Абстрактний клас для Медіатора
public abstract class ChatMediator
{
    public abstract void SendMessage(string sender, string receiver, string message);
}

// Клас для представлення учасника чату
public class Participant
{
    public string Name { get; }

    private ChatMediator _mediator;

    public Participant(string name, ChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void SendMessage(string receiver, string message)
    {
        Console.WriteLine($"{Name} надсилає повідомлення {receiver}: {message}");
        _mediator.SendMessage(Name, receiver, message);
    }

    public void ReceiveMessage(string sender, string message)
    {
        Console.WriteLine($"{Name} отримує повідомлення від {sender}: {message}");
    }
}

// Конкретний Медіатор для чату
public class ConcreteChatMediator : ChatMediator
{
    private Dictionary<string, Participant> _participants = new Dictionary<string, Participant>();

    public override void SendMessage(string sender, string receiver, string message)
    {
        if (_participants.ContainsKey(receiver))
        {
            _participants[receiver].ReceiveMessage(sender, message);
        }
        else
        {
            Console.WriteLine($"Учасник {receiver} не в чаті.");
        }
    }

    public void AddParticipant(Participant participant)
    {
        _participants[participant.Name] = participant;
    }
}

// Тестування
class Program
{
    static void Main(string[] args)
    {
        ChatMediator mediator = new ConcreteChatMediator();

        Participant participant1 = new Participant("Іван", mediator);
        Participant participant2 = new Participant("Петро", mediator);
        Participant participant3 = new Participant("Тарас", mediator);

        (mediator as ConcreteChatMediator)?.AddParticipant(participant1);
        (mediator as ConcreteChatMediator)?.AddParticipant(participant2);
        (mediator as ConcreteChatMediator)?.AddParticipant(participant3);

        participant1.SendMessage("Іван", "Привіт, Іван!");
        participant2.SendMessage("Петро", "Привіт, Петро!");
        participant3.SendMessage("Тарас", "Привіт, Тарас!");
    }
}

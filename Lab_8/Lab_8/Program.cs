using System;
using System.Collections;

// Клас, що представляє запис телефонної книги
public class Contact
{
    public string Name { get; set; }
    public string PhoneNumber { get; set; }

    public Contact(string name, string phoneNumber)
    {
        Name = name;
        PhoneNumber = phoneNumber;
    }

    public override string ToString()
    {
        return $"{Name}: {PhoneNumber}";
    }
}

// Клас, що представляє вузол двозв'язного списку
public class Node
{
    public Contact Data { get; set; }
    public Node Next { get; set; }
    public Node Previous { get; set; }

    public Node(Contact contact)
    {
        Data = contact;
        Next = null;
        Previous = null;
    }
}

// Клас, що представляє двозв'язний список
public class DoublyLinkedList : IEnumerable<Contact>
{
    private Node _head;
    private Node _tail;

    public void Add(Contact contact)
    {
        Node newNode = new Node(contact);

        if (_head == null)
        {
            _head = newNode;
            _tail = newNode;
        }
        else
        {
            _tail.Next = newNode;
            newNode.Previous = _tail;
            _tail = newNode;
        }
    }

    public IEnumerator<Contact> GetEnumerator()
    {
        Node current = _head;
        while (current != null)
        {
            yield return current.Data;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}

// Клас-ітератор для обходу двозв'язного списку
public class DoublyLinkedListIterator : IEnumerator<Contact>
{
    private Node _current;

    public DoublyLinkedListIterator(Node head)
    {
        _current = new Node(null);
        _current.Next = head;
    }

    public Contact Current
    {
        get { return _current.Data; }
    }

    object IEnumerator.Current => Current;

    public bool MoveNext()
    {
        if (_current.Next == null)
            return false;

        _current = _current.Next;
        return true;
    }

    public void Reset()
    {
        _current = null;
    }

    public void Dispose()
    {
        // Implement IDisposable if needed
    }
}


class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList phoneBook = new DoublyLinkedList();

        phoneBook.Add(new Contact("Іван", "1234567890"));
        phoneBook.Add(new Contact("Петро", "0987654321"));
        phoneBook.Add(new Contact("Тарас", "9876543210"));

        Console.WriteLine("Контакти:");
        foreach (var contact in phoneBook)
        {
            Console.WriteLine(contact);
        }
    }
}

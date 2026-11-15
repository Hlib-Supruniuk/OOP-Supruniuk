using System;
using System.Collections.Generic;

public class MessageManager
{
    private HashSet<string> recipients = new HashSet<string>();
    private Queue<Message> messageQueue = new Queue<Message>();
    private Stack<Message> sentHistory = new Stack<Message>();

    public void AddRecipient(string recipient)
    {
        if (recipients.Add(recipient))
        {
            Console.WriteLine($"Одержувача {recipient} додано");
        }
        else
        {
            Console.WriteLine($"Одержувач {recipient} вже існує");
        }
    }

    public void RemoveRecipient(string recipient)
    {
        if (recipients.Remove(recipient))
        {
            Console.WriteLine($"Одержувача {recipient} видалено");
        }
        else
        {
            Console.WriteLine($"Одержувача {recipient} не знайдено");
        }
    }

    public bool HasRecipient(string recipient)
    {
        return recipients.Contains(recipient);
    }

    public void AddMessage(Message message)
    {
        if (recipients.Contains(message.Recipient))
        {
            messageQueue.Enqueue(message);
            Console.WriteLine($"Повідомлення для {message.Recipient} додано до черги");
        }
        else
        {
            Console.WriteLine($"Одержувача {message.Recipient} немає у списку");
        }
    }

    public void SendMessages()
    {
        while (messageQueue.Count > 0)
        {
            Message message = messageQueue.Dequeue();
            Console.WriteLine($"Надіслано: {message}");

            sentHistory.Push(message);
        }
    }

    public void ShowNextMessage()
    {
        if (messageQueue.Count > 0)
        {
            Console.WriteLine($"Наступне повідомлення: {messageQueue.Peek()}");
        }
        else
        {
            Console.WriteLine("Черга повідомлень порожня");
        }
    }

    public void ShowLastSentMessage()
    {
        if (sentHistory.Count > 0)
        {
            Console.WriteLine($"Останнє надіслане повідомлення: {sentHistory.Peek()}");
        }
        else
        {
            Console.WriteLine("Історія повідомлень порожня");
        }
    }

    public void UndoLastSentMessage()
    {
        if (sentHistory.Count > 0)
        {
            Message message = sentHistory.Pop();
            Console.WriteLine($"Видалено з історії: {message}");
        }
        else
        {
            Console.WriteLine("Історія повідомлень порожня");
        }
    }
}
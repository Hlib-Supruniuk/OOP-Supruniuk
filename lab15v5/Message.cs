public class Message
{
    public string Recipient { get; set; }
    public string Text { get; set; }

    public Message(string recipient, string text)
    {
        Recipient = recipient;
        Text = text;
    }

    public override string ToString()
    {
        return $"Одержувач: {Recipient}, повідомлення: {Text}";
    }
}
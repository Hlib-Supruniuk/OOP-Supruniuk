using System;

MessageManager manager = new MessageManager();

Console.WriteLine("=== СИСТЕМА ПОВІДОМЛЕНЬ ===");

Console.WriteLine("\n=== СПИСОК ОДЕРЖУВАЧІВ ===");

manager.AddRecipient("Андрій");
manager.AddRecipient("Марія");
manager.AddRecipient("Олег");
manager.AddRecipient("Андрій");

Console.WriteLine($"Чи існує Марія? {manager.HasRecipient("Марія")}");

manager.RemoveRecipient("Олег");

Console.WriteLine("\n=== ЧЕРГА ПОВІДОМЛЕНЬ ===");

manager.AddMessage(new Message("Андрій", "Привіт!"));
manager.AddMessage(new Message("Марія", "Як справи?"));
manager.AddMessage(new Message("Андрій", "До зустрічі!"));

manager.ShowNextMessage();

Console.WriteLine("\n=== ВІДПРАВЛЕННЯ ПОВІДОМЛЕНЬ ===");

manager.SendMessages();

Console.WriteLine("\n=== ІСТОРІЯ ПОВІДОМЛЕНЬ ===");

manager.ShowLastSentMessage();

Console.WriteLine("\n=== СКАСУВАННЯ ОСТАННЬОЇ ОПЕРАЦІЇ ===");

manager.UndoLastSentMessage();

manager.ShowLastSentMessage();

Console.WriteLine("\n=== КІНЕЦЬ ПРОГРАМИ ===");
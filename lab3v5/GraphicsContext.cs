
using System;

public class GraphicsContext : IDisposable
{
    private readonly int _contextId;
    private bool _isContextCreated;
    private bool _disposed;

    public int ContextId => _contextId;
    public bool IsContextCreated => _isContextCreated;

    public GraphicsContext(int contextId)
    {
        _contextId = contextId;
        _isContextCreated = true;

        Console.WriteLine($"Графічний контекст {_contextId} створено.");
    }

    public void DrawShape(string shape)
    {
        if (_disposed)
            throw new ObjectDisposedException(nameof(GraphicsContext));

        if (!_isContextCreated)
        {
            Console.WriteLine("Неможливо малювати: контекст знищено.");
            return;
        }

        Console.WriteLine($"Малюємо фігуру «{shape}» у контексті {_contextId}.");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
            return;

        if (disposing)
        {
            // Звільнення керованих ресурсів.
        }

        if (_isContextCreated)
        {
            Console.WriteLine($"Графічний контекст {_contextId} знищено.");
            _isContextCreated = false;
        }

        _disposed = true;
    }

    ~GraphicsContext()
    {
        Dispose(false);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

public class InMemoryRepository<T> : IRepository<T>
    where T : IEntity
{
    private readonly List<T> _items = new List<T>();

    public T? GetById(int id)
    {
        return _items.FirstOrDefault(item => item.Id == id);
    }

    public IEnumerable<T> GetAll()
    {
        return _items;
    }

    public void Add(T item)
    {
        _items.Add(item);
    }

    public void Update(T item)
    {
        int index = _items.FindIndex(existing => existing.Id == item.Id);

        if (index == -1)
            throw new InvalidOperationException("Елемент не знайдено.");

        _items[index] = item;
    }

    public void Delete(int id)
    {
        T? item = GetById(id);

        if (item == null)
            throw new InvalidOperationException("Елемент не знайдено.");

        _items.Remove(item);
    }
}
using System;

public class MyStack<T>
{
    private T[] _items;
    private int _count;

    public MyStack()
    {
        _items = new T[0];
        _count = 0;
    }

    public int Count
    {
        get { return _count; }
    }

    public T Pop()
    {
        if (_count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }

        T item = _items[_count - 1];
        _count--;

        return item;
    }

    public void Push(T item)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _count == 0 ? 4 : _count * 2);
        }

        _items[_count] = item;
        _count++;
    }
}
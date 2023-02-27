using System;

public class MyList<T>
{
    private T[] _items;
    private int _count;

    public MyList()
    {
        _items = new T[0];
        _count = 0;
    }

    public void Add(T element)
    {
        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _count == 0 ? 4 : _count * 2);
        }

        _items[_count] = element;
        _count++;
    }

    public T Remove(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        T item = _items[index];

        for (int i = index; i < _count - 1; i++)
        {
            _items[i] = _items[i + 1];
        }

        _count--;
        _items[_count] = default(T);

        return item;
    }

    public bool Contains(T element)
    {
        for (int i = 0; i < _count; i++)
        {
            if (_items[i].Equals(element))
            {
                return true;
            }
        }

        return false;
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _count);
        _count = 0;
    }

    public void InsertAt(T element, int index)
    {
        if (index < 0 || index > _count)
        {
            throw new IndexOutOfRangeException();
        }

        if (_count == _items.Length)
        {
            Array.Resize(ref _items, _count == 0 ? 4 : _count * 2);
        }

        for (int i = _count; i > index; i--)
        {
            _items[i] = _items[i - 1];
        }

        _items[index] = element;
        _count++;
    }

    public void DeleteAt(int index)
    {
        Remove(index);
    }

    public T Find(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new IndexOutOfRangeException();
        }

        return _items[index];
    }
}
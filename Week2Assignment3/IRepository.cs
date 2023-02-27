using System;
using System.Collections.Generic;

/// <summary>
/// The IRepository interface defines the common CRUD operations that a data source can perform on entities of type T.
/// </summary>
/// <typeparam name="T"></typeparam>
public interface IRepository<T> where T : class, IEntity
{
    void Add(T item);
    void Remove(T item);
    void Save();
    IEnumerable<T> GetAll();
    T GetById(int id);
}

/// <summary>
/// The IEntity interface defines the basic properties of an entity that can be stored in a data source.
/// </summary>
public interface IEntity
{
    int Id { get; set; }
}

/// <summary>
/// The GenericRepository class implements the IRepository interface and can work with any data source that supports the necessary operations.
/// </summary>
/// <typeparam name="T"></typeparam>
public class GenericRepository<T> : IRepository<T> where T : class, IEntity
{
    private List<T> items;

    public GenericRepository()
    {
        items = new List<T>();
    }

    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public void Save()
    {
        // Perform any necessary operations to save the entities to the data source.
        Console.WriteLine("Entities saved to data source.");
    }

    public IEnumerable<T> GetAll()
    {
        return items;
    }

    public T GetById(int id)
    {
        return items.Find(item => item.Id == id);
    }
}
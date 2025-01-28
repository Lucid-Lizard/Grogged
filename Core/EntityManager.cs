using Grogged.Core;
using System.Collections.Generic;
using System;
using System.ComponentModel;
using System.Linq;

public class EntityManager
{
    private int nextEntityId = 0;
    private Dictionary<Type, Dictionary<int, object>> components = new();

    public int CreateEntity<T>() where T : Prefab, new()
    {
        int entityId = nextEntityId++;
        var prefab = new T();
        prefab.Configure(this, entityId); // Configure the entity with the prefab
        return entityId;
    }

    public void AddComponent<T>(int entityId, T component) where T : struct
    {
        if (!components.ContainsKey(typeof(T)))
        {
            components[typeof(T)] = new Dictionary<int, object>();
        }
        components[typeof(T)][entityId] = component;
    }

    public void RemoveComponent<T>(int entityId) where T : struct
    {
        components[typeof(T)].Remove(entityId);
    }
    public T GetComponent<T>(int entityId) where T : class
    {
        if (components.TryGetValue(typeof(T), out var entityComponents) &&
            entityComponents.TryGetValue(entityId, out var component))
        {
            return component as T;
        }

        return null;
    }

    public IEnumerable<(int entityId, T component)> GetAllComponents<T>() where T : struct
    {
        if (components.TryGetValue(typeof(T), out var entityComponents))
        {
            foreach (var kvp in entityComponents)
            {
                if (kvp.Value is T component)
                {
                    yield return (kvp.Key, component);
                }
            }
        }
    }

}

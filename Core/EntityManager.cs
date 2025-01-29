using System;
using System.Collections.Generic;

public class EntityManager
{
    private int nextEntityId = 0;
    private Dictionary<Type, object> components = new();

    private Dictionary<int, T> GetComponentDictionary<T>() where T : struct
    {
        if (!components.ContainsKey(typeof(T)))
        {
            components[typeof(T)] = new Dictionary<int, T>();
        }
        return (Dictionary<int, T>)components[typeof(T)];
    }

    public int CreateEntity<T>() where T : Prefab, new()
    {
        int entityId = nextEntityId++;
        var prefab = new T();
        prefab.Configure(this, entityId);
        return entityId;
    }

    public void AddComponent<T>(int entityId, T component) where T : struct
    {
        var componentDict = GetComponentDictionary<T>();
        componentDict[entityId] = component;
    }

    public void RemoveComponent<T>(int entityId) where T : struct
    {
        if (components.TryGetValue(typeof(T), out var dict))
        {
            ((Dictionary<int, T>)dict).Remove(entityId);
        }
    }

    public bool TryGetComponent<T>(int entityId, out T component) where T : struct
    {
        component = default;
        if (components.TryGetValue(typeof(T), out var dict))
        {
            var typedDict = (Dictionary<int, T>)dict;
            return typedDict.TryGetValue(entityId, out component);
        }
        return false;
    }

    public T GetComponent<T>(int entityId) where T : struct
    {
        if (TryGetComponent<T>(entityId, out var component))
        {
            return component;
        }
        throw new KeyNotFoundException($"No component of type {typeof(T)} found for entity {entityId}");
    }

    public IEnumerable<(int entityId, T component)> GetAllComponents<T>() where T : struct
    {
        if (components.TryGetValue(typeof(T), out var dict))
        {
            var typedDict = (Dictionary<int, T>)dict;
            foreach (var kvp in typedDict)
            {
                yield return (kvp.Key, kvp.Value);
            }
        }
    }
}
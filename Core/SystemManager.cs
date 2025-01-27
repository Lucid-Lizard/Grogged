using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Grogged.Core
{
    public class SystemManager
    {
        private readonly List<SystemBase> _systems = new();

        public void AddSystem(SystemBase system)
        {
            _systems.Add(system);
        }

        public void Update(EntityManager componentManager, float deltaTime)
        {
            foreach (SystemBase system in _systems)
            {
                system.Update(componentManager, deltaTime);
            }
        }

        public void LoadAllSystems()
        {
            var systemTypes = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.IsSubclassOf(typeof(SystemBase)) && !t.IsAbstract);

            foreach (var type in systemTypes)
            {
                if (Activator.CreateInstance(type) is SystemBase system)
                {
                    _systems.Add(system);
                }
            }
        }
    }
}

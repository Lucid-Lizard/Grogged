using System;
using System.Collections.Generic;

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
    }
}

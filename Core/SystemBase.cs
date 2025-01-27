using System;

namespace Grogged.Core
{
    public abstract class SystemBase
    {
        /// <summary>
        /// Override to create a system that updates components. Provides a deltaTime variable for calculations
        /// </summary>
        /// <param name="componentManager"></param>
        /// <param name="deltaTime"></param>
        public abstract void Update(EntityManager componentManager, float deltaTime);
    }
}

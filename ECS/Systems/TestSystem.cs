using Grogged.Core;
using Grogged.ECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.ECS.Systems
{
    public class TestSystem : SystemBase
    {
        public override void Update(EntityManager componentManager, float deltaTime)
        {
            foreach(var kvp in componentManager.GetAllComponents<SpriteComponent>())
            {
                kvp.entityId.Component<SpriteComponent>().color.R += 1;
            }
        }
    }
}

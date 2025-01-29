using Grogged.Core;
using Grogged.ECS.Components;

namespace Grogged.ECS.Systems
{
    public class TestSystem : SystemBase
    {
        public override void Update(EntityManager componentManager, float deltaTime)
        {
            foreach(var kvp in componentManager.GetAllComponents<SpriteComponent>())
            {
                var spriteComp = kvp.entityId.Component<SpriteComponent>();
                spriteComp.color.R += 1;
            }
        }
    }
}

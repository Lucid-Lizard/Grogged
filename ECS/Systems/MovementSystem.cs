using Grogged.Core;
using Grogged.ECS.Components;

public class MovementSystem : SystemBase
{
    public override void Update(EntityManager componentManager, float deltaTime)
    {
        foreach (var kvp in componentManager.GetAllComponents<PositionComponent>())
        {
            int entityId = kvp.entityId;
            PositionComponent position = kvp.component;
            var velocity = componentManager.GetComponent<VelocityComponent>(entityId);
            if (velocity != null)
            {
                position.X += velocity.X * deltaTime;
                position.Y += velocity.Y * deltaTime;
            }
        }
    }
}

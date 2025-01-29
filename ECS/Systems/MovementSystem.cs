using Grogged.Core;
using Grogged.ECS.Components;

public class MovementSystem : SystemBase
{
    public override void Update(EntityManager componentManager, float deltaTime)
    {
        foreach (var kvp in componentManager.GetAllComponents<PositionComponent>())
        {
            int entityId = kvp.entityId;
            var position = kvp.component;
            var velocity = componentManager.GetComponent<VelocityComponent>(entityId);

            position.X += velocity.X * deltaTime;
            position.Y += velocity.Y * deltaTime;

            componentManager.AddComponent(entityId, position);
        }
    }
}
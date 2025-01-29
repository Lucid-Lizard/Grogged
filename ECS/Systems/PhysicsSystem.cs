using Grogged.Core;
using Grogged.ECS.Components;
using Microsoft.Xna.Framework;

public class PhysicsSystem : SystemBase
{
    public override void Update(EntityManager componentManager, float deltaTime)
    {
        foreach (var kvp in componentManager.GetAllComponents<PhysicsComponent>())
        {
            var entityId = kvp.entityId;
            var physics = kvp.component;
            var velocity = componentManager.GetComponent<VelocityComponent>(entityId);

            velocity.X *= physics.Friction;
            velocity.Y *= physics.Friction;
            velocity.X = MathHelper.Clamp(velocity.X, -physics.MaxmiumVelocity, physics.MaxmiumVelocity);
            velocity.Y = MathHelper.Clamp(velocity.Y, -physics.MaxmiumVelocity, physics.MaxmiumVelocity);

            componentManager.AddComponent(entityId, velocity);
        }
    }
}
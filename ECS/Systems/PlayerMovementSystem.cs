using Grogged.Core;
using Grogged.ECS.Components;
using Grogged.Prefebs;
using Microsoft.Xna.Framework.Input;
using System.Linq;

public class PlayerMovementSystem : SystemBase
{
    public KeyboardState currentKeyboard;
    public KeyboardState previousKeyboard;

    public override void Update(EntityManager componentManager, float deltaTime)
    {
        currentKeyboard = Keyboard.GetState();
        foreach (var kvp in componentManager.GetAllComponents<TypeComponent>().Where(p => p.component.Type == PlayerPrefab.Type))
        {
            var entityId = kvp.entityId;
            var velocity = componentManager.GetComponent<VelocityComponent>(entityId);

            if (currentKeyboard.IsKeyDown(Keys.W)) velocity.Y -= 40;
            if (currentKeyboard.IsKeyDown(Keys.S)) velocity.Y += 40;
            if (currentKeyboard.IsKeyDown(Keys.A)) velocity.X -= 40;
            if (currentKeyboard.IsKeyDown(Keys.D)) velocity.X += 40;

            componentManager.AddComponent(entityId, velocity);
        }
        previousKeyboard = currentKeyboard;
    }
}
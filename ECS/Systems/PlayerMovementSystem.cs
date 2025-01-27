using Grogged.Core;
using Grogged.ECS.Components;
using Grogged.Prefebs;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.ECS.Systems
{
    public class PlayerMovementSystem : SystemBase
    {
        public KeyboardState currentKeyboard;
        public KeyboardState previousKeyboard;
        public override void Update(EntityManager componentManager, float deltaTime)
        {
            currentKeyboard = Keyboard.GetState();
            foreach (var idk in componentManager.GetAllComponents<TypeComponent>().Where(P => P.component.Type == PlayerPrefab.Type))
            {
                var velocity = componentManager.GetComponent<VelocityComponent>(idk.entityId);

                if (currentKeyboard.IsKeyDown(Keys.W)) velocity.Y -= 5;
                if (currentKeyboard.IsKeyDown(Keys.S)) velocity.Y += 5;
                if (currentKeyboard.IsKeyDown(Keys.A)) velocity.X -= 5;
                if (currentKeyboard.IsKeyDown(Keys.D)) velocity.X += 5;

                
                
            }
            previousKeyboard = currentKeyboard;
        }
    }
}

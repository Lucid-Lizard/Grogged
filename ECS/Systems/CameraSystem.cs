using Grogged.Core;
using Grogged.ECS.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.ECS.Systems
{
    public class CameraSystem : SystemBase
    {
        private const float LerpFactor = 5.0f; // Adjust for smoother or snappier movement

        public override void Update(EntityManager componentManager, float deltaTime)
        {
            foreach (var kvp in componentManager.GetAllComponents<CameraComponent>())
            {
                var cameraComponent = kvp.component;
                var cameraEntityId = kvp.entityId;

                var targetPosition = componentManager.GetComponent<PositionComponent>(cameraComponent.EntityTarget);
                var camPos = componentManager.GetComponent<PositionComponent>(cameraEntityId);

                
                 camPos.X += (targetPosition.X - camPos.X) * LerpFactor * deltaTime;
                 camPos.Y += (targetPosition.Y - camPos.Y) * LerpFactor * deltaTime;

                 
                 componentManager.AddComponent(cameraEntityId, camPos);
                
            }
        }
    }
}
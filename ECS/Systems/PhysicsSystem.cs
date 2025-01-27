using Grogged.Core;
using Grogged.ECS.Components;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grogged.ECS.Systems
{
    public class PhysicsSystem : SystemBase
    {
        public override void Update(EntityManager componentManager, float deltaTime)
        {
            foreach(var kvp in componentManager.GetAllComponents<PhysicsComponent>())
            {
                if(componentManager.GetComponent<VelocityComponent>(kvp.entityId) != null)
                {
                    componentManager.GetComponent<VelocityComponent>(kvp.entityId).X *= kvp.component.Friction;
                    componentManager.GetComponent<VelocityComponent>(kvp.entityId).Y *= kvp.component.Friction;
                    componentManager.GetComponent<VelocityComponent>(kvp.entityId).X =
                        MathHelper.Clamp(componentManager.GetComponent<VelocityComponent>(kvp.entityId).X,
                        -kvp.component.MaxmiumVelocity,
                        kvp.component.MaxmiumVelocity);
                    componentManager.GetComponent<VelocityComponent>(kvp.entityId).Y =
                        MathHelper.Clamp(componentManager.GetComponent<VelocityComponent>(kvp.entityId).Y,
                        -kvp.component.MaxmiumVelocity,
                        kvp.component.MaxmiumVelocity);
                }
            }
        }
    }
}

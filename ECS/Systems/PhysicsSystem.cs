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
                var VelComp = componentManager.GetComponent<VelocityComponent>(kvp.entityId);


                    VelComp.X *= kvp.component.Friction;
                VelComp.Y *= kvp.component.Friction;
                    VelComp.X =
                        MathHelper.Clamp(VelComp.X,
                        -kvp.component.MaxmiumVelocity,
                        kvp.component.MaxmiumVelocity);
                    VelComp.Y =
                        MathHelper.Clamp(VelComp.Y,
                        -kvp.component.MaxmiumVelocity,
                        kvp.component.MaxmiumVelocity);
                
            }
        }
    }
}

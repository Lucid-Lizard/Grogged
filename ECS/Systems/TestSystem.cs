using Grogged.Core;
using Grogged.ECS.Components;
using Grogged.Prefebs;
using Microsoft.Xna.Framework;
using System.Linq;

namespace Grogged.ECS.Systems
{
    public class TestSystem : SystemBase
    {
        float hue = 0f;

        public override void Update(EntityManager componentManager, float deltaTime)
        {
            foreach (var kvp in componentManager.GetAllComponents<TypeComponent>().Where(p => p.component.Type == PlayerPrefab.Type))
            {
                var spriteComp = componentManager.GetComponent<SpriteComponent>(kvp.entityId);
                hue = (hue + deltaTime) % 1f;
                spriteComp.color = HSVToRGB(hue, 1f, 1f);
                componentManager.AddComponent(kvp.entityId, spriteComp);
            }
        }

        private Color HSVToRGB(float h, float s, float v)
        {
            int hi = (int)(h * 6);
            float f = h * 6 - hi;
            float p = v * (1 - s);
            float q = v * (1 - f * s);
            float t = v * (1 - (1 - f) * s);

            float r, g, b;
            switch (hi)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                default: r = v; g = p; b = q; break;
            }

            return new Color(r, g, b);
        }
    }
}
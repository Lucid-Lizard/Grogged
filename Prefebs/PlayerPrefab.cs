using Grogged.ECS.Components;
using System;
using Microsoft.Xna.Framework;
using Grogged.ECS.Systems;


namespace Grogged.Prefebs
{
    public class PlayerPrefab : Dummy
    {
        public static string Type;
        public override void Configure(EntityManager entityManager, int entityId)
        {
            base.Configure(entityManager, entityId);

            entityManager.AddComponent<SpriteComponent>(entityId, new()
            {
                texturePath = "playerSprite",
                sourceRect = new Rectangle(0, 0, 32, 64),
                color = Color.Blue
            });

            entityManager.AddComponent<PhysicsComponent>(entityId, new() { Friction = 0.97f });

            entityManager.AddComponent<TypeComponent>(entityId, new() { Type = Type });
        }
    }
}

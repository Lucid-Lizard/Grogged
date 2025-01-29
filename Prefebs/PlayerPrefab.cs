using Grogged.ECS.Components;
using System;
using Microsoft.Xna.Framework;
using Grogged.ECS.Systems;


namespace Grogged.Prefebs
{
    public class PlayerPrefab : Dummy
    {
        public static string Type = "Player";
        public override void Configure(EntityManager entityManager, int entityId)
        {
            base.Configure(entityManager, entityId);


            entityManager.AddComponent<SpriteComponent>(entityId, SpriteComponent.Create(
                null,
                new(0, 0, 32, 64),
                Color.Blue,
                1f,
                0f,
                "PlayerSprite"
                ));

            entityManager.AddComponent<PhysicsComponent>(entityId, PhysicsComponent.Create(
                0.85f,
                200
                ));
            

            entityManager.AddComponent<TypeComponent>(entityId, TypeComponent.Create(Type));
        }
    }
}

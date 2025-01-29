using Grogged.ECS.Components;

namespace Grogged.Prefebs
{
    public class CameraPrefab : Prefab
    {
        public override void Configure(EntityManager entityManager, int entityId)
        {
            entityManager.AddComponent<CameraComponent>(entityId, CameraComponent.Create());

            entityManager.AddComponent<TypeComponent>(entityId, TypeComponent.Create("Camera"));

            entityManager.AddComponent<PositionComponent>(entityId, PositionComponent.Create(0, 0));

            entityManager.AddComponent<VelocityComponent>(entityId, VelocityComponent.Create(0, 0));
        }
    }
}

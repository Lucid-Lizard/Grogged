namespace Grogged.ECS.Components
{
    public struct PhysicsComponent
    {
        public float Friction;
        public float MaxmiumVelocity;

        public static PhysicsComponent Create(float friction, float maxVelocity)
        {
            return new PhysicsComponent
            {
                Friction = friction,
                MaxmiumVelocity = maxVelocity
            };
        }
    }
}

namespace Grogged.ECS.Components
{
    public struct VelocityComponent
    {
        public float X { get; set; }
        public float Y { get; set; }

        public static VelocityComponent Create(float x, float y)
        {
            return new VelocityComponent
            {
                X = x,
                Y = y
            };
        }
    }
}
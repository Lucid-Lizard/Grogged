namespace Grogged.ECS.Components
{
    public struct PositionComponent
    {
        public float X { get; set; }
        public float Y { get; set; }

        public static PositionComponent Create(float x, float y)
        {
            return new PositionComponent
            {
                X = x,
                Y = y
            };
        }
    }
}
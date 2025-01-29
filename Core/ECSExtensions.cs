namespace Grogged.Core
{
    public static class ECSExtensions
    {
        public static T Component<T>(this int ID) where T : struct
        {
            return Game1._ecsCoordinator._EntityManager.GetComponent<T>(ID);
        }
    }
}
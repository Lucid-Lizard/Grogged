using Grogged.Core;

public class ECSCoordinator
{
    public EntityManager _EntityManager { get; private set; }
    public SystemManager _SystemManager { get; private set; }

    public ECSCoordinator()
    {
        _EntityManager = new EntityManager();
        _SystemManager = new SystemManager();
    }

    public void Update(float deltaTime)
    {
        _SystemManager.Update(_EntityManager, deltaTime);
    }
}

namespace WiB.Ecs
{
    public interface ISystem
    {
        void Start(World world);
        void Update();
    }
}
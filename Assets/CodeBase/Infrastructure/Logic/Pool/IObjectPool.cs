namespace CodeBase.Infrastructure.Logic.Pool
{
    public interface IObjectPool
    {
        void Enable();
        void Disable();
        bool IsReady();
    }
}
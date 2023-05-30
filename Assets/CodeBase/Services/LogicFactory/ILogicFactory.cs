using CodeBase.Infrastructure.Logic.Pool;

namespace CodeBase.Services.LogicFactory
{
    public interface ILogicFactory : IService
    {
        BulletObjectPool CreateBulletObjectPool();
    }
}
using CodeBase.Logic.Pool;
using CodeBase.StaticData.Levels;
using CodeBase.Tower;

namespace CodeBase.Services.LogicFactory
{
    public interface ILogicFactory : IService
    {
        BulletPoolHandlerHandler CreateBulletObjectPool();
        TowerBuilder TowerBuilder { get; }
        void Cleanup();
        void InitializeTowerBuilder(LevelConfig levelConfig);
    }
}
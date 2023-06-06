using CodeBase.Logic.Pool;
using CodeBase.StaticData.Levels;

namespace CodeBase.Services.LogicFactory
{
    public interface ILogicFactory : IService
    {
        BulletPoolHandler CreateBulletObjectPool();

        void Cleanup();

        LevelBuilder.LevelBuilder LevelBuilder { get; }

        void InitializeLevelBuilder(LevelConfig levelConfig);
    }
}
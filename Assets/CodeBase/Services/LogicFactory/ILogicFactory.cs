using CodeBase.Let;
using CodeBase.Logic.Pool;
using CodeBase.StaticData.Levels;
using CodeBase.Tower;

namespace CodeBase.Services.LogicFactory
{
    public interface ILogicFactory : IService
    {
        BulletPoolHandlerHandler CreateBulletObjectPool();
        TowerBuilder TowerBuilder { get; }
        LetBuilder LetBuilder { get; }
        void Cleanup();
        void InitializeTowerBuilder(LevelConfig levelConfig);
        void InitializeLetBuilder(LevelConfig levelConfig);
    }
}
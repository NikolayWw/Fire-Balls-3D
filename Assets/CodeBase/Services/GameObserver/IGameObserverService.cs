using System;

namespace CodeBase.Services.GameObserver
{
    public interface IGameObserverService : IService
    {
        Action OnStartTowerBuild { get; set; }
        Action OnEndTowerBuild { get; set; }
        Action OnTowerDestroyed { get; set; }

        void Cleanup();

        void SendStartTowerBuild();

        void SendEndTowerBuild();

        void SendTowerDestroyed();
    }
}
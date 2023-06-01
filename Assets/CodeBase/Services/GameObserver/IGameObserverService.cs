using System;

namespace CodeBase.Services.GameObserver
{
    public interface IGameObserverService : IService
    {
        Action OnEndTowerBuild { get; set; }
        Action OnTowerDestroyed { get; set; }
        Action OnLevelCompleted { get; set; }
        Action OnPlayerFinishedMove { get; set; }

        void Cleanup();

        void SendEndTowerBuild();

        void SendTowerDestroyed();

        void SendLevelCompleted();

        void SendPlayerFinishedMove();
    }
}
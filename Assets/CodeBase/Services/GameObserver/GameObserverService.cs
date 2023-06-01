using System;

namespace CodeBase.Services.GameObserver
{
    public class GameObserverService : IGameObserverService
    {
        public Action OnEndTowerBuild { get; set; }
        public Action OnTowerDestroyed { get; set; }
        public Action OnLevelCompleted { get; set; }
        public Action OnPlayerFinishedMove { get; set; }

        public void Cleanup()
        {
            OnEndTowerBuild = null;
            OnEndTowerBuild = null;
            OnTowerDestroyed = null;
            OnLevelCompleted = null;
        }

        public void SendEndTowerBuild() =>
            OnEndTowerBuild?.Invoke();

        public void SendTowerDestroyed() =>
            OnTowerDestroyed?.Invoke();

        public void SendLevelCompleted() =>
            OnLevelCompleted?.Invoke();

        public void SendPlayerFinishedMove() =>
            OnPlayerFinishedMove?.Invoke();
    }
}
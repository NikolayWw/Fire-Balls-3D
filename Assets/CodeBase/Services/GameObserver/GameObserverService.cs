using System;

namespace CodeBase.Services.GameObserver
{
    public class GameObserverService : IGameObserverService
    {
        public Action OnEndTowerBuild { get; set; }
        public Action OnTowerDestroyed { get; set; }
        public Action OnGameEnd { get; set; }
        public Action OnPlayerFinishedMove { get; set; }

        public void Cleanup()
        {
            OnEndTowerBuild = null;
            OnEndTowerBuild = null;
            OnTowerDestroyed = null;
            OnGameEnd = null;
        }

        public void SendEndTowerBuild() =>
            OnEndTowerBuild?.Invoke();

        public void SendTowerDestroyed() =>
            OnTowerDestroyed?.Invoke();

        public void SendEndGame() =>
            OnGameEnd?.Invoke();

        public void SendPlayerFinishedMove() =>
            OnPlayerFinishedMove?.Invoke();
    }
}
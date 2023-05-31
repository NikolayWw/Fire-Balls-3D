using System;

namespace CodeBase.Services.GameObserver
{
    public class GameObserverService : IGameObserverService
    {
        public Action OnStartTowerBuild { get; set; }
        public Action OnEndTowerBuild { get; set; }
        public Action OnTowerDestroyed { get; set; }
        public Action OnGameEnd { get; set; }

        public void Cleanup()
        {
            OnEndTowerBuild = null;
            OnEndTowerBuild = null;
            OnTowerDestroyed = null;
            OnGameEnd = null;
        }

        public void SendStartTowerBuild() =>
            OnStartTowerBuild?.Invoke();

        public void SendEndTowerBuild() =>
            OnEndTowerBuild?.Invoke();

        public void SendTowerDestroyed() =>
            OnTowerDestroyed?.Invoke();

        public void SendEndGame() =>
            OnGameEnd?.Invoke();
    }
}
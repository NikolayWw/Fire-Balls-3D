using CodeBase.Services.GameObserver;
using UnityEngine;

namespace CodeBase.Obstacle
{
    public class ObstacleApplyDamage : MonoBehaviour
    {
        private IGameObserverService _gameObserver;
        private bool _hasBeenSent;

        public void Construct(IGameObserverService gameObserver)
        {
            _gameObserver = gameObserver;
            _gameObserver.OnTowerDestroyed += CloseThis;
        }

        private void Start()
        {
            FindApplyDamageReporter();
        }

        private void OnDestroy()
        {
            _gameObserver.OnTowerDestroyed -= CloseThis;
        }

        private void ApplyDamage()
        {
            if (_hasBeenSent)
                return;

            _gameObserver.SendEndGame();
            _hasBeenSent = true;
        }

        private void FindApplyDamageReporter()
        {
            foreach (var applyDamageReporter in GetComponentsInChildren<ObstacleSegmentApplyDamageReporter>())
                applyDamageReporter.OnApplyDamage += ApplyDamage;
        }

        private void CloseThis() =>
            Destroy(gameObject);
    }
}
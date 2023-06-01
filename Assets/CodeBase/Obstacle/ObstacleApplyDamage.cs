using CodeBase.Services.GameObserver;
using System;
using UnityEngine;

namespace CodeBase.Obstacle
{
    public class ObstacleApplyDamage : MonoBehaviour
    {
        public Action OnBulletTouch;

        private IGameObserverService _gameObserver;
        private bool _hasBeenSent;

        public void Construct(IGameObserverService gameObserver)
        {
            _gameObserver = gameObserver;
            _gameObserver.OnTowerDestroyed += CloseThis;

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

            OnBulletTouch?.Invoke();
            _gameObserver.SendLevelCompleted();
            _hasBeenSent = true;
        }

        private void FindApplyDamageReporter()
        {
            foreach (var applyDamageReporter in GetComponentsInChildren<ObstacleSegmentBulletTouchReporter>())
                applyDamageReporter.OnApplyDamage += ApplyDamage;
        }

        private void CloseThis() =>
            Destroy(gameObject);
    }
}
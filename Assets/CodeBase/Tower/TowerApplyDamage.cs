using CodeBase.Logic;
using CodeBase.Services.GameObserver;
using System;
using UnityEngine;

namespace CodeBase.Tower
{
    public class TowerApplyDamage : MonoBehaviour, IApplyDamage
    {
        public Action OnApplyDamage;
       
        private IGameObserverService _gameObserver;

        public void Construct(IGameObserverService gameObserver)
        {
            _gameObserver = gameObserver;
            _gameObserver.OnTowerDestroyed += CloseThis;
        }

        private void OnDestroy()
        {
            _gameObserver.OnTowerDestroyed -= CloseThis;
        }

        public void ApplyDamage()
        {
            OnApplyDamage?.Invoke();
        }

        private void CloseThis()
        {
            Destroy(gameObject);
        }
    }
}
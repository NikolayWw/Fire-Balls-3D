using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Player;
using CodeBase.StaticData.Trek;
using System;
using System.Collections;
using UnityEngine;

namespace CodeBase.Player
{
    public class PlayerMove : MonoBehaviour
    {
        private IStaticDataService _dataService;
        private LevelConfig _levelConfig;
        private IGameObserverService _gameObserver;
        private PlayerStaticData _playerConfig;

        private int _currentIndexTrek;

        public void Construct(IGameObserverService gameObserver, IStaticDataService dataService, LevelConfig levelConfig)
        {
            _gameObserver = gameObserver;
            _dataService = dataService;
            _playerConfig = _dataService.PlayerStaticData;
            _levelConfig = levelConfig;

            _gameObserver.OnTowerDestroyed += StartMove;
        }

        private void OnDestroy()
        {
            _gameObserver.OnTowerDestroyed -= StartMove;
        }

        private void StartMove()
        {
            if (_currentIndexTrek < _levelConfig.TrekLevelStaticData.Length)
            {
                TrekLevelStaticData trek = _levelConfig.TrekLevelStaticData[_currentIndexTrek];
                StartCoroutine(Move(trek, EndMove));
            }
        }

        private IEnumerator Move(TrekLevelStaticData trek, Action onMoveEnd)
        {
            int trekPointIndex = 0;
            while (true)
            {
                if (trek.Points[trekPointIndex] == transform.position)
                {
                    trekPointIndex++;
                    if (trekPointIndex >= trek.Points.Length)
                        break;
                }
                UpdateMove(trek.Points[trekPointIndex]);
                yield return null;
            }
            onMoveEnd?.Invoke();
        }

        private void EndMove()
        {
            _currentIndexTrek++;
            _gameObserver.SendPlayerFinishedMove();
        }

        private void UpdateMove(Vector3 position)
        {
            transform.LookAt(position);
            transform.position = Vector3.MoveTowards(transform.position, position, _playerConfig.MoveSpeed * Time.deltaTime);
        }
    }
}
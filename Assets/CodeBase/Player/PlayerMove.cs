using CodeBase.Services.GameObserver;
using CodeBase.Services.StaticData;
using CodeBase.StaticData.Levels;
using CodeBase.StaticData.Player;
using CodeBase.StaticData.Trek;
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

        private void StartMove() =>
            StartCoroutine(Move());

        private IEnumerator Move()
        {
            int trekPointIndex = 0;
            TrekLevelStaticData currentTrek = _levelConfig.TrekLevelStaticData[_currentIndexTrek];

            while (true)
            {
                if (UpdateMove(currentTrek, ref trekPointIndex))
                    break;
                yield return null;
            }

            _currentIndexTrek++;
            CheckEndTrekMove();
        }

        private void CheckEndTrekMove()
        {
            if (_currentIndexTrek > _levelConfig.TrekLevelStaticData.Length)
                _gameObserver.SendPlayerFinishedMove();
            else
                StartMove();
        }

        private bool UpdateMove(TrekLevelStaticData currentTrek, ref int trekPointIndex)
        {
            if (currentTrek.Points[trekPointIndex] == transform.position)
            {
                trekPointIndex++;
                if (trekPointIndex > currentTrek.Points.Length)
                    return true;
            }

            transform.position = Vector3.MoveTowards(transform.position, currentTrek.Points[trekPointIndex], _playerConfig.MoveSpeed * Time.deltaTime);
            return false;
        }
    }
}
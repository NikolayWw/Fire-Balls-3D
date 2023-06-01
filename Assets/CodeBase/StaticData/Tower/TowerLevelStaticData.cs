using CodeBase.StaticData.Obstacle;
using System;
using UnityEngine;

namespace CodeBase.StaticData.Tower
{
    [Serializable]
    public class TowerLevelStaticData
    {
        [SerializeField] private string _inspectorName;
        [field: SerializeField] public TowerId TowerId { get; private set; }
        [field: SerializeField] public ObstacleId ObstacleId { get; private set; }
        [field: SerializeField] public Vector3 Position { get; private set; }

        public TowerLevelStaticData(TowerId towerId, ObstacleId obstacleId, Vector3 position)
        {
            TowerId = towerId;
            ObstacleId = obstacleId;
            Position = position;
        }

        public void OnValidate()
        {
            _inspectorName = TowerId.ToString();
        }
    }
}
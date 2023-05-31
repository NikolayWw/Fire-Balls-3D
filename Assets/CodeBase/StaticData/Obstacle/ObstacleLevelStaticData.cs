using System;
using UnityEngine;

namespace CodeBase.StaticData.Obstacle
{
    [Serializable]
    public class ObstacleLevelStaticData
    {
        [SerializeField] private string _inspectorName;
        [field: SerializeField] public ObstacleId ObstacleId { get; private set; }
        [field: SerializeField] public Vector3 Position { get; private set; }

        public ObstacleLevelStaticData(ObstacleId obstacleId, Vector3 position)
        {
            Position = position;
            ObstacleId = obstacleId;
        }

        public void OnValidate()
        {
            _inspectorName = ObstacleId.ToString();
        }
    }
}